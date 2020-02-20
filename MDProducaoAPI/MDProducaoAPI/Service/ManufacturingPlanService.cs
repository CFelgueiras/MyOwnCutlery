using MDProducaoAPI.Service.Interfaces;
using MDProducaoAPI.Models;
using MDProducaoAPI.Models.DTO;
using MDProducaoAPI.Repository.Interfaces;
using System.Collections.Generic;
using MDProducaoAPI.Models.MVDTO;
using MDProducaoAPI.Models.ValueObjects;

namespace MDProducaoAPI.Service
{
    public class ManufacturingPlanService : IManufacturingPlanService
    {
        private readonly IManufacturingPlanRepository _repositoryManPlan;
        private readonly IOperationRepository _repositoryOperation;


        public ManufacturingPlanService(IManufacturingPlanRepository manufacturingPlanRepository, IOperationRepository repositoryOperation)
        {
            _repositoryManPlan = manufacturingPlanRepository;
            _repositoryOperation = repositoryOperation;
        }

        public ManufacturingPlan GetManufacturingPlanByID(long id)
        {
            ManufacturingPlan manufacturingPlan = new ManufacturingPlan();
            manufacturingPlan = _repositoryManPlan.GetById(id);
            List<Operation> operationsList = new List<Operation>();
            operationsList = _repositoryOperation.GetOperationsByManPlanId(id);
            manufacturingPlan.OperationsList = operationsList;
            return manufacturingPlan;
        }
        
        public List<ManufacturingPlan> GetAllManufacturingPlan()
        {
            return _repositoryManPlan.GetAllManPlan();
        }

        public ManufacturingPlan CreateManufacturingPlanAsync(ManufacturingPlanDTO manufacturingPlanDTO)
        {
            var mp = new ManufacturingPlan();
            List<ManufacturingPlan> item = new List<ManufacturingPlan>();

            item = _repositoryManPlan.GetByName(manufacturingPlanDTO.Name);

            if (item.Count == 0)
            {
                if (manufacturingPlanDTO.Name == null)
                {
                    return null;
                }
                else
                {
                    mp.Name.name = manufacturingPlanDTO.Name;
                }
                mp.Name.name = manufacturingPlanDTO.Name;
                List<Operation> operationsList = new List<Operation>();
                MVOperation oper = new MVOperation();

                foreach (var ops in manufacturingPlanDTO.Operations)
                {
                    Operation operation = new Operation();
                    long id = ops.OperationId;
                    oper = _repositoryOperation.GetOperationByID(id);
                    if (oper != null)
                    {
                        operation.Name = new Name(oper.Name);
                        operation.ToolName = new ToolName(oper.ToolName);
                        operation.OperationTool = new OperationTool(oper.OperationName);
                        operation.OperationTime = oper.OperationTime;
                        operation.PreparationTime = oper.PreparationTime;
                        operationsList.Add(operation);
                    }
                    else
                        return null;
                }

                mp.OperationsList = operationsList;
                _repositoryManPlan.Create(mp);
                return mp;
            }
            else
            {
                return null;
            }
        }


    }
}