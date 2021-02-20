using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess;
using Core.Manager;
using Core.Utilities.Results;
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

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.Listed);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car entity)
        {
            _carDal.Add(entity);
            return new SuccessResult(Messages.Added);
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car entity)
        {

            _carDal.Update(entity);
            return new SuccessResult(Messages.Updated);


        }

        public IDataResult<Car> Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id), Messages.Listed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll((p => p.ColorId == id)), Messages.Listed);
        }
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IResult Delete(Car entity)
        {
            _carDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }
    }
}
