using MDFabricaAPI.Service.Interfaces;
using MDFabricaAPI.Models;
using MDFabricaAPI.Models.DTO;
using MDFabricaAPI.Repository.Interfaces;
using System.Collections.Generic;
using MDFabricaAPI.Models.ValueObjects;

namespace MDFabricaAPI.Service
{
    public class MachineTypeService : IMachineTypeService
    {
        private readonly IMachineTypeRepository _repository;
        private readonly IOperationRepository _repositoryOperation;
        private readonly IMachineRepository _machineRepository;

        public MachineTypeService(IMachineTypeRepository machineTypeRepository, IOperationRepository repositoryOperation, IMachineRepository machineRepository)
        {
            _repository = machineTypeRepository;
            _repositoryOperation = repositoryOperation;
            _machineRepository = machineRepository;
        }

        public MachineType GetMachineTypeByMachineId(long id)
        {
            var machine = _machineRepository.GetById(id);
            return machine.MachineType;
        }
        


        public MachineType CreateMachineType(MachineTypeDTO machineTypeDto)
        {
            var mactype = new MachineType();
            List<MachineType> item = new List<MachineType>();

            item = _repository.GetByName(machineTypeDto.Name);

            if( item == null){
                return null;
            }

            if (item.Count == 0)
            {
                if (machineTypeDto.Name == null)
                {
                    return null;
                }
                else
                {
                    mactype.Name = new Name(machineTypeDto.Name);
                }
                ICollection<Operation> operationsList = new List<Operation>();

                foreach (var ops in machineTypeDto.Operations)
                {
                    Operation oper = new Operation();
                    oper = _repositoryOperation.GetById(ops.OperationId);
                    if (oper != null)
                    {
                        operationsList.Add(oper);
                    }
                    else
                        return null;
                }
                
                mactype.OperationsList = operationsList;

                _repository.Create(mactype);
                return mactype;
            }
            else
            {
                return null;
            }
        }
        
        public List<Operation> GetOperationsByMachineTypeId(long machineTypeId)
        {
            return _repositoryOperation.GetOperationsByMachineTypeId(machineTypeId);
        }

        public Operation GetOperationsById(long operationId)
        {
            return _repositoryOperation.GetById(operationId);
        }

        public MachineType UpdateMachineType(MachineTypeDTO machineTypeDto)
        {
            var item = _repository.GetByName(machineTypeDto.Name);

            if (item.Count == 1)
            {
                ICollection<Operation> operationsList = new List<Operation>();

                foreach (var ops in machineTypeDto.Operations)
                {
                    Operation oper = new Operation();
                    oper = _repositoryOperation.GetById(ops.OperationId);
                    if (oper != null)
                    {
                        operationsList.Add(oper);
                    }
                    else
                        return null;
                }

                _repository.UpdateOperationsList(item[0]);
                return item[0];
            }
            else
            {
                return null;
            }
        }

        public List<MachineType> GetAllMachineTypes()
        {
            return _repository.GetAllMachineTypes();
        }
    }
}