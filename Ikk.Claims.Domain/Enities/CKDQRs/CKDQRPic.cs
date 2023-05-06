using Ikk.Claims.Common.Entieties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Domain.Enities.CKDQRs
{
    public class CKDQRPic:BaseEntity
    {
        public string Address { get;private set; }
        public bool Status { get; set; }
        public long CkdqrId { get; set; }
        public CKDQR CKDQR { get; set; }

        protected CKDQRPic()
        {

        }

        public CKDQRPic(string address, long ckdqrId, CKDQR cKDQR)
        {
            Address = address;
            CkdqrId = ckdqrId;
            CKDQR = cKDQR;
        }

        public void Edit(string address)
        {
            Address = address;
        }
        public void ChangeStatus(bool status)
        {
            Status = status;
        }
    }
}
