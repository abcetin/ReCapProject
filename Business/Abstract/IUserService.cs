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
    public interface IUserService : IManagerBase<User>
    {
        IDataResult<List<UserDetailDto>> GetUserDetail();
        List<OperationClaim> GetClaims(User user);

        User GetByMail(string email);

    }
}
