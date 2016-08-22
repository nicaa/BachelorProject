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
    public class SaleController : Controller
    {
        [Authorize]
        public ActionResult SaleLog(int page = 1, int pagesize = 50)
        {
            //Variables used for sorting
            ViewBag.Date = "Date_DSC";
            ViewBag.OrderNO = "OrderNO";
            ViewBag.SalesManager = "SalesManager";
            ViewBag.Dealer = "Dealer";
            ViewBag.CarType = "CarType";
            ViewBag.Status = "Status";
            ViewBag.Price = "Price";

            List<Sale> s = SaleHandler.GetAllSales();
            PagedList<Sale> model = new PagedList<Sale>(s, page, pagesize);


            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult SaleLogSort(string sortingCriteria, string SearchString)
        {

            ViewBag.Date = "Date_DSC";
            ViewBag.OrderNO = "OrderNO";
            ViewBag.SalesManager = "SalesManager";
            ViewBag.Dealer = "Dealer";
            ViewBag.CarType = "CarType";
            ViewBag.Status = "Status";
            ViewBag.Price = "Price";

            List<Sale> s = SaleHandler.GetAllSales();

            if (sortingCriteria != null)
            {
                //Sort desc or asceending string variable
                sortingCriteria = sortingCriteria.Contains("DSC") ? sortingCriteria.Split('_')[0] : string.Format("{0}_DSC", sortingCriteria);
            }
            if (SearchString != null && SearchString != "")
            {
                s = s.Where(m => m.DealerName.ToLower().Contains(SearchString.ToLower())).ToList();
            }

            PagedList<Sale> model = new PagedList<Sale>(SaleSortByOrder(sortingCriteria, s), 1, 50);
            return PartialView("_SaleTable", model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult CreateSale()
        {
            CreateSaleModel model = new CreateSaleModel();
            model.car = CarHandler.GetAllCars();
            model.dealer = DealerHandler.GetAllDealers();
            model.employeeId = Convert.ToInt32(User.Identity.Name);
            ViewBag.Sale = "";
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult CreateSale(CreateSaleModel model, int CarId, int DealerId)
        {
            model.employeeId = Convert.ToInt32(User.Identity.Name);

            SaleHandler.CreateSale(model.Sale.Price, model.Sale.Date, model.Sale.Status, "", model.employeeId, CarId, DealerId);

            model.car = CarHandler.GetAllCars();
            model.dealer = DealerHandler.GetAllDealers();
            ViewBag.Sale = " - Sale Created Successfully";
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditSale(int Id)
        {
            CreateSaleModel model = new CreateSaleModel();
            model.Sale = SaleHandler.GetSaleByID(Id);
            model.car = CarHandler.GetAllCars();
            model.dealer = DealerHandler.GetAllDealers();
            model.employeeId = Convert.ToInt32(User.Identity.Name);
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditSale(CreateSaleModel model, int CarId, int DealerId)
        {
            model.employeeId = Convert.ToInt32(User.Identity.Name);

            SaleHandler.EditSale(model.Sale.SaleId, model.Sale.Price, model.Sale.Date, model.Sale.Status, model.employeeId, CarId, DealerId);

            return RedirectToAction("SaleLog");
        }

        [Authorize]
        [HttpPost]
        public JsonResult DeleteSale(int SaleId)
        {
            SaleHandler.DeleteSaleByID(SaleId);
            return Json("OK");
        }
        public List<Sale> SaleSortByOrder(string sortOrder, List<Sale> s)
        {
            //Used for sorting in Sale Table
            switch (sortOrder)
            {
                case "Date":
                    s = s.OrderBy(list => list.Date).ToList();
                    ViewBag.Date = "Date";
                    break;
                case "Date_DSC":
                    s = s.OrderByDescending(list => list.Date).ToList();
                    ViewBag.Date = "Date_DSC";
                    break;
                case "OrderNO":
                    s = s.OrderBy(list => list.SaleId).ToList();
                    ViewBag.OrderNO = "OrderNO";
                    break;
                case "OrderNO_DSC":
                    s = s.OrderByDescending(list => list.SaleId).ToList();
                    ViewBag.OrderNO = "OrderNO_DSC";
                    break;
                case "SalesManager":
                    s = s.OrderBy(list => list.EmployeeId).ToList();
                    ViewBag.SalesManager = "SalesManager";
                    break;
                case "SalesManager_DSC":
                    s = s.OrderByDescending(list => list.EmployeeId).ToList();
                    ViewBag.SalesManager = "SalesManager_DSC";
                    break;
                case "Dealer":
                    s = s.OrderBy(list => list.DealerId).ToList();
                    ViewBag.Dealer = "Dealer";
                    break;
                case "Dealer_DSC":
                    s = s.OrderByDescending(list => list.DealerId).ToList();
                    ViewBag.Dealer = "Dealer_DSC";
                    break;
                case "CarType":
                    s = s.OrderBy(list => list.CarType).ToList();
                    ViewBag.CarType = "CarType";
                    break;
                case "CarType_DSC":
                    s = s.OrderByDescending(list => list.CarType).ToList();
                    ViewBag.CarType = "CarType_DSC";
                    break;
                case "Status":
                    s = s.OrderBy(list => list.Status).ToList();
                    ViewBag.Status = "Status";
                    break;
                case "Status_DSC":
                    s = s.OrderByDescending(list => list.Status).ToList();
                    ViewBag.Status = "Status_DSC";
                    break;
                case "Price":
                    s = s.OrderBy(list => list.Price).ToList();
                    ViewBag.Price = "Price";
                    break;
                case "Price_DSC":
                    s = s.OrderByDescending(list => list.Price).ToList();
                    ViewBag.Price = "Price_DSC";
                    break;

            }

            return s;
        }
	}
}