using Clothing.DataAccess.Data;
using Clothing.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDBContext _context;
        public ICategoryRepository Category { get; private set; }
        public UnitOfWork(AppDBContext context) 
        {
            _context = context;
            Category= new CategoryRepository(_context);
        }
       

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
