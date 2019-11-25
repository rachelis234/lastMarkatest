using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Casting
{
    public class AnswerCasting
    {
        public static answer AnswerToDAL(AnswerDTO ans)
        {
                return new answer()
                {
                    answer_id = ans.answer_id,
                    answer_text = ans.answer_text,
                    question_id = ans.question_id,
                    //question = e.questions.First(q => q.question_id == ans.question_id),
                    //student_answer = e.student_answer.Where(sa => sa.ans_id == ans.answer_id).ToList()
                };
        }
        public static AnswerDTO AnswerToDTO(answer ans)
        {
              return new AnswerDTO()
              {
                  answer_id = ans.answer_id,
                  answer_text = ans.answer_text,
                  question_id = ans.question_id,
                  
              };   
        }
        public static List<answer>AnswersToDAL(List<AnswerDTO>lsdto)
        {
                List<answer> answers = new List<answer>();
                lsdto.ToList().ForEach(a => answers.Add(AnswerToDAL(a)));
                return answers;
        }
        public static List<AnswerDTO> AnswersToDTO(List<answer> lsdal)
        {
               List<AnswerDTO> answers = new List<AnswerDTO>();
               lsdal.ToList().ForEach(a => answers.Add(AnswerToDTO(a)));
               return answers;
        }
    }
}
//public static List<category> CategoriesToDAL(List<CategoryDTO> categoriesDTO)
//{
//    List<category> categories = new List<category>();
//    categoriesDTO.ToList().ForEach(c => categories.Add(CategoryToDAL(c)));
//    return categories;
//}
//public static List<CategoryDTO> CategoriesToDTO(List<category> categories)
//{
//    List<CategoryDTO> categoriesDTO = new List<CategoryDTO>();
//    categories.ToList().ForEach(c => categoriesDTO.Add(CategoryToDTO(c)));
//    return categoriesDTO;
//}
