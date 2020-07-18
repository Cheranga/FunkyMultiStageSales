using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FunkyMultiStageApp.Constants;
using FunkyMultiStageApp.Core;
using FunkyMultiStageApp.Requests;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace FunkyMultiStageApp.Services
{
    public class CreateNewSalesOrderService : ICreateNewSalesOrderService
    {
        private readonly IValidator<CreateNewOrderRequest> _validator;
        private readonly ILogger<CreateNewSalesOrderService> _logger;

        public CreateNewSalesOrderService(IValidator<CreateNewOrderRequest> validator, ILogger<CreateNewSalesOrderService> logger)
        {
            _validator = validator;
            _logger = logger;
        }

        public async Task<Result> HandleAsync(CreateNewOrderRequest request, IAsyncCollector<CreateNewOrderRequest> newOrders)
        {
            try
            {
                var validationResult = _validator.Validate(request);
                if (!validationResult.IsValid)
                {
                    return Result.Failure(ErrorCodes.ValidationError, validationResult.Errors.Select(x => x.ErrorMessage).ToArray());
                }

                await newOrders.AddAsync(request);

                return Result.Success();

            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error occured when processing the new order.");
            }

            return Result.Failure(ErrorCodes.NewOrder, "Error occured when processing the new order.");
        }
    }
}




