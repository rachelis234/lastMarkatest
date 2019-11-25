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
    [RoutePrefix("Class")]
    public class ClassController : ApiController
    {
        [Route("addClass")]
        [HttpPost]
        public IHttpActionResult AddClass([FromBody]ClassDTO cls)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(ClassLogic.AddClass(cls));
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
        [Route("getClassesForTeacher")]
        [HttpGet]
        public IHttpActionResult GetClassesForTeacher(int teacherId)
        {
            try
            {
                return Ok(ClassLogic.GetClassesByTeacherId(teacherId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("getStudentsForClass")]
        [HttpGet]
        public IHttpActionResult GetStudentsForClass(int classId)
        {
            try
            {
                return Ok(ClassLogic.GetStudentsForClass(classId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
