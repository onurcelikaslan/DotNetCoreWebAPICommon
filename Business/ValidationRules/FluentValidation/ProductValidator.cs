using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(c => c.ProductName).NotEmpty().WithMessage("Product name should not be empty.");
            RuleFor(c => c.ProductName).MinimumLength(3);
            RuleFor(c => c.QuantityPerUnit).Must(QuantityControl).WithMessage("Quantity must be greater than 1");
        }

        public bool QuantityControl(string QuantityPerUnit) 
        {
            return Convert.ToInt32(QuantityPerUnit) > 1;
        }
    }
}
