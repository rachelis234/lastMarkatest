using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Casting
{
    public class StudentCasting
    {
        public static student StudentToDAL(StudentDTO st)
        {
            return new student()
            {
                student_id = st.studentId,
                // @class = e.classes.FirstOrDefault(c => c.class_id == st.class_id),
                class_id = st.class_id,
                extra_time = st.extra_time,
                //student_answer = e.student_answer.Where(s => s.student_id == st.userId).ToList(),
                userId = st.userId,
                //user=e.users.FirstOrDefault(u=>u.user_id==st.userId)
            };
        }
        public static StudentDTO StudentToDTO(student s)
        {
            return new StudentDTO()
            {
                class_id = s.class_id,
                extra_time = s.extra_time,
                userId = s.user.user_id,
                studentId = s.student_id,
                user = UserCasting.UserToDTO(s.user)
            };
        }
        public static List<student> StudentsToDAL(List<StudentDTO> studentsDTO)
        {
            List<student> students = new List<student>();
            studentsDTO.ToList().ForEach(s => students.Add(StudentToDAL(s)));
            return students;
        }
        public static List<StudentDTO> StudentsToDTO(List<student> students)
        {
            List<StudentDTO> studentsDTO = new List<StudentDTO>();
            students.ToList().ForEach(s => studentsDTO.Add(StudentToDTO(s)));
            return studentsDTO;
        }
    }
}
