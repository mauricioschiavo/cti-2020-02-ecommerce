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
            optionsBuilder.UseMySQL("server=remotemysql.com;database=7t1NYKRaBv;user=7t1NYKRaBv;password=Pg64t8uIFM;port=3306");
            return optionsBuilder.Options;
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}
