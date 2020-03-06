using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.DAL.Entities;

namespace EShop.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Product> Products { get; }
        IRepository<Category> Categories { get; }
        void Save();
        void Dispose();
    }
}
