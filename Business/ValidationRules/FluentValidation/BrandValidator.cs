using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b => b.BrandId).NotEmpty();
            RuleFor(b => b.BrandName).NotEmpty();
            RuleFor(b => b.BrandId).Must(CheckBrandId).WithMessage("Bu Model Koduyla Başka Bir Kayıt Bulunuyor.");
        }

        private bool CheckBrandId(int id)
        {
            RentaCarContext context = new RentaCarContext();

            var check = context.Brands.Where(b => b.BrandId == id).Any();

            if (check)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
