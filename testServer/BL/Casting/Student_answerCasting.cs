using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Casting
{
    public class Student_answerCasting
    {
        public static student_answer Student_answerToDAL(Student_answerDTO sa)
        {
            return new student_answer()
            {
                ans_id = sa.ans_id,
                student_answer_id = sa.id,
                question_test_id = sa.question_test_id,
                student_id = sa.student_id,
            };
        }
        public static Student_answerDTO Student_answerToDTO(student_answer sa)
        {
            return new Student_answerDTO()
            {
                ans_id = sa.ans_id,
                id = sa.student_answer_id,
                student_id = sa.student_id,
                question_test_id = sa.question_test_id
            };
        }
        public static List<student_answer> Student_answersToDAL(List<Student_answerDTO> answersDTO)
        {
            List<student_answer> answers = new List<student_answer>();
            answersDTO.ToList().ForEach(a => answers.Add(Student_answerToDAL(a)));
            return answers;
        }
        public static List<Student_answerDTO> Student_answersToDTO(List<student_answer> answers)
        {
            List<Student_answerDTO> answersDTO = new List<Student_answerDTO>();
            answers.ToList().ForEach(a => answersDTO.Add(Student_answerToDTO(a)));
            return answersDTO;
        }
    }
}
