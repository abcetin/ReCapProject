using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserFindexService 
    {
        IDataResult<UserFindex> GetFindexByUserId(int id);
        IResult Add(UserFindex entity);
        IResult Update(UserFindex entity);
        IResult Delete(UserFindex entity);
    }
}
