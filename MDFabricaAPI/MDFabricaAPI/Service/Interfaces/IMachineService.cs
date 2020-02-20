using System.Collections.Generic;
using MDFabricaAPI.Models;
using MDFabricaAPI.Models.DTO;

namespace MDFabricaAPI.Service.Interfaces{
    public interface IMachineService{
        Machine GetMachineById(long id);

        Machine CreateMachine(MachineDTO machineDto);

        Machine CreateMachineFromSgrai(MachineFromSgraiDTO machineFromSgraiDTO); 

        Machine UpdateMachineTypeOfMachine(MachineDTO machineDto);

        Machine ChangeMachineState(MachineDTO machineDto);

        List<Machine> GetAllMachine();

        List<Machine> GetMachinesByProductionLine();
    }
}