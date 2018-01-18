using FilmFactory.FilmsData;
using FilmFactory.Models.Film;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilmFactory.Environment.DataMapper;
using PagedList;
using PagedList.Mvc;
using FilmFactory.Models.Shared;
using FilmFactory.Helpers;

namespace FilmFactory.Controllers
{
    public class FilmController : Controller
    {
        FilmDataServiceClient client;

        private int pageSize = 5;

        public FilmController()
        {
            client = new FilmDataServiceClient();
            ViewBag.ActiveMenu = "Film";
        }


        public ActionResult Index(int? page)
        {
            var Films = client.GetFilms();
            
            int pageNumber = (page ?? 1);
            return View(Films.ToPagedList(pageNumber, pageSize));
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

        public ActionResult FindFilm(FindFilter filter, int? page)
        {
            try
            {
                var FVM = new List<FilmViewModel>();
                //if (filter == null) filter = new FindFilter();
                if (page != null)
                {
                    FVM = Session["FVM"] as List<FilmViewModel>;
                    filter = Session["Filter"] as FindFilter;
                }
                else {

                    if (ModelState.IsValid)
                    {
                        var find = new FindingEngine();
                        FVM = find.Find(filter, client);
                        Session["FVM"] = FVM;
                        Session["Filter"] = filter;
                        
                    }
                }

                int pageNumber = (page ?? 1);
                var model = new FindViewModel()
                {
                    findFilter = filter,
                    films = FVM.ToPagedList(pageNumber, pageSize)
                };

                GetFilmViewBag(false);
                return View(model);

                
            }
            catch (Exception ex)
            {
                var error = new ErrorViewModel()
                {
                    ErrorMessage = ex.Message
                };
                return View("~/Views/Shared/Error.cshtml", error);
            }
           
        }

        public ActionResult Top()
        {
            var Films = client.GetTop20Films();
            return View(Films);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                client.DeleteFilm(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private void GetFilmViewBag(bool add = true)
        {
            var Genres = client.GetGenres().Select(x => new SelectListItem { Text = x.GenreName, Value = x.Id.ToString() }).ToList();
            if(!add) Genres.Insert(0, new SelectListItem() { Text = "-", Value = "-1" });
            ViewBag.Genre = Genres;

            var Directors = client.GetDirector().Select(x => new SelectListItem { Text = x.Director, Value = x.Id.ToString() }).ToList();
            if(!add) Directors.Insert(0, new SelectListItem() { Text = "-", Value = "-1" });
            ViewBag.DirectorId = Directors;
        }

    }
}