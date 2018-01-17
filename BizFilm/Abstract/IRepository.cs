using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IRepository<T> where T : class, new()
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> Find(Func<T, bool> predicat);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        //void Save();
    }
}
