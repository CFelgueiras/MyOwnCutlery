using System.Collections.Generic;
using MDFabricaAPI.Models;
using MDFabricaAPI.Models.DTO;

namespace MDFabricaAPI.Service.Interfaces
{
    public interface IMachineTypeService
    {
        MachineType GetMachineTypeByMachineId(long id);

        MachineType CreateMachineType(MachineTypeDTO machineTypeDto);
        
        List<Operation> GetOperationsByMachineTypeId(long machineTypeId);

        MachineType UpdateMachineType(MachineTypeDTO machineTypeDto);

        List<MachineType> GetAllMachineTypes();
    }
}