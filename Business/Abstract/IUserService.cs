using Core.Entities.Concrete;
using Core.Manager;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IResult Add(User entity);
        IResult Update(User entity);
        IResult Delete(User entity);
        IDataResult<List<UserDetailDto>> GetUserDetail();
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
        void Add2(User user);

    }
}
