using BL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
  [RoutePrefix("Test")]
  public class TestController : ApiController
  {
    //AddGeneratedTest------------------------------------------------------------------------------
    [Route("addGeneratedTest")]
    [HttpPost]
    public IHttpActionResult AddGeneratedTest([FromBody]GeneratedTest newtest)
    {
      try
      {
        if (ModelState.IsValid)
        {

          return Ok(TestLogic.AddGeneratedTest(newtest));
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
    //AddSimpleTest----------------------------------------------------------------------------------
    [Route("addSimpleTest")]
    [HttpPost]
    public IHttpActionResult AddSimpleTest([FromBody]SimpleTest newtest)
    {
      try
      {
        if (ModelState.IsValid)
        {

          return Ok(TestLogic.AddSimpleTest(newtest));
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
    //GetTestsForTeacher-----------------------------------------------------------------------------
    [Route("getTestsForTeacher")]
    [HttpGet]
    public WebResult GetTestsForTeacher(int teacherId)
    {
      WebResult wb = new WebResult();
      try
      {
        wb.value = TestLogic.GetTestsForTeacher(teacherId);
        wb.message = "success";
        wb.status = true;
        return wb;
      }
      catch (Exception ex)
      {
        wb.message = ex.Message;
        wb.status = false;
        return wb;
      }
    }
    [Route("getTest")]
    [HttpGet]
    public WebResult GetTest(int id, long time)
    {
      WebResult wb = new WebResult();

      try
      {
        wb.status = true;
        wb.message = "success";
        wb.value = TestLogic.GetTest(id, time);
        return wb;
      }
      catch (Exception e)
      {

        wb.status = false;
        wb.message = e.Message;
        return wb;
      }
    }
  }
}
