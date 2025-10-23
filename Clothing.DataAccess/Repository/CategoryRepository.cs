using Clothing.DataAccess.Data;
using Clothing.DataAccess.Repository.IRepository;
using Clothing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Clothing.DataAccess.Repository
{
public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDBContext _context;
        public CategoryRepository(AppDBContext context) :base(context)
        {
            _context = context;
        }

       

        public void Update(Category category)
        {
            _context.Update(category);
        }

    }
}
