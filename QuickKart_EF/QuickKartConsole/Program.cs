using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickKartDataAccessLayer;


namespace QuickKartConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ValidateUser();
            GetCatogeries();
            //AddCategory();
            //UpdateCategory();
            DeleteCategory();
        }

        public static void ValidateUser()
        {
            //Console.WriteLine("enter email");
            string email = "Anzio_Don@infosys.com";//Console.ReadLine();

            //Console.WriteLine("enter password");
            string password = "don@123";// Console.ReadLine();

            QuickKartRepository dal = new QuickKartRepository();
            var role = dal.ValidateLoginUsingLinq(email,password);

            Console.WriteLine(role);

        }
        public static void GetCatogeries()
        {
            QuickKartRepository dal = new QuickKartRepository();
            var categories = dal.GetCategoriesUsingLinq();
            foreach (Category catObj in categories)
            {
                Console.WriteLine(catObj.CategoryId);
                Console.WriteLine("\t\t\t\t");
                Console.WriteLine(catObj.CategoryName);
                Console.WriteLine("\n\n");
            }

            Console.WriteLine(categories);
        }
        public static void AddCategory()
        {
            QuickKartRepository dal = new QuickKartRepository();
            bool status = dal.AddCategoryUsingLinq("General");
            Console.WriteLine("========================================");
            GetCatogeries();
        }
        public static void UpdateCategory()
        {
            GetCatogeries();
            QuickKartRepository dal = new QuickKartRepository();
            var response = dal.UpdateCategoryUsingLinq(11, "Games");
            Console.WriteLine("update done");
            GetCatogeries();
        }
        public static void DeleteCategory()
        {
            GetCatogeries();
            QuickKartRepository dal = new QuickKartRepository();
            var response = dal.DeleteCategory(11);
            Console.WriteLine( "Deleted" );
            GetCatogeries();
        }


    }
}
