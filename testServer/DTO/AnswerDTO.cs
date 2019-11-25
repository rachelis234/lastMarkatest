using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AnswerDTO
    {
        public int answer_id { get; set; }
        public int question_id { get; set; }
        public string answer_text { get; set; }
    }
}
