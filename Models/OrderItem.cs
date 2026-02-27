using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaConstructor.Models
{
    public enum PizzaSize
    {
        Small,
        Medium,
        Large
    }

    public class OrderItem
    {
        public Pizza Pizza { get; set; }
        public PizzaSize Size { get; set; }
        public bool DoubleIngredients { get; set; }
        public double GetPrice()
        {
            double price = Pizza.GetPrice();
            if (Size == PizzaSize.Medium)
            {
                price *= 1.2;
            }
            else if (Size == PizzaSize.Large)
            {
                price *= 1.5;
            }
            if (DoubleIngredients)
            {
                price += Pizza.Ingredients.Sum(x => x.Price);
            }
            return price;
        }

        public string PizzaNameWithSize
        {
            get
            {
                string doubleStr = DoubleIngredients ? " (удвоенные ингридиенты)" : "";
                return $"{Pizza.Name} {Size}{doubleStr}";
            }
        }
    }
}
