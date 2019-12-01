using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Casting
{
    public class student_markCasting
    {
        public static students_mark studentMarkToDAL(student_markDTO s)
        {
            return new students_mark()
            {
                mark = s.mark,
                student_id = s.student_id,
                test_id = s.test_id
            };
        }
        public static student_markDTO studentMarkToDTO(students_mark s)
        {
            return new student_markDTO()
            {
                mark=s.mark,
                student_id=s.student_id,
                test_id=s.test_id
            };
        }
        public static List<students_mark> studentsMarkToDAL(List<student_markDTO> students_marksDTO)
        {
            List<students_mark> studentsMark = new List<students_mark>();
            students_marksDTO.ToList().ForEach(c => studentsMark.Add(studentMarkToDAL(c)));
            return studentsMark;
        }
        public static List<student_markDTO> ClassesToDTO(List<students_mark> students_marksDTO)
        {
            List<student_markDTO> studentsMarkDTO = new List<student_markDTO>();
            students_marksDTO.ToList().ForEach(tc => studentsMarkDTO.Add(studentMarkToDTO(tc)));
            return studentsMarkDTO;
        }
    }
}
