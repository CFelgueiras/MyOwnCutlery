using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MDFabricaAPI.Models;
using MDFabricaAPI.Repository.Interfaces;

namespace MDFabricaAPI.Repository
{
    public class MachineRepository : Repository<Machine>, IMachineRepository
    {
        private readonly Context _context;

        public MachineRepository(Context dataContext) : base(dataContext)
        {
            _context = dataContext;
        }

        public Machine GetById(long id)
        {
            return _context.Machines
            .Include(mt => mt.MachineType)
            .FirstOrDefault(x => x.MachineId == id);
        }
        
        public new List<Machine> GetAll()
        {
            return _context.Machines
            .Include(mt => mt.MachineType)
            .Include(pl => pl.ProductionLine)
            .ToList();
        }

        public List<Machine> GetByName(string identification)
        {
            return _context.Machines
                .Include(o => o.Identification)
                .Where(n => n.Identification.identification.Equals(identification))
                .ToList();
        }

        public Machine Create(Machine machine)
        {
            _context.Machines.Add(machine);
            _context.SaveChanges();
            return machine;
        }

        public Machine UpdateMachineTypeOfMachine(Machine machine)
        {
            _context.Machines.Update(machine);
            _context.SaveChanges();
            return machine;
        }

        public Machine UpdateMachineState(Machine machine)
        {
            _context.Machines.Update(machine);
            _context.SaveChanges();
            return machine;
        }
    }
}