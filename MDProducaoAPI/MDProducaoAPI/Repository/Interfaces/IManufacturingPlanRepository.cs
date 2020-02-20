using System.Collections.Generic;
using MDProducaoAPI.Models;

namespace MDProducaoAPI.Repository.Interfaces
{
    public interface IManufacturingPlanRepository
    {
        ManufacturingPlan GetById(long id);
        List<ManufacturingPlan> GetByName(string name);
        ManufacturingPlan Create(ManufacturingPlan manufacturingPlan);
        ManufacturingPlan GetManPlanByProductID(long productID);
        List<ManufacturingPlan> GetAllManPlan();
    }
}