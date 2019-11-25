using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class QuestionDTO
    {
        public int question_id { get; set; }
        public int sub_category_id { get; set; }
        public int type_id { get; set; }
        public string question_text { get; set; }
        public int level { get; set; }
    }
}
