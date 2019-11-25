using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Casting
{
    public class TeacherCasting
    {
        public static teacher TeacherToDAL(TeacherDTO t)
        {
            return new teacher()
            {
                design_id = t.design_id,
                userId = t.userId,
                teacher_id = t.teacherId,
                // user = e.users.FirstOrDefault(u=>u.user_id==t.userId),
                //categories=e.categories.Where(c=>c.teacher_id==t.teacherId).ToList(),
                //classes=e.classes.Where(c=>c.teacher_id==t.teacherId).ToList()
                //design = e.designs.FirstOrDefault(d => d.design_id == t.design_id)
            };
        }
        public static TeacherDTO TeacherToDTO(teacher t)
        {
            return new TeacherDTO()
            {
                teacherId = t.teacher_id,
                userId = t.userId,
                design_id = t.design_id,
                user = UserCasting.UserToDTO(t.user)
            };
        }
        public static List<teacher> TeachersToDAL(List<TeacherDTO> teachersDTO)
        {
            List<teacher> teachers = new List<teacher>();
            teachersDTO.ToList().ForEach(t => teachers.Add(TeacherToDAL(t)));
            return teachers;
        }
        public static List<TeacherDTO> TeachersToDTO(List<teacher> teachers)
        {
            List<TeacherDTO> teachersDTO = new List<TeacherDTO>();
            teachers.ToList().ForEach(t => teachersDTO.Add(TeacherToDTO(t)));
            return teachersDTO;
        }
    }
}
