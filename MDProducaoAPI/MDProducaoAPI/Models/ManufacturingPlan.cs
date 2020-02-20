using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MDProducaoAPI.Models.ValueObjects;

namespace MDProducaoAPI.Models
{
    public class ManufacturingPlan : Entity
    {
        [Key]
        public long manufacturingPlanId { get; set; }
        [Required]
        public Name Name { get; set; }

        public List<Operation> OperationsList { get; set; }

        public Product Product { get; set; }

        public ManufacturingPlan()
        {
            this.manufacturingPlanId = new ManufacturingPlanId().Id;
            this.Name = new Name();
            this.OperationsList = new List<Operation>();
            
        }

        public ManufacturingPlan(Name name)
        {
            this.manufacturingPlanId = new ManufacturingPlanId().Id;
            this.Name = name;
            this.OperationsList = new List<Operation>();
        }
    }
}