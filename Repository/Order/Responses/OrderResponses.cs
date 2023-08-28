namespace dotnet_dapper.Responses
{
    public class OrderResponses
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public int OrderTotal { get; set; }
        public byte OrderStatus { get; set; }
        public DateTime OrderCreation { get; set; }
        public List<ProductsOrderResponses>? Products { get; set; }
    }
    public class ProductsOrderResponses
    {
        public int OrderProductId { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public int OrderProductTotal { get; set; }
        public byte OrderProductStatus { get; set; }
    }
}