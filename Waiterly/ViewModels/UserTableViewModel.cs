using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waiterly.Models;

namespace Waiterly.ViewModels.UserTableViewModel
{
    public class UserTableViewModel
    {
        public List<Table> Tables { get; set; }

        public List<UserTable> UserTables { get; set; }
    }
}
