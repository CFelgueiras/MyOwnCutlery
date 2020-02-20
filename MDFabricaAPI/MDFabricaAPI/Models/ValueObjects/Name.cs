using System.Collections.Generic;
using MDFabricaAPI.Models;

namespace MDFabricaAPI.Models.ValueObjects
{
    public class Name : ValueObject
    {
        public string name { get; set; }

        public Name() { }
        public Name(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
                this.name = name;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return name;
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