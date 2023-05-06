using Ikk.Claims.Common.Entieties;
using Ikk.Claims.Domain.Enities.Batchs;
using Ikk.Claims.Domain.Enities.CKDQRs;
using Ikk.Claims.Domain.Enities.Claims;
using Ikk.Claims.Domain.Enities.Parts;

namespace Ikk.Claims.Domain.Enities.Claems
{
    public class Claem : BaseEntity
    {
        public string ClaemNumber { get; private set; }
        
        public int CountPart { get; private set; }
        public long BatchId { get; set; }
        public Batch Batch { get; set; }
        public string Country { get; private set; }
        public string Company { get; private set; }
        public string? Desc { get; private set; }
        public DateTime RegisterDate { get; set; }
        public ICollection<ClaemInCkdqr> claemInCkdqrs {get;set;}
        public ICollection<ClaimInPart> ClaemInParts { get; set; }
        public ICollection<ClaemPic> Pics { get; set; }

        protected Claem()
        {

        }
        public Claem(string claimNumber, int countPart, string country, string company, string desc, long batchId, DateTime registerDate)
        {
            ClaemNumber = claimNumber;
            CountPart = countPart;
            Country = country;
            Company = company;
            Desc = desc;
            BatchId = batchId;
            RegisterDate = registerDate;
            
        }
        public void EditClaim(string claimNumber, int countPart, string country, string company, string desc, long batchId,DateTime dateTime, long editedBy)
        {
            ClaemNumber = claimNumber;
            CountPart = countPart;
            Country = country;
            Company = company;
            Desc = desc;
            BatchId = batchId;
            Edit(editedBy);
        }


    }
}
