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
        IDataResult<User> Update(UserForRegisterDto userUpdateDto, string password );
        IResult Delete(User entity);
        IDataResult<List<UserDetailDto>> GetUserDetail(int id);
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
        IDataResult<List<UserDetailDto>> GetUserByMail(string email);

    }
}
