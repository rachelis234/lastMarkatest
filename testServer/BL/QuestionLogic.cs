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
  public class QuestionLogic
  {
    public static List<QuestionDTO> GetQuestions(int subCategoryId, int level)
    {
      using (Entities e = new Entities())
      {

        return QuestionCasting.QuestionsToDTO
  (e.questions.Where(q => q.question_level == level &&
  q.sub_category_id == subCategoryId).ToList());
      }
    }
    public static QuestionDTO GetQuestion(int teacherId, int sub_categoryId, int level = 0, int typeId = 0)
    {
      using (Entities e = new Entities())
      {
        return QuestionCasting.QuestionToDTO(e.questions.FirstOrDefault(q => ((q.sub_category_id == sub_categoryId
    ) && (level == 0 || q.question_level == level
    ) && (typeId == 0 || q.type_id == typeId
    ) && (q.sub_category.category.teacher_id == teacherId))));
      }
    }
    public static QuestionDTO AddQuestion(QuestionDTO question)
    {
      using (Entities e = new Entities())
      {
        try
        {
          if (e.sub_category.FirstOrDefault(c => c.sub_category_id == question.sub_category_id) == null)
          {
            throw new Exception("sub category id is not exists");
          }
          var q = e.questions.Add(QuestionCasting.QuestionToDAL(question));
          e.SaveChanges();
          return QuestionCasting.QuestionToDTO(q);
        }
        catch (Exception ex)
        {
          throw ex;
        }
      }
    }
    public static void DeleteQuestion(int id)
    {
      using (Entities e = new Entities())
      {
        var question = e.questions.FirstOrDefault(q => q.question_id == id);
        if (question != null)
        {
          e.questions.Remove(question);
          e.SaveChanges();
        }
      }
    }
    public void UpdateQuestion(QuestionDTO q)
    {
      using (Entities e = new Entities())
      {
        question question = e.questions.FirstOrDefault();
        //todo
      }
    }
    public static List<QuestionDTO> GetQuestionsForTeacher(int teacherId)
    {
      using (Entities e = new Entities())
      {
        var ques = e.questions.ToList();
        var q = ques.Where(qu => qu.sub_category.category.teacher_id == teacherId);
        return QuestionCasting.QuestionsToDTO(q.ToList());
      }
    }
  }
}
