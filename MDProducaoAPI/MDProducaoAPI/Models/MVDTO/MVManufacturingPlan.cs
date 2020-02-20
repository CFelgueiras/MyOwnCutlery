using System.Collections.Generic;
using MDProducaoAPI.Models.ValueObjects;

namespace MDProducaoAPI.Models.MVDTO
{
    public class MVManufacturingPlan
    {
        public long Id { get; set; }
        public Name Name { get; set; }
        public ICollection<MVOperation> Operations { get; set; }
        public MVManufacturingPlan() { }

        public MVManufacturingPlan(long id, Name name, ICollection<MVOperation> operations)
        {
            this.Id = id;
            this.Name = name;
            this.Operations = operations;
        }

        public static MVManufacturingPlan FromFull(ManufacturingPlan mp)
        {
            var operations = new List<MVOperation>();

            operations = MVOperation.FromList(mp.OperationsList);

            return new MVManufacturingPlan(mp.manufacturingPlanId, mp.Name, operations);
        }

        public static MVManufacturingPlan From(ManufacturingPlan mp)
        {
            var operations = new List<MVOperation>();

            foreach (var op in mp.OperationsList)
            {
                operations.Add(MVOperation.FromFull(op));
            }
            return new MVManufacturingPlan(mp.manufacturingPlanId, mp.Name, operations);
        }
        
        public static List<MVManufacturingPlan> FromList(List<ManufacturingPlan> manPlan)
        {
            List<MVManufacturingPlan> manPlanList = new List<MVManufacturingPlan>();

            foreach (var mp in manPlan)
            {
                MVManufacturingPlan mVManufacturingPlan = new MVManufacturingPlan();
                mVManufacturingPlan.Id = mp.manufacturingPlanId;
                mVManufacturingPlan.Name = mp.Name;
                manPlanList.Add(mVManufacturingPlan);
            }
            return manPlanList;
        }
    }
}