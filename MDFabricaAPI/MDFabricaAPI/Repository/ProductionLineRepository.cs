using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MDFabricaAPI.Models;
using MDFabricaAPI.Models.ValueObjects;
using MDFabricaAPI.Repository.Interfaces;

namespace MDFabricaAPI.Repository
{
    public class ProductionLineRepository : Repository<ProductionLine>, IProductionLineRepository
    {
        private readonly Context _context;

        public ProductionLineRepository(Context dataContext) : base(dataContext)
        {
            _context = dataContext;
        }
        public ProductionLine GetById(long id)
        {
            return _context.ProductionLines.Find(id);
            /*return _context.ProductionLines
                 .Include(pl => pl.Name)
                 .ThenInclude(p => p.name)
                 .Include(pl => pl.Machines)
                 .ThenInclude(mt => mt.MachineType)
                 .ThenInclude(t => t.Name)
                 .ThenInclude(n => n.name)
                 .Include(mt => mt.Machines)
                 .ThenInclude(pln => pln.Name)
                 .ThenInclude(plnn => plnn.name)
                 .FirstOrDefault(x => x.ProductionLineId == id);*/
        }
        public List<ProductionLine> GetByName(string name)
        {
            return _context.ProductionLines
                .Include(o => o.Name)
                .Where(n => n.Name.name.Equals(name))
                .ToList();
            //return _repositoryOperation.GetByName(name);
        }

        public ProductionLine Create(ProductionLine productionLine)
        {
            _context.ProductionLines.Add(productionLine);
            _context.SaveChanges();
            return productionLine;
        }

        public List<ProductionLine> GetAllProductionLines()
        {
            return _context.ProductionLines.ToList();
        }
    }
}