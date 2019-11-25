using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Casting
{
    public class Sub_categoryCasting
    {
        public static sub_category Sub_categoryToDAL(Sub_categoryDTO s)
        {
            return new sub_category()
            {
                //category = e.categories.FirstOrDefault(c => c.category_id == s.category_id),
                category_id = s.category_id,
                //questions = e.questions.Where(q => q.sub_category_id == s.sub_category_id).ToList(),
                sub_category_id = s.sub_category_id,
                sub_category_name = s.sub_category_name
            };
        }
        public static Sub_categoryDTO Sub_categoryToDTO(sub_category s)
        {
            return new Sub_categoryDTO()
            {
                category_id = s.category_id,
                sub_category_id = s.sub_category_id,
                sub_category_name = s.sub_category_name
            };
        }
        public static List<sub_category> Sub_categoriesToDAL(List<Sub_categoryDTO> categoriesDTO)
        {
            List<sub_category> categories = new List<sub_category>();
            categoriesDTO.ToList().ForEach(s => categories.Add(Sub_categoryToDAL(s)));
            return categories;
        }
        public static List<Sub_categoryDTO> Sub_categoriesToDTO(List<sub_category> categories)
        {
            List<Sub_categoryDTO> categoriesDTO = new List<Sub_categoryDTO>();
            categories.ToList().ForEach(s => categoriesDTO.Add(Sub_categoryToDTO(s)));
            return categoriesDTO;
        }
    }
}
