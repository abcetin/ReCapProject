using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User entity)
        {

            _userDal.Add(entity);
            return new SuccessResult(Messages.Added);


        }

        public IResult Delete(User entity)
        {
            _userDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<UserDetailDto>> GetUserDetail()
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetUserDetails());
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User entity)
        {
            if (entity.FirstName.Length < 2 || entity.Password.Length < 8)
            {
                return new ErrorResult(Messages.Error);
            }
            else
            {
                _userDal.Update(entity);
                return new SuccessResult(Messages.Updated);

            }
        }
    }
}
