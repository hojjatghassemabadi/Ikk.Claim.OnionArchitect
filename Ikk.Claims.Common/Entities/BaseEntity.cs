using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Common.Entieties
{
    public class BaseEntity<TKey>
    {
        public  TKey Id { get;private set; }
        public long CreatedBy { get; private set; }

        public DateTime DateCreated { get; private set; } = DateTime.Now;

        public long? LastModifiedBy { get; private set; }

        public DateTime? DateLastModified { get; private set; }
        public bool IsRemoved { get; private set; } = false;
        public DateTime? DateRemoved { get; private set; }
        public long RemovedBy { get; private set; }
        public void Remove(long deleteBy,DateTime deleteDate)
        {
            IsRemoved = true;
            DateRemoved = deleteDate;
            RemovedBy = deleteBy;
        }
        public void Create(long createBy)
        {
            CreatedBy = createBy;
        }
        public void Edit(long editBy)
        {
            LastModifiedBy = editBy;
            DateLastModified = DateTime.Now;
        }
        public void Activate(long deleteBy, DateTime deleteDate)
        {
            IsRemoved = false;
            DateRemoved = deleteDate;
            RemovedBy = deleteBy;
        }

    }
    public abstract class BaseEntity : BaseEntity<long>
    {

    }

  
}
