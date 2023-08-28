namespace dotnet_dapper.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public float ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime ProductCreation { get; set; }
    }
}