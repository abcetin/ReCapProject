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
        ICardDal _cardDal;
        
        public CardManager(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }

        [ValidationAspect(typeof(CartValidator))]
        public IResult Add(Card entity)
        {
            _cardDal.Add(entity);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Card entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Card>> GetAll()
        {
            return new SuccessDataResult<List<Card>>(_cardDal.GetAll());
        }

        public IDataResult<List<Card>> GetCardByUserId(int userId)
        {
            return new SuccessDataResult<List<Card>>(_cardDal.GetAll(c => c.UserId == userId));
        }

        public IDataResult<Card> GetCardById(int id)
        {
            return new SuccessDataResult<Card>(_cardDal.Get(c=>c.Id==id));
        }

        public IResult Update(Card entity)
        {
            throw new NotImplementedException();
        }
    }
}
