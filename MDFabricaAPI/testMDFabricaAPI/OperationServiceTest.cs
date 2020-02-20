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
    public class OperationServiceTest
    {
        private readonly IOperationService _service;
        private readonly Mock<IOperationRepository> _operationRepositoryMock = new Mock<IOperationRepository>();
        public OperationServiceTest()
        {
            _service = new OperationService(_operationRepositoryMock.Object);
        }

        [Fact]
        public void GetOperationById_IfIdNotExists_ReturnNull()
        {
            // Arrange
            long nonExistingId = 99999L;

            _operationRepositoryMock.Setup(iOperationRepository => iOperationRepository.GetById(nonExistingId)).Returns<Operation>(null);

            // Act
            var retrievedOperation = _service.GetOperationById(nonExistingId);

            // Assert
            Assert.Null(retrievedOperation);
        }

        [Fact]
        public void GetOperationById_IfExists_ReturnObjectOfTypeOperation()
        {
            // Arrange
            long existingId = 1L;

            _operationRepositoryMock.Setup(iOperationRepository => iOperationRepository.GetById(existingId)).Returns(new Operation());

            // Act
            var retrievedOperation = _service.GetOperationById(existingId);

            // Assert
            Assert.IsType<Operation>(retrievedOperation);
        }

        [Fact]
        public void GetOperationById_IfExists_ReturnsOperation()
        {

            Name name1 = new Name("OP1");
            Name name2 = new Name("M1");

            ToolName tool1 = new ToolName("T1");
            OperationTool operationTool1 = new OperationTool("x1");

            MachineType dumyMachineType = new MachineType()
            {
                Name = name2,
            };

            Operation dummyOperation = new Operation()
            {
                Name = name1,
                ToolName = tool1,
                OperationTool = operationTool1,
                MachineType = dumyMachineType,

            };

            // Arrange
            long existingId = 1L;

            _operationRepositoryMock.Setup(iOperationRepository => iOperationRepository.GetById(existingId)).Returns(dummyOperation);

            // Act
            var retrievedOperation = _service.GetOperationById(existingId);

            // Assert
            Assert.Equal("OP1", retrievedOperation.Name.name);
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
        }*/

        [Fact]
        public void CreateOperation_IfBodyIsEmpty_ReturnNull()
        {
            // Arrange
            var newOperationDto = new OperationDTO() { };

            _operationRepositoryMock.Setup(iOperationRepository => iOperationRepository.Create(It.IsAny<Operation>())).Returns(new Operation());

            // Act
            var returnedObject = _service.CreateOperation(newOperationDto);

            // Assert
            Assert.Null(returnedObject);
        }  
    }
}