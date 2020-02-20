using System.Collections.Generic;

namespace MDFabricaAPI.Models.DTO
{
    public class ProductionLineDTO
    {
        public string Name { get; set; }
        public ICollection<long> MachineIds { get; set; }

        public ProductionLineDTO() { }
    }
}