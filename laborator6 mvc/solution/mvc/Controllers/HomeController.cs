using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using DataAccess;
using Business;

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;
        List<PointOfInterest> Points = new List<PointOfInterest>();
        

        public HomeController(IRepository repository)
        {

            _repository = repository;


            Points = new List<PointOfInterest>();
            Points = _repository.GetAll();
        }

        public IActionResult Index()
        {

            return View(Points);
        }

        [HttpPost]
        public ActionResult CreatePoint()
        {
            var Id = Guid.NewGuid();
            string Coordinates = Request.Form["coordinates"];


            if (!Coordinates.Equals(""))
            {
                PointOfInterest p = new PointOfInterest(Guid.NewGuid(), Coordinates);
                _repository.Create(p);
                _repository.Commit();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewData["coordinatesInvalid"] = "-1";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult DeletePoint()
        {
            var id = Request.Form["id"];

            if (!id.Equals(""))
            {
                try
                { 
                PointOfInterest p = _repository.GetById(Guid.Parse(id));
                _repository.Delete(p);
                _repository.Commit();
                }catch{
                    throw new Exception("Guid nu este corect");
                }

                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult UpdatePoint()
        {
            var id = Request.Form["id"];
            var newCoords = Request.Form["newCoords"];

            if (!newCoords.Equals(""))
            {
                PointOfInterest p = _repository.GetById(Guid.Parse(id));
                p.Coordinates = newCoords;
                _repository.Commit();

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
