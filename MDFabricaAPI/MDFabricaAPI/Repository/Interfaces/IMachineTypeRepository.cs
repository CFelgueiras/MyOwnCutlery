using System.Collections.Generic;
using MDFabricaAPI.Models;
using MDFabricaAPI.Models.ValueObjects;

namespace MDFabricaAPI.Repository.Interfaces
{
    public interface IMachineTypeRepository
    {
        MachineType GetById(long id);

        List<MachineType> GetByName(string name);
    
        MachineType Create(MachineType machine);

        MachineType UpdateOperationsList(MachineType machineType);

        void RemoveOldOperationsOnUpdate(MachineType machineType);

        List<MachineType> GetAllMachineTypes();
    }
}