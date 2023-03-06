using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Domain
{
    public interface IRepository<T>
    {
        void Create(T item);
        List<T> GetAll();
        T Get(long id);
        void Save();
        void Delete(long id);
    }
}
