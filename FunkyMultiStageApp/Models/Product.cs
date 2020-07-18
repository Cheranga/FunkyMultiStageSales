namespace FunkyMultiStageApp.Models
{
    public class Product
    {
        public string ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int NumberOfItems { get; set; }

        public decimal Total => UnitPrice * NumberOfItems;
    }
}