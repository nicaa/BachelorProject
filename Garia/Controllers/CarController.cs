using Garia.Core.Entities;
using Garia.Core.Handlers;
using Garia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garia.Controllers
{
    public class CarController : Controller
    {
        [Authorize]
        [HttpGet]
        public ActionResult Cars()
        {
            CarModel model = new CarModel();
            model.CarList = CarHandler.GetAllCars();

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateCar(Car car)
        {

            CarHandler.CreateCar(car.CarType);
            CarModel model = new CarModel();
            model.CarList = CarHandler.GetAllCars();
            return PartialView("_CarList", model.CarList);
        }
        [Authorize]
        [HttpPost]
        public ActionResult DeleteCar(Car car)
        {

            CarHandler.DeleteCarByID(car.CarId);
            CarModel model = new CarModel();
            model.CarList = CarHandler.GetAllCars();
            return PartialView("_CarList", model.CarList);
        }
	}
}