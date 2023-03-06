using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Application.Contracts.UserContracts
{
    public class ResultGetUsers
    {
        public int RowCount { get; set; }
        public List<UsersViewModel> users { get; set; }
    }
}
