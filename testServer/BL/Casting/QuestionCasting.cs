using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Casting
{
    public class QuestionCasting
    {
        public static question QuestionToDAL(QuestionDTO ques)
        {
            return new question()
            {
                question_id = ques.question_id,
                question_text = ques.question_text,
                sub_category_id = ques.sub_category_id,
                question_level = ques.level,
                type_id = ques.type_id,
            };
        }
        public static QuestionDTO QuestionToDTO(question ques)
        {
            return new QuestionDTO()
            {
                question_id = ques.question_id,
                question_text = ques.question_text,
                sub_category_id = ques.sub_category_id,
                level = ques.question_level,
                type_id = ques.type_id,
            };
        }
        public static List<question> QuestionsToDAL(List<QuestionDTO> questionsDTO)
        {
            List<question> questions = new List<question>();
            questionsDTO.ToList().ForEach(q => questions.Add(QuestionToDAL(q)));
            return questions;
        }
        public static List<QuestionDTO> QuestionsToDTO(List<question> questions)
        {
            List<QuestionDTO> questionsDTO = new List<QuestionDTO>();
            questions.ToList().ForEach(q => questionsDTO.Add(QuestionToDTO(q)));
            return questionsDTO;
        }
    }
}
