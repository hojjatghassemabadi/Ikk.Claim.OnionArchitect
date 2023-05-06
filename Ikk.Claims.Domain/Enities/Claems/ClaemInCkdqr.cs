using Ikk.Claims.Domain.Enities.CKDQRs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Domain.Enities.Claems
{
    public class ClaemInCkdqr
    {
        public long Id { get; private set; }
        public long ClaemId { get; private set; }
        public virtual Claem Claem { get; set; }
        public long CkdqrId { get; private set; }
        public virtual CKDQR CKDQR { get; set; }

        protected ClaemInCkdqr()
        {

        }
        public ClaemInCkdqr(long ClaemId, Claem Claem, long CkdqrId, CKDQR CKDQR)
        {
            ClaemId = ClaemId;
            Claem = Claem;
            CkdqrId = CkdqrId;
            CKDQR = CKDQR;

        }
    }
}
