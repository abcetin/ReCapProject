using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage,RentaCarContext> , ICarImageDal
    {
        public List<CarImageDto> GetCarImagesDetail(Expression<Func<CarImageDto, bool>> filter = null)
        {
            using (RentaCarContext rentaCar = new RentaCarContext())
            {
                var query = from car in rentaCar.Cars
                            join image in rentaCar.CarImages
                            on car.Id equals image.CarId
                            join brand in rentaCar.Brands
                            on car.BrandId equals brand.BrandId
                            select new CarImageDto
                            {
                                Id = image.Id,
                                CarId = car.Id,
                                CarName = ($"{brand.BrandName}{car.CarName}"),
                                ImagePath = (from img in rentaCar.CarImages where img.CarId == car.Id select img.ImagePath).ToArray(),
                                Date=DateTime.Today
                            };

                //return query.ToList();
                return filter == null ? query.ToList() : query.Where(filter).ToList();
            }
        }
    }
}
