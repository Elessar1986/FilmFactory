using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilmFactory.FilmsData;
using FilmFactory.Models.Genre;
using AutoMapper;
using FilmFactory.Models.Shared;

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

        public ActionResult Add()
        {
            var genre = new GenreViewModel();
            return View(genre);
        }

        [HttpPost]
        public ActionResult Add(GenreViewModel genre)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    Mapper.Reset();
                    Mapper.Initialize(cfg => cfg.CreateMap<GenreViewModel, GenreContract>());
                    var genreData = Mapper.Map<GenreViewModel, GenreContract>(genre);

                    client.AddGenre(genreData);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(genre);
                }
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

        private void GetGenreViewBag()
        {

        }
    }
}