namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
    public class ProductReadDto
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Size { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public string Img { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Processor { get; set; }
        public string RAM { get; set; }
        public string Storage { get; set; }
        public string GraphicsCard { get; set; }
        public string DisplaySize { get; set; }
        public string OperatingSystem { get; set; }

    }
    public class ProductCreateDto
    {
        public Guid CategoryId { get; set; }
        public string? Size { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public string? Color { get; set; }
        public string? Img { get; set; }

        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Processor { get; set; }
        public string? RAM { get; set; }
        public string? Storage { get; set; }
        public string? GraphicsCard { get; set; }
        public string? DisplaySize { get; set; }
        public string? OperatingSystem { get; set; }

    }
    public class ProductUpdateDto
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public string Img { get; set; }

        public string Brand { get; set; }
        public string Model { get; set; }
        public string Processor { get; set; }
        public string RAM { get; set; }
        public string Storage { get; set; }
        public string GraphicsCard { get; set; }
        public string DisplaySize { get; set; }
        public string OperatingSystem { get; set; }

    }
}
