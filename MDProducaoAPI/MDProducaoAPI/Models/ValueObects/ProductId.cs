
using System.Collections.Generic;

namespace MDProducaoAPI.Models.ValueObjects
{

    public class ProductId : ValueObject
    {
        public long Id { get; set; }

        public ProductId() { }
        public ProductId(long id)
        {
            this.Id = id;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}