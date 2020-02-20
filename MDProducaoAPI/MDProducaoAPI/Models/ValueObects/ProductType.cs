using System.Collections.Generic;

namespace MDProducaoAPI.Models.ValueObjects {
    public class ProductType : ValueObject{
        public long prodType { get; set; }
        public Name Name { get; set; }

        public ProductType(){}
        
        public ProductType(long prodType, Name name)
        {
            this.prodType = prodType;
            this.Name = name;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return prodType;
        }
    }

}