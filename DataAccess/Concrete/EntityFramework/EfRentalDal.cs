using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentaCarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                var result = from re in context.Rentals
                             join us in context.Users
                             on re.CustomerId equals us.Id
                             join ca in context.Cars
                             on re.CarId equals ca.Id
                             join ba in context.Brands
                            on ca.BrandId equals ba.BrandId

                             select new RentalDetailDto
                             {
                                 Id = re.Id,
                                 CarName = ($"{ba.BrandName} {ca.CarName}"),
                                 UserName = ($"{us.FirstName} {us.LastName}"),
                                 RentDate = re.RentDate,
                                 ReturnDate = (DateTime)re.ReturnDate
                             };
                return result.ToList();
            }
        }

       
    }
}
