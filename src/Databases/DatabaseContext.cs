

using sda_onsite_2_csharp_backend_teamwork_The_countryside_developers.src.Entities;

namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers.src;


public class DatabaseContext
{
    public List<Product> products;
    public DatabaseContext()
    {
        products = [
            new Product( ProductSize.L, "Red",  155.99 ,12 ,"picture","T-shirt","red t-shirt")

        ];
    }
}
