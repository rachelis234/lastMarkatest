using BL;
using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace WebApplication1.Controllers
{
  [RoutePrefix("Student")]
  public class StudentController : ApiController
  {
    [Route("addStudents")]
    [HttpPost]
    public HttpResponseMessage AddStudents(int classId)
    {
      try
      {
        HttpResponseMessage response = new HttpResponseMessage();
        var httpRequest = HttpContext.Current.Request;
        if (httpRequest.Files.Count > 0)
        {
          foreach (string file in httpRequest.Files)
          {
            HttpPostedFile postedFile = httpRequest.Files[file];
            //string filePath = HttpContext.Current.Server.MapPath("~/UploadFiles/" + postedFile.FileName);
            //postedFile.SaveAs(filePath);
            string extension = Path.GetExtension(postedFile.FileName);
            if (!extension.Equals(".xlsx") && !extension.Equals(".xls"))
            {
              HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.NotImplemented);
              message.Content = new StringContent("file is not excel");
              throw new HttpResponseException(message);
            }
            StudentLogic.AddStudents(postedFile, classId);
          }
        }
        return response;
      }
      catch (Exception ex)
      {
        return null;
      }
    }

    [HttpGet]
    [Route("Generate")]
    public HttpResponseMessage Generate()
    {
      var stream = new MemoryStream(File.ReadAllBytes(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["pupilsListTemplate"])));
      // processing the stream.

      var result = new HttpResponseMessage(HttpStatusCode.OK)
      {
        Content = new ByteArrayContent(stream.ToArray())
      };
      result.Content.Headers.ContentDisposition =
          new ContentDispositionHeaderValue("attachment")
          {
            FileName = "pupils.xlsx"
          };
      result.Content.Headers.ContentType =
          new MediaTypeHeaderValue("application/octet-stream");

      return result;
    }

    [Route("addStudent")]
    [HttpPost]
    public IHttpActionResult AddStudent([FromBody]StudentDTO student)
    {
      try
      {
        if (ModelState.IsValid)
        {
          return Ok(UserLogic.AddUser(student));
        }
        var errors = ModelState.Select(x => x.Value.Errors)
           .Where(y => y.Count > 0)
           .ToList();
        return BadRequest(errors.ToString());
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
    [Route("deleteStudent")]
    [HttpGet]
    public IHttpActionResult DeleteStudent(int studentId)
    {
      try
      {
        StudentLogic.DeleteStudent(studentId);
        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
    [Route("editStudent")]
    [HttpPost]
    public IHttpActionResult EditStudent([FromBody]StudentDTO student)
    {
      try
      {
        return Ok(StudentLogic.UpdateStudent(student));
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}
