namespace CoffeeShop.Core.Domain
{
    public class Image
    {
        public int Id { get; set; }
        public string AzurePath { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
