using System;
using System.ComponentModel.DataAnnotations;
using MDFabricaAPI.Models.ValueObjects;

namespace MDFabricaAPI.Models
{
    public class Machine : Entity
    {
        private string name;

        [Key]
        public long MachineId { get; private set; }

        [Required(ErrorMessage = "Identification of Machine is required")]
        public Identification Identification { get; set; }
        public Brand Brand { get; set; }
        public Model Model { get; set; }
        public Localization Localization { get; set; }
        public Capacity Capacity { get; set; }
        public bool State { get; set; }
        public virtual MachineType MachineType { get; set; }
        public virtual ProductionLine ProductionLine { get; set; }

        public Machine() { }

        public Machine(ProductionLine ProductionLine)
        {
            this.ProductionLine.Name = ProductionLine.Name;
        }

        public Machine(Identification identification, Brand brand, Model model, Localization localization, Capacity capacity, Boolean state)
        {
            this.MachineId = new MachineId().Id;
            this.Identification = identification;
            this.Brand = brand;
            this.Model = model;
            this.Localization = localization;
            this.Capacity = capacity;
            this.State = state;
        }
    }
}