using System;
using System.Collections.Generic;
using MDFabricaAPI.Models;

namespace MDFabricaAPI.MVDTO
{
    public class MVProductionLine
    {
        public long ProductionLineId { get; set; }
        public string Name { get; set; }

        public ICollection<MVMachine> MachineList { get; set; }
        public MVProductionLine() { }

        public MVProductionLine(long ProductionLineId, string name,ICollection<MVMachine> machineList)
        {
            this.Name = name;
            this.ProductionLineId = ProductionLineId;
            this.MachineList = machineList;
        }

        public static MVProductionLine FromFull(ProductionLine pl)
        {
            var machines  = new List<MVMachine>();

            foreach(var m in pl.Machines)
            {
                machines.Add(MVMachine.FromFull(m));
            }

            return new MVProductionLine(pl.ProductionLineId, pl.Name.name, machines);
        }

        public static string[] ListProductionLines(List<ProductionLine> pls)
        {
            string[] plArray = new string[pls.Count];

            List<string> plNames = new List<string>();

            foreach(var pl in pls) {
                plNames.Add(pl.Name.name);
            }

            plNames.CopyTo(plArray);

            return plArray;
        }
    }
}