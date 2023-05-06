using Ikk.Claims.Common.Infrastructure;
using Ikk.Claims.Domain.Enities.Claems;
using Ikk.Claims.Domain.Enities.Claims;
using Ikk.Claims.Infrastructure.EfCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Infrastructure.EfCore.Repositories.Claems
{
    public class ClaemPicsRepository : BaseRepository<long, ClaemPic>, IClaemPicsRepositoy
    {
        private readonly ClaemContext _context;
        public ClaemPicsRepository(ClaemContext context) : base(context)
        {
            _context = context;
        }

        public void RemoveImage(string image)
        {
            var pic = _context.ClaemPics.FirstOrDefault(p => p.PicName.Equals(image));
            _context.ClaemPics.Remove(pic);
        }
    }
}
