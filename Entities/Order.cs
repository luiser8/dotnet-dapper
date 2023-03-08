namespace dotnet_dapper.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public DateTime OrderCreation { get; set; }
    }
}