using Garia.Core.Entities;
using Garia.Core.Handlers;
using Garia.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Garia.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            DashboardModel model = new DashboardModel();

            model.EmployeeRevenueThisMonth = SaleHandler.GetEmployeeRevenueThisMonth(Convert.ToInt32(User.Identity.Name));
            model.EmployeeRevenueThisYear = SaleHandler.GetEmployeeRevenueThisYear(Convert.ToInt32(User.Identity.Name));
            model.TotalRevenueThisMonth = SaleHandler.GetTotalRevenueThisMonth();
            model.TotalRevenueThisYear = SaleHandler.GetTotalRevenueThisYear();
            model.LatestSale = SaleHandler.GetLatestSale();

            model.CalculateEmployeeIndexes();
            model.EmployeeIndex1 = model.EmployeeIndex1.OrderByDescending(m => m.Index).ToList();
            model.CalculateDealerIndexes();
            model.DealerIndex1 = model.DealerIndex1.OrderByDescending(m => m.Index).ToList();
            
            return View(model);
        }

        //When using ajax remember to put the script link after other scripts are loaded
        [Authorize]
        [HttpPost]
        public ActionResult ajax(string text)
        {
            List<Person> model = PersonHandler.GetAllPersons();
            return PartialView("_Persons",model);
        }

        [Authorize]
        public ActionResult About(int page = 1, int pagesize = 5)
        {
            List<Person> persons = PersonHandler.GetAllPersons();
            //Used for paging convert model to PagedList Model 
           
            //Used for authentication
            //int i = Convert.ToInt32(User.Identity.Name);
           
            PagedList<Person> model = new PagedList<Person>(persons, page, pagesize);
            return View(model);
        }
        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            
            return View();
        }


       [Authorize]
       [HttpGet]
       public JsonResult JsonGraphData()
       {
         
           
           List<SaleGraph> GetSalesList = SaleHandler.GetSalesGroupByMonth();
           List<SaleGraph> salesGraphList = new List<SaleGraph>();
           // Init List of saleGraphList Object and populate them with data
           for (int i = 1; i <= 12; i++)
           {
               SaleGraph obj = new SaleGraph();
               obj.SaleMonth = i;
               obj.Revenue = 0;
               salesGraphList.Add(obj);
           }
           //insert revenue based on the month, where there is a sale
           for (int j = 0; j < GetSalesList.Count; j++)
           {
               salesGraphList[GetSalesList[j].SaleMonth - 1].Revenue = GetSalesList[j].Revenue;
           }


           List<DataSerie> dataSeries = new List<DataSerie>();
           dataSeries.Add(new DataSerie("Revenue"));
           
           for (int i = 0; i < 12; i++)
           {
               float[] currentArrayTotal = new float[2];
               currentArrayTotal[0] = i+1;
               currentArrayTotal[1] = salesGraphList[i].Revenue;

               dataSeries[0].values[i] = currentArrayTotal;
           }
           

           return Json(dataSeries, JsonRequestBehavior.AllowGet);
       }
       public int GetRole()
       {
           HttpCookie Role = HttpContext.Request.Cookies["Role"];
           int role = Convert.ToInt32(Role.Value);
           return role;

       }

    }
    public class DataSerie
    {
        public string key { get; set; }
        public object[] values { get; set; }

        public DataSerie()
        {
            this.values = new object[12];
        }

        public DataSerie(string key)
            : this()
        {
            this.key = key;
        }

    }
}