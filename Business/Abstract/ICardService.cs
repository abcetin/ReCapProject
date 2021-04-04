
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICardService 
    {
        IDataResult<List<Card>> GetAll();
        IResult Add(Card entity);
        IResult Update(Card entity);
        IResult Delete(Card entity);
    }
}
