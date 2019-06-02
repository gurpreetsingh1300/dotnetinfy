using System;
using System.Collections.Generic;
using System.Text;
using QuickKartDBFirstCoreDataAccessLayer.Models;
using System.Linq;


namespace QuickKartDBFirstCoreDataAccessLayer
{
    public class QuickKartRepository
    {
        QuickKart_EFContext context;
        public QuickKartRepository()
        {
            context = new QuickKart_EFContext();
        }

        public List<Categories> GetAllCategories()
        {
            var categoriesList = (from category in context.Categories
                                  orderby category.CategoryId
                                  select category).ToList();
            return categoriesList;
        }
    }
}
