using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> 
            {
                new Car{Id=1,BrandId=1,ColorId=1,CarName ="BMW",ModelYear="2019",DailyPrice= 100,Description="Fırsat Aracı" },
                new Car{Id=2,BrandId=1,ColorId=15,CarName ="VolksWagen",ModelYear="2010",DailyPrice= 50,Description="Sarı Bela" },
                new Car{Id=3,BrandId=2,ColorId=20,CarName ="Maserati",ModelYear="2021",DailyPrice= 200,Description="Güç Endeksi" },
                new Car{Id=4,BrandId=3,ColorId=1,CarName ="Peugeot",ModelYear="2005",DailyPrice= 30,Description="Otoban Faresi" },
                new Car{Id=5,BrandId=5,ColorId=3,CarName ="Volvo",ModelYear="2016",DailyPrice= 80,Description="Kara Gergedan" },
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }


        public void Delete(Car car)
        {
            Car carToTable = _cars.SingleOrDefault(c=>c.Id == car.Id);
            _cars.Remove(car);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            Car carToId = _cars.SingleOrDefault(c=>c.BrandId == Id);
            return _cars;
        }


        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c=>c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.CarName = car.CarName;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
