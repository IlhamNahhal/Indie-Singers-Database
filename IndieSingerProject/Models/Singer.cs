//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IndieSingerProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Singer
    { 
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [StringLength(30,MinimumLength =2, ErrorMessage = " the number of characters in Name must be between 2 and 30 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Nationality is Required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = " the number of characters in Nationality must be between 2 and 20 characters") ]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Genre is Required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = " the number of characters in Genre must be between 2 and 20 characters")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Biograpghy is Required")]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = " the number of characters in Biograpghy must be between 2 and 1000 characters")]
        public string Biography { get; set; }

        //[Required(ErrorMessage = "A picture URL is Required")]
        [Display( Name="Picture URL")]
        public string PictureUrl { get; set; }

        //[Required(ErrorMessage = "A video URL is required")]
        [Display(Name = "Video URL")]
        public string VideoUrl { get; set; }

        
        public Nullable<int> Likes { get; set; }
        public Nullable<int> Dislikes { get; set; }
    }
}
