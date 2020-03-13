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
    public class OrderRepository : IRepository<Order>
    {
        private EShopContext _context;

        public OrderRepository(EShopContext context)
        {
            this._context = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders;
        }

        public Order Get(int? id)
        {
            return _context.Orders.Find(id);
        }

        public void Create(Order order)
        {
            _context.Orders.Add(order);
        }

        public void Update(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Order order = _context.Orders.Find(id);
            if (order != null)
                _context.Orders.Remove(order);
        }

    }
}
