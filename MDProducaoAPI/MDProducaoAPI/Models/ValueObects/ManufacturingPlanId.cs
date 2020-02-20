using System.Collections.Generic;

namespace MDProducaoAPI.Models.ValueObjects
{

    public class ManufacturingPlanId : ValueObject
    {
        public long Id { get; set; }

        public ManufacturingPlanId() { }
        public ManufacturingPlanId(long id)
        {
            this.Id = id;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}