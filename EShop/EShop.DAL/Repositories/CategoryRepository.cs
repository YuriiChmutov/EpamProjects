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
    public class CategoryRepository: IRepository<Category>
    {
       
        private EShopContext _context;

        public CategoryRepository(EShopContext context)
        {
            this._context = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories; //Include(o => o.Phone)
        }

        public Category Get(int? id)
        {
            return _context.Categories.Find(id);
        }

        public void Create(Category category)
        {
            _context.Categories.Add(category);
        }

        public void Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
        }
        public IEnumerable<Category> Find(Func<Category, Boolean> predicate)
        {
            return _context.Categories.Where(predicate).ToList(); //.Include(o => o.Phone)
        }
        public void Delete(int id)
        {
            Category category = _context.Categories.Find(id);
            if (category != null)
                _context.Categories.Remove(category);
        }


    }
}
