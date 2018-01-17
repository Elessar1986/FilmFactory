using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmsDB.TestModel;

namespace Repository.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<films> Films { get; }
        IRepository<genre> Genres { get; }
        IRepository<director> Director { get; }
        void Save();
    }
}
