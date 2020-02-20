using MDFabricaAPI.Service.Interfaces;
using MDFabricaAPI.Models;
using MDFabricaAPI.Models.DTO;
using MDFabricaAPI.Repository.Interfaces;
using System.Collections.Generic;
using MDFabricaAPI.Models.ValueObjects;

namespace MDFabricaAPI.Service
{
    public class ProductionLineService : IProductionLineService
    {
        private readonly IProductionLineRepository _repository;
        private readonly IMachineRepository _repositoryMachine;

        public ProductionLineService(IProductionLineRepository productionLineRepository, IMachineRepository repositoryMachine)
        {
            _repository = productionLineRepository;
            _repositoryMachine = repositoryMachine;
        }

        public ProductionLine GetProductionLineById(long id)
        {
            return _repository.GetById(id);
        }

        public List<ProductionLine> GetByName(string name)
        {
            return _repository.GetByName(name);
        }

        public ProductionLine CreateProductionLine(ProductionLineDTO productionLineDto)
        {
            var pl = new ProductionLine();

            if( GetByName(productionLineDto.Name) == null){
                return null;
            }

            if (GetByName(productionLineDto.Name).Count == 0)
            {
                if (productionLineDto.Name == null)
                {
                    return null;
                }
                else
                {
                    Name name = new Name(productionLineDto.Name);
                    pl.Name = name;
                    ICollection<Machine> machinesList = new List<Machine>();

                    foreach (var machid in productionLineDto.MachineIds)
                    {
                        Machine machine = new Machine();
                        machine = _repositoryMachine.GetById(machid);
                        if (machine != null)
                        {
                            machinesList.Add(machine);
                        }
                        else
                            return null;
                    }
                    pl.Machines = machinesList;
                }
                _repository.Create(pl);
                return pl;
            }
            else
            {
                return null;
            }
        }

        public List<ProductionLine> GetAllProductionLines()
        {
            return _repository.GetAllProductionLines();
        }
    }
}