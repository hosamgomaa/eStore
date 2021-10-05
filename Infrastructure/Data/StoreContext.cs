using Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Data
{
    public class StoreContext :DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> dbContextOptions):base(dbContextOptions)
        {
        }
        DbSet<Product> Products { get; set; }
    }
}
