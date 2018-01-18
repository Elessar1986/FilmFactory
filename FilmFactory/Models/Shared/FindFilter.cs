using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmFactory.Models.Shared
{
    public class FindFilter
    {

        [Display(Name = "Year", ResourceType = typeof(Resources.Resource))]
        [Range(1900, 2018, ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "ErrorMessageWrongNum")]
        public int Year { get; set; } = 1900;

        [Display(Name = "Director", ResourceType = typeof(Resources.Resource))]
        //[Range(0, 9999, ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "ErrorMessageWrongNum")]
        public int DirectorId { get; set; }

        [Display(Name = "Genres", ResourceType = typeof(Resources.Resource))]
        public int GenreId { get; set; }

        [Display(Name = "Rate", ResourceType = typeof(Resources.Resource))]
        [Range(0.0, 10.0, ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "ErrorMessageWrongNum")]
        public double Rate { get; set; } = 0;

    }
}