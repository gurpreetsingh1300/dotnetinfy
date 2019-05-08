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

    }
}
