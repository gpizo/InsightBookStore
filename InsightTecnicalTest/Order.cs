using System;
using System.Collections.Generic;
using System.Text;

namespace InsightTecnicalTest
{
    public interface IOrderItem
    {
        Book Book { get; set; }

        double Price { get; set; }
        double? Discount { get; set; }

        int Quantity { get; set; }

        double UnitPrice { get; }
    }

    public class OrderItem : IOrderItem
    {
        public Book Book { get; set; }
        public double Price { get; set; }
        public double? Discount { get; set; }
        public int Quantity { get; set; }

        public OrderItem()
        {

        }

        public double UnitPrice
        {
            get
            {
                var price = Price;
                if (Discount.HasValue)
                {
                    price = Price - (Price * Discount.Value);
                }
                return price;
            }
        }
    }

    public interface IOrder
    {
        List<OrderItem> Items { get; set; }

        double Tax { get; set; }

        double CalculateTax();

        double CalculateTotal();
    }

    public class Order : IOrder
    {
        public List<OrderItem> Items { get; set; }
        public double Tax { get; set; }

        public Order(List<OrderItem> items)
        {
            Items = items;
            Tax = 0.1;
        }

        public double CalculateTax()
        {
            double taxOrder = 0;
            Items.ForEach(i =>
            {
                taxOrder += (i.UnitPrice*Tax) * i.Quantity;
            });

            return taxOrder;
        }

        public double CalculateTotal()
        {
            double total = 0;
            Items.ForEach(i => total += i.UnitPrice * i.Quantity);
            return total;
        }
    }
}
