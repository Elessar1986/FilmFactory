using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilmFactory.FilmsData;

namespace FilmFactory.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
            ViewBag.ActiveMenu = "Main";
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult ChangeCulture(string lang)
        {


            return RedirectToAction("Index");
        }

    }
}