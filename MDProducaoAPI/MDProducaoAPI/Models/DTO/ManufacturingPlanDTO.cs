using System.Collections.Generic;

namespace MDProducaoAPI.Models.DTO
{
    public class ManufacturingPlanDTO
    {
        public long manufacturingPlanId { get; set; }
        public string Name { get; set; }

        public ICollection<OperationDTO> Operations { get; set; }

        public ManufacturingPlanDTO() { }
    }
}