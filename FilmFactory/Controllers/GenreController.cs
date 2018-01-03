using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilmFactory.FilmsData;

namespace FilmFactory.Controllers
{
    public class GenreController : Controller
    {

        FilmDataServiceClient client;

        public GenreController()
        {
            client = new FilmDataServiceClient();
            ViewBag.ActiveMenu = "Other";
        }


        public ActionResult Index()
        {
            var Genres = client.GetGenres().ToList();
            return View(Genres);
        }
    }
}