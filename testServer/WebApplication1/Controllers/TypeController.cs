using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    [RoutePrefix("Type")]
    public class TypeController : ApiController
    {
        [Route("getTypes")]
        [HttpGet]
        public IHttpActionResult GetTypes()
        {
            try
            {
                return Ok(TypeLogic.GetTypes());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
