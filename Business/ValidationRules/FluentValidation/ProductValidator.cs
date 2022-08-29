using Entities.Concretes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    //bu product nesnesi için bir validator
    public class ProductValidator:AbstractValidator<Product>
    {
        //validation kuralları constructor icerisine yazılır
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductDescription).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(3);
        }
    }
}
