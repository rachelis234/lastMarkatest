using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class student_markDTO
    {

        public int student_id { get; set; }
        public int test_id { get; set; }
        public int mark { get; set; }

        public  StudentDTO student { get; set; }
        public  TestDTO test { get; set; }


    }
}
