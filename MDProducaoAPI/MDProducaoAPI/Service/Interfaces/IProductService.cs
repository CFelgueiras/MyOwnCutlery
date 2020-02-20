using System.Collections.Generic;
using MDProducaoAPI.Models.DTO;
using MDProducaoAPI.Models;

namespace MDProducaoAPI.Service.Interfaces
{
    public interface IProductService
    {
        Product GetProductByID(long id);
        Product CreateProduct(ProductDTOF productDtof);
        List<Product> GetAllProducts();
        List<List<string>> GetOperationsOfProduct();
    }
}