using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.DAL.EF;
using EShop.DAL.Entities;
using EShop.DAL.Interfaces;
using EShop.DAL.Repositories;

namespace EShop.DAL.Repositories
{
    public class EFUnitOfWork: IDisposable
    {
        private EShopContext _context = new EShopContext();
        private ProductRepository productRepository;
        private CategoryRepository categoryRepository;

       

        public ProductRepository Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(_context);
                return productRepository;
            }
        }

        public CategoryRepository Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(_context);
                return categoryRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
