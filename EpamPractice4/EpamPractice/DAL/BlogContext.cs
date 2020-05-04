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
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Tag> Tags { get; set; }

        //public DbSet<TagArticleModel> TagArticle { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<Tag>()
            //            .HasMany<Article>(t => t.Articles)
            //            .WithMany(a => a.Tags)
            //            .Map


        }
    }
}
