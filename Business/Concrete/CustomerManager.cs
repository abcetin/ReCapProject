using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer entity)
        {
            if (entity.CompanyName.Length <2)
            {
                return new ErrorResult(Messages.Error);
            }
            else
            {
                _customerDal.Add(entity);
                return new SuccessResult(Messages.Added);

            }
        }

        public IResult Delete(Customer entity)
        {
            _customerDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.Listed);
        }

        public IResult Update(Customer entity)
        {
            if (entity.CompanyName.Length < 2)
            {
                return new ErrorResult(Messages.Error);
            }
            else
            {
                _customerDal.Update(entity);
                return new SuccessResult(Messages.Updated);

            }
        }
    }
}
