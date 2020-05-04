using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.DLL.Entities;
using Entity.DLL.Interfaces;
using System.Data.Entity;
using EpamLecturePracticeProducts.DAL;

namespace EpamLecturePracticeProducts.Repository
{
    public class GanreRepository: IRepository<Ganre>
    {
        private BookContext db;

        public GanreRepository()
        {
            db = new BookContext();
        }

        public IEnumerable<Ganre> GetBookList()
        {
            return db.Ganres;
        }

        public Ganre GetBook(int? id)
        {
            return db.Ganres.Find(id);
        }

        public void Create(Ganre ganre)
        {
            db.Ganres.Add(ganre);
        }

        public void Update(Ganre ganre)
        {
            db.Entry(ganre).State = EntityState.Modified;

        }

        public void Delete(int id)
        {
            Ganre ganre = db.Ganres.Find(id);
            if (ganre != null)
            {
                db.Ganres.Remove(ganre);

            }
        }

        public void Save()
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