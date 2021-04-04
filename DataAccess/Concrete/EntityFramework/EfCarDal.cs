using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentaCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RentaCarContext rentaCar = new RentaCarContext())
            {
                var query = from car in rentaCar.Cars
                            join brand in rentaCar.Brands
                            on car.BrandId equals brand.BrandId
                            join color in rentaCar.Colors
                            on car.ColorId equals color.ColorId


                            select new CarDetailDto
                            {
                                Id = car.Id,
                                BrandName = brand.BrandName,
                                CarName = car.CarName,
                                ModelYear = car.ModelYear,
                                ColorName = color.ColorName,
                                FindexPuan = car.FindexPuan,
                                DailyPrice = car.DailyPrice,
                                ImagePath = (from img in rentaCar.CarImages where img.CarId == car.Id select img.ImagePath).ToArray()
                            };

                //return query.ToList();
                return filter == null ? query.ToList() : query.Where(filter).ToList();
            }
        }
    }
}
