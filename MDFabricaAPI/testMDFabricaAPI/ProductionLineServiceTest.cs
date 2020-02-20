using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using MDFabricaAPI.Models;
using MDFabricaAPI.Models.DTO;
using MDFabricaAPI.Models.ValueObjects;
using MDFabricaAPI.Service;
using MDFabricaAPI.Service.Interfaces;
using MDFabricaAPI.Repository.Interfaces;


namespace testMDFabricaAPI
{
    public class ProductionLineServiceTest
    {
        private readonly IProductionLineService _service;
        private readonly Mock<IProductionLineRepository> _productionLineRepositoryMock = new Mock<IProductionLineRepository>();

        private readonly Mock<IMachineRepository> _machineRepositoryMock = new Mock<IMachineRepository>();
        public ProductionLineServiceTest()
        {
            _service = new ProductionLineService(_productionLineRepositoryMock.Object, _machineRepositoryMock.Object);
        }

        [Fact]
        public void GetProductionLineById_IfIdNotExists_ReturnNull()
        {
            // Arrange
            long nonExistingId = 99999L;

            _productionLineRepositoryMock.Setup(iProductionLineRepository => iProductionLineRepository.GetById(nonExistingId)).Returns<ProductionLine>(null);

            // Act
            var retrievedProductionLine = _service.GetProductionLineById(nonExistingId);

            // Assert
            Assert.Null(retrievedProductionLine);
        }

        [Fact]
        public void GetProductionLineById_IfExists_ReturnObjectOfTypeProductionLine()
        {
            // Arrange
            long existingId = 1L;

            _productionLineRepositoryMock.Setup(iProductionLineRepository => iProductionLineRepository.GetById(existingId)).Returns(new ProductionLine());

            // Act
            var retrievedProductionLine = _service.GetProductionLineById(existingId);

            // Assert
            Assert.IsType<ProductionLine>(retrievedProductionLine);
        }

        [Fact]
        public void GetProductionLineById_IfExists_ReturnsProductionLine()
        {

            Name name = new Name("PL");
            Name name1 = new Name("MT");
            Identification identification = new Identification("M1");;

            MachineType dumyMachineType = new MachineType()
            {

                Name = name1,
            };
            Machine dummyMachine = new Machine()
            {
                Identification = identification,
                MachineType = dumyMachineType,
            };

            ProductionLine dummyProductionLine = new ProductionLine()
            {

                Name = name,

            };


            // Arrange
            long existingId = 1L;

            _productionLineRepositoryMock.Setup(iProductionLineRepository => iProductionLineRepository.GetById(existingId)).Returns(dummyProductionLine);

            // Act
            var retrievedProductionLine = _service.GetProductionLineById(existingId);

            // Assert
            Assert.Equal("PL", retrievedProductionLine.Name.name);
        }
        /* 
                [Fact]
                public void PostOperation_CreateNewOperation()
                {

                    // Arrange 

                    OperationDTO dummyOperation1 = new OperationDTO()
                    {
                        Name = "n1",
                        ToolName = "tool1",
                        OperationTime = 1,
                    };

                    _operationRepositoryMock.Setup(iOperationRepository => iOperationRepository.Create(It.IsAny<Operation>())).Returns(new Operation());

                    // Act
                    var retrievedOperation = _service.CreateOperation(dummyOperation1);

                    // Assert
                     Assert.IsType<OperationDTO>(retrievedOperation);
                }



        [Fact]
        public void CreateOperation_IfBodyIsEmpty_ReturnNull()
        {
            // Arrange
            var newOperationDto = new OperationDTO() { };

            _operationRepositoryMock.Setup(iOperationRepository => iOperationRepository.Create(It.IsAny<Operation>())).Returns(new Operation());

            // Act
            var returnedObject = _service.CreateOperation(newOperationDto);

            // Assert
            Assert.Null(returnedObject);*/
        }
    }