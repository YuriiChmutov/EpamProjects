using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CodeFirst.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EpamPractice.DAL
{
    public class BlogContext: DbContext
    {
        public BlogContext(): base("BlogContext")
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
