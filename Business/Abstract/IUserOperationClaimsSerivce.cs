using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
     public interface IUserOperationClaimsSerivce
    {
        IResult Add(UserOperationClaim entity);
        IResult Update(UserOperationClaim entity);
        IResult Delete(int id);

    } 
}
