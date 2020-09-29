using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;

namespace DAL
{
    public class Contexto : DbContext
    {
        public Contexto() : base(Connection()) { }

        private static DbContextOptions<Contexto> Connection()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Contexto>();
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseMySQL("server=localhost;database=ecommercecti;user=cti;password=123456;port=3306");
            return optionsBuilder.Options;
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}
