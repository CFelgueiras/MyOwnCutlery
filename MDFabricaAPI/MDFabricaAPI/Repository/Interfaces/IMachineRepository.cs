using System.Collections.Generic;
using MDFabricaAPI.Models;
using MDFabricaAPI.Models.ValueObjects;

namespace MDFabricaAPI.Repository.Interfaces
{
    public interface IMachineRepository
    {
        Machine GetById(long id);
        List<Machine> GetByName(string name);
        Machine Create(Machine machine);
        Machine UpdateMachineTypeOfMachine(Machine machine);
        Machine UpdateMachineState(Machine machine);
        List<Machine> GetAll();
    }
}