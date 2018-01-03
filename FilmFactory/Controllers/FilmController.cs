using FilmFactory.FilmsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmFactory.Controllers
{
    public class FilmController : Controller
    {
        FilmDataServiceClient client;

        public FilmController()
        {
            client = new FilmDataServiceClient();
            ViewBag.ActiveMenu = "Film";
        }


        public ActionResult Index()
        {
            var Films = client.GetFilms();
            return View(Films);
        }

        public ActionResult Add()
        {
            var film = new FilmContract();
            var Genres = client.GetGenres().ToList();
            var genres = new SelectList(Genres, "Id", "GenreName");
            ViewBag.Genres = genres;
            return View(film);
        }

        [HttpPost]
        public ActionResult Add(FilmContract film, int[] genresId)
        {
            client.AddFilm(film);
            return RedirectToAction("Index");
        }

        public ActionResult Top()
        {
            var Films = client.GetTop20Films();
            return View(Films);
        }
    }
}