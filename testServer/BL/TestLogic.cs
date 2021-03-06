using BL.Casting;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
	public class TestLogic
	{
		public static List<TestDTO> GetTests()
		{
			using (Entities e = new Entities())
			{
				return TestCasting.TestsToDTO(e.tests.ToList());
			}
		}
		public static TestDTO GetTestById(int id)
		{
			using (Entities e = new Entities())
			{
				try
				{
					var test = e.tests.FirstOrDefault(t => t.test_id == id);
					if (test != null)
					{
						return TestCasting.TestToDTO(test);
					}
					throw new Exception("test is not exists");
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}
		public static List<GeneratedTest> GetTestsForTeacher(int teacherId)
		{
			using (Entities e = new Entities())
			{
				try
				{
					//var classes = e.classes.Where(c => c.teacher_id == teacherId);
					//var tests = e.tests.Where(t => t.classes.FirstOrDefault(c=>c.class_id==classes.FirstOrDefault(cl => cl.class_id == )) == .class_id).ToList();
					//if (tests != null)
					//{
					//    return TestCasting.TestsToDTO(tests);
					//}
					throw new Exception("no tests");
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}
		public static List<TestDTO> GetTestsForCategory(int categoryId)
		{
			using (Entities e = new Entities())
			{
				try
				{
					var subCategory = e.sub_category.Where(s => s.category_id == categoryId).ToList();
					var tests = e.tests.Where(t => t.sub_category.FirstOrDefault(s => s.category_id == categoryId).category_id == categoryId).ToList();
					if (tests != null)
					{
						return TestCasting.TestsToDTO(tests);
					}
					throw new Exception("no tests");
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

		public static SolveTest GetTest(int studentId, DateTime time)
		{
			using (Entities e = new Entities())
			{
				try
				{
					SolveTest sTest = new SolveTest();
					test testDal = new test();


                    var student = e.students.FirstOrDefault(s => s.userId == studentId);
                    if (student != null)
                    {
                        var teacherId = student.@class.teacher_id;
                        var test = e.tests.FirstOrDefault(t => t.teacherId == teacherId
                           && t.test_date == time.Date && t.test_start_time < time.TimeOfDay && t.test_end_time > time.TimeOfDay);
                        var TTT = e.tests.ToList(); 
                        if (test != null)
                        {
                                sTest.test = TestCasting.TestToDTO(test);

                                sTest.questions = QuestionCasting.QuestionsToDTO((test.questions).ToList());
                            var x = e.answers.ToList();
                            var questionsIds = sTest.questions.Select(t => t.question_id).ToList();
                            var y = x.Where(a => questionsIds.Contains(a.question_id)).ToList();
                            sTest.answers = AnswerCasting.AnswersToDTO(y);
                            return sTest;
                        }
                        throw new Exception("no test0");
                    }
                    throw new Exception("no student");

                }
                catch (Exception ex)
				{

					throw ex;
				}
			}
		}
		//create generated test 
		public static WebResult AddGeneratedTest(GeneratedTest newtest)
		{

			using (Entities e = new Entities())
			{
				WebResult wb = new WebResult();
				try
				{
					//add new test
					test t = e.tests.Add(TestCasting.TestToDAL(newtest.test));
                    e.SaveChanges();
					//add rand questions to the new test
					List<question> newQuesList = RandQues(t.test_id, t.level, newtest.american,
						newtest.yesNo, newtest.match, newtest.classes.FirstOrDefault().teacher_id, newtest.subCategories);
					t.classes.AddRange( ClassCasting.ClassesToDAL(newtest.classes));
                    newQuesList.ForEach(q =>
                    {
                        question qq = new question()
                        {
                            question_level = q.question_level,
                            question_id = q.question_id,
                            question_text = q.question_text,
                           //// answers = q.answers,
                           // sub_category = q.sub_category,
                            sub_category_id = q.sub_category_id,
                           // tests = q.tests,
                           // type = q.type,
                            type_id = q.type_id
                        };
                        t.questions.Add(qq);
                    });
					//t.questions.AddRange(newQuesList.ToList());

					wb.status = true;
					wb.message = "succeed";
					wb.value = TestCasting.TestToDTO(t);
					e.SaveChanges();
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
		//create a simple test
		public static WebResult AddSimpleTest(SimpleTest newtest)
		{
			using (Entities e = new Entities())
			{
				WebResult wb = new WebResult();
				try
				{
					//add new test
					var t=e.tests.Add(TestCasting.TestToDAL(newtest.test));
                    //add classes o the new test
                    t.classes=ClassCasting.ClassesToDAL(newtest.classes);
                    //add questions to the new test
                    t.questions=QuestionCasting.QuestionsToDAL(newtest.questions);
					wb.status = true;
					wb.message = "succeed";
					wb.value = TestCasting.TestToDTO(t);
                    e.SaveChanges();
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
		//add rand questions to newListQues  
		private static List<question> RandQues(int test_id, int level, 
			int american, int yesNo, int match, int teacher_id, List<Sub_categoryDTO> subCategories)
		{
			using (Entities e = new Entities())
			{
                var subCategoriesIds = subCategories.Select(s => s.sub_category_id).ToList();
            


                List <question> quesList1 = e.questions
					.Where(q => q.question_level == level && q.sub_category.category.teacher_id == teacher_id
					&& q.type_id == 1 && subCategoriesIds.Contains(q.sub_category_id)).ToList();
				List<question> quesList2 = e.questions
					.Where(q => q.question_level == level && q.sub_category.category.teacher_id == teacher_id 
					&& q.type_id == 2 && subCategoriesIds.Contains(q.sub_category_id)).ToList();
				List<question> quesList3 = e.questions
					.Where(q => q.question_level == level && q.sub_category.category.teacher_id == teacher_id 
					&& q.type_id == 3 && subCategoriesIds.Contains(q.sub_category_id)).ToList();
				List<question> newListQues = new List<question>();

				AddQues(american, quesList1, newListQues);
				AddQues(yesNo, quesList2, newListQues);
				AddQues(match, quesList3, newListQues);
				return newListQues;

			}
		}
		//rand uniq qurstions that they are match to the test definitions.
		private static List<question> AddQues(int indexer,
			List<question> quesList, List<question> newListQues)
		{
			int count;
			int index;
			Random r = new Random();
            if (indexer > quesList.Count)
                indexer = quesList.Count;
			for (int i = 0; i < indexer; i++)
			{
				count = quesList.Count();
				index = r.Next(count);
				newListQues.Add(quesList[index]);
				quesList.RemoveAt(index);
			}
			return newListQues;
		}

		public static void UpdateTest(GeneratedTest newTest)
		{
			using (Entities e = new Entities())
			{
			}
			//todo
		}
		public static void DeleteTest(int TestId)
		{
			using (Entities e = new Entities())
			{
				var test = e.tests.FirstOrDefault(t => t.test_id == TestId);
				if (test != null)
				{
					e.tests.Remove(test);
					e.SaveChanges();
				}
			}
		}
	}
}
