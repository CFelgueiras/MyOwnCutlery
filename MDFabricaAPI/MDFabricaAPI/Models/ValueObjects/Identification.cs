using System.Collections.Generic;
using MDFabricaAPI.Models;

namespace MDFabricaAPI.Models.ValueObjects
{
    public class Identification : ValueObject
    {
        public string identification { get; set; }

        public Identification() { }
        public Identification(string identification)
        {
            if (!string.IsNullOrWhiteSpace(identification))
                this.identification = identification;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return identification;
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