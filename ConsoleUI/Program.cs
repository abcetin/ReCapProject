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
            CrudOperations operations = new CrudOperations();
            //operations.AddUser();
            //operations.GetRentAlDetail();
            //operations.GetAllCar();
            //operations.GetCarDetail();
            //operations.AddCar();
            //operations.DeleteCar(4017);
            //operations.UpdateCar(2012);
            //operations.AddRentAl();
            //operations.AddCustomer();
            //Aynı şekilde color ve brand için bütün özellikler kullanılabilir.
            Console.ReadKey();

        }

       

    }
}
