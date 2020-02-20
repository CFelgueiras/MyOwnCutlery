using System;
using MDFabricaAPI.Models.ValueObjects;

namespace MDFabricaAPI.Models.DTO
{
    public class MachineDTO
    {
        public long Id { get; set; }
        public string Identification { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Localization { get; set; }
        public double Capacity { get; set; }

        public bool State { get; set; }
        public long MachineTypeId { get; set; }
    }

    public class MachineDtoState
    {
        public string Identification { get; set; }
        public bool State { get; set; }
    }
}