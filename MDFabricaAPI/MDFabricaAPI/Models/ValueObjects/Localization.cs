using System.Collections.Generic;

namespace MDFabricaAPI.Models.ValueObjects
{
    public class Localization : ValueObject
    {
        public string localization { get; set; }

        public Localization() { }
        public Localization(string localization)
        {
            if (!string.IsNullOrWhiteSpace(localization))
                this.localization = localization;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return localization;
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