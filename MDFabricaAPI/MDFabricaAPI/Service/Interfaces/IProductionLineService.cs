using System.Collections.Generic;
using MDFabricaAPI.Models;
using MDFabricaAPI.Models.DTO;

namespace MDFabricaAPI.Service.Interfaces
{
    public interface IProductionLineService
    {
        ProductionLine GetProductionLineById(long id);

        ProductionLine CreateProductionLine(ProductionLineDTO productionLineDTO);

        List<ProductionLine> GetAllProductionLines();
    }
}