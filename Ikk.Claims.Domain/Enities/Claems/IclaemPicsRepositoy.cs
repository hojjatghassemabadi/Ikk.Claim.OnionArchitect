using Ikk.Claims.Common.Infrastructure;
using Ikk.Claims.Domain.Enities.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Domain.Enities.Claems
{
    public interface IClaemPicsRepositoy:IRepository<long,ClaemPic>
    {
        void RemoveImage(string image);
    }
}
