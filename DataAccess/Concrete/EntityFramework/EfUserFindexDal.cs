using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserFindexDal : EfEntityRepositoryBase<UserFindex,RentaCarContext> ,IUserFindexDal
    {
    }
}
