using Ikk.Claims.Common.Entieties;
using Ikk.Claims.Domain.Enities.CKDQRs.enums;
using Ikk.Claims.Domain.Enities.Claems;

namespace Ikk.Claims.Domain.Enities.CKDQRs
{
    public class CKDQR : BaseEntity
    {
        public string ReportNumber { get; private set; }
        public string OverSeasFactory { get; private set; }
        public string CountainerNo { get; private set; }
        public string caseNo { get; private set; }
        public PackingStauts PackingStatus { get; private set; }
        public OverSeasePlantAction OverSeasePlantAction { get; private set; }
        public Responsibility Responsibility { get; private set; }
        public URgencyClassification URgencyClassification { get; private set; }
        public Attachment Attachment { get; private set; }
        public Warranty Warranty { get; private set; }
        public ProblemType Problemtype { get; private set; }
        public string Details { get; private set; }
        public ICollection<ClaemInCkdqr> claemInCkdqrs { get; set; }

        public ICollection<CKDQRPic> Pics { get; set; }

        protected CKDQR()
        {

        }
        public CKDQR( string reportNumber, string overSeasFactory, string countainerNo, string caseNo, PackingStauts packingStatus, OverSeasePlantAction overSeasePlantAction, Responsibility responsibility, URgencyClassification uRgencyClassification, Attachment attachment, Warranty warranty, ProblemType problemtype, string details)
        {

            ReportNumber = reportNumber;
            OverSeasFactory = overSeasFactory;
            CountainerNo = countainerNo;
            this.caseNo = caseNo;
            PackingStatus = packingStatus;
            OverSeasePlantAction = overSeasePlantAction;
            Responsibility = responsibility;
            URgencyClassification = uRgencyClassification;
            Attachment = attachment;
            Warranty = warranty;
            Problemtype = problemtype;
            Details = details;

        }

        public void Edit( string reportNumber, string overSeasFactory, string countainerNo, string caseNo, PackingStauts packingStatus, OverSeasePlantAction overSeasePlantAction, Responsibility responsibility, URgencyClassification uRgencyClassification, Attachment attachment, Warranty warranty, ProblemType problemtype, string details, long editBy)
        {
            ReportNumber = reportNumber;
            OverSeasFactory = overSeasFactory;
            CountainerNo = countainerNo;
            this.caseNo = caseNo;
            PackingStatus = packingStatus;
            OverSeasePlantAction = overSeasePlantAction;
            Responsibility = responsibility;
            URgencyClassification = uRgencyClassification;
            Attachment = attachment;
            Warranty = warranty;
            Problemtype = problemtype;
            Details = details;
            Edit(editBy);
        }


    }

}
