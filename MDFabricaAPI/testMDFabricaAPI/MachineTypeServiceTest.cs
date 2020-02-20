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
using System.Threading.Tasks;
using Controllers;

namespace testMDFabricaAPI
{
    public class MachineTypeServiceTest
    {
        private readonly IMachineTypeService _service;
        private readonly Mock<IMachineTypeRepository> _machineTypeRepositoryMock = new Mock<IMachineTypeRepository>();

        private readonly Mock<IOperationRepository> _operationRepositoryMock = new Mock<IOperationRepository>();

        private readonly Mock<IMachineRepository> _machineRepositoryMock = new Mock<IMachineRepository>();

        private readonly Mock<IMachineTypeService> _machineTypeServiceMock; //cenas
        public MachineTypeServiceTest()
        {
            _service = new MachineTypeService(_machineTypeRepositoryMock.Object, _operationRepositoryMock.Object, _machineRepositoryMock.Object);

            _machineTypeServiceMock = new Mock<IMachineTypeService>(); //cenas
        }


        private MachineTypeDTO createMachineTypeDTO()
        {

             OperationDTO dummyOperation = new OperationDTO()
            {
                Name = "name",
                ToolName = "tool1",
                OperationTime = 2,

            };

            ICollection<OperationDTO> listOperationDTO = new List<OperationDTO>();
            //listOperationDTO.Add(dummyOperation);


            MachineTypeDTO dummyMachineTypeDTO = new MachineTypeDTO()
            {
                Name = "corte",
                Operations = listOperationDTO,
            };


            return dummyMachineTypeDTO;
        }


        private MachineType createMachineType()
        {

             Name name1 = new Name("corte");

            MachineType dummyMachineType2 = new MachineType()
            {
                Name = name1,
            };


            return dummyMachineType2;
        }
/* 
        [Fact]
        public void GetMachineTypeById_IfIdNotExists_ReturnNull()
        {
            // Arrange
            long nonExistingId = 99999L;

            _machineTypeRepositoryMock.Setup(iMachineTypeRepository => iMachineTypeRepository.GetById(nonExistingId)).Returns<MachineType>(null);

            // Act
            var retrievedMachineType = _service.GetMachineTypeByMachineId(nonExistingId);

            // Assert
            Assert.Null(retrievedMachineType);
        }

        [Fact]
        public void GetMachineTypeById_IfExists_ReturnObjectOfTypeMachineType()

        {
            // Arrange
            long existingId = 1L;

            _machineTypeRepositoryMock.Setup(iMachineTypeRepository => iMachineTypeRepository.GetById(existingId)).Returns(new MachineType());

            // Act
            var retrievedMachineType = _service.GetMachineTypeByMachineId(existingId);

            // Assert
            Assert.IsType<MachineType>(retrievedMachineType);
        }

        [Fact]
        public void GetMachineTypeById_IfExists_ReturnsMachineType()
        {

            Name name1 = new Name("corte");

            MachineType dummyMachineType = new MachineType()
            {
                Name = name1,
            };

            // Arrange
            long id = 1L;

            _machineTypeRepositoryMock.Setup(iMachineTypeRepository => iMachineTypeRepository.GetById(id)).Returns(dummyMachineType);

            // Act
            var retrievedMachineType = _service.GetMachineTypeByMachineId(id);

            // Assert
            Assert.Equal("corte", retrievedMachineType.Name.name);
        } */
/* 
        [Fact]
        public void PostMachineType_CreateNewMachineType()
        {

            // Arrange

            Name name1 = new Name("corte");

            MachineType dummyMachineType2 = new MachineType()
            {
                Name = name1,
            };

            MachineTypeDTO machineTypeDTO = new MachineTypeDTO(){
                Name = "adad"
            };


            _machineTypeServiceMock.Setup(machineTypeService => machineTypeService.CreateMachineType(It.IsAny<MachineTypeDTO>()))
                .Returns(dummyMachineType2);

            // Act
            var machineController = new MachineTypeController(_machineTypeServiceMock.Object);
            var result = machineController.PostMachine(createMachineTypeDTO());

            // Assert
            Assert.Equal(result.Value.Name.name, dummyMachineType2.Name.name );
        } */

        [Fact]
        public void CreateMachineType_IfBodyIsEmpty_ReturnNull()
        {
            // Arrange
            var newMachineTypeDto = new MachineTypeDTO() { };

            _machineTypeRepositoryMock.Setup(iMachineTypeRepository => iMachineTypeRepository.Create(It.IsAny<MachineType>())).Returns(new MachineType());

            // Act
            var returnedObject = _service.CreateMachineType(newMachineTypeDto);

            // Assert
            Assert.Null(returnedObject);
        }
    }
}