using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TestDTO
    {
        public int test_id { get; set; }
        public DateTime test_date { get; set; }
        public TimeSpan test_start_time { get; set; }
        public TimeSpan test_end_time { get; set; }
        public double over_mark { get; set; }
        public int level { get; set; }
        public Nullable<double> quesPercent { get; set; }

    }
}
