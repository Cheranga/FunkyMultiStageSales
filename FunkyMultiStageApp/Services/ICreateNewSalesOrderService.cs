using System.Threading.Tasks;
using FunkyMultiStageApp.Core;
using FunkyMultiStageApp.Requests;
using Microsoft.Azure.WebJobs;

namespace FunkyMultiStageApp.Services
{
    public interface ICreateNewSalesOrderService
    {
        Task<Result> HandleAsync(CreateNewOrderRequest request, IAsyncCollector<CreateNewOrderRequest> newOrders);
    }
}