using Microsoft.EntityFrameworkCore;
using Npgsql;
namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }

        public DbSet<Category> Category { get; set; }
        public DbSet<Payment> Payment { get; set; }
        private IConfiguration _config;
        public DatabaseContext(IConfiguration config)
        {
            _config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            var dataSourceBuilder = new NpgsqlDataSourceBuilder(@$"Host={_config["Db:Host"]};
            Username={_config["Db:Username"]};Database={_config["Db:Database"]};Password={_config["Db:Password"]}");
            dataSourceBuilder.MapEnum<Role>();
            var dataSource = dataSourceBuilder.Build();
            optionsBuilder.UseNpgsql(dataSource).UseSnakeCaseNamingConvention();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<Role>();
        }
    }
}