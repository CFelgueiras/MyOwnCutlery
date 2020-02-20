using System.Collections.Generic;

namespace MDFabricaAPI.Models.ValueObjects
{
    public class OperationId : ValueObject
    {
        public long Id { get; set; }

        public OperationId() { }
        public OperationId(long id)
        {
            this.Id = id;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}