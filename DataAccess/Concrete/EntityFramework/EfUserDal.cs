using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal: EfEntityRepositoryBase<User,RentaCarContext> , IUserDal
    {
        public List<UserDetailDto> GetUserDetails() 
        {
            using (var context = new RentaCarContext())
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

        public List<OperationClaim> GetClaims(User user) //Gönderdiğimiz user ın claim lerini join operasyonuyla çektik
        {
            using (var context = new RentaCarContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }
    }
}
