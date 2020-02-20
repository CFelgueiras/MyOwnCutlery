using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MDFabricaAPI.Models.ValueObjects;

namespace MDFabricaAPI.Models
{
    public class MachineType : Entity
    {

        public long MachineTypeId { get; set; }

        [Required(ErrorMessage = "Name of Machine Type is required")]
        public Name Name { get; set; }
        public virtual ICollection<Machine> Machines { get; set; }
        public virtual ICollection<Operation> OperationsList { get; set; }
        public MachineType() {
            this.MachineTypeId = new MachineTypeId().Id;
            this.Name = new Name();
        }
        public MachineType(long id, Name name)
        {
            this.MachineTypeId = new MachineTypeId().Id;
            this.Machines = new List<Machine>();
            this.OperationsList = new List<Operation>();
            this.MachineTypeId = new MachineTypeId().Id;
            this.Name = name;
        }
    }
}