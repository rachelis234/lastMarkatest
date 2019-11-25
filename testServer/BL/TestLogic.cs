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

		public static SolveTest GetTest(int studentId, long time)
		{
			using (Entities e = new Entities())
			{
				try
				{
					SolveTest sTest = new SolveTest();
					test testDal = new test();



					sTest.test = TestCasting.TestToDTO(testDal = e.tests.FirstOrDefault(t => t.sub_category.FirstOrDefault().category.teacher_id == e.students.FirstOrDefault(s => s.userId == studentId).@class.teacher_id));

					if (sTest.test != null)
					{
						sTest.questions = QuestionCasting.QuestionsToDTO((testDal.questions).ToList());
						var x = e.answers.ToList();

						var y = x.Where(a => (sTest.questions.FirstOrDefault(q => q.question_id == a.question_id)) != null).ToList();
						sTest.answers = AnswerCasting.AnswersToDTO(y);
						return sTest;
					}
					throw new Exception("no test0");
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
					//add rand questions to the new test
					List<question> newQuesList = RandQues(t.test_id, t.level, newtest.american,
						newtest.yesNo, newtest.match, newtest.classes.FirstOrDefault().teacher_id, newtest.subCategories);
					e.tests.Last().classes = ClassCasting.ClassesToDAL(newtest.classes);
					e.tests.Last().questions.AddRange(newQuesList);

					wb.status = true;
					wb.message = "succeed";
					wb.value = TestCasting.TestToDTO(e.tests.Last());
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
					e.tests.Add(TestCasting.TestToDAL(newtest.test));
					//add classes o the new test
					e.tests.Last().classes.AddRange(ClassCasting.ClassesToDAL(newtest.classes));
					//add questions to the new test
					e.tests.Last().questions.AddRange(QuestionCasting.QuestionsToDAL(newtest.questions));
					wb.status = true;
					wb.message = "succeed";
					wb.value = TestCasting.TestToDTO(e.tests.Last());
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

				List<question> quesList1 = e.questions
					.Where(q => q.question_level == level && q.sub_category.category.teacher_id == teacher_id
					&& q.type_id == 1 && (subCategories.FirstOrDefault(s => s.sub_category_id == q.sub_category_id)) != null).ToList();
				List<question> quesList2 = e.questions
					.Where(q => q.question_level == level && q.sub_category.category.teacher_id == teacher_id 
					&& q.type_id == 2 && (subCategories.FirstOrDefault(s => s.sub_category_id == q.sub_category_id)) != null).ToList();
				List<question> quesList3 = e.questions
					.Where(q => q.question_level == level && q.sub_category.category.teacher_id == teacher_id 
					&& q.type_id == 3 && (subCategories.FirstOrDefault(s => s.sub_category_id == q.sub_category_id)) != null).ToList();
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
