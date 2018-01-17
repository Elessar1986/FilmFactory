using FilmFactory.FilmsData;
using FilmFactory.Models.Film;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilmFactory.Environment.DataMapper;

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
            return View("~/Views/Film/Add.cshtml",film);
        }

        [HttpPost]
        public ActionResult AddFilm(FilmViewModel film, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                var filmPhotoName = fileUpload != null ? fileUpload.FileName : null;
                if(fileUpload != null) fileUpload.SaveAs(Server.MapPath("~/Files/" + filmPhotoName));
                client.AddFilm(FilmDataMapper.getFilmContract(film, filmPhotoName));
                return RedirectToAction("Index");
            }
            else
            {
                GetFilmViewBag();
                return View("~/Views/Film/Add.cshtml", film);
            }

        }

        [HttpGet]
        public ActionResult EditFilm(int id)
        {
            var film = FilmDataMapper.getFilmViewModel( client.GetFilmById(id));
            GetFilmViewBag();
            return View("~/Views/Film/Edit.cshtml", film);
        }

        [HttpPost]
        public ActionResult EditFilm(FilmViewModel film, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid)
            {
                var photoNameOld = client.GetFilmById(film.Id).PhotoName;
                if (fileUpload != null && photoNameOld != fileUpload.FileName)
                {
                    string fullPath = Request.MapPath("~/Files/" + photoNameOld);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                    fileUpload.SaveAs(Server.MapPath("~/Files/" + fileUpload.FileName));
                    photoNameOld = fileUpload.FileName;
                }
                client.UpdateFilm(FilmDataMapper.getFilmContract(film, photoNameOld));
                return RedirectToAction("Index");
            }
            else
            {
                GetFilmViewBag();
                return View("~/Views/Film/Edit.cshtml", film);
            }

        }

        public ActionResult Top()
        {
            var Films = client.GetTop20Films();
            return View(Films);
        }

        private void GetFilmViewBag()
        {
            var Genres = client.GetGenres().Select(x => new SelectListItem { Text = x.GenreName, Value = x.Id.ToString() }).ToList();
            ViewBag.Genre = Genres;

            var Directors = client.GetDirector().Select(x => new SelectListItem { Text = x.Director, Value = x.Id.ToString(), Selected = x.Id == 20 }).ToList();
            ViewBag.DirectorId = Directors;
        }

    }
}