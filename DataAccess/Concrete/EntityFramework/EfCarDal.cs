using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentaCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentaCarContext rentaCar = new RentaCarContext())
            {
                var query = from c in rentaCar.Cars
                            join b in rentaCar.Brands
                            on c.BrandId equals b.BrandId
                            join cr in rentaCar.Colors
                            on c.ColorId equals cr.ColorId
                            select new CarDetailDto
                            {

                                CarName = c.CarName,
                                BrandName = b.BrandName,
                                ColorName = cr.ColorName,
                                DailyPrice = c.DailyPrice
                            };

                return query.ToList();
            }
        }
    }
}
