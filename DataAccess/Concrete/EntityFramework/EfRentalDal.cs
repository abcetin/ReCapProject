using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentaCarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail()
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                var query = from r in context.Rentals
                            join c in context.Cars
                            on r.CarId equals c.Id
                            join u in context.Users
                            on r.CustomerId equals u.Id
                            select new RentalDetailDto 
                            {
                                CarName = c.CarName,
                                CustomerName = u.FirstName,
                                RentDate = r.RentDate,
                                ReturnDate = (DateTime)r.ReturnDate
                            };

                return query.ToList();
            }
        }
    }
}
