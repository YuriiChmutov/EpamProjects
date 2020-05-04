using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.DLL.Entities;

namespace Entity.DLL.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetBookList();
        T GetBook(int? id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}
