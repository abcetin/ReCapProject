using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserFindexManager : IUserFindexService
    {
        IUserFindexDal _userFindexDal;

        public UserFindexManager(IUserFindexDal userFindexDal)
        {
            _userFindexDal = userFindexDal;
        }

        [ValidationAspect(typeof(FindexValidator))]
        public IResult Add(UserFindex entity)
        {
            Random random = new Random();
            entity.FindexPuan = random.Next(0, 1900);
            _userFindexDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(UserFindex entity)
        {
            _userFindexDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<UserFindex> GetFindexByUserId(int id)
        {
            return new SuccessDataResult<UserFindex>(_userFindexDal.Get(f => f.UserId == id));
        }

        public IResult Update(UserFindex entity)
        {
            _userFindexDal.Update(entity);
            return new SuccessResult();
        }
    }
}
