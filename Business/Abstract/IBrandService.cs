using Core.Manager;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService 
    {
        IDataResult<List<Brand>> GetAll();
        IDataResult<List<Brand>> GetBrandById(int id);
        IDataResult<List<Brand>> GetById(int id);
        IResult Add(Brand entity);
        IResult Update(Brand entity);
        IResult Delete(Brand entity);
    }
}
