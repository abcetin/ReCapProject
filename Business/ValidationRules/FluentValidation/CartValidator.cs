using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    
    public class CartValidator : AbstractValidator<Card>
    {
        
        public CartValidator()
        {
            RuleFor(c => c.CartNumber).NotEmpty();
            RuleFor(c => c.CartNumber).MaximumLength(16);
            RuleFor(c => c.CartNumber).MinimumLength(16);
            RuleFor(c => c.CartOwner).NotEmpty();
            RuleFor(c => c.CCV).NotEmpty();
            RuleFor(c => c.Mounth).NotEmpty();
            RuleFor(c => c.Year).NotEmpty();
            
        }
    }
}
