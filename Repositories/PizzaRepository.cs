using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using PizzaConstructor.Models;

namespace PizzaConstructor.Repositories
{
    public class PizzaRepository
    {
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<PizzaBase> Bases { get; set; } = new List<PizzaBase>();
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
        public List<Border> Borders { get; set; } = new List<Border>();


        public void AddIngredient(string name, double price)
        {
            Ingredients.Add(new Ingredient(name, price));
        }

        public void RemoveIngredient(Guid Id)
        {
            Ingredients.RemoveAll(p => p.Id == Id);
        }

        public void ChangeIngredient(string newName, double newPrice, Guid id)
        {
            var ingredient = Ingredients.FirstOrDefault(p => p.Id == id);
            if (ingredient != null)
            {
                ingredient.Name = newName;
                ingredient.Price = newPrice;
            }
        }

        public void AddBase(string name, double price)
        {
            PizzaBase classicBase = Bases.FirstOrDefault(p => p.Name.ToLower() == "классическая");
            double classicPrice;

            if (classicBase != null)
            {
                classicPrice = classicBase.Price;
            }
            else
            {
                classicPrice = price;
            }

            if (name.ToLower() != "классическая" && price > classicPrice * 1.2)
            {
                MessageBox.Show("цена основы не должна превышать 20% стоимости классической");
                return;
            }
            Bases.Add(new PizzaBase(name, price));
        }

        public void RemoveBase(Guid Id)
        {
            Bases.RemoveAll(p => p.Id == Id);
        }

        public void ChangeBase(string newName, double newPrice, Guid id)
        {
            var b = Bases.FirstOrDefault(p => p.Id == id);
            PizzaBase classicBase = Bases.FirstOrDefault(i => i.Name.ToLower() == "классическая");
            double classicPrice;
            if (classicBase != null)
            {
                classicPrice = classicBase.Price;
            }
            else
            {
                classicPrice = newPrice;
            }

            if (newName.ToLower() != "классическая" && newPrice > classicPrice * 1.2)
            {
                MessageBox.Show("цена основы не должна превышать 20% стоимости классической");
                return;
            }
            b.Name = newName;
            b.Price = newPrice;
        }

        public void AddPizza(string name, PizzaBase pizzaBase, List<Ingredient> ingredients)
        {
            var pizza = new Pizza(name, pizzaBase);
            pizza.Ingredients.AddRange(ingredients);
            Pizzas.Add(pizza);
        }

        public void RemovePizza(Guid Id)
        {
            Pizzas.RemoveAll(p => p.Id == Id);
        }

        public void ChangePizza(string newName, PizzaBase newPizzaBase, List<Ingredient> newIngredients, Guid id)
        {
            var pizza = Pizzas.FirstOrDefault(p => p.Id == id);
            pizza.Name = newName;
            pizza.Base = newPizzaBase;
            pizza.Ingredients = newIngredients;
        }

        public void AddBorder(string name, List<Ingredient> ingredients)
        {
            var border = new Border(name, ingredients);
            Borders.Add(border);
        }

        public void RemoveBorder(Guid id)
        {
            Borders.RemoveAll(p => p.Id == id);
        }

        public void SetAllowedPizzas(Border border, List<Pizza> allowedPizzas)
        {
            border.AllowedPizzas = allowedPizzas.Select(p => p.Id).ToList();
        }

        public bool AddBorderToPizza(Pizza pizza, Border border)
        {
            if (!border.AllowedPizzas.Contains(pizza.Id))
            {
                MessageBox.Show($"Пицца '{pizza.Name}' не разрешена для бортика '{border.Name}'");
                return false;
            }
            pizza.PizzaBorder = border;
            return true;
        }

        public List<Pizza> GetDisallowedPizzas(Border border)
        {
            return Pizzas.
                Where(p => !border.AllowedPizzas.Contains(p.Id))
                .ToList();
        }

        public void LoadDefaultData()
        {
            AddIngredient("Сыр", 50);
            AddIngredient("Колбаса", 70);
            AddIngredient("Грибы", 40);
            AddIngredient("Помидоры", 60);
            AddIngredient("Оливки", 50);
            AddIngredient("Кунжут", 20);

            AddBase("классическая", 200);
            AddBase("Черная", 220);
            AddBase("Толстая", 240);

            var cheese = Ingredients.FirstOrDefault(i => i.Name == "Сыр");
            var sausage = Ingredients.FirstOrDefault(i => i.Name == "Колбаса");
            var mushrooms = Ingredients.FirstOrDefault(i => i.Name == "Грибы");
            var tomatoes = Ingredients.FirstOrDefault(i => i.Name == "Помидоры");
            var olives = Ingredients.FirstOrDefault(i => i.Name == "Оливки");
            var sesame = Ingredients.FirstOrDefault(i => i.Name == "Кунжут");

            var classicBase = Bases.FirstOrDefault(b => b.Name == "классическая");

            AddPizza("Пепперони", classicBase, new List<Ingredient> { cheese, sausage });
            AddPizza("Грибная", classicBase, new List<Ingredient> { cheese, mushrooms });
            AddPizza("Маргарита", classicBase, new List<Ingredient> { cheese, tomatoes });

            var pepperoni = Pizzas.FirstOrDefault(p => p.Name == "Пепперони");
            var mushroom = Pizzas.FirstOrDefault(p => p.Name == "Грибная");
            var margarita = Pizzas.FirstOrDefault(p => p.Name == "Маргарита");

            AddBorder("Сырный", new List<Ingredient> { cheese });
            AddBorder("Кунжутный", new List<Ingredient> { sesame });
        }
    }
}
