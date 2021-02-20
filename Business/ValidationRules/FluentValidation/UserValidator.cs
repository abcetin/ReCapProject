using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).MinimumLength(8).WithMessage("Parola en az 8 karakterden oluşmalı");
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).Must(CheckEmail).WithMessage("Bu maille daha önce kayıt oluşturulmuş");
        }

        private bool CheckEmail(string arg)
        {
            RentaCarContext context = new RentaCarContext();
            var check = context.Users.Where(u => u.Email == arg).SingleOrDefault();

            if (check == null)
            {
                return true;
            }
            return false;
        }
    }
}
