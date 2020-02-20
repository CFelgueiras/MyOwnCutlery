using System.Collections.Generic;

namespace MDFabricaAPI.Models.ValueObjects
{
    public class MachineId : ValueObject
    {
        public long Id { get; set; }

        public MachineId() { }
        public MachineId(long id)
        {
            this.Id = id;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }
}