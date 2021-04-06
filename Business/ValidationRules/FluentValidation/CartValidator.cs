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
            RuleFor(c => c.CardNumber).NotEmpty();
            RuleFor(c => c.CardNumber).MaximumLength(16);
            RuleFor(c => c.CardNumber).MinimumLength(16);
            RuleFor(c => c.CardOwner).NotEmpty();
            RuleFor(c => c.CCV).NotEmpty();
            RuleFor(c => c.Mounth).NotEmpty();
            RuleFor(c => c.Year).NotEmpty();
            
        }
    }
}
