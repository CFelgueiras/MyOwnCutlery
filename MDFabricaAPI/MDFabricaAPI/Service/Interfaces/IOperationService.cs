using System.Collections.Generic;
using MDFabricaAPI.Models;
using MDFabricaAPI.Models.DTO;

namespace MDFabricaAPI.Service.Interfaces
{
    public interface IOperationService
    {
        Operation GetOperationById(long id);

        List<Operation> GetOperationByOperationTool(string operationTool);

        Operation CreateOperation(OperationDTOF operationDto);

        Operation GetOperationsById(long operationId);

        List<Operation> GetAllOperations();

        Operation UpdateMachineTypeOperation(OperationDTO operationDto);

        List<Operation> GetAllTools();
        List<Operation> GetAllOperationTool();
    }
}