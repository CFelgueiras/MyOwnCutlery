using System.Collections.Generic;
using MDProducaoAPI.Models.ValueObjects;

namespace MDProducaoAPI.Models
{
    public class ToolName : ValueObject
    {
        public string toolName { get; set; }

        public ToolName()
        {
        }

        public ToolName(string toolName)
        {
            if (!string.IsNullOrWhiteSpace(toolName))
                this.toolName = toolName;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return toolName;
        }

        public override string ToString()
        {
            return base.ToString();
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