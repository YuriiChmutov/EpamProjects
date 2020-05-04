using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.SqlServer;
using Entity.DLL.Entities;

namespace EpamLecturePracticeProducts.DAL
{
    public class BookContext: DbContext
    {

        public BookContext(): base("BookContext")
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Ganre> Ganres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}