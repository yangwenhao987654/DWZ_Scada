using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ_Scada.DAL.Entity
{
    public class Role
    {
        public int Id { get; set; }

        public int  RoleType { get; set; }

        public string RoleName { get; set; }
    }
}
