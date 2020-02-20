using Microsoft.AspNetCore.Mvc;
using MDFabricaAPI.Service.Interfaces;
using MDFabricaAPI.Models;
using MDFabricaAPI.Models.DTO;
using MDFabricaAPI.MVDTO;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineTypeController : ControllerBase
    {
        private readonly IMachineTypeService _service;

        public MachineTypeController(IMachineTypeService service)
        {
            this._service = service;
        }

        //GET api/MachineType/{MachineId}
        [HttpGet("{MachineId:MachineId}", Name = "GetMachineTypeByMachineId")]
        public ActionResult<MVMachineType> GetMachineTypeByMachineId(long machineId)
        {
            MachineType item = _service.GetMachineTypeByMachineId(machineId);

            if (item == null)
            {
                return NotFound();
            }
            return Ok(MVMachineType.From(item));
        }

        //GET api/MachineType/{MachineTypeId}
        [HttpGet("machinetypeid/{machineTypeId}", Name = "GetMachineTypeById")]
        public ActionResult<MVMachineType> GetOperationsByMachineTypeId(int machineTypeId)
        {
            var item = _service.GetOperationsByMachineTypeId(machineTypeId);

            if (item == null)
            {
                return NotFound();
            }
            return Ok(MVOperation.FromList(item));
        }

        //POST: /api/MachineType/ || BODY: {}
        [HttpPost(Name = "CreateMachineType")]
        public ActionResult<MVMachineType> PostMachine(MachineTypeDTO machineTypeDto)
        {
            var m = _service.CreateMachineType(machineTypeDto);

            if (m == null)
            {
                return BadRequest();
            }
            else
            {
                return Created("", MVMachineType.FromFull(m));
            }
        }

        //GET: /api/MachineType/ || BODY: {}
        [HttpGet(Name="GetAllMachineTypes")]
        public ActionResult<MVMachineType> GetAllMachineTypes()
        {
            var item = _service.GetAllMachineTypes();

            if(item == null)
            {
                return NotFound();
            }
            return Ok(MVMachineType.FromListToArray(item));
        }
    }
}