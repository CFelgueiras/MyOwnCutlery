using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using MDProducaoAPI.Service.Interfaces;
using MDProducaoAPI.Models.MVDTO;
using Microsoft.AspNetCore.Http;
using MDProducaoAPI.Models.DTO;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturingPlanController : ControllerBase
    {
        private readonly IManufacturingPlanService _service;

        public ManufacturingPlanController(IManufacturingPlanService service)
        {
            this._service = service;
        }

        //GET api/ManufacturingPlan/{id}
        [HttpGet("{ManufacturingPlanId:ManufacturingPlanId}", Name = "GetManufacturingPlanById")]
        public ActionResult<MVManufacturingPlan> GetManufacturingPlanById(long ManufacturingPlanId)
        {
            var item = _service.GetManufacturingPlanByID(ManufacturingPlanId);

            if (item == null)
            {
                return NotFound();
            }
            return Ok(MVManufacturingPlan.FromFull(item));
        }
        
        //GET api/ManufacturingPlan/
        [HttpGet( Name = "GetAllManufacturingPlan")]
        public ActionResult<MVManufacturingPlan> GetAllManufacturingPlan()
        {
            var item = _service.GetAllManufacturingPlan();

            if (item == null)
            {
                return NotFound();
            }
            return Ok(MVManufacturingPlan.FromList(item));
        }

        //POST: /api/ManufacturingPlan/ || BODY: {}
        [HttpPost(Name = "CreateManufacturingPlan")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<MVManufacturingPlan> PostManufacturingPlanAsync(ManufacturingPlanDTO manufacturingPlanDto)
        {
            var manplan = _service.CreateManufacturingPlanAsync(manufacturingPlanDto);

            if (manplan == null)
            {
                return BadRequest();
            }
            else
            {
                return Created("", MVManufacturingPlan.FromFull(manplan));
            }
        }
    }
}