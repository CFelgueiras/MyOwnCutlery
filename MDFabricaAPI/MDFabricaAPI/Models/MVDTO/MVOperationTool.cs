using System.Collections.Generic;
using MDFabricaAPI.Models;
using MDFabricaAPI.Models.ValueObjects;

namespace MDFabricaAPI.MVDTO
{
    public class MVOperationTool
    {
        public string OperationTool { get; set; }
        
        public string MachineTypeName { get; set; }
        
        public string ToolName { get; set; }
        
        public int OperationTime { get; set; }
        
        public double PreparationTime { get; set; }
        
        public MVOperationTool(string operationTool, string machineType, string toolName, int operationTime,
            double preparationTime)
        {
            this.OperationTool = operationTool;
            this.MachineTypeName = machineType;
            this.ToolName = toolName;
            this.OperationTime = operationTime;
            this.PreparationTime = preparationTime;
        }
        
        public MVOperationTool() { }

        public static MVOperationTool From(Operation op)
        {
            
            return new MVOperationTool(op.OperationTool.operationTool, op.MachineType.Name.name, op.ToolName.toolName, op.OperationTime, op.PreparationTime);
        }
        
        public static List<MVOperationTool> FromList(List<Operation> ops)
        {
            List<MVOperationTool> oplist = new List<MVOperationTool>();

            foreach (var op in ops)
            {
                MVOperationTool mvOperationTool = new MVOperationTool();

                mvOperationTool.OperationTool = op.OperationTool.operationTool;
                mvOperationTool.MachineTypeName = op.MachineType.Name.name;
                mvOperationTool.ToolName = op.ToolName.toolName;
                mvOperationTool.PreparationTime = op.PreparationTime;
                mvOperationTool.OperationTime = op.OperationTime;
                oplist.Add(mvOperationTool);
            }
            return oplist;
        }
    }
}