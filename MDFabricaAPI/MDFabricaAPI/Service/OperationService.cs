using System.Collections.Generic;
using System.Linq;
using MDFabricaAPI.Service.Interfaces;
using MDFabricaAPI.Models;
using MDFabricaAPI.Models.DTO;
using MDFabricaAPI.Models.ValueObjects;
using MDFabricaAPI.Repository.Interfaces;

namespace MDFabricaAPI.Service
{
    public class OperationService : IOperationService
    {
        private readonly IOperationRepository _operationRepository;
        private readonly IMachineTypeRepository _machineTypeRepository;

        public OperationService(IOperationRepository operationOperationRepository, IMachineTypeRepository machineTypeRepository)
        {
            _operationRepository = operationOperationRepository;
            _machineTypeRepository = machineTypeRepository;
        }

        public Operation GetOperationById(long id)
        {
            return _operationRepository.GetById(id);
        }

        public List<Operation> GetOperationByOperationTool(string operationTool)
        {
            
            return _operationRepository.GetByOperationTool(operationTool);
        }

        public Operation CreateOperation(OperationDTOF operationDto)
        {
            var op = new Operation();

            OperationTool opt = new OperationTool(operationDto.Name + operationDto.ToolName);

            if (opt.operationTool == null)
            {
                return null;
            }

            if (GetOperationByOperationTool(opt.operationTool).Count == 0)
            {
                if (operationDto.Name == null ||
                    operationDto.ToolName == null)
                {
                    return null;
                }
                else
                {
                    op.Name = new Name(operationDto.Name);
                    op.ToolName = new ToolName(operationDto.ToolName);
                    op.OperationTool = opt;
                    op.OperationTime = operationDto.OperationTime;
                    op.PreparationTime = operationDto.PreparationTime;
                }

                _operationRepository.Create(op);
                return op;
            }
            else
            {
                return
                    null; //BadRequestResult("Operation/Tool operation already exists!");  // necessário retornar operação / ferramenta já existe;
            }
        }

        public List<Operation> GetOperationsByMachineTypeId(long machineTypeId)
        {
            return _operationRepository.GetOperationsByMachineTypeId(machineTypeId);
        }

        public Operation GetOperationsById(long operationId)
        {
            return _operationRepository.GetById(operationId);
        }

        public List<Operation> GetAllOperations()
        {
            return _operationRepository.GetAllOperations();
        }

        public Operation UpdateMachineTypeOperation(OperationDTO operationDTO)
        {
            var operation = _operationRepository.GetById(operationDTO.OperationId);
            var machineType = _machineTypeRepository.GetById(operationDTO.MachineTypeId);

            if (operation == null || machineType == null)
            {
                return null;
            }
            else
            {
                operation.MachineType = machineType;
                _operationRepository.UpdateOperation(operation);
                return operation;
            }
        }

        public List<Operation> GetAllTools()
        {
            return _operationRepository.GetAllOperations();
        }
        

        public List<Operation> GetAllOperationTool()
        {
            return _operationRepository.GetAllOperations();
        }

        /* public bool DeleteOperation(OperationDTO operationDTO)
         {
 
             var item = _repository.GetById(operationDTO.OperationId);
 
             if (item == null)
             {
                 return false;
             }
             else
             {
                 _repository.Delete(item); 
                 return true;
             }
         } */
    }
}