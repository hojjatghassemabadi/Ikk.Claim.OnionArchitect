using Ikk.Claims.Application.Contracts.TypeCarContract;

namespace Ikk.Claims.Application.Contracts.BatchContract
{
    public class RegisterBatchViewModel
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public List<GetIdTypeCarViewModel> CarInBatchs { get; set; }
    }
}
