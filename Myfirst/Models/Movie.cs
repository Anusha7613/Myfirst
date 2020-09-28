using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Myfirst.Models.CustomAttributes;

namespace Myfirst.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Display(Name="Movie Name")]
        [Required(ErrorMessage ="Please Enter the Movie Name")]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name="Release Date")]
        [CustomReleaseDate]
        public DateTime? Releasedate { get; set; }

        [Display(Name="Hero Name")]
        [Required(ErrorMessage ="Please Enter Hero Name")]
        [StringLength(100)]
        public string Hero { get; set; }

        [Display(Name="Director Name")]
        [Required(ErrorMessage ="Please Enter Director name")]
        [StringLength(100)]
        public string DirectorName { get; set; }
        //Referance of the Table
        public Genre Genre { get; set; }
        //Foreign Key

        [Display(Name="Genre")]
        [Required]
        public int GenreId { get; set; }
        
    }
}