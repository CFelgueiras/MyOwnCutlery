using System.Collections.Generic;

namespace MDFabricaAPI.Models.ValueObjects
{
    public class Model : ValueObject
    {
        public string model { get; set; }

        public Model() { }
        public Model(string model)
        {
            if (!string.IsNullOrWhiteSpace(model))
                this.model = model;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return model;
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