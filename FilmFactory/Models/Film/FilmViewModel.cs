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

        [Display(Name ="Title", ResourceType = typeof(Resources.Resource))]
        [Required (ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "ErrorMessageRequired")]
        public string Title { get; set; }

        [Display(Name = "Director", ResourceType = typeof(Resources.Resource))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "ErrorMessageRequired")]
        public int DirectorId { get; set; }

        //public string DirectorName { get; set; }

        [Display(Name = "Year", ResourceType = typeof(Resources.Resource))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "ErrorMessageRequired")]
        [Range(1900, 2018, ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "ErrorMessageWrongNum")]
        public int Year { get; set; }

        [Display(Name = "Rate", ResourceType = typeof(Resources.Resource))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "ErrorMessageRequired")]
        [Range(0.1, 10.0, ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "ErrorMessageWrongNum")]
        public double Rate { get; set; }

        //public string PhotoName { get; set; }
        [Display(Name = "Description", ResourceType = typeof(Resources.Resource))]
        public string Description { get; set; }

        [Display(Name = "Genres", ResourceType = typeof(Resources.Resource))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "ErrorMessageRequired")]
        public int[] Genre { get; set; }
    }
}