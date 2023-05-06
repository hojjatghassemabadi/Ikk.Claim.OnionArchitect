namespace Ikk.Claims.Application.Contracts.ClaemContracts
{
    public class ResultGetClaems
    {
        public int RowCount { get; set; }
        public List<GetClaemViewModel> claims { get; set; }
    }
}