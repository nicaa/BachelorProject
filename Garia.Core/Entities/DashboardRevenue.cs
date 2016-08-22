using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garia.Core.Entities
{
    public class DashboardRevenue
    {
        public float EmployeeRevenue { get; set; }
        public float Budget { get; set; }

        public int Procentage { 
            get
            {
                int procent = 0;
                if(EmployeeRevenue > 0){

                
                    procent = Convert.ToInt32((EmployeeRevenue/Budget) * 100);
                    if (procent > 100)
                    {
                        procent = 100;
                    }
                }
                return procent;
            } 
        }
    }
}
