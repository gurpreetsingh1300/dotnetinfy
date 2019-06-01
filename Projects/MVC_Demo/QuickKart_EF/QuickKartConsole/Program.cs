using QuickKartDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickKartConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            QuickKartApp();
            //Console.WriteLine(GetNextProductId());   //Uncomment this line to execute scalar valued function in DAL
        }

        //Method to input user credentials
        public static void QuickKartApp()
        {
            Console.Clear();
            Validation obj = new Validation();

            Console.WriteLine("\n*************************Welcome to QuickKart****************************");
            Console.WriteLine("\n\tPlease login to continue\n");
            c1:
            Console.Write("\nPlease enter your email ID : ");
            string emailID = Console.ReadLine();
            if (!obj.IsNull(emailID))
            {
                Console.WriteLine("\n Email Id cannot be empty");
                goto c1;
            }
            c2:
            Console.Write("\nPlease enter your password : ");
            string password = Console.ReadLine();
            if (!obj.IsNull(password))
            {
                Console.WriteLine("\n Password cannot be empty");
                goto c2;
            }

            //Method call to validate using ADO/EF

            //ValidateUserUsingADO(emailID,password);
            ValidateUser(emailID,password);
        }

        //Validate User Credentials and show respective Menu options

        #region Demo 1

        public static void ValidateUser(string emailID, string password)
        {
            QuickKartRepository dal = new QuickKartRepository();
            var role = dal.ValidateLoginUsingLinq(emailID, password);

            if (role.ToLower().Equals("customer"))
            {
                Console.WriteLine("You have logged in as a customer ");
                ShowMenu(role);
            }
            else if (role.ToLower().Equals("admin"))
            {
                Console.WriteLine("You have logged in as an administrator");
                ShowMenu(role);
            }
            else
            {
                Console.WriteLine("Invalid user credentials");
            }
        }

        public static void ValidateUserUsingADO(string emailID, string password)
        {
            //QuickKartDALUsingADO.QuickKartRepository dal = new QuickKartDALUsingADO.QuickKartRepository();

            //var role = dal.ValidateUser(emailID, password);
            //if (role==1)
            //{
                //Console.WriteLine("You have logged in as an administrator");
                //ShowMenu("admin");
            //}
            //else if(role==2)
            //{   
                //Console.WriteLine("You have logged in as a customer");
                //ShowMenu("customer");
            //}
            //else
            //{
                //Console.WriteLine("Invalid user credentials");
            //}
        }

        public static void ShowMenu(string roleName)
        {
            Validation valObj = new Validation();
            if (roleName.ToLower().Equals("customer"))
            {
            c3:
                Console.WriteLine("\n************Start shopping with QuickKart*************");
                Console.WriteLine("\n************Choose an option from the menu***************");
                Console.WriteLine("1. View Categories");
                Console.WriteLine("2. View all Products");
                Console.WriteLine("3. View Products of a Category");
                Console.WriteLine("4. Purchase Products");
                Console.WriteLine("5. Exit");
                Console.Write("Choice : ");
                var choice = Console.ReadLine();
                if(valObj.IsInteger(choice))
                {
                    if (choice == "1")
                    {
                        ShowCategories();
                        goto c3;
                    }
                    else if (choice == "2")
                    {
                        ShowProducts();
                        goto c3;
                    }
                    else if (choice == "3")
                    {
                        ViewProductsOfACategory();
                        goto c3;
                    }
                    else if (choice == "4")
                    {
                        PurchaseProduct();
                        goto c3;
                    }
                    else if (choice == "5")
                    {
                        Console.WriteLine("\nPress <ENTER> to exit");
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice!");
                        goto c3;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                    goto c3;
                }
            }
            else if (roleName.ToLower().Equals("admin"))
            {
            c4:
                Console.WriteLine("\n************Welcome to QuickKart*************");
                Console.WriteLine("\n************Choose an option from the menu***************");
                Console.WriteLine("1. View Categories");
                Console.WriteLine("2. Add Category");
                Console.WriteLine("3. Modify Categories");
                Console.WriteLine("4. View Products");
                Console.WriteLine("5. Add Product");
                Console.WriteLine("6. Exit");
                Console.Write("Choice : ");
                var choice = Console.ReadLine();
                if(valObj.IsInteger(choice))
                {
                    if (choice == "1")
                    {
                        ShowCategories();
                        goto c4;
                    }
                    else if (choice == "2")
                    {
                        ShowCategories();
                        AddCategory();
                        goto c4;
                    }
                    else if (choice == "3")
                    {
                        ModifyCategories();
                        goto c4;
                    }
                    else if (choice == "4")
                    {
                        ViewProductsOfACategory();
                        goto c4;
                    }
                    else if (choice == "5")
                    {
                        AddProduct();
                        goto c4;
                    }
                    else if (choice == "6")
                    {
                        Console.WriteLine("\nPress <ENTER> to exit");
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice!");
                        goto c4;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                    goto c4;
                }
            }
            else
            {
                Console.WriteLine("\nLogin Failed");
                Console.WriteLine("\nPress <ENTER> to exit");
            }

        }

        #endregion

        //Show all categories

        #region Demo 2

        public static void ShowCategories()
        {
            QuickKartRepository dal = new QuickKartRepository();
            var categories = dal.GetCategoriesUsingLinq();
            Console.WriteLine("\n---Available Categories--\n\n");
            Console.WriteLine("CategoryId    CategoryName");
            Console.WriteLine("-----------------------------\n");
            foreach (var item in categories)
            {
                Console.WriteLine("  " + item.CategoryId + "\t\t" + item.CategoryName);
            }
        }

        #endregion

        //Add a category

        #region Demo 3

        public static void AddCategory()
        {
            QuickKartRepository dal = new QuickKartRepository();
            Validation valObj = new Validation();
            string categoryName = "";

        c1:
            Console.WriteLine("Please enter the category name : ");
            categoryName = Console.ReadLine();
            if (!valObj.IsNull(categoryName))
            {
                Console.WriteLine("\n Category Id cannot be NULL");
                goto c1;
            }
            if (dal.AddCategoryUsingLinq(categoryName))
            {
                Console.WriteLine("Category added successfully");
            }
            else
            {
                Console.WriteLine("Category already exists.");
            }
        }

        #endregion

        //Modify categories - Update and Delete

        #region Demo 4

        public static void ModifyCategories()
        {
            Validation val = new Validation();
            Console.Clear();
            c1:
            Console.WriteLine("\n************Choose an option from the menu***************");
            Console.WriteLine("1. Update a Category");
            Console.WriteLine("2. Delete a Category");

            Console.Write("Choice : ");
            var choice = Console.ReadLine();
            if (val.IsInteger(choice))
            {
                if (choice == "1")
                {
                    UpdateCategory();
                }
                else if (choice == "2")
                {
                    DeleteCategory();
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                    goto c1;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice");
                goto c1;
            }
        }

        public static void UpdateCategory()
        {
            QuickKartRepository dal = new QuickKartRepository();
            Console.WriteLine("\n------------------Update Category----------------\n");
            Category category = new Category();
            Validation valObj = new Validation();
            ShowCategories();
        c1:
            Console.Write("\n\n Enter the categoryid that you want to update: ");
            string catId = Console.ReadLine();
            if (!valObj.IsNull(catId))
            {
                Console.Write("\n\n CategoryId should not be NULL ");
                goto c1;
            }
            if (!valObj.IsByte(catId))
            {
                Console.Write("\n\n CategoryId should be byte datatype ");
                goto c1;
            }
            byte categoryId = Convert.ToByte(catId);
        c2:
            Console.Write("\n Enter the new category name for this categoryid: ");
            string categoryName = Console.ReadLine();
            if (!valObj.IsNull(categoryName))
            {
                Console.Write("\n\n Category name should not be NULL ");
                goto c2;
            }
            int result = dal.UpdateCategoryUsingLinq(categoryId, categoryName);
            if (result == 1)
            {
                Console.WriteLine("\n\n Category updated successfully");
            }
            else if (result == 0)
            {
                Console.WriteLine("\n\n Category not found");
            }
            else
            {
                Console.WriteLine("\n\n Some error occured");
            }
        }

        public static void DeleteCategory()
        {
            QuickKartRepository dal = new QuickKartRepository();
            Console.WriteLine("\n-----------Delete Category---------\n");
            Validation valObj = new Validation();
            ShowCategories();
        c1:
            Console.Write("\n\n Enter the categoryid that you want to delete: ");
            string catId = Console.ReadLine();
            if (!valObj.IsNull(catId))
            {
                Console.Write("\n\n CategoryId should not be NULL ");
                goto c1;
            }
            if (!valObj.IsByte(catId))
            {
                Console.Write("\n\n CategoryId should be byte datatype ");
                goto c1;
            }
            byte categoryId = Convert.ToByte(catId);


            if (dal.DeleteCategory(categoryId))
            {
                Console.WriteLine("\n\n Category deleted successfully");
                ShowCategories();
            }
            else
            {
                Console.WriteLine("\n\n Some error occured..please try again");
            }
        }

        #endregion

        //Add a product

        #region Demo 5
        
        public static string GetNextProductId()
        {
            QuickKartRepository dal = new QuickKartRepository();
            string prodId = dal.GetNextProductIdUsingUFN();
            return prodId;
            //return "";
        }

        public static void AddProduct()
        {

            Console.Clear();
            QuickKartRepository dal = new QuickKartRepository();
            Console.WriteLine("\n------------------Add Products----------------\n\n");
            Console.WriteLine("\n\n---Please enter the Product details---\n");
            Validation valObj = new Validation();
        c1:
            ShowCategories();
            Console.Write("\n Please choose a CategoryId: ");

            string categoryId = (Console.ReadLine());

            if (!valObj.IsNull(categoryId))
            {
                Console.WriteLine("\nCategory Id cannot be NULL");
                goto c1;

            }
            if (!valObj.IsByte(categoryId))
            {
                Console.WriteLine("\nCategory Id should be byte data type");
                goto c1;

            }
            byte catId = Convert.ToByte(categoryId);

        c3:
            Console.Write("\n Please enter Product Name: ");
            string productName = Console.ReadLine();
            if (!valObj.IsNull(productName))
            {
                Console.WriteLine("\nProduct Name cannot be NULL");
                goto c3;

            }

        c4:
            Console.Write("\n Product Price: ");
            string pri = Console.ReadLine();

            if (!valObj.IsNull(pri))
            {
                Console.WriteLine("\nPrice cannot be NULL");
                goto c4;

            }
            if (!valObj.IsDecimal(pri))
            {
                Console.WriteLine("\nPrice should be decimal datatype");
                goto c4;

            }
            if (!valObj.ValidateGreaterThanZero(pri))
            {
                Console.WriteLine("\nPrice should be greater than zero");
                goto c4;

            }
            decimal price = Convert.ToDecimal(pri);
        c5:
            Console.Write("\n Available Quantity: ");
            string qtyAvailable = Console.ReadLine();
            if (!valObj.IsNull(qtyAvailable))
            {
                Console.WriteLine("\nQuantity cannot be NULL");
                goto c5;

            }
            if (!valObj.IsInteger(qtyAvailable))
            {
                Console.WriteLine("Quantity should be integer datatype");
                goto c5;

            }
            if (!valObj.ValidateGreaterThanZero(qtyAvailable))
            {
                Console.WriteLine("\nQuantity should be greater than zero");
                goto c5;

            }

            int quantityAvailable = Convert.ToInt32(qtyAvailable);
            string productId = GetNextProductId();
            int result = Convert.ToInt32(dal.AddProductUsingUSP(productId, productName, catId, price, quantityAvailable));
            if (result > 0)
            {
                Console.WriteLine("\n\n You have successfully added this product \n");
            }
            else if (result == -1)
            {
                Console.WriteLine("\n\n Product id can't be null \n");
            }
            else if (result == -2)
            {
                Console.WriteLine("\n\n Product id should start with P \n");
            }
            else if (result == -3)
            {
                Console.WriteLine("\n\n Product name can't be null \n");
            }
            else if (result == -4)
            {
                Console.WriteLine("\n\n Category id can't be null \n");
            }
            else if (result == -5)
            {
                Console.WriteLine("\n\n The Category id you have entered is not valid \n");
            }
            else if (result == -6)
            {
                Console.WriteLine("\n\n The price that you have entered is not valid \n");
            }
            else if (result == -7)
            {
                Console.WriteLine("\n\n The Quantity available is not valid \n");
            }
            else
            {
                Console.WriteLine("\n\n Some error occured..please try again \n");
            }
        }

        #endregion

        //View products of a particular category

        #region Demo 6

        public static void ViewProductsOfACategory()
        {
            Console.Clear();
            QuickKartRepository dal = new QuickKartRepository();
            Category category = new Category();
            Validation valObj = new Validation();
            Console.WriteLine("\n------------------View Products----------------\n\n\n");
            ShowCategories();
        c1:
            Console.Write("\n\n Please choose a CategoryId: ");
            string catId = Console.ReadLine();
            if (!valObj.IsNull(catId))
            {
                Console.WriteLine("\n Category Id cannot be NULL");
                goto c1;

            }
            if (!valObj.IsByte(catId))
            {
                Console.WriteLine("\n Category Id should be an integer");
                goto c1;

            }

            category.CategoryId = Convert.ToByte(catId);
            var lstproducts = dal.GetProductsUsingUFN(category.CategoryId);
            Console.WriteLine("\n\n ----Product Details----");
            Console.WriteLine("---------------------------------------------");
            if (lstproducts.Count != 0)
            {
                foreach (var item in lstproducts)
                {
                    Console.WriteLine("Product id: " + item.ProductId);
                    Console.WriteLine("Product Name: " + item.ProductName);
                    Console.WriteLine("Quantity: " + item.QuantityAvailable);
                    Console.WriteLine("Price: " + item.Price);
                    Console.WriteLine("------------------------------------\n");
                }
            }
            else
            {
                Console.WriteLine("Product details not found.... Try again...!!!\n");
            }
        }
        #endregion

        #region Additional Methods

        //Method to display all products

        public static void ShowProducts()
        {
            //QuickKartRepository dal = new QuickKartRepository();
            //var products = dal.DisplayProductDetails();
            //Console.WriteLine("\n--------------Available Products-------------\n\n");
            //Console.WriteLine("ProductId\tProductName\tCategoryId\tPrice\tQuantityAvailable");
            //Console.WriteLine("-----------------------------------------------------------------------------------------------------\n");
            //foreach (var item in products)
            //{
            //    Console.WriteLine("  " + item.ProductId + "\t\t" + item.ProductName + "\t\t" + item.CategoryId + "\t\t" + item.Price + "\t\t" + item.QuantityAvailable);
            //}
        }

        //Method to purchase a product

        public static void PurchaseProduct()
        {
        //    Console.Clear();
        //    QuickKartRepository dal = new QuickKartRepository();
        //    Validation valObj = new Validation();
        //    //ViewProducts();
        //    Console.WriteLine("\n\n------------------Purchase Products--------\n\n");
        //c1:
        //    Console.Write("\n Please enter Product id which you wish to purchase: ");
        //    string pid = Console.ReadLine();
        //    if (!valObj.IsNull(pid))
        //    {
        //        Console.Write("\n Product Id should not be null ");
        //        goto c1;
        //    }
        //    if (!valObj.ValidateProductId(pid))
        //    {
        //        Console.Write("\n Product Id be in proper format ");
        //        goto c1;
        //    }
        //c2:
        //    Console.Write("\n Please enter how much quantity you wish to purchase: ");
        //    string qty = Console.ReadLine();

        //    if (!valObj.IsNull(qty))
        //    {
        //        Console.Write("\n Quantity should not be null ");
        //        goto c2;
        //    }
        //    if (!valObj.IsInteger(qty))
        //    {
        //        Console.Write("\n Quantity should be integer type ");
        //        goto c2;
        //    }
        //    if (!valObj.ValidateGreaterThanZero(qty))
        //    {
        //        Console.Write("\n Quantity should be greater than zero ");
        //        goto c2;
        //    }
        //    int quantity = Convert.ToInt32(qty);
        //c3:
        //    Console.Write("\n Please enter your email id: ");
        //    string email = Console.ReadLine();
        //    if (!valObj.IsNull(email))
        //    {
        //        Console.Write("\n Email id should not be null ");
        //        goto c3;
        //    }
        //    long purchaseid = 0;
        //    int result = dal.PurchaseUsingUSP(email, pid, quantity, out purchaseid);
        //    if (result > 0)
        //    {
        //        Console.WriteLine("\nYou have successfully purchased this product.       purchase id is: " + purchaseid);
        //    }
        //    else if (result == -1)
        //    {
        //        Console.WriteLine("\n\n Email id can't be null");
        //    }
        //    else if (result == -2)
        //    {
        //        Console.WriteLine("\n\n Email id that you have entered is not registered in     the system");
        //    }

        //    else if (result == -3)
        //    {
        //        Console.WriteLine("\n\n Product id can't be null");
        //    }
        //    else if (result == -4)
        //    {
        //        Console.WriteLine("\n\n The product id that you have entered is not valid");
        //    }
        //    else if (result == -5)
        //    {
        //        Console.WriteLine("\n\n The quantity that you have requested is not   valid");
        //    }
        //    else
        //    {
        //        Console.WriteLine("\n\n Some error occured. Please try again");
        //    }
        }

        public static void AddPurchase()
        {
        //    QuickKartRepository dal = new QuickKartRepository();
        //    Validation valObj = new Validation();
        //    string emailId = "";
        //    string productId = "";
        //    string qtyPurchased = "";
        //c1:
        //    Console.WriteLine("Please enter the email Id : ");
        //    emailId = Console.ReadLine();
        //    if (!valObj.IsNull(emailId))
        //    {
        //        Console.WriteLine("\n Email Id cannot be NULL");
        //        goto c1;
        //    }
        //c2:
        //    Console.WriteLine("Please enter the product Id : ");
        //    productId = Console.ReadLine();
        //    if (!valObj.IsNull(productId))
        //    {
        //        Console.WriteLine("\n Product Id cannot be NULL");
        //        goto c2;
        //    }

        //c3:
        //    Console.WriteLine("Please enter the quantity purchased : ");
        //    qtyPurchased = Console.ReadLine();
        //    if (!valObj.IsNull(qtyPurchased))
        //    {
        //        Console.WriteLine("\n Quantity purchased cannot be NULL");
        //        goto c3;
        //    }
        //    if (!valObj.IsInteger(qtyPurchased))
        //    {
        //        Console.WriteLine("\n Quantity purchased should be a number");
        //        goto c3;
        //    }

        //    if (dal.AddPurchaseDetails(emailId, productId, qtyPurchased))
        //    {
        //        Console.WriteLine("Purchase added successfully");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Purchase could not be added. Please try again.");
        //    }
        }
        #endregion
    }
}
