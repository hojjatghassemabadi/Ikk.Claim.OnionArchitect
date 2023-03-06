using Ikk.Claims.Common.Entieties;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Domain.Enities.Parts
{
    public class Part : BaseEntity
    {
        public string PartName { get; private set; }
        public string PartNumber { get; private set; }
        public bool Status { get; private set; }

        protected Part()
        {

        }
        public Part(string partname, string partnumber, bool status)
        {
            PartName = partname;
            PartNumber = partnumber;
            Status = status;

        }
        public void EditPart(string partname, string partnumber, bool status, long editedBy)
        {
            PartName = partname;
            PartNumber = partnumber;
            Status = status;
            Edit(editedBy);
        }
        public void ChangeStatus(bool status)
        {
            Status = status;

        }

    }
}
