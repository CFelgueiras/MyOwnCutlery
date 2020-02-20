using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using MDFabricaAPI.Service.Interfaces;
using MDFabricaAPI.Models.DTO;
using MDFabricaAPI.MVDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;


namespace Controllers
{
    [Route("api/operation")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IOperationService _service;

        public OperationController(IOperationService service)
        {
            this._service = service;
        }

        //GET api/Operation/{OperationId}
        [HttpGet("{OperationId:long}", Name = "GetOperationById")]
        public ActionResult<MVOperation> GetOperationsById(long operationId)
        {
            var item = _service.GetOperationsById(operationId);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(MVOperation.From(item));
        }
        
        //GET api/Operation/{OperationTool
        [HttpGet("operationtool/{OperationTool}", Name = "GetByOperationTool")]
        public ActionResult<MVOperationTool> GetByOperationTool(string OperationTool)
        {
            var item = _service.GetOperationByOperationTool(OperationTool);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(MVOperationTool.From(item[0]));
        }
        
        //GET api/Operation/{OperationsTools
        [HttpGet("{operationstools}", Name = "GetAllOperationTool")]
        public ActionResult<MVOperationTool> GetAllOperationTool()
        {
            var item = _service.GetAllOperationTool();

            if (item == null)
            {
                return NotFound();
            }

            return Ok(MVOperationTool.FromList(item));
        }

        //GET api/Operation
        [HttpGet(Name = "GetAllOperations")]
        public ActionResult<MVOperation> GetAllOperations()
        {
            var item = _service.GetAllOperations();

            if (item == null)
            {
                return NotFound();
            }

            return Ok(MVOperation.FromList(item));
        }

        //POST: /api/operation/ || BODY: {}
        [HttpPost(Name = "CreateOperation")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<MVOperation> PostOperation(OperationDTOF operationDtof)
        {
            var oper = _service.CreateOperation(operationDtof);

            if (oper == null)
            {
                return BadRequest();
            }
            else
            {
                return Created("", MVOperation.FromFull(oper));
            }
        }

        //PUT: /api/operation/ || BODY: {}
        [HttpPut(Name = "UpdateMachineTypeOperation")]
        public ActionResult<MVOperation> UpdateMachineTypeOperation(OperationDTO operationDto)
        {
            var m = _service.UpdateMachineTypeOperation(operationDto);

            if (m == null)
            {
                return BadRequest();
            }
            else
            {
                return Created("", MVOperation.updateMachineTypeMV(m));
            }
        }

        //GET: /api/operation/listtoolnames/ || BODY: {}
        [HttpGet("listtoolnames/", Name="GetAllToolsNames")]
        public ActionResult<MVOperation> GetAllTools()
        {
            var item = _service.GetAllTools();

            if(item == null)
            {
                return NotFound();
            }
            return Ok(MVOperation.ListToolNames(item));
        }

        //GET: /api/operation/listoperationtools/ || BODY: {}
        [HttpGet("listoperationtools/", Name="GetAllOperationTools")]
        public ActionResult<MVOperation> GetAllOperationTools()
        {
            var item = _service.GetAllTools();

            if(item == null)
            {
                return NotFound();
            }
            return Ok(MVOperation.ListOperationToolNames(item));
        }
    }
}