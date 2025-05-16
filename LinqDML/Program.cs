using LinqDML.Data;
using LinqDML.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LinqDML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext context = new();
            // 1 - List all customers' first and last names along with their email addresses.

            //var customers = context.Customers;
            //foreach (var item in customers)
            //{
            //    Console.WriteLine($"Full Name  :{item.FirstName} {item.LastName} Email :{item.Email}");

            //}

            //OR
            //var customers = context.Customers.Select(c => new
            //{
            //    FullName = c.FirstName + c.LastName,
            //    c.Email
            //});
            //foreach (var item in customers)
            //{
            //    Console.WriteLine($"Full Name  :{item.FullName} Email :{item.Email}");
            //}

            // 2 - Retrieve all orders processed by a specific staff member(e.g., staff_id = 3).
            //var orders = context.Orders.Where(o => o.StaffId == 3);
            //foreach (var item in orders)
            //{
            //    Console.WriteLine($"Date :{item.OrderDate}  ID: {item .StaffId}");

            //}
            //3- Get all products that belong to a category named "Mountain Bikes".
            //var products = context.Products. Include(p=>p.Category).Where(p => p.Category.CategoryName== "Mountain Bikes");
            //foreach (var item in products)
            //{
            //    Console.WriteLine($"Product Name :{item.ProductName} Category Name :{item.Category.CategoryName}");
            //}
            //4-Count the total number of orders per store.
            //var NumberOfOrders = context.Orders.GroupBy(o => o.StoreId).Select(
            //    o => new
            //    {
            //        StoreId=o.Key,
            //        OrderCount=o.Count()
            //    }
            //    );
            //foreach (var item in NumberOfOrders)
            //{
            //    Console.WriteLine($"StoreID: {item.StoreId} Count: {item.OrderCount}");
            //}
            //5- List all orders that have not been shipped yet (shipped_date is null).
            //var orders = context.Orders.Where(o => o.ShippedDate == null);
            //foreach (var item in orders)
            //{
            //    Console.WriteLine($"Date :{item.OrderDate}  ID: {item.ShippedDate}");
            //}
            //6- Display each customer’s full name and the number of orders they have placed.
            //var customers = context.Customers.Select(
            //    c => new
            //    {
            //        FullName=c.FirstName+" "+c.LastName,
            //        OrderCount=c.Orders.Count

            //    });
            //foreach (var item in customers)
            //{
            //    Console.WriteLine($"Full Name: {item.FullName} Order Count:{item.OrderCount}" );

            //}
            //7- List all products that have never been ordered (not found in order_items).
            //var products = context.Products.Where(p => !p.OrderItems.Any());
            //foreach (var item in products)
            //{
            //    Console.WriteLine($"product Name {item.ProductName}");


            //}
            //Console.WriteLine($"{products.ToList().Count}");
            //8- Display products that have a quantity of less than 5 in any store stock.
            //var products = context.Stocks.Where(s=>s.Quantity<5 ).Select(s=>s.Product).Distinct();
            //foreach (var item in products)
            //{
            //    Console.WriteLine($"product Name {item.ProductName}");
            //}

            //Console.WriteLine($"{products.ToList().Count}");

            //OR
            //var products = context.Products.Where(p=>p.Stocks.Any(s=>s.Quantity<5));
            //foreach (var item in products)
            //{
            //    Console.WriteLine($"product Name {item.ProductName}");
            //}
            //Console.WriteLine($"{products.ToList().Count}");
            //9- Retrieve the first product from the products table.
            //var product = context.Products.FirstOrDefault();
            //if (product != null) 
            //    Console.WriteLine($"{product.ProductName}");
            //10- Retrieve all products from the products table with a certain model year.
            //Console.WriteLine("Please enter Model Year  ex(2022,2023,2024.....)");
            //int modelYear = Convert.ToInt32(Console.ReadLine());

            //var products = context.Products.Where(p => p.ModelYear == modelYear);
            //foreach (var item in products)
            //{
            //    Console.WriteLine($"Product Name: {item.ProductName}, Model Year: {item.ModelYear}");

            //}

            //11- Display each product with the number of times it was ordered.
            //var products = context.Products.Select(
            //    p => new
            //    {
            //        p.ProductName,
            //        OrderCount = p.OrderItems.Count()
            //    });
            //foreach (var item in products)
            //{
            //    Console.WriteLine($"Product Name: {item.ProductName}, Order Count: {item.OrderCount}");

            //}
            //12- Count the number of products in a specific category.
            //Console.WriteLine("Please enter specific category  ex(Mountain Bikes.....)");
            //var specific_category = Console.ReadLine();
            //var CountProduct = context.Products.Where(p => p.Category.CategoryName == specific_category).Count();
            //Console.WriteLine($"{CountProduct}");
            //13- Calculate the average list price of products.
            //var AverageListPrice = context.Products.Average(p => p.ListPrice);

            //    Console.WriteLine($"{AverageListPrice}");

            //14- Retrieve a specific product from the products table by ID.
            //Console.WriteLine("Please enter Product ID  ex(1,2,3.....)");
            //int product_id = Convert.ToInt32(Console.ReadLine());
            //var product = context.Products.FirstOrDefault(p=>p.ProductId == product_id);
            //if (product != null) 
            //    Console.WriteLine($"Product Id:{product.ProductId}  Product Name:{product.ProductName}");
            //15 - List all products that were ordered with a quantity greater than 3 in any order.
            //var products = context.OrderItems.Where(oi => oi.Quantity > 3).Select(oi => oi.Product).
            //    Distinct();
            //foreach (var item in products)
            //{
            //    Console.WriteLine($"{item.ProductName} was ordered with quantity > 3");
            //}
            //16- Display each staff member’s name and how many orders they processed.
            //var staffs=context.Staffs.Select(s => new
            //{
            //    FullName= s.FirstName +" "+s.LastName,
            //    OrdersProcessed = s.Orders.Count,
            //});
            //foreach (var item in staffs)
            //{
            //    Console.WriteLine($"Staff: {item.FullName}  Orders Processed: {item.OrdersProcessed}");

            //}
            //17- List active staff members only (active = true) along with their phone numbers.
            //var staffs = context.Staffs.Where(s => s.Active == 1).Select(s => new
            //{
            //    FullName = s.FirstName + " " + s.LastName,
            //    s.Phone,
            //    s.Active

            //});
            //foreach (var item in staffs)
            //{
            //    Console.WriteLine($"Name: {item.FullName} Phone: {item.Phone}    Activation: {item.Active}");
            //}
            //18- List all products with their brand name and category name.
            //var products = context.Products.Include(p => p.Brand).Include(p => p.Category).Select(
            //    p => new
            //    {
            //         p.ProductName,
            //         p.Brand.BrandName,
            //         p.Category.CategoryName
            //    });
            //foreach (var item in products)
            //{
            //    Console.WriteLine($"Product Name: {item.ProductName} Brand Name: {item.BrandName} Category Name: {item.CategoryName}");
            //}
            //19-Retrieve orders that are completed.3or4
            //var orders = context.Orders.Where(o => o.OrderStatus==4);
            //foreach (var item in orders)
            //{
            //    Console.WriteLine($"Order ID: {item.OrderId} Order Status: {item.OrderStatus}");
            //}
            //20 - List each product with the total quantity sold(sum of quantity from order_items).
            //var products = context.Products.Select(
            //    p => new
            //    {
            //        p.ProductName,
            //        Total = p.OrderItems.Sum(oi => oi.Quantity)
            //    });
            //foreach (var item in products)
            //{
            //    Console.WriteLine($"Product Name: {item.ProductName} Total Quantity Sold: {item.Total}");
            //}

           





        }
    }
}
