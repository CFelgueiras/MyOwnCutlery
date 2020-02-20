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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            this._service = service;
        }

        //GET api/Product/{ProductId}
        [HttpGet("{ProductId:int}", Name = "GetProductById")]
        public ActionResult<MVProduct> GetProductById(long ProductId)
        {
            var item = _service.GetProductByID(ProductId);

            if (item == null)
            {
                return NotFound();
            }
            return Ok(MVProduct.From(item));
        }
        
        //GET api/Products
        [HttpGet("prolog/", Name = "GetAllProductsProlog")]
        public ActionResult<MVProduct> GetAllProductsProlog()
        {
            var item = _service.GetAllProducts();

            if (item == null)
            {
                return NotFound();
            }
            return Ok(MVProduct.ListProducts(item));
        }
        
        //GET api/Products
        [HttpGet(Name = "GetAllProducts")]
        public ActionResult<MVProduct> GetAllProducts()
        {
            var item = _service.GetAllProducts();

            if (item == null)
            {
                return NotFound();
            }
            return Ok(MVProduct.FromList(item));
        }
        
        //GET api/product/
        [HttpGet("{operationsofproduct}", Name = "GetOperationsOfProduct")]
        public ActionResult<MVProduct> GetOperationsOfProduct()
        {
            var item = _service.GetOperationsOfProduct();

            if (item == null)
            {
                return NotFound();
            }
            return Ok(MVOperationsOfProduct.FromList(item));
        }

        //POST: /api/product/ || BODY: {}
        [HttpPost(Name = "CreateProduct")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<MVProduct> PostProduct(ProductDTOF productDtof)
        {
            var oper = _service.CreateProduct(productDtof);

            if (oper == null)
            {
                return BadRequest();
            }
            else
            {
                return Created("", MVProduct.From(oper));
            }
        }
    }
}
