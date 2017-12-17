using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IRepository<T> : IDisposable where T : class, new()
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void AddOrUpdate(T item);
        void Delete(T item);
        //void Save();
    }
}
