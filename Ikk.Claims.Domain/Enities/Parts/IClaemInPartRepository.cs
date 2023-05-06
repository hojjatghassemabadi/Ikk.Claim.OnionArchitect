using Ikk.Claims.Application.Contracts.PartInClaim;
using Ikk.Claims.Common.Infrastructure;

namespace Ikk.Claims.Domain.Enities.Parts
{
    public interface IClaemInPartRepository : IRepository<long, ClaimInPart>
    {
        GetPartInClaimViewModel GetPartWithClaemId(long id);
    }
}
