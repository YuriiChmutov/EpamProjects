using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeFirst.Interfaces;
using CodeFirst.Models;
using EpamPractice.DAL;

namespace EpamPractice.Repository
{
    public class TagRepository : IRepository<Tag>
    {
        private BlogContext db;

        public TagRepository()
        {
            this.db = new BlogContext();
        }

        public IEnumerable<Tag> GetAll()
        {
            return db.Tags;
        }

        public Tag Get(int? id)
        {
            return db.Tags.Find(id);
        }

        public void Create(Tag item)
        {
            db.Tags.Add(item);
        }

        public void Update(Tag item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Tag tag = db.Tags.Find(id);
            if (tag != null)
            {
                db.Tags.Remove(tag);
            }
        }

        public void SaveAll()
        {
            db.SaveChanges();
        }

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