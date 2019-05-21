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
        public List<Product> GetProducts()
        {
            List<Product> products = null;
            products = (from c in Context.Products
                        select c).ToList<Product>();
            return products;
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
        public List<ufn_GetProductDetails_Result> GetProductsUsingUFN(int categoryId)
        {
            List<ufn_GetProductDetails_Result> lstProducts = null;
            try
            {
                lstProducts = Context.ufn_GetProductDetails(categoryId).ToList();
            }
            catch (Exception)
            {
                lstProducts = null;
            }
            return lstProducts;
        }
        public string GetNextProductIdUsingUFN()
        {
            var productId = Context.Database.SqlQuery<string>("SELECT dbo.ufn_GenerateNewProductId()").FirstOrDefault<string>();
            return productId;
        }
        public int AddProductUsingUSP(string productId, string productName, byte catId, decimal price, int quantityAvailable)
        {
            System.Nullable<int> returnValue = 0;
            try
            {
                returnValue = Context.usp_AddProduct(productId, productName, catId, price, quantityAvailable).SingleOrDefault();
            }
            catch (Exception)
            {
                returnValue = -99;
            }
            return Convert.ToInt32(returnValue);
        }
        public bool RegisterUser(string emailID, string userPassword, string gender, System.DateTime dateOfBirth, string address )
        {
            bool status = false;
            try
            {
                //var result =Context.usp_RegisterUser(userPassword, gender, emailID, dateOfBirth, address).SingleOrDefault();
                //if (result.Value == 1)
                //{
                //    status = true;

                //}
                User userObj = new User();
                Role roleObj = new Role();
                roleObj.RoleId = 2;
                roleObj.RoleName = "Customer";
                userObj.EmailId = emailID;
                userObj.Address = address;
                userObj.DateOfBirth = dateOfBirth;
                userObj.Gender = gender;
                userObj.Role = roleObj;
                //userObj.RoleId = roleObj.RoleId;
                userObj.RoleId = 2;
                userObj.UserPassword = userPassword;
                Context.Users.Add(userObj);
                Context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                status = false;
            }
            
            return status;
        }
    }
}
