using Business.Concrete;
using DataAccess.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager car = new CarManager(new InMemoryCarDal());
            
            foreach (var cars in car.GetAll())
            {
                Console.WriteLine(cars.CarName);
            }

            Console.ReadKey();
        }
    }
}
