using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental entity)
        {
            if (entity.RentDate == null)
            {
                return new ErrorResult(Messages.Error);
            }
            else
            {
                _rentalDal.Add(entity);
                return new SuccessResult(Messages.Added);

            }
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetail());
        }

        public IResult Update(Rental entity)
        {
            if (entity.RentDate == null)
            {
                return new ErrorResult(Messages.Error);
            }
            else
            {
                _rentalDal.Update(entity);
                return new SuccessResult(Messages.Updated);

            }
        }
    }
}
