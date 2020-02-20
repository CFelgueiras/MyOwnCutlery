using System;
using System.Collections.Generic;
using MDFabricaAPI.Models;

namespace MDFabricaAPI.MVDTO
{
    public class MVOperation
    {
        public long OperationId { get; set; }
        public string Name { get; set; }

        public string ToolName { get; set; }

        public string OperationName { get; set; }

        public int OperationTime { get; set; }
        
        public long MachineTypeId { get; set; }

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

        public MVOperation(long operationId, string name, string toolName, string operationName, int operationTime, double preparationTime, long machineTypeId)
        {
            this.Name = name;
            this.OperationId = operationId;
            this.ToolName = toolName;
            this.OperationName = operationName;
            this.OperationTime = operationTime;
            this.PreparationTime = preparationTime;
            this.MachineTypeId = machineTypeId;
        }

        public static MVOperation FromFull(Operation o)
        {
            return new MVOperation(o.OperationId, o.Name.name, o.ToolName.toolName, o.OperationTool.operationTool, o.OperationTime, o.PreparationTime, o.MachineType.MachineTypeId);
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

        public static MVOperation From(Operation op)
        {
            MVOperation mvOperation = new MVOperation();

            mvOperation.OperationId = op.OperationId;
            mvOperation.Name = op.Name.name;
            mvOperation.ToolName = op.ToolName.toolName;
            mvOperation.OperationName = op.OperationTool.operationTool;
            mvOperation.OperationTime = op.OperationTime;
            mvOperation.PreparationTime = op.PreparationTime;
            return mvOperation;
        }

        public static MVOperation updateMachineTypeMV(Operation operation)
        {
            MVOperation mvOperation = new MVOperation();

            mvOperation.OperationId = operation.OperationId;
            mvOperation.Name = operation.Name.name;
            mvOperation.MachineTypeId = operation.MachineType.MachineTypeId;
            return mvOperation;
        }

        public static string[] ListToolNames(List<Operation> ops)
        {
            string[] opArray = new string[ops.Count];

            List<string> opnames = new List<string>();

            foreach(var op in ops) {
                opnames.Add(op.Name.name);
            }

            opnames.CopyTo(opArray);

            return opArray;
        }

        public static string[] ListOperationToolNames(List<Operation> ops)
        {
            string[] opArray = new string[ops.Count];

            List<string> opToolNames = new List<string>();

            foreach(var op in ops) {
                opToolNames.Add(op.OperationTool.operationTool);
            }

            opToolNames.CopyTo(opArray);

            return opArray;
        }
    }
}