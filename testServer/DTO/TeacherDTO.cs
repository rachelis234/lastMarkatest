using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TeacherDTO
    {
        public int teacherId { get; set; }
        [Required]
        public int design_id { get; set; }
        [Required]
        public int userId { get; set; }
        public UserDTO user { get; set; }
    }
}
