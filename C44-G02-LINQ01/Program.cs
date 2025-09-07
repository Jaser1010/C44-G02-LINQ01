using System;
using System.Collections.Generic;
using System.Linq;

namespace C44_G02_LINQ01
{
    #region Data Models and Generators
    // This region contains the necessary classes and data for the solutions.
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }

    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
    }

    public class Customer
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public List<Order> Orders { get; set; }
    }

    public static class ListGenerators
    {
        public static readonly List<Product> ProductList = new List<Product>
        {
            new Product { ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18.00M, UnitsInStock = 39 },
            new Product { ProductID = 2, ProductName = "Chang", Category = "Beverages", UnitPrice = 19.00M, UnitsInStock = 17 },
            new Product { ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10.00M, UnitsInStock = 13 },
            new Product { ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", Category = "Condiments", UnitPrice = 22.00M, UnitsInStock = 53 },
            new Product { ProductID = 5, ProductName = "Chef Anton's Gumbo Mix", Category = "Condiments", UnitPrice = 21.35M, UnitsInStock = 0 },
            new Product { ProductID = 6, ProductName = "Grandma's Boysenberry Spread", Category = "Condiments", UnitPrice = 25.00M, UnitsInStock = 120 },
            new Product { ProductID = 7, ProductName = "Uncle Bob's Organic Dried Pears", Category = "Produce", UnitPrice = 30.00M, UnitsInStock = 15 },
            new Product { ProductID = 8, ProductName = "Northwoods Cranberry Sauce", Category = "Condiments", UnitPrice = 40.00M, UnitsInStock = 6 },
            new Product { ProductID = 9, ProductName = "Mishi Kobe Niku", Category = "Meat/Poultry", UnitPrice = 97.00M, UnitsInStock = 29 },
            new Product { ProductID = 10, ProductName = "Ikura", Category = "Seafood", UnitPrice = 31.00M, UnitsInStock = 0 }
        };

        public static readonly List<Customer> CustomerList = new List<Customer>
        {
            new Customer
            {
                CustomerID = "ALFKI", CustomerName = "Alfreds Futterkiste",
                Orders = new List<Order>
                {
                    new Order { OrderID = 10643, OrderDate = new DateTime(1997, 8, 25), Total = 814.50M },
                    new Order { OrderID = 10692, OrderDate = new DateTime(1997, 10, 3), Total = 471.20M },
                    new Order { OrderID = 10702, OrderDate = new DateTime(1997, 10, 13), Total = 330.00M }
                }
            },
            new Customer
            {
                CustomerID = "ANATR", CustomerName = "Ana Trujillo Emparedados y helados",
                Orders = new List<Order>
                {
                    new Order { OrderID = 10308, OrderDate = new DateTime(1996, 9, 18), Total = 88.80M }
                }
            },
            new Customer
            {
                CustomerID = "WARTH", CustomerName = "Wartian Herkku",
                Orders = new List<Order>
                {
                    new Order { OrderID = 10835, OrderDate = new DateTime(1998, 1, 15), Total = 845.50M },
                    new Order { OrderID = 10952, OrderDate = new DateTime(1998, 3, 16), Total = 471.30M }
                }
            }
        };
    }
    #endregion

    #region Restriction Operators

    #region Question 1: Find all products that are out of stock.
    public static class RestrictionQ1
    {
        public static List<Product> GetOutOfStockProducts()
        {
            return ListGenerators.ProductList.Where(p => p.UnitsInStock == 0).ToList();
        }
    }
    #endregion

    #region Question 2: Find all products that are in stock and cost more than 3.00 per unit.
    public static class RestrictionQ2
    {
        public static List<Product> GetPricyInStockProducts()
        {
            return ListGenerators.ProductList.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00M).ToList();
        }
    }
    #endregion

    #region Question 3: Returns digits whose name is shorter than their value.
    public static class RestrictionQ3
    {
        public static IEnumerable<string> GetDigitsNameShorterThanValue()
        {
            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            return Arr.Where((digit, index) => digit.Length < index);
        }
    }
    #endregion

    #endregion

    #region Ordering Operators

    #region Question 1: Sort a list of products by name.
    public static class OrderingQ1
    {
        public static List<Product> SortProductsByName()
        {
            return ListGenerators.ProductList.OrderBy(p => p.ProductName).ToList();
        }
    }
    #endregion

    #region Question 2: Uses a custom comparer to do a case-insensitive sort of the words in an array.
    public static class OrderingQ2
    {
        public static IEnumerable<string> CaseInsensitiveSort()
        {
            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BIUeBeRrY", "CIOvEr", "cHeRry" };
            return Arr.OrderBy(w => w, StringComparer.OrdinalIgnoreCase);
        }
    }
    #endregion

    #region Question 3: Sort a list of products by units in stock from highest to lowest.
    public static class OrderingQ3
    {
        public static List<Product> SortProductsByStockDescending()
        {
            return ListGenerators.ProductList.OrderByDescending(p => p.UnitsInStock).ToList();
        }
    }
    #endregion

    #region Question 4: Sort a list of digits, first by length of their name, and then alphabetically by the name itself.
    public static class OrderingQ4
    {
        public static IEnumerable<string> SortDigitsByNameLengthThenAlpha()
        {
            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            return Arr.OrderBy(d => d.Length).ThenBy(d => d);
        }
    }
    #endregion

    #region Question 5: Sort first by-word length and then by a case-insensitive sort of the words in an array.
    public static class OrderingQ5
    {
        public static IEnumerable<string> SortWordsByLengthThenCaseInsensitive()
        {
            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BIUeBeRrY", "CIOvEr", "cHeRry" };
            return Arr.OrderBy(w => w.Length).ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
        }
    }
    #endregion

    #region Question 6: Sort a list of products, first by category, and then by unit price, from highest to lowest.
    public static class OrderingQ6
    {
        public static List<Product> SortProductsByCategoryThenPrice()
        {
            return ListGenerators.ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice).ToList();
        }
    }
    #endregion

    #region Question 7: Sort first by-word length and then by a case-insensitive descending sort of the words in an array.
    public static class OrderingQ7
    {
        public static IEnumerable<string> SortWordsByLengthThenCaseInsensitiveDescending()
        {
            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BIUeBeRrY", "CIOvEr", "cHeRry" };
            return Arr.OrderBy(w => w.Length).ThenByDescending(w => w, StringComparer.OrdinalIgnoreCase);
        }
    }
    #endregion

    #region Question 8: Create a list of all digits in the array whose second letter is 'i' that is reversed.
    public static class OrderingQ8
    {
        public static IEnumerable<string> GetReversedDigitsWithSecondLetterI()
        {
            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            return Arr.Where(d => d.Length > 1 && d[1] == 'i').Reverse();
        }
    }
    #endregion

    #endregion

    #region Transformation Operators

    #region Question 1: Return a sequence of just the names of a list of products.
    public static class TransformationQ1
    {
        public static IEnumerable<string> GetProductNames()
        {
            return ListGenerators.ProductList.Select(p => p.ProductName);
        }
    }
    #endregion

    #region Question 2: Produce a sequence of the uppercase and lowercase versions of each word.
    public static class TransformationQ2
    {
        public static IEnumerable<object> GetUpperAndLowerWordVersions()
        {
            string[] words = { "aPPLE", "BIUeBeRrY", "cHeRry" };
            return words.Select(w => new { Upper = w.ToUpper(), Lower = w.ToLower() });
        }
    }
    #endregion

    #region Question 3: Produce a sequence containing some properties of Products, renaming UnitPrice to Price.
    public static class TransformationQ3
    {
        public static IEnumerable<object> GetProductSubset()
        {
            return ListGenerators.ProductList.Select(p => new { p.ProductName, Price = p.UnitPrice, p.Category });
        }
    }
    #endregion

    #region Question 4: Determine if the value of int in an array matches its position.
    public static class TransformationQ4
    {
        public static IEnumerable<object> GetNumbersInPlace()
        {
            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            return Arr.Select((num, index) => new { Number = num, InPlace = (num == index) });
        }
    }
    #endregion

    #region Question 5: Returns all pairs of numbers from two arrays where number from A < number from B.
    public static class TransformationQ5
    {
        public static IEnumerable<object> GetMatchingPairs()
        {
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            return from a in numbersA
                   from b in numbersB
                   where a < b
                   select new { a, b };
        }
    }
    #endregion

    #region Question 6: Select all orders where the order total is less than 500.00.
    public static class TransformationQ6
    {
        public static IEnumerable<Order> GetOrdersUnder500()
        {
            return ListGenerators.CustomerList.SelectMany(c => c.Orders).Where(o => o.Total < 500.00M);
        }
    }
    #endregion

    #region Question 7: Select all orders where the order was made in 1998 or later.
    public static class TransformationQ7
    {
        public static IEnumerable<Order> GetOrdersFrom1998Onward()
        {
            return ListGenerators.CustomerList.SelectMany(c => c.Orders).Where(o => o.OrderDate.Year >= 1998);
        }
    }
    #endregion

    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            // --- Restriction Operators ---
            Console.WriteLine("--- Restriction Operators ---");

            Console.WriteLine("\nQ1: Products that are out of stock:");
            var outOfStock = RestrictionQ1.GetOutOfStockProducts();
            foreach (var p in outOfStock) Console.WriteLine(p.ProductName);

            Console.WriteLine("\nQ2: In-stock products costing more than 3.00:");
            var pricyInStock = RestrictionQ2.GetPricyInStockProducts();
            foreach (var p in pricyInStock) Console.WriteLine($"{p.ProductName} - Price: {p.UnitPrice:C}");

            Console.WriteLine("\nQ3: Digits with names shorter than their value:");
            var shortDigitNames = RestrictionQ3.GetDigitsNameShorterThanValue();
            foreach (var d in shortDigitNames) Console.WriteLine(d);

            // --- Ordering Operators ---
            Console.WriteLine("\n\n--- Ordering Operators ---");

            Console.WriteLine("\nQ1: Products sorted by name:");
            var sortedProducts = OrderingQ1.SortProductsByName();
            foreach (var p in sortedProducts) Console.WriteLine(p.ProductName);

            Console.WriteLine("\nQ2: Case-insensitive word sort:");
            var sortedWords = OrderingQ2.CaseInsensitiveSort();
            foreach (var w in sortedWords) Console.WriteLine(w);

            Console.WriteLine("\nQ3: Products sorted by units in stock (desc):");
            var sortedByStock = OrderingQ3.SortProductsByStockDescending();
            foreach (var p in sortedByStock) Console.WriteLine($"{p.ProductName} - Stock: {p.UnitsInStock}");

            Console.WriteLine("\nQ4: Digits sorted by name length, then alphabetically:");
            var sortedDigits = OrderingQ4.SortDigitsByNameLengthThenAlpha();
            foreach (var d in sortedDigits) Console.WriteLine(d);

            Console.WriteLine("\nQ5: Words sorted by length, then case-insensitively:");
            var complexWordSort = OrderingQ5.SortWordsByLengthThenCaseInsensitive();
            foreach (var w in complexWordSort) Console.WriteLine(w);

            Console.WriteLine("\nQ6: Products sorted by category, then by price (desc):");
            var sortedByCategoryThenPrice = OrderingQ6.SortProductsByCategoryThenPrice();
            foreach (var p in sortedByCategoryThenPrice) Console.WriteLine($"{p.Category} - {p.ProductName} - {p.UnitPrice:C}");

            Console.WriteLine("\nQ7: Words sorted by length, then case-insensitively (desc):");
            var complexWordSortDesc = OrderingQ7.SortWordsByLengthThenCaseInsensitiveDescending();
            foreach (var w in complexWordSortDesc) Console.WriteLine(w);

            Console.WriteLine("\nQ8: Reversed list of digits with second letter 'i':");
            var reversedDigitsWithI = OrderingQ8.GetReversedDigitsWithSecondLetterI();
            foreach (var d in reversedDigitsWithI) Console.WriteLine(d);


            // --- Transformation Operators ---
            Console.WriteLine("\n\n--- Transformation Operators ---");

            Console.WriteLine("\nQ1: Product names:");
            var productNames = TransformationQ1.GetProductNames();
            foreach (var name in productNames) Console.WriteLine(name);

            Console.WriteLine("\nQ2: Uppercase and lowercase word versions:");
            var wordVersions = TransformationQ2.GetUpperAndLowerWordVersions();
            foreach (var v in wordVersions) Console.WriteLine(v);

            Console.WriteLine("\nQ3: Product subset with renamed 'Price' property:");
            var productSubset = TransformationQ3.GetProductSubset();
            foreach (var p in productSubset) Console.WriteLine(p);

            Console.WriteLine("\nQ4: Numbers matching their position in array:");
            var numbersInPlace = TransformationQ4.GetNumbersInPlace();
            foreach (var item in numbersInPlace) Console.WriteLine(item);

            Console.WriteLine("\nQ5: Pairs where number from A < number from B:");
            var matchingPairs = TransformationQ5.GetMatchingPairs();
            foreach (var pair in matchingPairs) Console.WriteLine(pair);

            Console.WriteLine("\nQ6: Orders with total less than 500.00:");
            var cheapOrders = TransformationQ6.GetOrdersUnder500();
            foreach (var order in cheapOrders) Console.WriteLine($"OrderID: {order.OrderID}, Total: {order.Total:C}");

            Console.WriteLine("\nQ7: Orders from 1998 or later:");
            var recentOrders = TransformationQ7.GetOrdersFrom1998Onward();
            foreach (var order in recentOrders) Console.WriteLine($"OrderID: {order.OrderID}, Date: {order.OrderDate:d}");
        }
    }
}