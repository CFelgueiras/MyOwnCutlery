using System.Collections.Generic;

namespace MDFabricaAPI.Models.ValueObjects
{

    public class MachineTypeId : ValueObject
    {
        public long Id { get; set; }

        public MachineTypeId() { }
        public MachineTypeId(long id)
        {
            this.Id = id;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }

    /* private readonly long _Id;
    public long Id
    {
        get { return _Id; }
    }

    public MachineTypeId(long _id)
    {
        _Id = _id;
    }

    public override bool Equals(object obj)
    {
        var item = obj as MachineTypeId;
        if ((item.Id == Id))
        {
            return true;
        }
        return false;
    }

    public static bool operator !=(MachineTypeId id1, MachineTypeId id2)
    {
        if ((id1.Id != id2.Id))
        {
            return true;
        }
        return false;
    }

    public static bool operator ==(MachineTypeId id1, MachineTypeId id2)
    {
        if ((id1.Id == id2.Id))
        {
            return true;
        }
        return false;
    }
    
    
    public override int GetHashCode()
    {
        return (_Id).GetHashCode();
    } */
}