using Business.Abstract;
using Core.DataAccess;
using Core.Manager;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
            
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }
        public void Add(Car entity)
        {
            if (entity.CarName.Length <=2 || entity.DailyPrice <1)
            {
                Console.WriteLine("Şartlar Sağlanamadı");
            }
            else
            {
                _carDal.Add(entity);
                Console.WriteLine("{0} : Başarıyla Eklendi",entity.CarName);
            }
        }

        public void Update(Car entity)
        {
            _carDal.Update(entity);
        }


        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p=>p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll((p => p.ColorId == id));
        }
        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public void Delete(Car entity)
        {
            _carDal.Delete(entity);
            Console.WriteLine("{0} : Başarıyla Silindi", entity.CarName);
        }
    }
}
