using System;
using System.Threading.Tasks;
using FunkyMultiStageApp.Core;
using FunkyMultiStageApp.Requests;
using FunkyMultiStageApp.Responses;

namespace FunkyMultiStageApp.Services
{
    public class ShippingService : IShippingService
    {
        public async Task<Result<ShipNewOrderResponse>> ShipNewOrderAsync(ShipNewOrderRequest request)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            return Result<ShipNewOrderResponse>.Success(new ShipNewOrderResponse());
        }
    }
}