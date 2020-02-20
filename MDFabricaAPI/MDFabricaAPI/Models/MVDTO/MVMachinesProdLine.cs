
using System;
using System.Linq;
using System.Collections.Generic;
using MDFabricaAPI.Models;

namespace MDFabricaAPI.MVDTO
{
    public class MVMachinesProdLine
    {
        public string ProductionLineName { get; set; }

        public string[] MachineTypeName { get; set; }

        public MVMachinesProdLine() { }

        public MVMachinesProdLine(string ProductionLineName)
        {
            this.ProductionLineName = ProductionLineName;
        }

        public static List<MVMachinesProdLine> FromList(List<Machine> machList)
        {
            List<Machine> activeMachines = new List<Machine>();
            activeMachines = MVMachinesProdLine.listActiveMachines(machList);

            List<String> maqlist = new List<String>();
            

            List<MVMachinesProdLine> mpllist = new List<MVMachinesProdLine>();

            MVMachinesProdLine mVMachinesProdLine = new MVMachinesProdLine();

            List<Machine> machinesbypl = new List<Machine>();

            long[] idArray = new long[machList.Count];
            int counter = 0;
            foreach (var machine in activeMachines)
            {
                long id = machine.ProductionLine.ProductionLineId;
                idArray[counter] = id;
                counter++;
            }

            long[] idArray2 = idArray.Distinct().ToArray();
            idArray2 = idArray2.Where(x => x != 0).ToArray();

            string plname = "";
            int count1 = 0;

            for (long i = 0; i < idArray2.Count(); i++)
            {
                string[] machArray = new string[machList.Count];
                
                foreach (var machine in activeMachines)
                {
                    if (machine.ProductionLine.ProductionLineId == idArray2[i])
                    {
                        plname = machine.ProductionLine.Name.name;
                        machArray[count1] = machine.MachineType.Name.name;
                        count1++;
                    }
                }
                mVMachinesProdLine = new MVMachinesProdLine();
                machArray = machArray.Where(c => c != null).ToArray();
                mVMachinesProdLine.ProductionLineName = plname;
                mVMachinesProdLine.MachineTypeName = machArray;
                mpllist.Add(mVMachinesProdLine);
                count1 = 0;
            }
            return mpllist;
        }

        private static List<Machine> listActiveMachines(List<Machine> list)
        {
            List<Machine> listActiveMachines = new List<Machine>();
            foreach (var machine in list)
            {
                if (machine.State == true)
                {
                    listActiveMachines.Add(machine);
                }
            }
            return listActiveMachines;
        }
    }
}