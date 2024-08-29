using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWZ.DAL.Entity
{
    public class OpUser
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int OpType { get; set; }

        public string UserCode { get; set; }
    }
}
