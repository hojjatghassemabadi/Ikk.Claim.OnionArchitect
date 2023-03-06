using Ikk.Claims.Common.Entieties;
using Ikk.Claims.Domain.Enities.Batchs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Domain.Enities.TypeCars
{
    public class TypeCar:BaseEntity
    {
        public string Name { get; private set; }
        public bool Status { get; private set; }
        public long BatchId { get; set; }
        public Batch Batch { get; set; }

        protected TypeCar()
        {

        }
        public TypeCar(string name, bool status)
        {
            Name = name;
            Status = status;

        }
        public void EditTypeCar(string name, bool status, long editedBy)
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
