using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
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

        public User GetByMail(string email)
        {
            return _userDal.Get(u=>u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IDataResult<List<UserDetailDto>> GetUserDetail()
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetUserDetails());
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }

        
    }
}
