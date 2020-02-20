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
    public class MachineServiceTest
    {
        private readonly IMachineService _service;
        private readonly Mock<IMachineRepository> _machineRepositoryMock = new Mock<IMachineRepository>();

        private readonly Mock<IMachineTypeRepository> _machineTypeRepositoryMock = new Mock<IMachineTypeRepository>();
        public MachineServiceTest()
        {
            _service = new MachineService(_machineRepositoryMock.Object, _machineTypeRepositoryMock.Object);
        }

        [Fact]
        public void GetMachineById_IfIdNotExists_ReturnNull()
        {
            // Arrange
            long nonExistingId = 99999L;

            _machineRepositoryMock.Setup(iMachineRepository => iMachineRepository.GetById(nonExistingId)).Returns<Machine>(null);

            // Act
            var retrievedMachine = _service.GetMachineById(nonExistingId);

            // Assert
            Assert.Null(retrievedMachine);
        }

        [Fact]
        public void GetMachineById_IfExists_ReturnObjectOfTypeMachine()
        {
            // Arrange
            long existingId = 1L;

            _machineRepositoryMock.Setup(iMachineRepository => iMachineRepository.GetById(existingId)).Returns(new Machine());

            // Act
            var retrievedMachine = _service.GetMachineById(existingId);

            // Assert
            Assert.IsType<Machine>(retrievedMachine);
        }

        [Fact]
        public void GetMachineById_IfExists_ReturnsMachine()
        {

            Name name1 = new Name("corte");
            Identification identification = new Identification("M1");

            MachineType dumyMachineType = new MachineType()
            {

                Name = name1,
            };
            Machine dummyMachine = new Machine()
            {
                Identification = identification,
                MachineType = dumyMachineType,
            };

            // Arrange
            long existingId = 1L;

            _machineRepositoryMock.Setup(iMachineRepository => iMachineRepository.GetById(existingId)).Returns(dummyMachine);

            // Act
            var retrievedMachine = _service.GetMachineById(existingId);

            // Assert
            Assert.Equal("M1", retrievedMachine.Identification.identification);
        }
        /* 
                [Fact]
                public void PostMachine_CreateNewMachine()
                {

                    Name name1 = new Name("corte");
                    Name name2 = new Name("M1");

                    MachineType dumyMachineType = new MachineType()
                    {
                        Name = name1,
                    };

                    MachineDTO dummyMachineDTO = new MachineDTO()
                    {
                        Name = "teste",
                    };

                    // Arrange
                    _machineRepositoryMock.Setup(iMachineRepository => iMachineRepository.Create(It.IsAny<Machine>())).Returns(new Machine());

                    // Act
                    var retrievedMachine = _service.CreateMachine(dummyMachineDTO);

                    // Assert
                    Assert.IsType<MachineDTO>(retrievedMachine);
                }
        */

        [Fact]
        public void CreateMachine_IfBodyIsEmpty_ReturnNull()
        {
            // Arrange
            var newMachineDto = new MachineDTO() { };

            _machineRepositoryMock.Setup(iMachineRepository => iMachineRepository.Create(It.IsAny<Machine>())).Returns(new Machine());

            // Act
            var returnedObject = _service.CreateMachine(newMachineDto);


            // Assert
            Assert.Null(returnedObject);
        }
    }
}