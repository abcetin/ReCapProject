using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class FindexValidator : AbstractValidator<UserFindex>
    {
        public FindexValidator()
        {
            RuleFor(u => u.UserId).Must(CheckId);
        }

        private bool CheckId(int id)
        {
            RentaCarContext context = new RentaCarContext();
            var result = context.UserFindex.Where(u=>u.UserId == id).Any();
            if (result)
            {
                return false;
            }
            return true;
        }
    }
}
