using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MDFabricaAPI.Models.ValueObjects;

namespace MDFabricaAPI.Models
{
    public class ProductionLine : Entity
    {
        public long ProductionLineId { get; set; }

        [Required(ErrorMessage = "Name of Production Line is required")]
        public Name Name { get; set; }
        
        public ICollection<Machine> Machines { get; set; }

        public ProductionLine() { }

        public ProductionLine(Name name){
            this.Name = name;
        }

        public ProductionLine(long id){
            this.ProductionLineId = id;
        }

        public ProductionLine(Name name, List<Machine> machinelist)
        {
            this.ProductionLineId = new ProductionLineId().Id;
            this.Name = name;
            this.Machines = new List<Machine>();
        }
    }
}