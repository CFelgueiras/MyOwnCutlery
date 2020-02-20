using System.Collections.Generic;

namespace MDFabricaAPI.Models.ValueObjects
{
    public class Brand : ValueObject
    {
        public string brand { get; set; }

        public Brand() { }
        public Brand(string brand)
        {
            if (!string.IsNullOrWhiteSpace(brand))
                this.brand = brand;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return brand;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}