using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Product.Microservice.Context
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Product.Microservice.Model.Product> Products { get; set; }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }

    }
}
