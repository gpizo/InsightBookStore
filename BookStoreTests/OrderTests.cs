using AutoFixture;
using AutoFixture.AutoMoq;
using InsightTecnicalTest;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BookStoreTests
{
    public class OrderTests
    {
        AutoFixture.Fixture fixture;
        public OrderTests()
        {
            fixture = new AutoFixture.Fixture();
            fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true });
        }
        [Fact]
        public void OrderCalculatesTotalsCorrectly()
        {
            var listItems = fixture.Build<OrderItem>().With(oi => oi.Quantity, 1).With(oi => oi.Discount, (double?)null).CreateMany(5).ToList();
            var order = fixture.Build<Order>().With(o => o.Items, listItems).Create();

            Assert.Equal(listItems.Sum(x => x.UnitPrice), order.CalculateTotal());
            Assert.Equal(listItems.Sum(x => x.UnitPrice * order.Tax), order.CalculateTax());
        }
    }
}
