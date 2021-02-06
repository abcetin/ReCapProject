using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager car = new CarManager(new EfCarDal());
            Car car1 = new Car()
            {
                CarName = "Bugatti",

                BrandId = 2,
                ColorId = 3,
                DailyPrice = 0,
                ModelYear= "2021",
                Description = "Sakinnn"
            };

            car.Add(car1);
            
            foreach (var cars in car.GetAll())
            {
                Console.WriteLine(cars.CarName);
            }

            Console.ReadKey();
        }
    }
}
