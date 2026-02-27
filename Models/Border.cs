using PizzaConstructor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaConstructor.Models
{
    public class Border : Entity, IPricable
    {
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<Guid> AllowedPizzas { get; set; } = new List<Guid>();

        public Border(string name, List<Ingredient> ingredients) : base(name)
        {
            Ingredients.AddRange(ingredients);
        }

        public double GetPrice()
        { 
            return Ingredients.Sum(i => i.GetPrice());
        }

        public override string ToString()
        {
            return $"Бортик: {Name} - {GetPrice():F2} руб.";
        }
    }
}
