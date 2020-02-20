using System.Collections.Generic;
using MDFabricaAPI.Service.Interfaces;
using MDFabricaAPI.Models;
using MDFabricaAPI.Models.DTO;
using MDFabricaAPI.Models.ValueObjects;
using MDFabricaAPI.Repository.Interfaces;

namespace MDFabricaAPI.Service
{
    public class MachineService : IMachineService
    {
        private readonly IMachineRepository _repository;
        private readonly IMachineTypeRepository _machineTypeRepository;

        private readonly IProductionLineRepository _ProdLinerepository;

        public MachineService(IMachineRepository machineRepository, IMachineTypeRepository machineTypeRepository, IProductionLineRepository prodLinerepository)
        {
            _repository = machineRepository;
            _machineTypeRepository = machineTypeRepository;
            _ProdLinerepository = prodLinerepository;
        }

        public Machine GetMachineById(long id)
        {
            return _repository.GetById(id);
        }
        
        public List<Machine> GetAllMachine()
        {
            return _repository.GetAll();
        }

        public Machine CreateMachine(MachineDTO machineDto)
        {
            var mac = new Machine();

            var item = _repository.GetByName(machineDto.Identification);

            if (item == null)
            {
                return null;
            }

            if (item.Count == 0)
            {
                if (machineDto.Identification == null)
                {
                    return null;
                }
                else
                {
                    mac.Identification = new Identification(machineDto.Identification);
                }

                MachineType machineType = new MachineType();
                machineType = _machineTypeRepository.GetById(machineDto.MachineTypeId);
                if (machineDto.MachineTypeId < 0)
                {
                    return null;
                }
                else
                {
                    mac.MachineType = machineType;
                    mac.Brand = new Brand(machineDto.Brand);
                    mac.Model = new Model(machineDto.Model);
                    mac.Localization = new Localization(machineDto.Localization);
                    mac.Capacity = new Capacity(machineDto.Capacity);
                    mac.State = machineDto.State;
                }

                _repository.Create(mac);
                return mac;
            }
            else
            {
                return null;
            }
        }

        public Machine ChangeMachineState(MachineDTO machineDto)
        {
            var item = _repository.GetByName(machineDto.Identification);
            if (item[0] == null)
            {
                return null;
            } else
            {
                item[0].State = machineDto.State;
                _repository.UpdateMachineState(item[0]);
                return item[0];
            }
        }

        public Machine UpdateMachineTypeOfMachine(MachineDTO machineDto)
        {
            var machine = _repository.GetById(machineDto.Id);
            var machineType = _machineTypeRepository.GetById(machineDto.MachineTypeId);

            if (machine == null || machineType == null)
            {
                return null;
            }
            else
            {
                machine.MachineType = machineType;
                _repository.UpdateMachineTypeOfMachine(machine);
                return machine;
            }
        }

        public List<Machine> GetMachinesByProductionLine()
        {
            return _repository.GetAll();
        }

        public Machine CreateMachineFromSgrai(MachineFromSgraiDTO machineFromSgraiDTO)
        {
            var mac = new Machine();

            var item = _repository.GetByName(machineFromSgraiDTO.Identification);

            if (item == null)
            {
                return null;
            }

            if (item.Count == 0)
            {
                if (machineFromSgraiDTO.Identification == null)
                {
                    return null;
                }
                else
                {
                    mac.Identification = new Identification(machineFromSgraiDTO.Identification);
                }

                MachineType machineType = new MachineType();
                machineType = _machineTypeRepository.GetById(machineFromSgraiDTO.MachineTypeId);
                if (machineFromSgraiDTO.MachineTypeId < 0)
                {
                    return null;
                }
                else
                {
                    mac.MachineType = machineType;
                    mac.Brand = new Brand(machineFromSgraiDTO.Brand);
                    mac.Model = new Model(machineFromSgraiDTO.Model);
                    mac.Localization = new Localization(machineFromSgraiDTO.Localization);
                    mac.Capacity = new Capacity(machineFromSgraiDTO.Capacity);
                    mac.State = machineFromSgraiDTO.State;
                    mac.ProductionLine = _ProdLinerepository.GetById(machineFromSgraiDTO.ProductionLineId);
                }

                _repository.Create(mac);
                return mac;
            }
            else
            {
                return null;
            }
        }
    }
}