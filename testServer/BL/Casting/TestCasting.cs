using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Casting
{
    public class TestCasting
    {
        public static test TestToDAL(TestDTO t)
        {
            return new test()
            {
                over_mark = t.over_mark,
                test_date = t.test_date,
                test_start_time = t.test_start_time,
                test_end_time = t.test_end_time,
                test_id = t.test_id,
                // test_question = e.test_question.Where(tq => tq.test_id == t.test_id).ToList(),
                
                level = t.level,
                quesPercent = t.quesPercent
                //class_test = e.class_test.Where(c => c.test_id == t.test_id).ToList()
                //            public int test_id { get; set; }
                //public System.DateTime test_date_start { get; set; }
                //public System.DateTime test_date_end { get; set; }
                //public double over_mark { get; set; }
                //public int class_id { get; set; }
                //public bool enable { get; set; }
                //public int level { get; set; }
            };
        }
        public static TestDTO TestToDTO(test t)
        {
            return new TestDTO()
            {
                test_date = t.test_date,
                test_start_time = t.test_start_time,
                test_end_time = t.test_end_time,
                test_id = t.test_id,
                over_mark = t.over_mark,
                
                level = t.level
            };
        }
        public static List<test> TestsToDAL(List<TestDTO> testsDTO)
        {
            List<test> tests = new List<test>();
            testsDTO.ToList().ForEach(t => tests.Add(TestToDAL(t)));
            return tests;
        }
        public static List<TestDTO> TestsToDTO(List<test> tests)
        {
            List<TestDTO> testsDTO = new List<TestDTO>();
            tests.ToList().ForEach(t => testsDTO.Add(TestToDTO(t)));
            return testsDTO;
        }
    }
}
