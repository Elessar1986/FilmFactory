using FilmFactory.Models.Film;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmFactory.Models.Shared
{
    public class FindViewModel
    {
        public FindFilter findFilter { get; set; }

        public IPagedList<FilmViewModel> films { get; set; }

    }
}