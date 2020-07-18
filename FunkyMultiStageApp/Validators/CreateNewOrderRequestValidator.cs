using FluentValidation;
using FunkyMultiStageApp.Requests;

namespace FunkyMultiStageApp.Validators
{
    public class CreateNewOrderRequestValidator : ModelValidatorBase<CreateNewOrderRequest>
    {
        public CreateNewOrderRequestValidator()
        {
            RuleFor(x => x.OrderId);
            RuleFor(x => x.Customer).SetValidator(new CustomerValidator());
            RuleFor(x => x.Products).NotNull().NotEmpty().ForEach(collection => collection.SetValidator(new ProductValidator()));
        }
    }
}