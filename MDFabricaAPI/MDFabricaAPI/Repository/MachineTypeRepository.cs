using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using MDFabricaAPI.Models;
using MDFabricaAPI.Models.ValueObjects;
using MDFabricaAPI.Repository.Interfaces;

namespace MDFabricaAPI.Repository
{
    public class MachineTypeRepository : Repository<MachineType>, IMachineTypeRepository
    {
        private readonly Context _context;

        public MachineTypeRepository(Context dataContext) : base(dataContext)
        {
            _context = dataContext;
        }

        public MachineType GetById(long id)
        {
            return _context.MachineTypes.Find(id);
        }

        public List<MachineType> GetByName(string name)
        {
            return _context.MachineTypes
                .Include(o => o.Name)
                .Where(n => n.Name.name.Equals(name))
                .ToList();
        }
        
        public MachineType Create(MachineType machineType)
        {
            _context.MachineTypes.Add(machineType);
            _context.SaveChanges();
            return machineType;
        }

        public MachineType UpdateOperationsList(MachineType machineType)
        {
            _context.MachineTypes.Update(machineType);
            _context.SaveChanges();
            return machineType;
        }

        public void RemoveOldOperationsOnUpdate(MachineType machineType)
        {
        }

        public List<MachineType> GetAllMachineTypes()
        {
            return _context.MachineTypes.ToList();
        }
    }
}