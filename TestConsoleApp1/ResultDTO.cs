using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp1
{
    public class ResultDTO
    {
        public ResultDTO(int code, string message)
        {
            this.Code =code;
            this.Message = message;
        }

        public int Code { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}
