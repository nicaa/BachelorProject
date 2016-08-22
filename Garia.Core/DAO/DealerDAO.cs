using BLToolkit.DataAccess;
using Garia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garia.Core.DAO
{
    public abstract class DealerDAO : DataAccessor
    {
        [SprocName("tblDealer_GetAllDealers")]
        public abstract List<Dealer> GetAllDealers();

        [SprocName("tblDealer_GetDealerById")]
        public abstract Dealer GetDealerById(int DealerId);

        [SprocName("tblDealer_DeleteDealerById")]
        public abstract int DeleteDealerById(int DealerId);

        [SprocName("tblDealer_CreateDealer")]
        public abstract int CreateDealer(string DealerName, int RegionId, float Budget);

        [SprocName("tblDealerAssign_GetAllRelationships")]
        public abstract List<AssignDealer> GetAllRelationships();

        [SprocName("tblDealerAssign_DeleteRelationshipById")]
        public abstract int DeleteRelationshipById(int DealerAssignId);

        [SprocName("tblDealerAssign_AssignDealer")]

        public abstract int AssignDealer(int EmployeeId, int DealerId);

        [SprocName("tblDealerAssign_getDealerRelationship")]
        public abstract List<DealerRelationship> getDealerRelationship();

        [SprocName("tblRegion_GetRegions")]
        public abstract List<Region> GetRegions();


    }
}
