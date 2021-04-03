using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Bussiness;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand entity)
        {
            _brandDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Brand entity)
        {
            
            _brandDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<Brand>> GetById(int id)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(b => b.Id == id));
        }

        public IDataResult<List<Brand>> GetBrandById(int id)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(b=>b.BrandId==id));
        }

        public IResult Update(Brand entity)
        {
            IResult result = BussinessRules.Run(CheckBrandId(entity.Id));
            if (result!=null)
            {
                return new ErrorResult(result.Message);
            }
            _brandDal.Update(entity);
            return new SuccessResult();
        }

        private IResult CheckBrandId(int id)
        {
            var result = _brandDal.GetAll(b => b.Id == id);
            if (result.Count>0)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Marka Kodu Bulunamadı");
        }
    }
}   
