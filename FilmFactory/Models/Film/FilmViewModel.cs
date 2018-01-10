using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmFactory.Models.Film
{
    public class FilmViewModel
    {
        
        public int Id { get; set; }

        [Display(Name ="Films", ResourceType = typeof(Resources.Resource))]
        public string Title { get; set; }

        public string DirectorId { get; set; }
        
        public string DirectorName { get; set; }
        
        public int Year { get; set; }
        [Range(0.1,10.0,ErrorMessage ="Wrong value")]
        public double Rate { get; set; }
        
        public string PhotoName { get; set; }
        
        public string Description { get; set; }
        
        public int[] Genre { get; set; }
    }
}