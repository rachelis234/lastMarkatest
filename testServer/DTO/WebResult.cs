using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class WebResult
    {
        public bool status { get; set; }
        public string message { get; set; }
        public object value { get; set; }
    }
}
