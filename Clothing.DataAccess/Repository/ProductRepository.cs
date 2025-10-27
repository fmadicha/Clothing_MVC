using Clothing.DataAccess.Data;
using Clothing.DataAccess.Repository.IRepository;
using Clothing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothing.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private AppDBContext _context;

        public ProductRepository(AppDBContext context):base(context) 
        {
            _context = context;
        }
        public void Update(Product product)
        {
            _context.Update(product);
        }
    }
}
