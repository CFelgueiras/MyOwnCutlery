using System.Collections.Generic;

namespace MDFabricaAPI.Models.DTO
{
    public class MachineTypeDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<OperationDTO> Operations { get; set; }

        public MachineTypeDTO() { }
    }
}