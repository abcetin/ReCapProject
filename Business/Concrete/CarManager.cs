using Business.Abstract;
using Business.BussinessAspect.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess;
using Core.Utilities.Bussiness;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            Thread.Sleep(2000);
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.Listed);
        }

        
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("car.add,admin")]
        public IResult Add(Car entity)
        {

            _carDal.Add(entity);
            return new SuccessResult(Messages.Added);
        }

        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("car.list,admin")]
        public IResult Update(Car entity)
        {

            _carDal.Update(entity);
            return new SuccessResult(Messages.Updated);


        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<CarDetailDto>> GetCarsByBrandName(string brandName, string colorName)
        {
            if (brandName==null || colorName==null)
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.ColorName == colorName || p.BrandName==brandName), Messages.Listed);
            }
            else
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.BrandName == brandName && p.ColorName == colorName), Messages.Listed);
            }
            
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsByColorName(string colorName)
        {
            
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails((p => p.ColorName == colorName)), Messages.Listed);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.Listed);
        }


        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("car.list,admin")]
        public IResult Delete(Car entity)
        {
            _carDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetById(int id)
        {

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.Id == id), Messages.Listed);
        }
        public IDataResult<List<Car>> GetCarById(int id)
        {

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.Id == id), Messages.Listed);
        }

        [TransactionAspect]
        public IResult TransactionalOperation(Car car)
        {
            _carDal.Update(car);
            _carDal.Add(car);
            return new SuccessResult(Messages.Updated);
        }


    }
}