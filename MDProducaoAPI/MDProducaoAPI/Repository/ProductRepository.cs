using Microsoft.EntityFrameworkCore;
using System.Linq;
using MDProducaoAPI.Models;
using MDProducaoAPI.Repository.Interfaces;
using System.Collections.Generic;

namespace MDProducaoAPI.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context dataContext) : base(dataContext)
        {
            _context = dataContext;
        }
        public Product GetById(long id)
        {
            return _context.Products.Find(id);
        }
        public List<Product> GetAllProducts()
        {
            return _context.Products
                .Include(mp => mp.ManPlan)
                .ToList();
        }

        public List<Product> GetByName(string name)
        {
            return _context.Products
                .Include(o => o.Name)
                .Where(n => n.Name.name.Equals(name))
                .ToList();
        }

        public void Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

    }
}
