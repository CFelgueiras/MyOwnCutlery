using System.Collections.Generic;
using MDProducaoAPI.Models;

namespace MDProducaoAPI.Models.ValueObjects
{
    public class OperationTool : ValueObject
    {
        public string operationTool { get; set; }

        public OperationTool() { }
        public OperationTool(string operationTool)
        {
            if (!string.IsNullOrWhiteSpace(operationTool))
                this.operationTool = operationTool;
        }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return operationTool;
        }

    }
}