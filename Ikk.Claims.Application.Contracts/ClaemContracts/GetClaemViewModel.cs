namespace Ikk.Claims.Application.Contracts.ClaemContracts
{
    public class GetClaemViewModel : RegisterClaemViewModel
    {
        public long Id { get; set; }
        public string CarModel { get; set; }
        public string PartName { get; set; }
        public string BatchName { get; set; }
    }
}