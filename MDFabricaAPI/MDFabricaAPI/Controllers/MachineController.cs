using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MDFabricaAPI.Service.Interfaces;
using MDFabricaAPI.Models;
using MDFabricaAPI.Models.DTO;
using MDFabricaAPI.Models.ValueObjects;
using MDFabricaAPI.MVDTO;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        private readonly IMachineService _service;

        public MachineController(IMachineService service)
        {
            this._service = service;
        }

        //GET api/Machine
        [HttpGet(Name = "GetAllMachine")]
        public ActionResult<Machine> GetAllMachine()
        {
            var item = _service.GetAllMachine();

            if (item == null)
            {
                return NotFound(); //404
            }
            return Ok(MVMachine.FromList(item));
        }

        //GET api/Machine/{MachineId}
        [HttpGet("{MachineId:MachineId}", Name = "GetMachineById")]
        public ActionResult<Machine> GetMachineById(long MachineId)
        {
            var item = _service.GetMachineById(MachineId);

            if (item == null)
            {
                return NotFound();
            }
            return Ok(MVMachine.From(item));
        }

        //GET api/Machine/MachinesByProductionLine/
        [HttpGet("MachinesByProductionLine/", Name = "GetMachinesByProductionLine")]
        public ActionResult<MVMachinesProdLine> GetMachinesByProductionLine()
        {
            var item = _service.GetMachinesByProductionLine();

            if (item == null)
            {
                return NotFound();
            }
            return Ok(MVMachinesProdLine.FromList(item));
        }

        //POST: /api/machine/ || BODY: {}
        [HttpPost(Name = "CreateMachine")]
        public ActionResult<MVMachine> PostMachine(MachineDTO machineDto)
        {
            var m = _service.CreateMachine(machineDto);

            if (m == null)
            {
                return BadRequest();
            }
            else
            {
                return Created("", MVMachine.From(m));
            }
        }

         //POST: /api/machine/ || BODY: {}
        [HttpPost("MachineFromSgrai/",Name = "CreateMachineFromSgrai")]
        public ActionResult<MVMachine> PostMachineFromSgrai(MachineFromSgraiDTO machineFromSgraiDTO)
        {
            var m = _service.CreateMachineFromSgrai(machineFromSgraiDTO);

            if (m == null)
            {
                return BadRequest();
            }
            else
            {
                return Created("", MVMachineFromSgrai.From(m));
            }
        }

        //PUT: /api/machine/ || BODY: {}
        [HttpPut(Name = "UpdateMachineTypeOfMachine")]
        public ActionResult<MVMachine> UpdateMachineTypeOfMachine(MachineDTO machineDto)
        {
            var m = _service.UpdateMachineTypeOfMachine(machineDto);

            if (m == null)
            {
                return BadRequest();
            }
            else
            {
                return Created("", MVMachine.From(m));
            }
        }

        //PUT: /api/machinestate/ || BODY: {}
        [HttpPut("{machinestate}", Name = "ChangeMachineState")]
        public ActionResult<MVMachine> ChangeMachineState(MachineDTO machineDto)
        {
            var m = _service.ChangeMachineState(machineDto);

            if (m == null)
            {
                return BadRequest();
            }
            else
            {
                return Created("", MVMachine.UpdateSate(m));
            }
        }
    }
}