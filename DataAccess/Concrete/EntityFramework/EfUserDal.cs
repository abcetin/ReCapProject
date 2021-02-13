using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal: EfEntityRepositoryBase<User,RentaCarContext> , IUserDal
    {
        public List<UserDetailDto> GetUserDetails() 
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                var query = from c in context.Customers
                           join u in context.Users
                           on c.UserId equals u.Id
                           select new UserDetailDto
                           {
                               UserId = u.Id,
                               FirstName = u.FirstName,
                               LastName = u.LastName,
                               Email = u.Email
                           };
                return query.ToList();
            }
        }
    }
}
