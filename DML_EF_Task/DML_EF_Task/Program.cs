using DML_EF_Task.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DML_EF_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            //1-Retrieve all categories from the production.categories table.

            var categoriesList = context.Categories.ToList();
            foreach (var category in categoriesList)
            {
                Console.WriteLine($"CategoryID : {category.CategoryId} , Category Name: {category.CategoryName}");
            }

            Console.WriteLine("-----------------------------------------------------------");

            //2-Retrieve the first product from the production.products table.
            var FirstProduct = context.Products.First();
            Console.WriteLine($"ProductId: {FirstProduct.ProductId}, ProductName: {FirstProduct.ProductName}, ModelYear: {FirstProduct.ModelYear}, Price: {FirstProduct.ListPrice} ");

            Console.WriteLine("-----------------------------------------------------------");

            //3-Retrieve a specific product from the production.products table by ID.
            var Prod = context.Products.Where(p => p.ProductId == 5).ToList();
            foreach (var product in Prod)
            {
                Console.WriteLine($"ProductId: {product.ProductId}, ProductName: {product.ProductName}, ModelYear: {product.ModelYear}, Price: {product.ListPrice} ");
            }

            Console.WriteLine("-----------------------------------------------------------");

            //4-Retrieve all products from the production.products table with a certain model year.
            var ProdByYear = context.Products.Where(p => p.ModelYear == 2017).ToList();
            foreach (var product in ProdByYear)
            {
                Console.WriteLine($"ProductId: {product.ProductId}, ProductName: {product.ProductName}, ModelYear: {product.ModelYear}, Price: {product.ListPrice} ");
            }

            Console.WriteLine("-----------------------------------------------------------");

            //5-Retrieve a specific customer from the sales.customers table by ID.
            var customer = context.Customers.Where(e => e.CustomerId == 7).ToList();
            foreach(var c in customer)
            {
                Console.WriteLine($"CustomerId: {c.CustomerId}, CustomerName: {c.FirstName} {c.LastName}, Email: {c.Email}");
            }

            Console.WriteLine("-----------------------------------------------------------");

            //6-Retrieve a list of product names and their corresponding brand names.
            var ProductBrand = context.Products.Include(p => p.Brand).ToList();
            foreach (var PB in ProductBrand)
            {
                Console.WriteLine($"ProductName: {PB.ProductName}, Brand: {PB.Brand.BrandName}");
            }

            Console.WriteLine("-----------------------------------------------------------");

            //7-Count the number of products in a specific category.
            var productCount = context.Products.Include(p => p.Category).Where(e=> e.Category.CategoryName == "Electric Bikes").Count();
            Console.WriteLine($"Number of products in the Electric Bikes Category: {productCount}");

            Console.WriteLine("-----------------------------------------------------------");

            //8-Calculate the total list price of all products in a specific category.
            var productSum = context.Products.Include(p => p.Category).Where(e => e.Category.CategoryName == "Electric Bikes").Sum(l => l.ListPrice);
            Console.WriteLine($"Sum of products' list prices in the Electric Bikes Category: {productSum}");

            Console.WriteLine("-----------------------------------------------------------");

            //9-Calculate the average list price of products.
            var productAVG = context.Products.Average(e=>e.ListPrice);
            Console.WriteLine($"Average price: {productAVG}");

            Console.WriteLine("-----------------------------------------------------------");

            //10-Retrieve orders that are completed.
            var orders = context.Orders.Where(e => e.OrderStatus == 4).ToList(); 
            foreach( var order in orders)
            {
                Console.WriteLine($"OrderId: {order.OrderId}, OrderStatus: {order.OrderStatus}, OrderDate: {order.OrderDate}, RequieredDate: {order.RequiredDate}");
            }

        }
    }
}
