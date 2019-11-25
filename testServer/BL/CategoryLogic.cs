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
    public class CategoryLogic
    {
        public static List<CategoryDTO> GetCategories()
        {
            using (Entities e = new Entities())
            {
                return CategoryCasting.CategoriesToDTO(e.categories.ToList());
            }
        }
        public static CategoryDTO GetCategoryById(int id)
        {
            using (Entities e = new Entities())
            {
                try
                {
                    var category = e.categories.FirstOrDefault(c => c.category_id == id);
                    if (category != null)
                    {
                        return CategoryCasting.CategoryToDTO(category);
                    }
                    throw new Exception("category is not exists");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public static List<CategoryDTO> GetCategoriesForTeacher(int teacherId)
        {
            using (Entities e = new Entities())
            {
                try
                {
                    var categories = e.categories.Where(c => c.teacher_id == teacherId).ToList();
                    if (categories != null)
                    {
                        return CategoryCasting.CategoriesToDTO(categories);
                    }
                    throw new Exception("no categories");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public static CategoryDTO GetCategoryForSubCategory(int subCategoryId)
        {
            using (Entities e = new Entities())
            {
                return CategoryCasting.CategoryToDTO(e.sub_category.Find(subCategoryId).category);
            }
        }
        public static CategoryDTO AddCategory(CategoryDTO category)
        {
            using (Entities e = new Entities())
            {
                var cat = e.teachers.FirstOrDefault(t => t.teacher_id == category.teacher_id);
                if (cat == null)
                {
                    throw new Exception("teacher id is not exists");
                }
                category ca = e.categories.Where(c => c.teacher_id == category.teacher_id && c.category_name == category.category_name).FirstOrDefault();
                if (ca != null)
                {
                    throw new Exception("category name is exists");
                }
                else
                {
                    var c = e.categories.Add(CategoryCasting.CategoryToDAL(category));
                    e.SaveChanges();
                    return CategoryCasting.CategoryToDTO(c);
                }
            }
        }
        public static void UpdateCategory(CategoryDTO newCategory)
        {
            using (Entities e = new Entities())
            {
                //todo
            }
        }
        public static void DeleteCategory(int categoryId)
        {
            using (Entities e = new Entities())
            {
                var category = e.categories.FirstOrDefault(c => c.category_id == categoryId);
                if (category != null)
                {
                    e.categories.Remove(category);
                    e.SaveChanges();
                }
            }
        }
    }
}