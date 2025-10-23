using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clothing.DataAccess.Data;
using Clothing.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Clothing.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDBContext _context;
        internal DbSet<T> dbSet;
        public Repository (AppDBContext context)
        {
            _context = context;
            dbSet= _context.Set<T>();// _context.Categories == dbSet
        }
        public void Add(T entity)
        {
            _context.Add(entity);
           
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
