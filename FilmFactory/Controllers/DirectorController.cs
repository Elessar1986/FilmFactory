using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using FilmFactory.FilmsData;
using FilmFactory.Models.Deirector;
using FilmFactory.Models.Shared;

namespace FilmFactory.Controllers
{
    public class DirectorController : Controller
    {
        FilmDataServiceClient client;

        public DirectorController()
        {
            client = new FilmDataServiceClient();
            ViewBag.ActiveMenu = "Other";
            
        }
        // GET: Director
        public ActionResult Index()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.CreateMap<DirectorContract, DirectorViewModel>());
            var directors = Mapper.Map<IEnumerable<DirectorContract>, List<DirectorViewModel>>(client.GetDirector());
            
            return View(directors);
        }

        // GET: Director/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Director/Create
        public ActionResult Create()
        {
            var dir = new DirectorViewModel();
            return View(dir);
        }

        // POST: Director/Create
        [HttpPost]
        public ActionResult Create(DirectorViewModel DIR)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Mapper.Reset();
                    Mapper.Initialize(cfg => cfg.CreateMap<DirectorViewModel, DirectorContract>());
                    client.AddDirector(Mapper.Map<DirectorViewModel, DirectorContract>(DIR));

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(DIR);
                }
            }
            catch(Exception ex)
            {
                var error = new ErrorViewModel()
                {
                    ErrorMessage = ex.Message
                };
                return View("~/Views/Shared/Error.cshtml", error);
            }
        }

        // GET: Director/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Director/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Director/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Director/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
