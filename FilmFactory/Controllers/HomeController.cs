using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FilmFactory.DataService;

namespace FilmFactory.Controllers
{
    public class HomeController : Controller
    {

        DataClient data;


        public HomeController()
        {
            data = new DataClient();
        }

        public ActionResult Index()
        {
            return View();
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

        public ActionResult List()
        {
            var model = data.GetFilms();
            return View(model);
        }
    }
}