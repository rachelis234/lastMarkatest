using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
 public class SolveTest
  {

    public TestDTO test { get; set; } = new TestDTO();
    public List<QuestionDTO> questions { get; set; } = new List<QuestionDTO>();
    public List<AnswerDTO> answers { get; set; } = new List<AnswerDTO>();
    public List<AnswerDTO> selectedAnswers { get; set; } = new List<AnswerDTO>();
  }
}
//export class SolveTest
//{
//  test:Test;
//    questions:Question[];
//    answers:Answer[];
//    selectedAnswer:Answer[];
//}
