using System.Collections.Generic;
using MDProducaoAPI.Service.Interfaces;
using MDProducaoAPI.Models;
using MDProducaoAPI.Models.ValueObjects;
using MDProducaoAPI.Repository.Interfaces;
using MDProducaoAPI.Models.DTO;
using MDProducaoAPI.Models.MVDTO;
using MDProducaoAPI.MVDTO;
using Microsoft.AspNetCore.Builder;

namespace MDProducaoAPI.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IManufacturingPlanRepository _manPlanRepository;
        private readonly IOperationRepository _operationRepository;

        public ProductService(IProductRepository productRepository, IManufacturingPlanRepository manPlanRepository, IOperationRepository operationRepository)
        {
            _repository = productRepository;
            _manPlanRepository = manPlanRepository;
            _operationRepository = operationRepository;
        }

        public Product GetProductByID(long id)
        {
            Product product = new Product();
            product = _repository.GetById(id);
            product.ManPlan = _manPlanRepository.GetManPlanByProductID(id);
            return product;
        }

        public List<Product> GetAllProducts()
        {
            return _repository.GetAllProducts();
        }

        public List<List<string>> GetOperationsOfProduct()
        {
            var productList = _repository.GetAllProducts();
            ManufacturingPlan mp = new ManufacturingPlan();
            // var operationsFromMDF = _operationRepository.GetAllOperationsFromMDF();
            MVOperationTool oFromMDF = new MVOperationTool();

            var finalList = new List<List<string>>();

            foreach (var p in productList)
            {
                mp = _manPlanRepository.GetManPlanByProductID(p.ProductId);

                List<Operation> oper = new List<Operation>();

                    var o = _operationRepository.GetOperationsByManPlanId(mp.manufacturingPlanId);
                    foreach (var op in o){
                        oper.Add(op);
                    
                }



                var prodOpList = new List<string>();

                prodOpList.Add(p.Name.name);

                foreach (var op in oper)
                {
                    var test = op.OperationTool.operationTool;
                    oFromMDF = new MVOperationTool();
                    oFromMDF = _operationRepository.GetOperationsFromMDFByOperationTool(test);
                    if (oFromMDF != null)
                    {

                        prodOpList.Add(oFromMDF.operationTool);
                    }
                }
                finalList.Add(prodOpList);
            }

            return finalList;
        }

        public Product CreateProduct(ProductDTOF productDTOf)
        {
            var product = new Product();

            var item = _repository.GetByName(productDTOf.Name);

            if (item.Count == 0)
            {
                if (productDTOf.Name.ToString().Equals(null))
                {
                    return null;
                }
                else
                {
                    product.Name = new Name(productDTOf.Name);
                }

                ManufacturingPlan manufacturingPlan = new ManufacturingPlan();
                manufacturingPlan = _manPlanRepository.GetById(productDTOf.ManPlanId);
                product.ManPlan = manufacturingPlan;

                _repository.Create(product);
                return product;
            }
            else
            {
                return null;
            }
        }
    }
}