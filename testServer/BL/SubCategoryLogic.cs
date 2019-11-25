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
    public class SubCategoryLogic
    {
        public static List<Sub_categoryDTO> GetSubCategories()
        {
            using (Entities e = new Entities())
            {
                return Sub_categoryCasting.Sub_categoriesToDTO(e.sub_category.ToList());
            }
        }
        public static Sub_categoryDTO GetSubCategoryById(int id)
        {
            using (Entities e = new Entities())
            {
                var subCategory = e.sub_category.FirstOrDefault(s => s.sub_category_id == id);
                return Sub_categoryCasting.Sub_categoryToDTO(subCategory);
            }
        }
        public static List<Sub_categoryDTO> GetSubCategoriesForTeacher(int teacherId)
        {
            using (Entities e = new Entities())
            {
                var subCategories = e.sub_category.Where(s => s.category.teacher_id == teacherId).ToList();
                return Sub_categoryCasting.Sub_categoriesToDTO(subCategories);
            }
        }
        public static List<Sub_categoryDTO> GetSubCategoriesForCategory(int categoryId)
        {
            using (Entities e = new Entities())
            {
                try
                {
                    var subCategories = e.sub_category.Where(s => s.category_id == categoryId).ToList();
                    if (subCategories != null)
                    {
                        return Sub_categoryCasting.Sub_categoriesToDTO(subCategories);
                    }
                    throw new Exception("no sub categories");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public static Sub_categoryDTO AddSubCategory(Sub_categoryDTO subCategory)
        {
            using (Entities e = new Entities())
            {
                category category = e.categories.FirstOrDefault(c => c.category_id == subCategory.category_id);
                if (category == null)
                {
                    throw new Exception("category id is not exists");
                }
                sub_category sc = e.sub_category.Where(s => s.category_id == category.category_id && s.category.teacher_id == category.teacher_id && s.sub_category_name == subCategory.sub_category_name).FirstOrDefault();
                if (sc != null)
                {
                    throw new Exception("sub category name is exists");
                }
                var added = e.sub_category.Add(Sub_categoryCasting.Sub_categoryToDAL(subCategory));
                e.SaveChanges();
                return Sub_categoryCasting.Sub_categoryToDTO(added);
            }
        }
        public static void DeleteSubCategory(int subCategoryId)
        {
            using (Entities e = new Entities())
            {
                var subCat = e.sub_category.FirstOrDefault(s => s.sub_category_id == subCategoryId);
                if (subCat != null)
                {
                    e.sub_category.Remove(subCat);
                    e.SaveChanges();
                }
            }
        }
    }
}
