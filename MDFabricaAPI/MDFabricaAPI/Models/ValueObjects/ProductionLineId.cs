using System.Collections.Generic;

namespace MDFabricaAPI.Models.ValueObjects
{

    public class ProductionLineId : ValueObject
    {
        public long Id { get; set; }

        public ProductionLineId() { }
        public ProductionLineId(long id)
        {
            this.Id = id;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }

    /* {
        private readonly long _Id;
        public long Id
        {
            get { return _Id; }
        }

        public ProductionLineId(long _id)
        {
            _Id = _id;
        }

        public override bool Equals(object obj)
        {
            var item = obj as ProductionLineId;
            if ((item.Id == Id))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(ProductionLineId id1, ProductionLineId id2)
        {
            if ((id1.Id != id2.Id))
            {
                return true;
            }
            return false;
        }

        public static bool operator ==(ProductionLineId id1, ProductionLineId id2)
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