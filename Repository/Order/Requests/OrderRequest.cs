namespace dotnet_dapper.Requests
{
    public class OrderRequest
    {
        public int ClientId { get; set; }
        public int OrderTotal { get; set; }
        public List<OrderProductsRequest> Products { get; set; }
    }
    public class OrderProductsRequest
    {
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public float OrderProductTotal { get; set; }
    }
}
