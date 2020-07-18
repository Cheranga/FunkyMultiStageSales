using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FunkyMultiStageApp.Requests;
using FunkyMultiStageApp.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace FunkyMultiStageApp.Functions
{
    public class ProcessSalesOrderFunction
    {
        private readonly IShippingService _shippingService;
        private readonly ILogger<ProcessSalesOrderFunction> _logger;

        public ProcessSalesOrderFunction(IShippingService shippingService, ILogger<ProcessSalesOrderFunction> logger)
        {
            _shippingService = shippingService;
            _logger = logger;
        }

        [FunctionName(nameof(ProcessSalesOrderFunction))]
        public async Task ProcessOrderAsync([QueueTrigger("%NewOrdersQueue%")]CreateNewOrderRequest request)
        {
            try
            {
                //
                // TODO: Do some additional processing.
                //
                await _shippingService.ShipNewOrderAsync(new ShipNewOrderRequest());
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error when processing the new order.");
            }
        }
    }
}
