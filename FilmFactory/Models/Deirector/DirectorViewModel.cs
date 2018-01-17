using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmFactory.Models.Deirector
{
    public class DirectorViewModel
    {

        public int Id { get; set; }

        [Display(ResourceType = typeof(Resources.Resource), Name = "Genres")]
        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "ErrorMessageRequired")]
        public string Director { get; set; }

    }
}