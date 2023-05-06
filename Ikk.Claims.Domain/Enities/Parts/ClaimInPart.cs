using Ikk.Claims.Domain.Enities.Claems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Domain.Enities.Parts
{
    public class ClaimInPart
    {
        public long Id { get; private set; }
        public long PartId { get; set; }
        public Part Part { get; set; }
        public long ClaemId { get; set; }
        public Claem claem { get; set; }

        protected ClaimInPart()
        {

        }
        public ClaimInPart(long partId, Part part, long claemId, Claem claem)
        {
            PartId = partId;
            Part = part;
            ClaemId = claemId;
            this.claem = claem;
        }
    }
}
