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
    public class ClassLogic
    {
        public static ClassDTO AddClass(ClassDTO cls)
        {
            using (Entities e = new Entities())
            {
                var c = e.teachers.FirstOrDefault(t => t.teacher_id == cls.teacher_id);
                if (c == null)
                {
                    throw new Exception("teacher id is not exists");
                }
                var cl = e.classes.FirstOrDefault(cc => cc.teacher_id == cls.teacher_id && cc.class_name == cls.class_name);
                if (cl != null)
                {
                    throw new Exception("class name is exists");
                }
                var added = e.classes.Add(ClassCasting.ClassToDAL(cls));
                e.SaveChanges();
                return ClassCasting.ClassToDTO(added);
            }
        }
        public static ClassDTO GetClassById(int classId)
        {
            using (Entities e = new Entities())
            {
                try
                {
                    var cls = e.classes.FirstOrDefault(c => c.class_id == classId);
                    if (cls != null)
                    {
                        return ClassCasting.ClassToDTO(cls);
                    }
                    throw new Exception("class is not exists");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public static List<ClassDTO> GetClasses()
        {
            using (Entities e = new Entities())
            {
                return ClassCasting.ClassesToDTO(e.classes.ToList());
            }
        }
        public static List<ClassDTO> GetClassesByTeacherId(int teacherId)
        {
            using (Entities e = new Entities())
            {
                try
                {
                    var classes = e.classes.Where(c => c.teacher_id == teacherId).ToList();
                    if (classes != null)
                    {
                        return ClassCasting.ClassesToDTO(classes);
                    }
                    throw new Exception("no classes");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public static void UpdateClass(ClassDTO newClass)
        {
            using (Entities e = new Entities())
            {
                //todo
            }
        }
        public static void DeleteClass(int classId)
        {
            using (Entities e = new Entities())
            {
                var cls = e.classes.FirstOrDefault(c => c.class_id == classId);
                if (cls != null)
                {
                    e.classes.Remove(cls);
                    e.SaveChanges();
                }
            }
        }
        public static List<StudentDTO> GetStudentsForClass(int classId)
        {
            using (Entities e = new Entities())
            {
                try
                {
                    var students = e.students.Where(s => s.class_id == classId).ToList();
                    if (students != null)
                    {
                        return StudentCasting.StudentsToDTO(students);
                    }
                    throw new Exception("no students");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
