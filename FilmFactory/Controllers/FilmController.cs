using FilmFactory.FilmsData;
using FilmFactory.Models.Film;
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

        //[HttpGet]
        //public JsonResult GetFilmById(int id)
        //{
        //    var film = client.GetFilmById(id);
        //    return Json(film, JsonRequestBehavior.AllowGet);
        //}

        [HttpGet]
        public ActionResult GetFilmById(int id)
        {
            var film = client.GetFilmById(id);
            return PartialView("~/Views/Film/Partials/Details.cshtml", film);
        }

        [HttpGet]
        public ActionResult AddFilm()
        {
            var film = new FilmViewModel();
            GetFilmViewBag();
            return PartialView("~/Views/Film/_AddPartial.cshtml",film);
        }

        [HttpPost]
        public ActionResult AddFilm(FilmViewModel film)
        {
            if (ModelState.IsValid)
            {
                var genres = new List<GenreContract>();
                foreach (var item in film.Genre)
                {
                    genres.Add(new GenreContract() { Id = item });
                }
                var model = new FilmContract()
                {
                    Description = film.Description,
                    Rate = film.Rate,
                    DirectorId = Int32.Parse(film.DirectorId),
                    PhotoName = film.PhotoName,
                    Title = film.Title,
                    Year = film.Year,
                    Genre = genres.ToArray()
                };
                client.AddFilm(model);
                return RedirectToAction("Index");
            }
            else
            {
                //TODO: return partial in modal
                GetFilmViewBag();
                return PartialView("~/Views/Film/_AddPartial.cshtml", film);
            }

        }

        public ActionResult Top()
        {
            var Films = client.GetTop20Films();
            return View(Films);
        }

        private void GetFilmViewBag()
        {
            var Genres = client.GetGenres().Select(x => new SelectListItem { Text = x.GenreName, Value = x.Id.ToString(), Selected = x.Id == 1 }).ToList();
            ViewBag.Genre = Genres;

            var Directors = client.GetDirector().Select(x => new SelectListItem { Text = x.Director, Value = x.Id.ToString(), Selected = x.Id == 1 }).ToList();
            ViewBag.DirectorId = Directors;
        }

    }
}