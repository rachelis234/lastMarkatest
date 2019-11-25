using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Casting
{
    public class ClassCasting
    {
        public static @class ClassToDAL(ClassDTO c)
        {
            //var students = e.users.OfType<student>();
            //var teachers = e.users.OfType<teacher>();
            var cls = new @class()
            {
                class_id = c.class_id,
                class_name = c.class_name,
                //students = e.students.Where(s => s.class_id == c.class_id).ToList(),
                //teacher = e.teachers.FirstOrDefault(t => t.teacher_id == c.teacher_id),
                teacher_id = c.teacher_id
                //class_test = e.class_test.Where(ct => ct.class_id == c.class_id).ToList()
            };
            return cls;
        }
        public static ClassDTO ClassToDTO(@class c)
        {
            return new ClassDTO()
            {
                class_id = c.class_id,
                class_name = c.class_name,
                teacher_id = c.teacher_id
            };
        }
        public static List<@class> ClassesToDAL(List<ClassDTO> classesDTO)
        {
            List<@class> classes = new List<@class>();
            classesDTO.ToList().ForEach(c => classes.Add(ClassToDAL(c)));
            return classes;
        }
        public static List<ClassDTO> ClassesToDTO(List<@class> classes)
        {
            List<ClassDTO> classesDTO = new List<ClassDTO>();
            classes.ToList().ForEach(tc => classesDTO.Add(ClassToDTO(tc)));
            return classesDTO;
        }
    }
}
