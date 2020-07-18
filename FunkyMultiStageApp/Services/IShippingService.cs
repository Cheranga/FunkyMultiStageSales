using System.Threading.Tasks;
using FunkyMultiStageApp.Core;
using FunkyMultiStageApp.Requests;
using FunkyMultiStageApp.Responses;

namespace FunkyMultiStageApp.Services
{
    public interface IShippingService
    {
        Task<Result<ShipNewOrderResponse>> ShipNewOrderAsync(ShipNewOrderRequest request);
    }
}