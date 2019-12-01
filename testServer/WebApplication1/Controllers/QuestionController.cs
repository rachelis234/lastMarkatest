using BL;
using DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    [RoutePrefix("Question")]
    public class QuestionController : ApiController
    {
        [Route("getQuestionsForSubCat")]
        [HttpGet]
        public WebResult GetQuestionsForSubCat(int subCategoryId, int level)
        {
            WebResult wb = new WebResult();
            try
            {
                wb.value = QuestionLogic.GetQuestions(subCategoryId, level);
                wb.message = "success";
                wb.status = true;
                return wb;
            }
            catch (Exception ex)
            {
                wb.status = false;
                wb.message = ex.Message;
                return wb;
            }
        }
        [Route("addQuestion")]
        [HttpPost]
        public WebResult AddQuestion([FromBody]JObject obj)
        {
            QuestionDTO question = obj["ques"].ToObject<QuestionDTO>();
            List<AnswerDTO> answers = obj["ans"].ToObject<List<AnswerDTO>>();
            WebResult wr = new WebResult();
            try
            {
                wr.value = QuestionLogic.AddQuestion(question, answers);
                wr.message = "success";
                wr.status = true;
                return wr;
            }
            catch (Exception ex)
            {
                wr.status = false;
                wr.message = ex.Message;
                return wr;
            }
        }
        [Route("getQuestions")]
        [HttpGet]
        public WebResult GetQuestions(int teacherId)
        {
            WebResult wb = new WebResult();
            try
            {
                wb.value = QuestionLogic.GetQuestionsForTeacher(teacherId);
                wb.message = "success";
                wb.status = true;
                return wb;
            }
            catch (Exception ex)
            {
                wb.status = false;
                wb.message = ex.Message;
                return wb;
            }
        }
    }
}
