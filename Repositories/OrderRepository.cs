using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaConstructor.Models;

namespace PizzaConstructor.Repositories
{
    public class OrderRepository
    {
        private int lastOrderNumber = 0;
        public List<Order> Orders { get; set; } = new List<Order>();

        public Order CreateOrder(List<OrderItem> items, string comment = "", DateTime? scheduledTime = null)
        {
            Order newOrder = new Order
            {
                OrderNumber = ++lastOrderNumber,
                Comment = comment,
                ScheduledTime = scheduledTime,
                Items = items
            };
            Orders.Add(newOrder);
            return newOrder;
        }
    }
}
