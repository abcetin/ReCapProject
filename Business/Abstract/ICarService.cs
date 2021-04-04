using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService 
    {
        IDataResult<List<Car>> GetAll();
        IResult Add(Car entity);
        IResult Update(Car entity);
        IResult Delete(Car entity);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetCarsByBrandName(string brandName, string colorName);
        IDataResult<List<CarDetailDto>> GetCarsByColorName(string colorName);
        IDataResult<List<CarDetailDto>> GetById(int id);
        IDataResult<List<Car>> GetCarById(int id);
    }
}
