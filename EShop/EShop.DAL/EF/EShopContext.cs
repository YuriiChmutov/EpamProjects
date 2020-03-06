using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EShop.DAL.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EShop.DAL.EF
{
    public class EShopContext: DbContext
    {
        public EShopContext(): base("EShopContext")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    
}
