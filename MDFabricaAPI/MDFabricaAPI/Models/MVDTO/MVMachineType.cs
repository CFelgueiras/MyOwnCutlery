using System.Collections.Generic;
using MDFabricaAPI.Models;
using MDFabricaAPI.Models.ValueObjects;

namespace MDFabricaAPI.MVDTO
{
    public class MVMachineType
    {
        public long MachineTypeId { get; set; }
        public Name Name { get; set; }

        public ICollection<MVOperation> Operations { get; set; }
        public ICollection<MVMachine> Machines { get; set; }

        public MVMachineType() { }

        public MVMachineType(long machineTypeId, Name name, ICollection<MVOperation> operations)
        {
            this.Name = name;
            this.MachineTypeId = machineTypeId;
            this.Operations = operations;
        }

        public MVMachineType(long machineTypeId, Name name, ICollection<MVMachine> machines)
        {
            this.Name = name;
            this.MachineTypeId = machineTypeId;
            this.Machines = machines;
        }
        public static MVMachineType FromFull(MachineType mt)
        {
            var operations = new List<MVOperation>();

            foreach (var op in mt.OperationsList)
            {
                operations.Add(MVOperation.FromFull(op));
            }

            return new MVMachineType(mt.MachineTypeId, mt.Name, operations);
        }

        public static MVMachineType From(MachineType mt)
        {
            var machines = new List<MVMachine>();

            foreach (var machine in mt.Machines)
            {
                machines.Add(MVMachine.From(machine));
            }
            return new MVMachineType(mt.MachineTypeId, mt.Name, machines);
        }

             public static string[] FromListToArray(List<MachineType> mts)
        {
            string[] mtlist = new string[mts.Count];

            List<string> mtnames = new List<string>();

            foreach(var mt in mts) {
                mtnames.Add(mt.Name.name);
            }

            mtnames.CopyTo(mtlist);

            return mtlist;
        }
             
             public static List<MVMachineType> FromList(List<MachineType> machineTypes)
             {
                 List<MVMachineType> macTypeslist = new List<MVMachineType>();

                 foreach (var mt in machineTypes)
                 {
                     MVMachineType mvMachineType = new MVMachineType();
                     mvMachineType.Name = mt.Name;
                     mvMachineType.MachineTypeId = mt.MachineTypeId;

                     macTypeslist.Add(mvMachineType);
                 }
                 return macTypeslist;
             }
        
    }
}