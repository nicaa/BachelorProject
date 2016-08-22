using BLToolkit.DataAccess;
using Garia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garia.Core.DAO
{
    public abstract class CarDAO : DataAccessor
    {
        [SprocName("tblCar_GetAllCars")]
        public abstract List<Car> GetAllCars();

        [SprocName("tblCar_DeleteCar")]
        public abstract int DeleteCar(int CarId);

        [SprocName("tblCar_GetCarByID")]
        public abstract Car GetCarByID(int CarId);

        [SprocName("tblCar_CreateCar")]
        public abstract int CreateCar(string CarType);

    }
}
