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

            // GetAllCar();
            //GetCarDetail();
            //AddCar();
            //DeleteCar(2011);
            //UpdateCar(2012);

            //Aynı şekilde color ve brand için bütün özellikler kullanılabilir.
            Console.ReadKey();
            
        }

        private static void UpdateCar(int id)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car() {Id = id, CarName = "Bugatti", BrandId = 2,ColorId=4,DailyPrice=1000,ModelYear="2021" };
            carManager.Update(car);
            Console.WriteLine("{0} : Başarıyla Güncellendi", car.CarName);
        }

        private static void DeleteCar(int id)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car() { Id = id };
            carManager.Delete(car);  
        }

        private static void AddCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car()
            {
                CarName = "Car",
                BrandId = 2,
                ColorId = 3,
                DailyPrice = 100,
                ModelYear = "2021",
                Description = "Sakinnn"
            };
            carManager.Add(car1);
        }

        private static void GetCarDetail()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("----------------------------------------------------------- -");
                Console.WriteLine("{0} {1} {2} {3}",car.CarName,car.BrandName,car.ColorName,car.DailyPrice);
            }

        }
        private static void GetAllCar()
        {
            CarManager car = new CarManager(new EfCarDal());
            foreach (var cars in car.GetAll())
            {
                Console.WriteLine("--------------");
                Console.WriteLine(cars.CarName);
            }

        }

    }
}
