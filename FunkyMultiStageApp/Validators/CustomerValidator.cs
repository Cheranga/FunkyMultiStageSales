using FluentValidation;
using FunkyMultiStageApp.Models;

namespace FunkyMultiStageApp.Validators
{
    public class CustomerValidator : ModelValidatorBase<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.CustomerId).NotNull().NotEmpty();
        }
    }
}