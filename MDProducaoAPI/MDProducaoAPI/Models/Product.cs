using System.ComponentModel.DataAnnotations;
using MDProducaoAPI.Models.ValueObjects;

namespace MDProducaoAPI.Models
{
    public class Product : Entity
    {
        [Key]
        public long ProductId { get; set; }
        public Name Name { get; set; }

        public long ManPlanId { get; set; }
        public ManufacturingPlan ManPlan { get; set; }

        public Product() { }

        public Product(Name name)
        {
            this.ProductId = new ProductId().Id;
            this.Name = name;
        }
    }
}