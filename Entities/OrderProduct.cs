namespace dotnet_dapper.Entities
{
    public class OrderProduct
    {
        public int OrderProductId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public float OrderProductTotal { get; set; }
        public bool OrderProductStatus { get; set; }
        public DateTime OrderProductCreation { get; set; }
    }
}