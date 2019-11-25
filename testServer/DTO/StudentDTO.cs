using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class StudentDTO
    {
        public int studentId { get; set; }
        public int class_id { get; set; }
        public bool extra_time { get; set; }
        public int userId { get; set; }
        public UserDTO user { get; set; }
    }
}
