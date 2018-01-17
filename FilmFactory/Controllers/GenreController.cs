using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilmFactory.FilmsData;
using FilmFactory.Models.Genre;
using AutoMapper;

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
            if (ModelState.IsValid)
            {
                Mapper.Reset();
                Mapper.Initialize(cfg => cfg.CreateMap<GenreViewModel, GenreContract>());
                var genreData = Mapper.Map<GenreViewModel, GenreContract>(genre);

                //var g = new GenreContract()
                //{
                //    GenreName = genre.GenreName
                //};
                client.AddGenre(genreData);
                return RedirectToAction("Index");
            }
            else
            {
                return View(genre);
            }
        }

        private void GetGenreViewBag()
        {

        }
    }
}