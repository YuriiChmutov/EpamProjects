using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeFirst.Interfaces;
using CodeFirst.Models;
using EpamPractice.DAL;

namespace EpamPractice.Repository
{
    public class ArticleRepository: IRepository<Article>
    {
        private BlogContext db;

        public ArticleRepository()
        {
            this.db = new BlogContext();
        }

        public IEnumerable<Article> GetAll()
        {
            return db.Articles;
        }

        public Article Get(int? id)
        { 
            return db.Articles.Find(id);
        }

        public void Create(Article item)
        {
            db.Articles.Add(item);
        }

        public void Update(Article item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Article article = db.Articles.Find(id);
            if(article != null)
            {
                db.Articles.Remove(article);
            }
        }

        //public void SaveAll()
        //{
        //    db.SaveChanges();
        //}

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}