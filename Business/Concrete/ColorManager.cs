using Business.Abstract;
using Core.Manager;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public void Add(Color entity)
        {
            _colorDal.Add(entity);
        }

        public IResult Delete(Color entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Color>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Color entity)
        {
            throw new NotImplementedException();
        }

        IResult IManagerBase<Color>.Add(Color entity)
        {
            throw new NotImplementedException();
        }
    }
}
