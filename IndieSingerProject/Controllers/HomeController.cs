using IndieSingerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace IndieSingerProject.Controllers
{
    public class HomeController : Controller
    {
        private IndieSingersEntities db = new IndieSingersEntities();

        public ActionResult Index(string searchString, string singerGenre)

        {   
            //Creating the selectlist for the genre dropdown list
            List<string> genreList = new List<string>();
            var genreQuery = from g in db.Singers
                             orderby g.Genre
                             select g.Genre;
            genreList.AddRange(genreQuery.Distinct());
            ViewBag.singerGenre = new SelectList(genreList);

            //gettimg all the singers from DB

            var singers = from s in db.Singers
                          select s;

            //searching by genre
            if (!String.IsNullOrEmpty(singerGenre))
            {
                singers = singers.Where(x => x.Genre==singerGenre);
            }

          

            //searching by name

            if (!String.IsNullOrEmpty(searchString))
            {
                singers = singers.Where(x => x.Name.Contains(searchString));
            }

            return View(singers);


        }

        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(Singer singer)
        {

            singer.Likes = 0;
            singer.Dislikes = 0;

            if (singer.PictureUrl == null)
            {
                singer.PictureUrl = "https://st3.depositphotos.com/3802717/17613/v/1600/depositphotos_176135516-stock-illustration-indie-rock-music-vintage-styled.jpg";
            }

            if (singer.VideoUrl == null)
            {
                singer.VideoUrl = "https://www.youtube.com/embed/yVO_pKi0TRY";
            }

            if (ModelState.IsValid)
            {
                db.Singers.Add(singer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(singer);

        }


        public ActionResult Details(int? id)

        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Singer singer = db.Singers.Find(id);

            if (singer == null)
            {
                return HttpNotFound();
            }

            return View(singer);

        }

        public ActionResult Edit (int? id)

        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Singer singer = db.Singers.Find(id);

            if (singer == null)
            {
                return HttpNotFound();
            }


            return View(singer);

        }

        [HttpPost]
        public ActionResult Edit(Singer singer)

        {
            if (ModelState.IsValid)
            {
                db.Entry(singer).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(singer);

        }


        public ActionResult Delete(int? id)

        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Singer singer = db.Singers.Find(id);

            if (singer == null)
            {
                return HttpNotFound();
            }

            return View(singer);

        }

        //[HttpPost]
        //public ActionResult Delete(Singer singer)

        //{
        //    db.Singers.Remove(singer);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");

        //}

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)

        {
            Singer singer = db.Singers.Find(id);
            db.Singers.Remove(singer);
            db.SaveChanges();
            return RedirectToAction("Index");

        }



        public ActionResult Like (int id)

        {
            Singer singer = db.Singers.Find(id);

            singer.Likes++;

            db.SaveChanges();
            return RedirectToAction("index");
            

        }

        public ActionResult Dislike(int id)

        {
            Singer singer = db.Singers.Find(id);

            singer.Dislikes++;
           
            db.SaveChanges();
            return RedirectToAction("index");


        }














        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}