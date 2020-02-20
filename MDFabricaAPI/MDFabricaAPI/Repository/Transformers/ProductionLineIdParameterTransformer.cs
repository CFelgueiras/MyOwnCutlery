using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Routing;

namespace MDFabricaAPI.Repository.Transformers
{
    public class ProductionLineIdParameterTransformer : IParameterPolicy
    {
        public string TransformOutBound(object value)
        {
            return value == null ? null : Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1-$2").ToLower();
        }
    }
}