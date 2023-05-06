using Ikk.Claims.Common.Entieties;
using Ikk.Claims.Domain.Enities.Claems;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Domain.Enities.Claims
{
    public class ClaemPic:BaseEntity
    {
        public string PicName { get;private set; }
        [NotMapped]
        public IFormFile file { get; set; }
        public long ClaemId { get; set; }
        public Claem Claem { get; set; }

        protected ClaemPic()
        {

        }
        public ClaemPic(string picAddress, long claemId)
        {
            PicName = picAddress;
            ClaemId = claemId;
            
        }
        public void EditclaimPic(string picAddress)
        {
            PicName = picAddress;
        }
    }

    
}
