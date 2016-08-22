using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Garia.Core.Entities;
using Garia.Core.Handlers;
namespace Garia.Models
{
    public class DashboardModel
    {
        public DashboardRevenue EmployeeRevenueThisMonth { get; set; }
        public DashboardRevenue EmployeeRevenueThisYear { get; set; }

        public DashboardRevenue TotalRevenueThisMonth { get; set; }
        public DashboardRevenue TotalRevenueThisYear { get; set; }
        
        public Sale LatestSale { get; set; }
        public List<IndexModel> EmployeeIndex1 { get; set; }
        public List<IndexModel> EmployeeIndex2 { get; set; }

        public List<IndexModel> DealerIndex1 { get; set; }
        public List<IndexModel> DealerIndex2 { get; set; }

        public void CalculateEmployeeIndexes()
        {
            DateTime dateIndex1 = DateTime.Now.AddMonths(-1); // last months date
            DateTime dateIndex2 = DateTime.Now.AddMonths(-2); // Last last months date

            EmployeeIndex1 = SaleHandler.GetEmployeeIndex(dateIndex1);
            EmployeeIndex2 = SaleHandler.GetEmployeeIndex(dateIndex2);
            // Calculate index
            for (int i = 0; i < EmployeeIndex1.Count; i++)
            {
                if (EmployeeIndex1[i].Revenue > 0 && EmployeeIndex2[i].Revenue > 0)
                {
                    float index = ((EmployeeIndex1[i].Revenue / EmployeeIndex2[i].Revenue) * 100);
                    EmployeeIndex1[i].Index = index;
                }
            }
        }

        public void CalculateDealerIndexes()
        {
            DateTime date1 = DateTime.Now.AddMonths(-1); // Last months date
            DateTime date2 = DateTime.Now.AddMonths(-2); // Last Last months date

            DealerIndex1 = SaleHandler.GetDealerIndex(date1);
            DealerIndex2 = SaleHandler.GetDealerIndex(date2);
            // Calculate index
            for (int i = 0; i < DealerIndex1.Count; i++)
            {
                if (DealerIndex1[i].Revenue > 0 && DealerIndex2[i].Revenue > 0)
                {
                    float index = ((DealerIndex1[i].Revenue / DealerIndex2[i].Revenue) * 100);
                    DealerIndex1[i].Index = index;
                }
            }
        }

    }
}