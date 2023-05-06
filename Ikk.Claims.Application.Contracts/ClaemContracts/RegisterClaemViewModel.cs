using Ikk.Claims.Application.Contracts.PartContracts;
using Microsoft.AspNetCore.Http;

namespace Ikk.Claims.Application.Contracts.ClaemContracts
{
    public class RegisterClaemViewModel
    {
        public string ClaimNumber { get; set; }
        public int CountPart { get; set; }
        public long BatchId { get; set; }
        public string Country { get; set; }
        public string Company { get; set; }
        public string? Desc { get; set; }
        public long PartId { get; set; }
        public DateTime RegisterDate { get; set; }
        public List<IFormFile>? files { get; set; }
    }
}