using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    [RoutePrefix("Teacher")]
    public class TeacherController : ApiController
    {
        [Route("getTeacher")]
        [HttpGet]
        public IHttpActionResult GetTeacher(int userId)
        {
            try
            {
                return Ok(TeacherLogic.GetTeacherByUserId(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}