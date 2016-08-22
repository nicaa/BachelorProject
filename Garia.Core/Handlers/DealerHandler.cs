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
    public class DealerHandler
    {
        public static List<Dealer> GetAllDealers()
        {
            DealerDAO dealer = TypeAccessor<DealerDAO>.CreateInstance();  
            return dealer.GetAllDealers();
        }

        public static Dealer GetDealerById(int DealerId)
        {
            DealerDAO dealer = TypeAccessor<DealerDAO>.CreateInstance();
            return dealer.GetDealerById(DealerId);
        }
        public static int DeleteDealerById(int DealerId)
        {
            DealerDAO dealer = TypeAccessor<DealerDAO>.CreateInstance();
            return dealer.DeleteDealerById(DealerId );
        }
        public static int CreateDealer(string DealerName, int RegionId, float Budget)
        {
            DealerDAO dealer = TypeAccessor<DealerDAO>.CreateInstance();
            return dealer.CreateDealer(DealerName, RegionId, Budget);
        }
        public static List<AssignDealer> GetAllRelationships()
        {
            DealerDAO dealer = TypeAccessor<DealerDAO>.CreateInstance();
            return dealer.GetAllRelationships();

        }

        public static int DeleteRelationshipById(int DealerAssignId)
        {
            DealerDAO dealer = TypeAccessor<DealerDAO>.CreateInstance();
            return dealer.DeleteRelationshipById(DealerAssignId);
        }

        public static int AssignDealer(int EmployeeId,int DealerId)
        {
            DealerDAO dealer = TypeAccessor<DealerDAO>.CreateInstance();
            return dealer.AssignDealer(EmployeeId, DealerId);
        }
        public static List<DealerRelationship> getDealerRelationship()
        {
            DealerDAO dealer = TypeAccessor<DealerDAO>.CreateInstance();
            return dealer.getDealerRelationship();

        }
        public static List<Region> GetRegions()
        {
            DealerDAO dealer = TypeAccessor<DealerDAO>.CreateInstance();
            return dealer.GetRegions();

        }

    }
}
