using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDProducaoAPI.Models;
using MDProducaoAPI.Models.DTO;
using MDProducaoAPI.Models.MVDTO;

namespace MDProducaoAPI.Service.Interfaces
{
    public interface IOperationService
    {
        Operation GetOperationById(long id);

        List<Operation> GetOperationByOperationTool(string operationTool);

        Operation CreateOperation(OperationDTO operationDto);

        Operation GetOperationsById(long operationId);

        MVOperation GetOperationByID(long id);

    }
}