using System.Collections.Generic;
using MDFabricaAPI.Models;
using MDFabricaAPI.Models.ValueObjects;

namespace MDFabricaAPI.Repository.Interfaces
{
    public interface IProductionLineRepository
    {
        ProductionLine GetById(long id);

        List<ProductionLine> GetByName(string name);

        ProductionLine Create(ProductionLine productionLine);

        List<ProductionLine> GetAllProductionLines();
    }
}