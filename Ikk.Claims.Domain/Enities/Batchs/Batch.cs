using Ikk.Claims.Common.Entieties;
using Ikk.Claims.Domain.Enities.CarInBaches;
using Ikk.Claims.Domain.Enities.Claems;

namespace Ikk.Claims.Domain.Enities.Batchs
{
    public class Batch : BaseEntity
    {
        public string Name { get; private set; }
        public bool Status { get; private set; }
        public long CarInBatchId { get; set; }
        public ICollection<Claem> Claims { get; set; }
        public ICollection<CarInBatch> CarInBatchs { get; set; }

        protected Batch()
        {

        }

        public Batch(string name, bool status)
        {
            Name = name;
            Status = status;

        }
        public void EditBatch(string name, bool status, long editedBy)
        {
            Name = name;
            Status = status;
            Edit(editedBy);
        }
        public void ChangeStatus(bool status)
        {
            Status = status;

        }
    }
}
