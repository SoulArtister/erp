using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Infrastructure.ExtenalLibs
{
    public class RetMessage
    {
        public string message { get; set; }
        public data data { get; set; }
    }

    public class data
    {
        public string Code { get; set; }
        public int StatusCode { get; set; }
    }
}
