using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using MDProducaoAPI.Models;
using MDProducaoAPI.Models.DTO;
using MDProducaoAPI.Models.ValueObjects;
using MDProducaoAPI.Service;
using MDProducaoAPI.Service.Interfaces;
using MDProducaoAPI.Repository.Interfaces;


namespace testMDProducaoAPI
{
    public class ProductServiceTest
    {
        private readonly IProductService _service;
        private readonly Mock<IProductRepository> _productRepositoryMock = new Mock<IProductRepository>();
        private readonly Mock<IManufacturingPlanRepository> _manPlanRepositoryMock = new Mock<IManufacturingPlanRepository>();
        public ProductServiceTest()
        {
            _service = new ProductService(_productRepositoryMock.Object, _manPlanRepositoryMock.Object);
        }

        [Fact]
        public void GetProduceById_IfIdNotExists_ReturnNull()
        {
            // Arrange
            long nonExistingId = 99999L;

            _productRepositoryMock.Setup(iProductRepository => iProductRepository.GetById(nonExistingId)).Returns<Product>(null);

            // Act
            var retrievedProduct = _service.GetProductByID(nonExistingId);

            // Assert
            Assert.Null(retrievedProduct);
        }

        [Fact]
        public void GetProductById_IfExists_ReturnObjectOfTypeProduct()
        {
            // Arrange
            long existingId = 1L;

            _productRepositoryMock.Setup(iProductRepository => iProductRepository.GetById(existingId)).Returns(new Product());

            // Act
            var retrievedProduct = _service.GetProductByID(existingId);

            // Assert
            Assert.IsType<Product>(retrievedProduct);
        }


        [Fact]
        public void GetMachineById_IfExists_ReturnsMachine()
        {

            Name name = new Name("abc");

            Product prod = new Product(){

                Name = name
            };
            
            // Arrange
            long existingId = 1L;

            _productRepositoryMock.Setup(iProductRepository => iProductRepository.GetById(existingId)).Returns(prod);

            // Act
            var retrievedProduct = _service.GetProductByID(existingId);

            // Assert
            Assert.Equal("abc", retrievedProduct.Name.name);
        }
    }
}