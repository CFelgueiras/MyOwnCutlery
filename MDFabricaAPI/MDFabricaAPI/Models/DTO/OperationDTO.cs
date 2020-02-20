
namespace MDFabricaAPI.Models.DTO
{
    public class OperationDTO
    {
        public long OperationId { get; set; }
        public string Name { get; set; }
        
        public long MachineTypeId { get; set; }

        public string ToolName { get; set; }

        public int OperationTime { get; set; }

        public double PreparationTime { get; set; }

        public OperationDTO() { }
    }
}