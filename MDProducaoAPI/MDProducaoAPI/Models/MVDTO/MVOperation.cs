using System.Collections.Generic;

namespace MDProducaoAPI.Models.MVDTO
{
    public class MVOperation
    {
        public long OperationId { get; set; }
        public string Name { get; set; }
        public string ToolName { get; set; }
        public string OperationName { get; set; }
        public int OperationTime { get; set; }
        public double PreparationTime { get; set; }

        public MVOperation() { }

        public MVOperation(List<Operation> operations)
        {
            operations = new List<Operation>();
        }

        public MVOperation(Operation operations)
        {
            operations = new Operation();
        }

        public MVOperation(long operationId, string name, string toolName, string operationName, int operationTime, double preparationTime)
        {
            this.OperationId = operationId;
            this.Name = name;
            this.ToolName = toolName;
            this.OperationName = operationName;
            this.OperationTime = operationTime;
            this.PreparationTime = preparationTime;
        }

        public static MVOperation FromFull(Operation o)
        {
            return new MVOperation(o.OperationId, o.Name.name, o.ToolName.toolName, o.OperationTool.operationTool, o.OperationTime, o.PreparationTime);
        }

        public static List<MVOperation> FromList(List<Operation> ops)
        {
            List<MVOperation> oplist = new List<MVOperation>();

            foreach (var op in ops)
            {
                MVOperation mvOperation = new MVOperation();
                mvOperation.OperationId = op.OperationId;
                mvOperation.Name = op.Name.name;
                mvOperation.ToolName = op.ToolName.toolName;
                mvOperation.OperationName = op.OperationTool.operationTool;
                mvOperation.OperationTime = op.OperationTime;
                mvOperation.PreparationTime = op.PreparationTime;
                oplist.Add(mvOperation);
            }
            return oplist;
        }
    }
}