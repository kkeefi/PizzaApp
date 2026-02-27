using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaConstructor.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public int OrderNumber { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public string Comment { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime? ScheduledTime { get; set; }

        public double GetTotalPrice => Items.Sum(p => p.GetPrice());

        public override string ToString()
        {
            return $"Заказ #{OrderNumber} - {GetTotalPrice:F2} руб.";
        }
    }
   
}
