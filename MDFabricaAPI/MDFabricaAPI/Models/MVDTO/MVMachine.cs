using System;
using System.Collections.Generic;
using MDFabricaAPI.Models;

namespace MDFabricaAPI.MVDTO
{
    public class MVMachine
    {
        public long MachineId { get; set; }
        public string Identification { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Localization { get; set; }
        public double Capacity { get; set; }
        
        public bool State { get; set; }
        
        public long MachineTypeId { get; set; }
        
        public string MachineTypeName { get; set; }

        public MVMachine() { }

        public MVMachine(long machineId, string Identification, string brand, string model, string localization, double capacity, long machineTypeId, bool state, string machineTypeName)
        {
            this.MachineId = machineId;
            this.Identification = Identification;
            this.Brand = brand;
            this.Model = model;
            this.Localization = localization;
            this.Capacity = capacity;
            this.MachineTypeId = machineTypeId;
            this.State = state;
            this.MachineTypeName = machineTypeName;
        }
        
        public MVMachine(long machineId, string Identification, string brand, string model, bool state)
        {
            this.MachineId = machineId;
            this.Identification = Identification;
            this.Brand = brand;
            this.Model = model;
            this.State = state;
        }

        public static MVMachine FromFull(Machine o)
        {
            return new MVMachine(o.MachineId, o.Identification.identification, o.Brand.brand, o.Model.model, o.Localization.localization, o.Capacity.capacity, o.MachineType.MachineTypeId, o.State, o.MachineType.Name.name);
        }

        public static MVMachine From(Machine o)
        {

            return new MVMachine(o.MachineId, o.Identification.identification, o.Brand.brand, o.Model.model, o.Localization.localization, o.Capacity.capacity, o.MachineType.MachineTypeId, o.State, o.MachineType.Name.name);
        }
        
        public static MVMachine UpdateSate(Machine o)
        {

            return new MVMachine(o.MachineId, o.Identification.identification, o.Brand.brand, o.Model.model, o.State);
        }
        
        public static List<MVMachine> FromList(List<Machine> machines)
        {
            List<MVMachine> maclist = new List<MVMachine>();

            foreach (var m in machines)
            {
                MVMachine mvMachine = new MVMachine();
                mvMachine.Brand = m.Brand.brand;
                mvMachine.Capacity = m.Capacity.capacity;
                mvMachine.Identification = m.Identification.identification;
                mvMachine.Localization = m.Localization.localization;
                mvMachine.Model = m.Model.model;
                mvMachine.State = m.State;
                mvMachine.MachineId = m.MachineId;
                mvMachine.MachineTypeId = m.MachineType.MachineTypeId;
                mvMachine.MachineTypeName = m.MachineType.Name.name;
                maclist.Add(mvMachine);
            }
            return maclist;
        }
    }
}