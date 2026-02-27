using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaConstructor.Models
{
    public class PizzaBase : Entity, IPricable
    {
        public double Price { get; set; }

        public PizzaBase(string name, double price) : base(name)
        {
            Price = price;
        }

        public double GetPrice()
        {
            return Price;
        }

        public override string ToString()
        {
            return $"Основа: {Name} - {Price:F2} руб.";
        }
    }
}
