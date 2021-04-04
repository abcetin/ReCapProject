using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimsSerivce
    {
        IUserOperationClaimsDal _userOperationClaimsDal;

        public UserOperationClaimManager(IUserOperationClaimsDal userOperationClaimsDal)
        {
            _userOperationClaimsDal = userOperationClaimsDal;
        }

        public IResult Add(UserOperationClaim entity)
        {
            var claim = new UserOperationClaim { UserId=entity.UserId, OperationClaimId = 2006 };
            _userOperationClaimsDal.Add(claim);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(UserOperationClaim entity)
        {
            throw new NotImplementedException();
        }
    }
}
