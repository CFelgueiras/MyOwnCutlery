using System.Collections.Generic;
using MDProducaoAPI.Models;
using MDProducaoAPI.Models.DTO;
using MDProducaoAPI.Models.MVDTO;

namespace MDProducaoAPI.Service.Interfaces
{
    public interface IManufacturingPlanService
    {
        ManufacturingPlan GetManufacturingPlanByID(long id);

        ManufacturingPlan CreateManufacturingPlanAsync(ManufacturingPlanDTO manufacturingPlanDTO);
        List<ManufacturingPlan> GetAllManufacturingPlan();
    }
}