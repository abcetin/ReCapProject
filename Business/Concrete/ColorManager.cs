using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Manager;
using Core.Utilities.Bussiness;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color entity)
        {
            _colorDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Color entity)
        {
            _colorDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<Color>> GetColorById(int id)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c=>c.ColorId==id));
        }

        public IResult Update(Color entity)
        {
            IResult result = BussinessRules.Run(CheckBrandId(entity.Id));

            if (result!=null)
            {
                return new ErrorResult(result.Message);
            }

            _colorDal.Update(entity);
            return new SuccessResult();
        }

        private IResult CheckBrandId(int id)
        {
            var result = _colorDal.GetAll(c => c.Id == id);
            if (result.Count > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Renk Kodu Bulunamadı");
        }

    }
}
