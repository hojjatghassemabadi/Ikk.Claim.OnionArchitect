using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Common.Infrastructure
{
    public class BaseRepository<Tkey, T> : IRepository<Tkey, T> where T : class
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Add<T>(entity);
        }

        public T Get(Tkey id)
        {
            return _context.Find<T>(id);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public bool Exists(Expression<Func<T,bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }

        public void Delete(Tkey id)
        {
            var result = Get(id);
            _context.Remove(result);
        }
    }
}
