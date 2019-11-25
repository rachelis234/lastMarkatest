using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class CategoryDTO
    {
        public int category_id { get; set; }
        [Required]
        public string category_name { get; set; }
        [Required]
        public int teacher_id { get; set; }

    }
}
