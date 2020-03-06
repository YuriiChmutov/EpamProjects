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
    public class ProductRepository: IRepository<Product>
    {
        private EShopContext _context;

        public ProductRepository(EShopContext context)
        {
            this._context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products;
        }

        public Product Get(int? id)
        {
            return _context.Products.Find(id);
        }

        public void Create(Product product)
        {
            _context.Products.Add(product);
        }

        public void Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
        }

        //public IEnumerable<Product> Find(Func<Product, Boolean> predicate)
        //{
        //    return _context.Products.Where(predicate).ToList();
        //}

        public void Delete(int id)
        {
            Product product = _context.Products.Find(id);
            if (product != null)
                _context.Products.Remove(product);
        }
    }
}
