using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SimpleTest
    {
        public TestDTO test { get; set; }
        public List<ClassDTO> classes { get; set; }
        public List<QuestionDTO> questions { get; set; }

    }
}
