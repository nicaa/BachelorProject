using Garia.Core.Entities;
using Garia.Core.Handlers;
using Garia.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garia.Controllers
{
    public class DealerController : Controller
    {
        [HttpGet]
        [Authorize]
        public ActionResult Dealers(int page = 1, int pagesize = 50)
        {
            List<DealerRelationship> r = DealerHandler.getDealerRelationship();

            PagedList<DealerRelationship> model = new PagedList<DealerRelationship>(r, page, pagesize);
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult DealersSort(string SearchString)
        {
            List<DealerRelationship> r = DealerHandler.getDealerRelationship();

            if (SearchString != null && SearchString != "")
            {
                r = r.Where(m => (m.Fname + " " + m.Lname).ToLower().Contains(SearchString.ToLower())).ToList();
            }
            PagedList<DealerRelationship> model = new PagedList<DealerRelationship>(r, 1, 50);

            return PartialView("_DealerList", model);
        }

        [HttpGet]
        [Authorize]
        public ActionResult CreateDealer()
        {
            CreateDealerModel model = new CreateDealerModel();
            model.Regions = DealerHandler.GetRegions();

            return View(model);
        }
        [HttpPost]
        [Authorize]
        public ActionResult CreateDealer(CreateDealerModel model, int RegionId)
        {
            DealerHandler.CreateDealer(model.Dealer.DealerName, RegionId, model.Dealer.Budget);

            CreateDealerModel model1 = new CreateDealerModel();
            model1.Regions = DealerHandler.GetRegions();

            return View(model1);
        }

        [Authorize]
        [HttpGet]
        public ActionResult CreateDealerRelationship()
        {
            DealerRelationshipModel model = new DealerRelationshipModel();
            model.Dealers = DealerHandler.GetAllDealers();
            model.Employees = EmployeeHandler.GetAllEmployees();

            return View(model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult CreateDealerRelationship(int EmployeeId, int DealerId)
        {
            DealerHandler.AssignDealer(EmployeeId, DealerId);
            DealerRelationshipModel model = new DealerRelationshipModel();
            model.Dealers = DealerHandler.GetAllDealers();
            model.Employees = EmployeeHandler.GetAllEmployees();

            return View(model);
        }
        [Authorize]
        [HttpPost]
        public JsonResult DeleteRelationship(int Id)
        {
            DealerHandler.DeleteRelationshipById(Id);
            return Json("OK");
        }
	}
}