using System.Collections.Generic;
using System.Threading.Tasks;
using MDProducaoAPI.Models;
using MDProducaoAPI.Models.DTO;
using MDProducaoAPI.Models.MVDTO;
using MDProducaoAPI.MVDTO;

namespace MDProducaoAPI.Repository.Interfaces
{
    public interface IOperationRepository
    {
        Operation GetById(long id);

        List<Operation> GetByName(string name);

        List<Operation> GetByOperationTool(string operationTool);

        Operation Create(Operation operation);
        MVOperation GetOperationByID(long id);

        List<Operation> GetOperationsByManPlanId(long manPlanID);
        MVOperationTool GetOperationsFromMDFByOperationTool(string opTool);
    }
}