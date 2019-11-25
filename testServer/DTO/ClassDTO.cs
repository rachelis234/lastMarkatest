using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ClassDTO
    {
        public int class_id { get; set; }
        [Required]
        public string class_name { get; set; }
        [Required]
        public int teacher_id { get; set; }
    }
}
