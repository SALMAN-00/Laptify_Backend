namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{

    public class Product
    {

        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }
        public ProductSize Size { get; set; }
        public string? Color { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string? Img { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

    }
}