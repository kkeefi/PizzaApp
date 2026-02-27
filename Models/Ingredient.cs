using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaConstructor.Models
{
    public class Ingredient : Entity, IPricable
    {
        public double Price { get; set; }

        public Ingredient(string name, double price) : base(name)
        {
            Price = price;
        }

        public double GetPrice() => Price;

        public override string ToString()
        {
            return $"Ингридиент: {Name} - {Price:F2} руб.";
        }
    }
}
