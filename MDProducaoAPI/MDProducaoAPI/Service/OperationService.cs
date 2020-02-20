using System.Collections.Generic;
using MDProducaoAPI.Service.Interfaces;
using MDProducaoAPI.Models;
using MDProducaoAPI.Models.DTO;
using MDProducaoAPI.Models.ValueObjects;
using MDProducaoAPI.Repository.Interfaces;
using MDProducaoAPI.Repository;
using MDProducaoAPI.Models.MVDTO;

namespace MDProducaoAPI.Service
{
    public class OperationService : IOperationService
    {
        private readonly IOperationRepository _operationRepository;

        public OperationService(IOperationRepository operationOperationRepository)
        {
            _operationRepository = operationOperationRepository;
        }

        public Operation GetOperationById(long id)
        {
            return _operationRepository.GetById(id);
        }

        public List<Operation> GetOperationByOperationTool(string operationTool)
        {
            return _operationRepository.GetByOperationTool(operationTool);
        }

        public Operation CreateOperation(OperationDTO operationDto)
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

        public Operation GetOperationsById(long operationId)
        {
            return _operationRepository.GetById(operationId);
        }

        public MVOperation GetOperationByID(long id)
        {
            OperationRepository repo = new OperationRepository();
            MVOperation operation = new MVOperation();

            operation = _operationRepository.GetOperationByID(id);
            return operation;
        }
    }
}