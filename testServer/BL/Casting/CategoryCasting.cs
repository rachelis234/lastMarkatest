using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Casting
{
    public class CategoryCasting
    {
        public static category CategoryToDAL(CategoryDTO c)
        {
            return new category()
            {
                category_id = c.category_id,
                category_name = c.category_name,
                //sub_category = e.sub_category.Where(ca => ca.category_id == c.category_id).ToList(),
                teacher_id = c.teacher_id,
                //teacher = e.teachers.FirstOrDefault(t => t.user.user_id == c.teacher_id)
            };
        }
        public static CategoryDTO CategoryToDTO(category c)
        {
            return new CategoryDTO()
            {
                category_id = c.category_id,
                category_name = c.category_name,
                teacher_id = c.teacher_id
            };
        }
        public static List<category> CategoriesToDAL(List<CategoryDTO> categoriesDTO)
        {
            List<category> categories = new List<category>();
            categoriesDTO.ToList().ForEach(c => categories.Add(CategoryToDAL(c)));
            return categories;
        }
        public static List<CategoryDTO> CategoriesToDTO(List<category> categories)
        {
            List<CategoryDTO> categoriesDTO = new List<CategoryDTO>();
            categories.ToList().ForEach(c => categoriesDTO.Add(CategoryToDTO(c)));
            return categoriesDTO;
        }
    }
}
