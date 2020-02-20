using System.Collections.Generic;

namespace MDFabricaAPI.Models.ValueObjects
{
    public class Capacity : ValueObject
    {
        public double capacity { get; set; }

        public Capacity() { }
        public Capacity(double capacity)
        {
            this.capacity = capacity;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return capacity;
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