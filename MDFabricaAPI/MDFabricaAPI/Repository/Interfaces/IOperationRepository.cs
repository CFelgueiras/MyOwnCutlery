using System.Collections.Generic;
using System.Linq;
using MDFabricaAPI.Models;
using MDFabricaAPI.Models.ValueObjects;

namespace MDFabricaAPI.Repository.Interfaces
{
    public interface IOperationRepository
    {
        Operation GetById(long id);

        List<Operation> GetByName(string name);

        List<Operation> GetByOperationTool(string operationTool);

        Operation Create(Operation operation);
        List<Operation> GetOperationsByMachineTypeId(long machineTypeId);
        List<Operation> GetAllOperations();
        Operation UpdateOperation(Operation operation);
    }
}