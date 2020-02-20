using System.ComponentModel.DataAnnotations;
using MDFabricaAPI.Models.ValueObjects;

namespace MDFabricaAPI.Models
{
    public class Operation : Entity
    {
        [Key]
        public long OperationId { get; private set; }

        [Required(ErrorMessage = "Name of Operation is required")]
        public Name Name { get; set; }

        public ToolName ToolName { get; set; }

        public OperationTool OperationTool { get; set; }

        public MachineType MachineType { get; set; }

        public int OperationTime { get; set; }
        
        public double PreparationTime { get; set; }

        public Operation() { }

        public Operation(Name name, ToolName toolName, OperationTool operationTool, int operationTime, double preparationTime)
        {
            this.OperationId = new OperationId().Id;
            this.Name = name;
            this.ToolName = toolName;
            this.OperationTool = operationTool;
            this.OperationTime = operationTime;
            this.PreparationTime = preparationTime;
        }
    }
}