using System.Collections.Generic;
using MDProducaoAPI.Models;

namespace MDProducaoAPI.Repository.Interfaces
{
    public interface IProductRepository
    {
        Product GetById(long id);
        
        List<Product> GetByName(string name);

        void Create(Product product);
        List<Product> GetAllProducts();
    }
}