using System;
using System.Collections.Generic;
using MDFabricaAPI.Models;

namespace MDFabricaAPI.MVDTO
{
    public class MVMachineFromSgrai
    {
        public long MachineId { get; set; }
        public string Identification { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Localization { get; set; }
        public double Capacity { get; set; }

        public bool State { get; set; }

        public long MachineTypeId { get; set; }

        public long ProductionLineId { get; set; }

        public MVMachineFromSgrai() { }

        public MVMachineFromSgrai(long machineId, string Identification, string brand, string model, string localization, double capacity, long machineTypeId, bool state, long productionLineId)
        {
            this.MachineId = machineId;
            this.Identification = Identification;
            this.Brand = brand;
            this.Model = model;
            this.Localization = localization;
            this.Capacity = capacity;
            this.MachineTypeId = machineTypeId;
            this.State = state;
            this.ProductionLineId = productionLineId;
        }

        public MVMachineFromSgrai(long machineId, string Identification, string brand, string model, bool state)
        {
            this.MachineId = machineId;
            this.Identification = Identification;
            this.Brand = brand;
            this.Model = model;
            this.State = state;
        }

        public static MVMachineFromSgrai From(Machine o)
        {

            return new MVMachineFromSgrai(o.MachineId, o.Identification.identification, o.Brand.brand, o.Model.model, o.Localization.localization, o.Capacity.capacity, o.MachineType.MachineTypeId, o.State, o.ProductionLine.ProductionLineId);
        }

    }
}