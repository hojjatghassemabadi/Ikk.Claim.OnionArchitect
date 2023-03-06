using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Application.Contracts.Rolecontract
{
    public class GetRolesViewModel
    {
        public string Name { get; set; }
        public bool Status { get; set; }
    }
    public class GetRolesWithIdViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
    public class GetIdRolesViewModel
    {
        public long Id { get; set; }
    }
}
