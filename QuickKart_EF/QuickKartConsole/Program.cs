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

            Console.WriteLine(categories);
        }


    }
}
