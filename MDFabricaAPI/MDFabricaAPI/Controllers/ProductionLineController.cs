using Microsoft.AspNetCore.Mvc;
using MDFabricaAPI.Service.Interfaces;
using MDFabricaAPI.Models;
using MDFabricaAPI.Models.DTO;
using MDFabricaAPI.MVDTO;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionLineController : ControllerBase
    {
        private readonly IProductionLineService _service;

        public ProductionLineController(IProductionLineService service)
        {
            this._service = service;
        }

        //GET api/ProductionLine/{ProductionLineID}
        [HttpGet("{ProductionLineID:ProductionLineID}", Name = "GetProductionLineById")]
        public ActionResult<ProductionLine> GetProductionLineById(long productionLineId)
        {
            ProductionLine item = _service.GetProductionLineById(productionLineId);

            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        //POST: /api/ProductionLine/ || BODY: {}
        [HttpPost(Name = "CreateProductionLine")]
        public ActionResult<MVProductionLine> PostProductionLine(ProductionLineDTO productionLineDto)
        {
            var prodline = _service.CreateProductionLine(productionLineDto);

            if (prodline == null)
            {
                return BadRequest();
            }
            else
            {
                return Created("", MVProductionLine.FromFull(prodline));
            }
        }

        //GET: /api/ProductionLine/listproductionlines/ || BODY: {}
        [HttpGet("listproductionlines/", Name="GetAllProductionLines")]
        public ActionResult<MVProductionLine> GetAllProductionLines()
        {
            var item = _service.GetAllProductionLines();

            if(item == null)
            {
                return NotFound();
            }
            return Ok(MVProductionLine.ListProductionLines(item));
        }
    }
}