using BL.Casting;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TeacherLogic
    {
        //public List<TeacherDTO> GetTeachers()
        //{
        //    var teachers = e.users.OfType<teacher>().ToList();
        //    return TeacherCasting.TeachersToDTO(teachers);
        //}
        //public TeacherDTO GetTeacher(string name, string password)
        //{
        //    var teachers = e.users.OfType<teacher>().ToList();
        //    return TeacherCasting.TeacherToDTO(teachers.FirstOrDefault(t => t.user_name == name && t.user_password == password));
        //}
        public static TeacherDTO GetTeacherByUserId(int userId)
        {
            using (Entities e = new Entities())
            {
                try
                {
                    var teacher = e.teachers.FirstOrDefault(t => t.userId == userId);
                    if (teacher != null)
                    {
                        return TeacherCasting.TeacherToDTO(teacher);
                    }
                    throw new Exception("UserId is not exists");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        
        public static List<student_markDTO> GetMark(int teacherId)
        {
            using (Entities e = new Entities())
            {
                var studentsIds = e.students.Where(s => s.@class.teacher_id == teacherId).Select(s => s.student_id).ToList();
                var marks = e.students_mark.Where(sm => studentsIds.Contains(sm.student_id)).ToList();
                return student_markCasting.studentsMarkToDTO(marks);
            }
        }

        public void DeleteTeacher(int id)
        {
            using (Entities e = new Entities())
            {
                var teacher = e.users.FirstOrDefault(t => t.user_id == id);
                if (teacher != null)
                {
                    e.users.Remove(teacher);
                    e.SaveChanges();
                }
            }
        }
        public void UpdateTeacher(TeacherDTO t)
        {
            using (Entities e = new Entities())
            {
                teacher teacher = e.teachers.FirstOrDefault(te => te.userId == t.userId);
                //todo updete
                teacher = TeacherCasting.TeacherToDAL(t);



                e.SaveChanges();
            }
        }

    }
}
