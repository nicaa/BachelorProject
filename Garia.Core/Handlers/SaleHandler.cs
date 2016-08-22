using BLToolkit.Reflection;
using Garia.Core.DAO;
using Garia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garia.Core.Handlers
{
    public class SaleHandler
    {
        public static List<Sale> GetAllSales()
        {
            SaleDAO sale = TypeAccessor<SaleDAO>.CreateInstance();
            return sale.GetAllSales();
        }
        public static Sale GetSaleByID(int SaleId)
        {
            SaleDAO sale = TypeAccessor<SaleDAO>.CreateInstance();
            return sale.GetSaleById(SaleId);
        }
        public static int DeleteSaleByID(int SaleId)
        {
            SaleDAO sale = TypeAccessor<SaleDAO>.CreateInstance();
            return sale.DeleteSaleById(SaleId);
        }
        public static int CreateSale(float Price, DateTime Date, string Status, string Comment, int EmployeeId, int CarId, int DealerId)
        {
            SaleDAO sale = TypeAccessor<SaleDAO>.CreateInstance();
            return sale.CreateSale(Price, Date, Status, Comment,EmployeeId, CarId,DealerId);
        }
        public static int EditSale(int SaleId,float Price, DateTime Date, string Status, int EmployeeId, int CarId, int DealerId)
        {
            SaleDAO sale = TypeAccessor<SaleDAO>.CreateInstance();
            return sale.EditSale(SaleId,Price, Date, Status, EmployeeId, CarId, DealerId);
        }
        
        public static List<HighScore> GetHighscore_YTD(int Year)
        {
            SaleDAO sale = TypeAccessor<SaleDAO>.CreateInstance();
            return sale.GetHighscore_YTD(Year);
        }
        public static List<HighScore> GetHighscore_Month()
        {
            SaleDAO sale = TypeAccessor<SaleDAO>.CreateInstance();
            return sale.GetHighscore_Month();
        }
        public static List<HighScore> GetHighscoreByDealerYear()
        {
            SaleDAO sale = TypeAccessor<SaleDAO>.CreateInstance();
            return sale.GetHighscoreByDealerYear();
        }
        public static List<HighScore> GetHighscoreByRegionYear()
        {
            SaleDAO sale = TypeAccessor<SaleDAO>.CreateInstance();
            return sale.GetHighscoreByRegionYear();
        }
        public static List<HighScore> GetHighscoreByCarYear()
        {
            SaleDAO sale = TypeAccessor<SaleDAO>.CreateInstance();
            return sale.GetHighscoreByCarYear();
        }


        public static int TotalSaleYTD(int Year)
        {
            SaleDAO sale = TypeAccessor<SaleDAO>.CreateInstance();
            return sale.TotalSaleYTD(Year);
        }
        public static DashboardRevenue GetEmployeeRevenueThisMonth(int EmployeeId)
        {
            SaleDAO sale = TypeAccessor<SaleDAO>.CreateInstance();
            return sale.GetEmployeeRevenueThisMonth(EmployeeId);
        }
        public static DashboardRevenue GetEmployeeRevenueThisYear(int EmployeeId)
        {
            SaleDAO sale = TypeAccessor<SaleDAO>.CreateInstance();
            return sale.GetEmployeeRevenueThisYear(EmployeeId);
        }

        public static DashboardRevenue GetTotalRevenueThisMonth()
        {
            SaleDAO sale = TypeAccessor<SaleDAO>.CreateInstance();
            return sale.GetTotalRevenueThisMonth();
        }
        public static DashboardRevenue GetTotalRevenueThisYear()
        {
            SaleDAO sale = TypeAccessor<SaleDAO>.CreateInstance();
            return sale.GetTotalRevenueThisYear();
        }
        public static Sale GetLatestSale()
        {
            SaleDAO sale = TypeAccessor<SaleDAO>.CreateInstance();
            return sale.GetLatestSale();
        }
        public static List<SaleGraph> GetSalesGroupByMonth()
        {
            SaleDAO sale = TypeAccessor<SaleDAO>.CreateInstance();
            return sale.GetSalesGroupByMonth();
        }
        public static List<IndexModel> GetEmployeeIndex(DateTime Date)
        {
            SaleDAO sale = TypeAccessor<SaleDAO>.CreateInstance();
            return sale.GetEmployeeIndex(Date);
        }
        public static List<IndexModel> GetDealerIndex(DateTime Date)
        {
            SaleDAO sale = TypeAccessor<SaleDAO>.CreateInstance();
            return sale.GetDealerIndex(Date);
        }
        public static List<SaleGraph> GetSalesGroupByMonthEmployee(int EmployeeId)
        {
            SaleDAO sale = TypeAccessor<SaleDAO>.CreateInstance();
            return sale.GetSalesGroupByMonthEmployee(EmployeeId);
        }
        public static List<SaleGraph> GetSalesGroupByMonthDealer(int DealerId)
        {
            SaleDAO sale = TypeAccessor<SaleDAO>.CreateInstance();
            return sale.GetSalesGroupByMonthDealer(DealerId);
        }

    }
}
