using BL.Casting;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UserLogic
    {
		//login and return student or teacher.
        public static object Login(string name, string password)
        {
            using (Entities e = new Entities())
            {
                try
                {
                    user user = e.users.FirstOrDefault(u => u.user_name == name && u.user_password == password);
                    if (user != null)
                    {
						//if trhec user is teacher
                        if (user.status == 1)
                        {
                            var te = e.teachers.FirstOrDefault(t => t.userId == user.user_id);
                            return TeacherCasting.TeacherToDTO(te);
                        }
						//if the user user teacher
                        if (user.status == 2)
                        {
              var x=e.students.FirstOrDefault(s => s.userId == user.user_id);
                            return StudentCasting.StudentToDTO(x);
                        }
                    }
                    throw new Exception("UserName or Password are not correct");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static Object AddUser<T>(T user)
        {
            using (Entities e = new Entities())
            {
                try
                {

                    if (user is TeacherDTO teacher)
                    {
                        if (e.users.FirstOrDefault(t => t.user_name == teacher.user.user_name || t.user_id_number == teacher.user.user_id_number) != null)
                        {
                            throw new Exception("user name is unique");
                        }
                        else
                        {
                            e.users.Add(UserCasting.UserToDAL(teacher.user));
                            var t = e.teachers.Add(TeacherCasting.TeacherToDAL(teacher));
                            e.SaveChanges();
                            return TeacherCasting.TeacherToDTO(t);
                        }
                    }
                    else if (user is StudentDTO student)
                    {
                        if (e.users.FirstOrDefault(t => t.user_name == student.user.user_name || t.user_id_number == student.user.user_id_number) != null)
                        {
                            throw new Exception("user name is unique");
                        }
                        else
                        {
                            e.users.Add(UserCasting.UserToDAL(student.user));
                            var s = e.students.Add(StudentCasting.StudentToDAL(student));
                            e.SaveChanges();
                            return StudentCasting.StudentToDTO(s);
                        }
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public static void DeleteUserById(int id)
        {
            using (Entities e = new Entities())
            {
                user user = e.users.FirstOrDefault(u => u.user_id == id);
                e.users.Remove(user);
                if (user.status == 1)
                {
                    var teacher = e.teachers.FirstOrDefault(t => t.userId == id);
                    if (teacher != null)
                    {
                        e.teachers.Remove(teacher);
                        e.SaveChanges();
                    }

                }
                else if (user.status == 2)
                {
                    var student = e.students.FirstOrDefault(s => s.userId == id);
                    if (student != null)
                    {
                        e.students.Remove(student);
                        e.SaveChanges();
                    }
                }
            }
        }
        public static void updateUser<T>(T newUser)
        {
            using (Entities e = new Entities())
            {
                if (newUser is TeacherDTO newTeacher)
                {
                    var teacher = e.teachers.FirstOrDefault(t => t.userId == newTeacher.userId);
                    //todo update
                }
                else if (newUser is StudentDTO newStudent)
                {
                    //todo update
                }
            }
        }
        public static void ForgotPassword(string emailAddress)
        {
            using (Entities e = new Entities())
            {
                try
                {
                    //todo:case that there are some emails with same address
                    var pass = e.users.FirstOrDefault(u => u.user_mail == emailAddress).user_password.ToString();
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress("your_email_address@gmail.com");
                    mail.To.Add(emailAddress);
                    mail.Subject = "Your password,please login with this password";
                    //mail.Body = "This is for testing SMTP mail from GMAIL";
                    mail.Body = pass;

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
