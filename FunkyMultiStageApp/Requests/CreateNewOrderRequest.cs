using System.Collections.Generic;
using System.Linq;
using FunkyMultiStageApp.Models;

namespace FunkyMultiStageApp.Requests
{
    public class CreateNewOrderRequest
    {
        public string OrderId { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }

        public decimal GetTotal()
        {
            if (Products == null || !Products.Any())
            {
                return 0;
            }

            var total = Products.Sum(x => x.Total);
            return total;
        }
    }
}