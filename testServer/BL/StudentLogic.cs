using BL.Casting;
using DAL;
//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Spreadsheet;
using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using OfficeOpenXml;
using System.Data.OleDb;
using System.IO;
using System.Configuration;

namespace BL
{
    public class StudentLogic
    {
        //פונקציה להחזרת כל התלמידים של מורה מסוים
        public static StudentDTO GetStudentByUserId(int userId)
        {
            using (Entities e = new Entities())
            {
                try
                {
                    var student = e.students.FirstOrDefault(s => s.userId == userId);
                    if (student != null)
                    {
                        return StudentCasting.StudentToDTO(student);
                    }
                    throw new Exception("UserId is not exists");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        //פונקציה להוספת תלמיד
        public static void AddStudent(StudentDTO s)
        {

        }
        //פונקציה להוספת תלמידים מתוך קובץ, הפונקציה עוברת על קובץ  אקסל שהמורה העלה ומכניסה כל תלמיד למאגר 
        public static void AddStudents(HttpPostedFile postedFile, int classId)
        {
            try
            {
                string filePath = string.Empty;
                if (postedFile != null)
                {
                    string path = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["UploadFilesFolder"]);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    filePath = path + "/" + Path.GetFileName(postedFile.FileName);
                    string extension = Path.GetExtension(postedFile.FileName);
                    postedFile.SaveAs(filePath);

                    string conString = string.Empty;
                    switch (extension)
                    {
                        case ".xls": //Excel 97-03.
                                     //conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                            conString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                                     "Data Source = '" + filePath +
                                     "';Extended Properties=\"Excel 8.0;HDR=YES;\"";
                            break;
                        case ".xlsx": //Excel 07 and above.
                                      //conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                            conString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                     "Data Source='" + filePath +
                                     "';Extended Properties=\"Excel 12.0;HDR=YES;\"";
                            break;
                    }

                    DataTable dt = new DataTable();
                    //conString = string.Format(conString, filePath);

                    using (OleDbConnection connExcel = new OleDbConnection(conString))
                    {
                        using (OleDbCommand cmdExcel = new OleDbCommand())
                        {
                            using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                            {
                                cmdExcel.Connection = connExcel;

                                //Get the name of First Sheet.
                                connExcel.Open();
                                DataTable dtExcelSchema;
                                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                                string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                                connExcel.Close();

                                //Read Data from First Sheet.
                                connExcel.Open();
                                cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
                                odaExcel.SelectCommand = cmdExcel;
                                odaExcel.Fill(dt);
                                connExcel.Close();
                            }
                        }
                    }

                    using (Entities e = new Entities())
                    {
                        //Insert records to database table.
                        List<user> incorrectUsers = new List<user>();
                        foreach (DataRow row in dt.Rows)
                        {
                            user newUser = new user();
                            newUser.user_mail = row[4].ToString();
                            newUser.user_id_number = row[0].ToString();
                            newUser.user_name = row[1].ToString();
                            newUser.status = 2;
                            newUser.user_password = row[3].ToString();
                            //TODO: add  validation for the data
                            if (e.users.FirstOrDefault(u => u.user_id_number == newUser.user_id_number || u.user_name == newUser.user_name) != null)
                            {
                                incorrectUsers.Add(newUser);
                                continue;
                            }

                            e.users.Add(newUser);
                            e.SaveChanges();
                            StudentDTO s = new StudentDTO();
                            s.class_id = classId;
                            s.extra_time = (row[2].ToString() == "1") ? true : false;
                            s.userId = e.users.FirstOrDefault(u => u.user_name == newUser.user_name && u.user_password == newUser.user_password).user_id;
                            s.user = UserCasting.UserToDTO(e.users.FirstOrDefault(u => u.user_id == newUser.user_id));
                            e.students.Add(StudentCasting.StudentToDAL(s));
                        }
                        e.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        //פונקציה למחיקת תלמיד
        public static void DeleteStudent(int id)
        {
            using (Entities e = new Entities())
            {
                var student = e.students.FirstOrDefault(s => s.userId == id);
                if (student != null)
                {
                    e.students.Remove(student);
                    e.users.Remove(student.user);
                    e.SaveChanges();
                }
            }
        }
        //פונקציה לעדכון נתוני תלמיד
        public static StudentDTO UpdateStudent(StudentDTO s)
        {
            using (Entities e = new Entities())
            {
                e.Entry(UserCasting.UserToDAL(s.user)).State = EntityState.Modified;
                e.Entry(StudentCasting.StudentToDAL(s)).State = EntityState.Modified;
                e.SaveChanges();
                var st = e.students.FirstOrDefault(ss => ss.userId == s.userId);
                return StudentCasting.StudentToDTO(st);
            }
        }
    }
}
