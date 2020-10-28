using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;

namespace DAL
{
    public class AppContext : DbContext
    {
        public AppContext() : base(Connection()) { }

        private static DbContextOptions<AppContext> Connection()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppContext>();
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseMySQL("server=remotemysql.com;database=7t1NYKRaBv;user=7t1NYKRaBv;password=Pg64t8uIFM;port=3306");
            return optionsBuilder.Options;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
