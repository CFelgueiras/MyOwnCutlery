using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MDFabricaAPI.Models;
using MDFabricaAPI.Repository.Interfaces;

namespace MDFabricaAPI.Repository
{
    public class OperationRepository : Repository<Operation>, IOperationRepository
    {
        private readonly Context _context;

        public List<Operation> GetAllOperations()
        {
            return _context.Operations
                .Include(mt => mt.MachineType)
                .ToList();
        }

        public Operation UpdateOperation(Operation operation)
        {
            _context.Operations.Update(operation);
            _context.SaveChanges();
            return operation;
        }

        public OperationRepository(Context dataContext) : base(dataContext)
        {
            _context = dataContext;
        }

        public Operation GetById(long id)
        {
            return _context.Operations.Find(id);
        }

        public List<Operation> GetByName(string name)
        {
            return _context.Operations
                .Include(o => o.Name)
                .Where(n => n.Name.name.Equals(name))
                .ToList();
        }

        public List<Operation> GetByOperationTool(string operationTool)
        {
            return _context.Operations
                .Include(o => o.OperationTool)
                .Where(x => x.OperationTool.operationTool.Equals(operationTool))
                .Include(mt => mt.MachineType)
                .ToList();
        }



        public Operation Create(Operation operation)
        {
            _context.Operations.Add(operation);
            _context.SaveChanges();
            return operation;
        }

        public List<Operation> GetOperationsByMachineTypeId(long machineTypeId)
        {
            return _context.Operations
                .Include(o => o.MachineType)
                .Where(mt => mt.MachineType.MachineTypeId == machineTypeId)
                .ToList();
        }
    }
}