using Ikk.Claims.Application.Contracts.PartContracts;
using Ikk.Claims.Application.Contracts.PartInClaim;
using Ikk.Claims.Common.Infrastructure;
using Ikk.Claims.Domain.Enities.Parts;
using Ikk.Claims.Infrastructure.EfCore.Context;

namespace Ikk.Claims.Infrastructure.EfCore.Repositories.Parts
{
    public class ClaemInRepository : BaseRepository<long, ClaimInPart>, IClaemInPartRepository
    {
        private readonly ClaemContext _Context;
        public ClaemInRepository(ClaemContext context) : base(context)
        {
            _Context = context;
        }

        public GetPartInClaimViewModel GetPartWithClaemId(long id)
        {
            var partInClaim = _Context.claemInParts.Select(p => new GetPartInClaimViewModel
            {
                Id =p.Id,
                ClaemId=p.ClaemId,
                PartId=p.PartId
            }).Where(p=>p.ClaemId==id).FirstOrDefault();
            return partInClaim;
        }
    }
}
