using System;
using QuickKartDBFirstCoreDataAccessLayer;

namespace QuickKartDBFirstCoreConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            QuickKartRepository repository = new QuickKartRepository();
            var categories = repository.GetAllCategories();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("CategoryId\tCategoryName");
            Console.WriteLine("----------------------------------");
            foreach (var category in categories)
            {
                Console.WriteLine("{0}\t\t{1}", category.CategoryId, category.CategoryName);
            }
            Console.WriteLine("Hello World!");
        }
    }
}
