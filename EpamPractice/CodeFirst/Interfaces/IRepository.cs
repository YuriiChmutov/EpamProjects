using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Models;

namespace CodeFirst.Interfaces
{
    public interface IRepository<T>: IDisposable
    {
        IEnumerable<T> GetAll();
        T Get(int? id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        // SaveAll();
    }
}
