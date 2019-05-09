using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuickKartDataAccessLayer
{
    public class QuickKartRepository
    {
        private QuickKartDBContext Context { get; set; }
        public QuickKartRepository()
        {
            Context = new QuickKartDBContext();
        }

        public string ValidateLoginUsingLinq(string emailId, string password)
        {
            string roleName = "";
            var objUser = (from usr in Context.Users
                           where usr.EmailId == emailId && usr.UserPassword == password
                           select usr).FirstOrDefault<User>();
            if (objUser != null)
            {
                roleName = objUser.Role.RoleName;
            }
            else
            {
                roleName = "Invalid Credentials";
            }
            return roleName;
        }

        public List<Category> GetCategoriesUsingLinq()
        {
            List<Category> lstCategories = null;
            try
            {
                lstCategories = (from c in Context.Categories
                                 orderby c.CategoryId
                                 ascending
                                 select c).ToList<Category>();
            }
            catch (Exception)
            {
                lstCategories = null;
            }
            return lstCategories;
        }
        public bool AddCategoryUsingLinq(string categoryName)
        {
            bool status = false;
            try
            {
                Category category = new Category();
                category.CategoryName = categoryName;
                Context.Categories.Add(category);
                Context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public int UpdateCategoryUsingLinq(byte categoryId, string categoryName)
        {
            int status = -1;
            try
            {
                //using Find()
                Category category = Context.Categories.Find(categoryId); //note ... find uses primary key 
                //using query expression
                //var category = (from ctgry in Context.Categories where ctgry.CategoryId == categoryId select ctgry).FirstOrDefault<Category>();
                //using lambda expression
                //Category category = Context.Categories.Where(e => e.CategoryId == categoryId).FirstOrDefault<Category>();
                if (category != null)
                {
                    category.CategoryName = categoryName;
                    Context.SaveChanges();
                    status = 1;
                }
                else
                {
                    status = 0;
                }
            }
            catch (Exception)
            {
                status = -2;
            }
            return status;
        }
        public bool DeleteCategory(byte categoryId)
        {
            bool status = false;
            try
            {
                var category = (from ctgry in Context.Categories
                                where ctgry.CategoryId == categoryId
                                select ctgry).FirstOrDefault<Category>();
                Context.Categories.Remove(category);
                Context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

    }
}
