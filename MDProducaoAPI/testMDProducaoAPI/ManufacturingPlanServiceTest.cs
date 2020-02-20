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
    public class ManufacturingPlanServiceTest
    {
        private readonly IManufacturingPlanService _service;
        private readonly Mock<IManufacturingPlanRepository> _manufacturingPlanRepositoryMock = new Mock<IManufacturingPlanRepository>();

        private readonly Mock<IOperationRepository> _operationRepositoryMock = new Mock<IOperationRepository>();
        public ManufacturingPlanServiceTest()
        {
            _service = new ManufacturingPlanService(_manufacturingPlanRepositoryMock.Object, _operationRepositoryMock.Object);
        }

        [Fact]
        public void GetManufacturingPlanById_IfIdNotExists_ReturnNull()
        {
            // Arrange
            long nonExistingId = 99999L;

            _manufacturingPlanRepositoryMock.Setup(iManufacturingPlanRepository => iManufacturingPlanRepository.GetById(nonExistingId)).Returns<ManufacturingPlan>(null);

            // Act
            var retrieved = _service.GetManufacturingPlanByID(nonExistingId);

            // Assert
            Assert.Null(retrieved);
        }

        [Fact]
        public void GetManufacturingPlanById_IfExists_ReturnObjectOfTypeManufacturingPlan()
        {
            // Arrange
            long existingId = 1L;

            _manufacturingPlanRepositoryMock.Setup(iManufacturingPlanRepository => iManufacturingPlanRepository.GetById(existingId)).Returns(new ManufacturingPlan());

            // Act
            var retrievedManufacturingPlan = _service.GetManufacturingPlanByID(existingId);

            // Assert
            Assert.IsType<ManufacturingPlan>(retrievedManufacturingPlan);
        }


        [Fact]
        public void GetManufacturingPlanById_IfExists_ReturnsManufacturingPlan()
        {

            Name name = new Name("abc");

            ManufacturingPlan mp = new ManufacturingPlan(){

                Name = name
            };
            
            // Arrange
            long existingId = 1L;

            _manufacturingPlanRepositoryMock.Setup(iManufacturingPlanRepository => iManufacturingPlanRepository.GetById(existingId)).Returns(mp);

            // Act
            var retrievedManufacturingPlan = _service.GetManufacturingPlanByID(existingId);

            // Assert
            Assert.Equal("abc", retrievedManufacturingPlan.Name.name);
        }
    }
}