namespace eComm.Api.Orders.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public double TotalPrice { get; set; }
    }
}
