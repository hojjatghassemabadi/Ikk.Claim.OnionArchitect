using Ikk.Claims.Common.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Application.Contracts.ClaemContracts
{
    public interface IClaemApplication
    {
        ResultGetClaems List(RequestDto request);
        ResultGetClaems ListWithoutCkdqr(RequestDto request);
        List<GetClaemPicsViewModel> GetClaemPics(long id);

        void Create(RegisterClaemViewModel command);

        void Edit(EditClaemViewModel command);
        GetClaemViewModel Get(string id);
        void Remove(long id);
        void RemoveImage(string image);
        void ChangeStatus(long id);
        int count();
    }
}