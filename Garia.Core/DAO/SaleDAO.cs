using BLToolkit.DataAccess;
using Garia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garia.Core.DAO
{
    public abstract class SaleDAO : DataAccessor
    {
        [SprocName("tblSale_GetAllSales")]
        public abstract List<Sale> GetAllSales();

        [SprocName("tblSale_GetSaleById")]
        public abstract Sale GetSaleById(int SaleId);

        [SprocName("tblSale_DeleteSaleById")]
        public abstract int DeleteSaleById(int SaleId);

        [SprocName("tblSale_CreateSale")]
        public abstract int CreateSale(float Price, DateTime Date, string Status, string Comment, int EmployeeId, int CarId, int DealerId);

        [SprocName("tblSale_EditSale")]
        public abstract int EditSale(int SaleId,float Price, DateTime Date, string Status, int EmployeeId, int CarId, int DealerId);

        [SprocName("tblSale_Highscore_YTD")]
        public abstract List<HighScore> GetHighscore_YTD(int Year);

        [SprocName("tblSale_HighscoreMonth")]
        public abstract List<HighScore> GetHighscore_Month();

        [SprocName("tblSale_HighscoreByDealerYear")]
        public abstract List<HighScore> GetHighscoreByDealerYear();
        [SprocName("tblSale_HighscoreByRegionYear")]
        public abstract List<HighScore> GetHighscoreByRegionYear();

        [SprocName("tblSale_HighscoreByCarYear")]
        public abstract List<HighScore> GetHighscoreByCarYear();

        [SprocName("tblSale_Highscore_TotalSaleYTD")]
        public abstract int TotalSaleYTD(int Year);

        [SprocName("tblSale_GetEmployeeRevenueThisMonth")]
        public abstract DashboardRevenue GetEmployeeRevenueThisMonth(int EmployeeId);

        [SprocName("tblSale_GetEmployeeRevenueThisYear")]
        public abstract DashboardRevenue GetEmployeeRevenueThisYear(int EmployeeId);

        [SprocName("tblSale_GetTotalRevenueThisMonth")]
        public abstract DashboardRevenue GetTotalRevenueThisMonth();

        [SprocName("tblSale_GetTotalRevenueThisYear")]
        public abstract DashboardRevenue GetTotalRevenueThisYear();

        [SprocName("tblSale_GetLatestSale")]
        public abstract Sale GetLatestSale();

        [SprocName("tblSale_TotalSaleEachMonth")]
        public abstract List<SaleGraph> GetSalesGroupByMonth();

        [SprocName("tblSale_EmployeeIndex")]
        public abstract List<IndexModel> GetEmployeeIndex(DateTime Date);

        [SprocName("tblSale_DealerIndex")]
        public abstract List<IndexModel> GetDealerIndex(DateTime Date);

        [SprocName("tblSale_GetTotalSaleByMonthEmployee")]
        public abstract List<SaleGraph> GetSalesGroupByMonthEmployee(int EmployeeId);

        [SprocName("tblSale_GetTotalSaleByMonthDealer")]
        public abstract List<SaleGraph> GetSalesGroupByMonthDealer(int DealerId);


    }
}
