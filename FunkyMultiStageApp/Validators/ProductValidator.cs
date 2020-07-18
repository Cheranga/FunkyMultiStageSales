using FluentValidation;
using FunkyMultiStageApp.Models;

namespace FunkyMultiStageApp.Validators
{
    public class ProductValidator : ModelValidatorBase<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductId).NotNull().NotEmpty();
            RuleFor(x => x.UnitPrice).GreaterThan(0);
            RuleFor(x => x.NumberOfItems).GreaterThan(0);
        }
    }
}