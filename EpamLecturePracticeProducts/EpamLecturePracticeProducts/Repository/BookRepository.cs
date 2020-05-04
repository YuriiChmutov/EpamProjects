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
    public class BookRepository: IRepository<Book>
    {
        private BookContext db;

        public BookRepository()
        {
            db = new BookContext();
        }

        public IEnumerable<Book> GetBookList()
        {
            return db.Books;
        }

        public Book GetBook(int? id)
        {
            return db.Books.Find(id);
        }

        public void Create(Book book)
        {
            db.Books.Add(book);
        }

        public void Update(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
           
        }

        public void Delete(int id)
        {
            Book book = db.Books.Find(id);
            if (book != null) {
                db.Books.Remove(book);
                
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
