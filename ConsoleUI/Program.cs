using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();
            //CategoryTest();
            //ProductDetailsDtoTest();

        }

        //private static void CategoryTest()
        //{
        //    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        //    var result = categoryManager.GetAll();
        //    if (result.Success)
        //    {
        //        result.Data.ForEach(x => Console.WriteLine(x.CategoryName));
        //    }
        //    else { Console.WriteLine(result.Message); }
             
        //}

        //private static void ProductTest()
        //{
        //    ProductManager productManager = new ProductManager(new EfProductDal());
        //    var result = productManager.GetAllByCategoryId(2);
        //    if (result.Success)
        //    {
        //        result.Data.ForEach(x => Console.WriteLine(x.ProductName));
        //    }
        //}
        //private static void ProductDetailsDtoTest()
        //{
        //    ProductManager productManager = new ProductManager(new EfProductDal());
        //    var result = productManager.GetProductDetails();
        //    if (result.Success)
        //    {
        //        result.Data.ForEach(x => Console.WriteLine(x.ProductName + "  /  " + x.CategoryName));
        //    }

            
        //}
    }
}
