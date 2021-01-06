using System;
using System.Collections.Generic;

namespace InsightTecnicalTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new List<OrderItem>()
            {
                new OrderItem{
                    Book = new Book("Unsolved crimes", BookCategory.Crime),
                    Discount = 0.05,
                    Price = 10.99,
                    Quantity = 1
                }, 
                new OrderItem{
                    Book = new Book("A Little Love Story", BookCategory.Romance),
                    Price = 2.40,
                    Quantity = 1
                }, 
                new OrderItem{
                    Book = new Book("Heresy", BookCategory.Fantasy),
                    Price = 6.80,
                    Quantity = 1
                }, 
                new OrderItem{
                    Book = new Book("Jack the Ripper", BookCategory.Crime),
                    Discount = 0.05,
                    Price = 16.00,
                    Quantity = 1
                }, 
                new OrderItem{
                    Book = new Book("The Tolkien Years", BookCategory.Fantasy),
                    Price = 22.90,
                    Quantity = 1
                }
            };

            var order = new Order(items);

            Console.WriteLine($"Total with TAX: {order.CalculateTotal()}");
            Console.WriteLine($"Total without TAX: {order.CalculateTotal() - order.CalculateTax()}");
            

        }
    }
}
