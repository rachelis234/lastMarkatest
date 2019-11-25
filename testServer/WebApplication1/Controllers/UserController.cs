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
    [RoutePrefix("User")]
    public class UserController : ApiController
    {
        [Route("signIn")]
        [HttpGet]
        public IHttpActionResult SignIn(string name, string password)
        {
            try
            {
                return Ok(UserLogic.Login(name, password));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("signUp")]
        [HttpPost]
        public IHttpActionResult SignUp([FromBody]TeacherDTO teacher)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(UserLogic.AddUser(teacher));
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
        [Route("forgotPassword")]
        [HttpGet]
        public IHttpActionResult ForgotPassword(string emailAddress)
        {
            try
            {
                UserLogic.ForgotPassword(emailAddress);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
