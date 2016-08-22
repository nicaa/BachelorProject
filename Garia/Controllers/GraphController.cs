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
    public class GraphController : Controller
    {
        [Authorize]
        [HttpGet]
        public ActionResult BudgetSalesDealer()
        {
            DealerGraphModel model = new DealerGraphModel();
            model.Dealers = DealerHandler.GetAllDealers();
            if (model.Dealers.Count == 0)
            {
                // if no dealers have beem created Create a Dummy dealer
                model.Dealer = new Dealer();
                model.Dealer.DealerName = "No dealers - Create a dealer";
                return View(model);
            }
            if (Request.Cookies["DealerId"] != null)
            {
                HttpCookie DealerId = HttpContext.Request.Cookies["DealerId"];

                model.Dealer = DealerHandler.GetDealerById(Convert.ToInt32(DealerId.Value));
            }
            else
            {
                model.Dealer = model.Dealers[0];
                HttpCookie DealerId = new HttpCookie("DealerId");
                DealerId.Value = model.Dealer.DealerId.ToString();
                DealerId.Expires = DateTime.Now.AddMonths(1);
                HttpContext.Response.Cookies.Add(DealerId);
            }
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult BudgetSalesDealer(int DealerId)
        {
            HttpCookie DealerGraphId = new HttpCookie("DealerId");
            DealerGraphId.Value = DealerId.ToString();
            DealerGraphId.Expires = DateTime.Now.AddMonths(1);
            HttpContext.Response.Cookies.Add(DealerGraphId);

            Dealer model = DealerHandler.GetDealerById(DealerId);
            return PartialView("_GraphDealer", model);
        }
        [Authorize]
        [HttpGet]
        public JsonResult DealerGraph()
        {
            //Cookie is used for passing DealerId to graph
            HttpCookie DealerId = HttpContext.Request.Cookies["DealerId"];
            int id;
            if (DealerId != null)
            {
                id = Convert.ToInt32(DealerId.Value);
            }
            else
            {
                id = 0;
            }

            Dealer dealer = DealerHandler.GetDealerById(id);
            List<SaleGraph> GetSalesList = SaleHandler.GetSalesGroupByMonthDealer(id);
            List<SaleGraph> salesGraphList = new List<SaleGraph>();
            // Init List of saleGraphList Object and populate them with data
            for (int i = 1; i <= 12; i++)
            {
                SaleGraph obj = new SaleGraph();
                obj.SaleMonth = i;
                obj.Revenue = 0;
                if (dealer != null)
                {
                    obj.Budget = dealer.Budget;
                }
                else
                {
                    obj.Budget = 0;
                }

                salesGraphList.Add(obj);
            }
            //insert revenue based on the month, where there is a sale
            for (int j = 0; j < GetSalesList.Count; j++)
            {
                salesGraphList[GetSalesList[j].SaleMonth - 1].Revenue = GetSalesList[j].Revenue;
            }
            // for running revenue and budget
            for (int i = 0; i < salesGraphList.Count; i++)
            {
                if (i != 0)
                {
                    salesGraphList[i].Revenue = salesGraphList[i].Revenue + salesGraphList[i - 1].Revenue;
                    salesGraphList[i].Budget = salesGraphList[i].Budget + salesGraphList[i - 1].Budget;
                }
            }
            List<DataSerie> dataSeries = new List<DataSerie>();
            dataSeries.Add(new DataSerie("Revenue"));
            dataSeries.Add(new DataSerie("Budget"));

            for (int i = 0; i < 12; i++)
            {
                float[] currentArrayTotal = new float[2];
                currentArrayTotal[0] = i + 1;
                currentArrayTotal[1] = salesGraphList[i].Revenue;

                float[] currentBudgetArrayTotal = new float[2];
                currentBudgetArrayTotal[0] = i + 1;
                currentBudgetArrayTotal[1] = salesGraphList[i].Budget;

                dataSeries[0].values[i] = currentArrayTotal;
                dataSeries[1].values[i] = currentBudgetArrayTotal;

            }


            return Json(dataSeries, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpGet]
        public ActionResult BudgetSales()
        {
            //Graph for EMployees
            SaleManagerGraphModel model = new SaleManagerGraphModel();
            model.Employees = EmployeeHandler.GetAllEmployees();

            if (Request.Cookies["SaleManagerId"] != null)
            {
                HttpCookie ManagerId = HttpContext.Request.Cookies["SaleManagerId"];

                model.employee = EmployeeHandler.GetEmployeeById(Convert.ToInt32(ManagerId.Value));
            }
            else
            {
                model.employee = EmployeeHandler.GetEmployeeById(Convert.ToInt32(User.Identity.Name));
                HttpCookie SaleManagerId = new HttpCookie("SaleManagerId");
                SaleManagerId.Value = model.employee.EmployeeId.ToString();
                SaleManagerId.Expires = DateTime.Now.AddMonths(1);
                HttpContext.Response.Cookies.Add(SaleManagerId);
            }
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult BudgetSalesId(int EmployeeId)
        {

            HttpCookie SaleManagerId = new HttpCookie("SaleManagerId");
            SaleManagerId.Value = EmployeeId.ToString();
            SaleManagerId.Expires = DateTime.Now.AddMonths(1);
            HttpContext.Response.Cookies.Add(SaleManagerId);

            Employee model = EmployeeHandler.GetEmployeeById(EmployeeId);
            return PartialView("_GraphSalesManager", model);
        }

        [HttpGet]
        [Authorize]
        public JsonResult SaleManagerGraph()
        {
            //Cookie is used for passing EmployeeID to graph
            HttpCookie ManagerId = HttpContext.Request.Cookies["SaleManagerId"];
            int id;
            if (ManagerId != null)
            {
                id = Convert.ToInt32(ManagerId.Value);
            }
            else
            {//if no id is Chosen Use the id of the person who is logged in
                id = Convert.ToInt32(User.Identity.Name);
            }

            Employee employee = EmployeeHandler.GetEmployeeById(id);
            List<SaleGraph> GetSalesList = SaleHandler.GetSalesGroupByMonthEmployee(id);
            List<SaleGraph> salesGraphList = new List<SaleGraph>();
            // Init List of saleGraphList Object and populate them with data
            for (int i = 1; i <= 12; i++)
            {
                SaleGraph obj = new SaleGraph();
                obj.SaleMonth = i;
                obj.Revenue = 0;
                if (employee != null)
                {
                    obj.Budget = employee.Budget;
                }
                else
                {
                    obj.Budget = 0;
                }
                salesGraphList.Add(obj);
            }
            //insert revenue based on the month, where there is a sale
            for (int j = 0; j < GetSalesList.Count; j++)
            {
                salesGraphList[GetSalesList[j].SaleMonth - 1].Revenue = GetSalesList[j].Revenue;
            }
            // for running revenue and budget
            for (int i = 0; i < salesGraphList.Count; i++)
            {
                if (i != 0)
                {
                    salesGraphList[i].Revenue = salesGraphList[i].Revenue + salesGraphList[i - 1].Revenue;
                    salesGraphList[i].Budget = salesGraphList[i].Budget + salesGraphList[i - 1].Budget;
                }
            }
            List<DataSerie> dataSeries = new List<DataSerie>();
            dataSeries.Add(new DataSerie("Revenue"));
            dataSeries.Add(new DataSerie("Budget"));

            for (int i = 0; i < 12; i++)
            {
                float[] currentArrayTotal = new float[2];
                currentArrayTotal[0] = i + 1;
                currentArrayTotal[1] = salesGraphList[i].Revenue;

                float[] currentBudgetArrayTotal = new float[2];
                currentBudgetArrayTotal[0] = i + 1;
                currentBudgetArrayTotal[1] = salesGraphList[i].Budget;

                dataSeries[0].values[i] = currentArrayTotal;
                dataSeries[1].values[i] = currentBudgetArrayTotal;

            }


            return Json(dataSeries, JsonRequestBehavior.AllowGet);
        }
	}
}