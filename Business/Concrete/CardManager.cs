using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CardManager : ICardService
    {
        ICardDal _cartDal;
        
        public CardManager(ICardDal cartDal)
        {
            _cartDal = cartDal;
        }

        [ValidationAspect(typeof(CartValidator))]
        public IResult Add(Card entity)
        {
            _cartDal.Add(entity);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Card entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Card>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Card entity)
        {
            throw new NotImplementedException();
        }
    }
}
