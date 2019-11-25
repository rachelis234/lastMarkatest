using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Sub_categoryDTO
    {
        public int sub_category_id { get; set; }
        [Required]
        public int category_id { get; set; }
        [Required]
        public string sub_category_name { get; set; }
    }
}
