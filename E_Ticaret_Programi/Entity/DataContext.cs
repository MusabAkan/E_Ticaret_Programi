

using System.Data.Entity;

namespace E_Ticaret_Programi.Entity
{
    public class DataContext : DbContext
    {
        public DataContext() : base("dataConnection")
        {
          
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}