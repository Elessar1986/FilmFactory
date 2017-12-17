using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmFactory.Controllers
{
    public class HomeController : Controller
    {

        FilmsData.FilmDataServiceClient client;

        public HomeController()
        {
            client = new FilmsData.FilmDataServiceClient();
        }

        public ActionResult Index()
        {
            var Films = client.GetFilms();
            return View(Films);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}