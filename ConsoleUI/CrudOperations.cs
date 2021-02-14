using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class CrudOperations // Sadece Metotlar Program cs de kalabalık etmemsi için oluşturulmuştur.
    {
        public void UpdateCar(int id)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car() { Id = id, CarName = "Bugatti", BrandId = 2, ColorId = 4, DailyPrice = 1000, ModelYear = "2021" };
            var result = carManager.Update(car);
            if (result.Success == true)
            {
                string name = car.CarName;
                string message = result.Message;
                Console.WriteLine("{0} : {1}", name, message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        public void DeleteCar(int id)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car() { Id = id };

            var result = carManager.Delete(car);
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        public void AddCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car()
            {
                CarName = "Car3",
                BrandId = 2,
                ColorId = 3,
                DailyPrice = 10,
                ModelYear = "2021",
                Description = "Sakinnn"
            };

            var result = carManager.Add(car1);
            if (result.Success == true)
            {
                string name = car1.CarName;
                string message = result.Message;
                Console.WriteLine("{0} : {1}", name, message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
        public void GetByBrandId(int id)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarsByBrandId(id);
            foreach (var car in result.Data)
            {
                if (result.Success == true)
                {
                    Console.WriteLine("----------------------------------------------------------- -");
                    Console.WriteLine("{0} ,{1}", car.CarName,car.BrandId);
                }
                else
                {
                    Console.WriteLine(result.Message);
                }
            }

        }

        public void GetCarDetail()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            foreach (var car in result.Data)
            {
                if (result.Success == true)
                {
                    Console.WriteLine("----------------------------------------------------------- -");
                    Console.WriteLine("{0} {1} {2} {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
                }
                else
                {
                    Console.WriteLine(result.Message);
                }
            }

        }
        public void GetAllCar()
        {
            CarManager car = new CarManager(new EfCarDal());
            var result = car.GetAll();
            foreach (var cars in result.Data)
            {
                if (result.Success == true)
                {
                    Console.WriteLine("--------------");
                    Console.WriteLine(cars.CarName);
                }
                else
                {
                    Console.WriteLine(result.Message);
                }
            }

        }
        public void AddUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User user = new User()
            {
                FirstName = "Hüseyin",
                LastName = "ÇOBAN",
                Email = "hc@gmail.com",
                Password = "12332112"
            };

            var result = userManager.Add(user);
            if (result.Success == true)
            {
                string name = user.FirstName;
                string message = result.Message;
                Console.WriteLine("{0} : {1}", name, message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        public void GetRentAlDetail()
        {
            RentalManager rental = new RentalManager(new EfRentalDal());

            var result = rental.GetRentalDetail();
            foreach (var car in result.Data)
            {
                if (result.Success == true)
                {
                    Console.WriteLine("----------------------------------------------------------- -");
                    Console.WriteLine("{0} {1} {2} {3}", car.CarName, car.CustomerName, car.RentDate, car.ReturnDate);
                }
                else
                {
                    Console.WriteLine(result.Message);
                }
            }

        }

        public void AddRentAl() 
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental()
            {
                CarId = 3,
                CustomerId = 5,
                RentDate = DateTime.Now
            };

            var result = rentalManager.Add(rental);
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
        public void AddCustomer() 
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Customer customer = new Customer() { UserId=5,CompanyName="MRTCNTC"};

            var result = customerManager.Add(customer);
            if (result.Success==true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
