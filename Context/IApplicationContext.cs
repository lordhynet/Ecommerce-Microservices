using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Product.Microservice.Context
{
    public interface IApplicationContext
    {
        Task<int> SaveChanges();
        DbSet<Model.Product> Products { get; set; }


    }
}