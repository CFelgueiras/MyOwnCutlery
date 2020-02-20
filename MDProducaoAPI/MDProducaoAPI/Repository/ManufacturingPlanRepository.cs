using Microsoft.EntityFrameworkCore;
using System.Linq;
using MDProducaoAPI.Models;
using System.Collections.Generic;
using MDProducaoAPI.Repository.Interfaces;
using MDProducaoAPI.Models.MVDTO;

namespace MDProducaoAPI.Repository
{
    public class ManufacturingPlanRepository : Repository<ManufacturingPlan>, IManufacturingPlanRepository
    {
        private readonly Context _context;

        public ManufacturingPlanRepository(Context dataContext) : base(dataContext)
        {
            _context = dataContext;
        }
        public ManufacturingPlan GetById(long id)
        {
            return _context.ManufacturingPlans.Find(id);
        }

        public List<ManufacturingPlan> GetByName(string name)
        {
            return _context.ManufacturingPlans
                .Include(mp => mp.Name)
                .Where(n => n.Name.name.Equals(name))
                .ToList();
        }

        public ManufacturingPlan Create(ManufacturingPlan manufacturingPlan)
        {
            _context.ManufacturingPlans.Add(manufacturingPlan);
            _context.SaveChanges();
            return manufacturingPlan;
        }

        public ManufacturingPlan GetManPlanByProductID(long productID)
        {
            return _context.ManufacturingPlans
                .Include(m => m.Product)
                .FirstOrDefault(mp => mp.Product.ProductId == productID);
        }

        public List<ManufacturingPlan> GetAllManPlan()
        {
            return _context.ManufacturingPlans
                .ToList();
        }
    }
}
