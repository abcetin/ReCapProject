using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.ColorName).NotEmpty();
            RuleFor(c => c.ColorId).Must(CheckColorId).WithMessage("Bu Renk Kodu Halihazırda Bulunmaktadır!");
        }

        private bool CheckColorId(int id)
        {
            RentaCarContext context = new RentaCarContext();

            var result = context.Colors.Where(c => c.ColorId==id).Any();

            if (result)
            {
                return false;
            }

            return true;
        }
    }
}
