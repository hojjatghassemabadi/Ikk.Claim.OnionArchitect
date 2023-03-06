using Ikk.Claims.Common.Entieties;
using Ikk.Claims.Domain.Enities.TypeCars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Domain.Enities.Batchs
{
    public class Batch:BaseEntity
    {
        public string Name { get; private set; }
        public bool Status { get; private set; }
        public long TypecarId { get; set; }
        public TypeCar TypeCar{ get; set; }

        protected Batch()
        {

        }

        public Batch(string name, bool status)
        {
            Name = name;
            Status = status;

        }
        public void EditBatch(string name, bool status, long editedBy)
        {
            Name = name;
            Status = status;
            Edit(editedBy);
        }
        public void ChangeStatus(bool status)
        {
            Status = status;

        }
    }
}
