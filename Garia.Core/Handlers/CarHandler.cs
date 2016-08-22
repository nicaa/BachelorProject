using Garia.Core.Entities;
using Garia.Core.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLToolkit.Reflection;

namespace Garia.Core.Handlers
{
    public class CarHandler
    {
        public static List<Car> GetAllCars()
        {
            CarDAO car = TypeAccessor<CarDAO>.CreateInstance();
            return car.GetAllCars();
        }

        public static Car GetCarByID(int CarId)
        {
            CarDAO car = TypeAccessor<CarDAO>.CreateInstance();
            return car.GetCarByID(CarId);
        }
        public static int DeleteCarByID(int CarId)
        {
            CarDAO car = TypeAccessor<CarDAO>.CreateInstance();
            return car.DeleteCar(CarId);
        }
        public static int CreateCar(string CarType)
        {
            CarDAO car = TypeAccessor<CarDAO>.CreateInstance();
            return car.CreateCar(CarType);
        }
    }
}
