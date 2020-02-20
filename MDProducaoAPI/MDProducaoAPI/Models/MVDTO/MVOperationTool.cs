using System.Collections.Generic;
using MDProducaoAPI.Models;

namespace MDProducaoAPI.MVDTO
{
    public class MVOperationTool
    {
        public string operationTool { get; set; }
        public string machineTypeName { get; set; }
        public string toolName{ get; set; }
        public string operationTime { get; set; }
        public string preparationTime{ get; set; }

        public MVOperationTool(string operationTool, string machineTypeName, string toolName, string operationTime, string preparationTime)
        {
            this.operationTool = operationTool;
            this.machineTypeName =  machineTypeName;
            this.toolName = toolName;
            this.operationTime = operationTime;
            this.preparationTime = preparationTime;
        }

        public MVOperationTool(string operationTool) {
            this.operationTool = operationTool;
        }


        public MVOperationTool() { }

        public static MVOperationTool From(Operation op)
        {
            
            return new MVOperationTool(op.OperationTool.operationTool);
        }
        
        public static List<MVOperationTool> FromList(List<Operation> ops)
        {
            List<MVOperationTool> oplist = new List<MVOperationTool>();

            foreach (var op in ops)
            {
                MVOperationTool mvOperationTool = new MVOperationTool();

                mvOperationTool.operationTool = op.OperationTool.operationTool;
                oplist.Add(mvOperationTool);
            }
            return oplist;
        }
    }
}