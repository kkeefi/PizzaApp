using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaConstructor.Models
{
    public class Pizza : Entity, IPricable
    {
        public PizzaBase Base { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public Border PizzaBorder { get; set; } = null;

        public Pizza(string name, PizzaBase pizzaBase) : base(name)
        {
            Base = pizzaBase;
        }

        public double GetPrice()
        {
            double price = Base.Price + Ingredients.Sum(x => x.Price);
            if (PizzaBorder != null)
            {
                price += PizzaBorder.GetPrice();
            }
            return price;
        }

        public override string ToString()
        {
            return $"Пицца: {Name} - {GetPrice():F2} руб.";
        }
    }
}
