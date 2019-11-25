using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class UserDTO
    {
        public int user_id { get; set; }
        [Required]
        public string user_id_number { get; set; }
        [Required]

        public string user_password { get; set; }
        [Required]

        public string user_name { get; set; }
        [Required]

        public string user_mail { get; set; }
        [Required]

        public int status { get; set; }
    }
}
