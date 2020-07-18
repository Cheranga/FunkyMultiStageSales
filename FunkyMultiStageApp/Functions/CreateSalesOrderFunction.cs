using System.Threading.Tasks;
using FunkyMultiStageApp.Extensions;
using FunkyMultiStageApp.Requests;
using FunkyMultiStageApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace FunkyMultiStageApp.Functions
{
    public class CreateSalesOrderFunction
    {
        private readonly ILogger<CreateSalesOrderFunction> _logger;
        private readonly ICreateNewSalesOrderService _newSalesOrderService;

        public CreateSalesOrderFunction(ICreateNewSalesOrderService newSalesOrderService, ILogger<CreateSalesOrderFunction> logger)
        {
            _newSalesOrderService = newSalesOrderService;
            _logger = logger;
        }

        [FunctionName(nameof(CreateSalesOrderFunction))]
        public async Task<IActionResult> CreateAsync([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "orders")]
            HttpRequest request,
            [Queue("%NewOrdersQueue%")] IAsyncCollector<CreateNewOrderRequest> orders)
        {
            var newSalesOrder = await request.GetModel<CreateNewOrderRequest>();
            var operation = await _newSalesOrderService.HandleAsync(newSalesOrder, orders);

            if (!operation.Status)
            {
                _logger.LogError("Error when processing new order request.");
                return new BadRequestObjectResult(operation.Error);
            }

            return new AcceptedResult();
        }
    }
}