using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PizzaConstruct.Models;

namespace PizzaConstructor
{
    public partial class Form1 : Form
    {
        private PizzaRepository repository = new PizzaRepository();

        public Form1()
        {
            InitializeComponent();
            InitializeBindings();
        }

        private BindingList<Ingredient> ingredientsBinding;
        private BindingList<PizzaBase> basesBinding;
        private BindingList<Pizza> pizzasBinding;

        private void InitializeBindings()
        {
            ingredientsBinding = new BindingList<Ingredient>(repository.Ingredients);
            basesBinding = new BindingList<PizzaBase>(repository.Bases);
            pizzasBinding = new BindingList<Pizza>(repository.Pizzas);

            checkedListBoxIngredients.DataSource = ingredientsBinding;
            listBoxIngredients.DataSource = ingredientsBinding;
            listBoxBases.DataSource = basesBinding;
            listBoxPizzas.DataSource = pizzasBinding;
        }

        //ингредиенты
        private void buttonAddIngredient_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textIngredientPrice.Text, out double price))
            {
                repository.AddIngredient(textIngredientName.Text, price);
                UpdateIngredients();
            }
            else MessageBox.Show("Некорректная цена");
        }

        private void buttonChangeIngredient_Click(object sender, EventArgs e)
        {
           if (double.TryParse(textIngredientPrice.Text, out double price) && listBoxIngredients.SelectedItem is Ingredient ingredient)
           {
                repository.ChangeIngredient(textIngredientName.Text, price, ingredient.Id);
                UpdateIngredients();
           }
        }

        private void buttonDeleteIngredient_Click(object sender, EventArgs e)
        {
            if (listBoxIngredients.SelectedItem is Ingredient ingredient)
            {
                repository.RemoveIngredient(ingredient.Id);
                UpdateIngredients();
            }
        }

        private void listBoxIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxIngredients.SelectedItem is Ingredient ingredient)
            {
                textIngredientName.Text = ingredient.Name;
                textIngredientPrice.Text = ingredient.Price.ToString();
            }
        }

        private void UpdateIngredients()
        {
            ingredientsBinding = new BindingList<Ingredient>(repository.Ingredients);
            checkedListBoxIngredients.DataSource = ingredientsBinding;
            listBoxIngredients.DataSource = ingredientsBinding;
            //ingredientsBinding.ResetBindings();
        }

        //основы

        private void buttonAddBase_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBasePrice.Text, out double price))
            {
                repository.AddBase(textBaseName.Text, price);
                UpdateBases();
            }
            else MessageBox.Show("Некорректная цена");
        }

        private void buttonChangeBase_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBasePrice.Text, out double price) && listBoxBases.SelectedItem is PizzaBase ing)
            {
                repository.ChangeBase(textBaseName.Text, price, ing.Id);
                UpdateBases();
            }
        }

        private void buttonDeleteBase_Click(object sender, EventArgs e)
        {
            if (listBoxBases.SelectedItem is PizzaBase ing)
            {
                repository.RemoveBase(ing.Id);
                UpdateBases();
            }
        }

        private void listBoxBases_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxBases.SelectedItem is PizzaBase b)
            {
                textBaseName.Text = b.Name;
                textBasePrice.Text = b.Price.ToString();
            }
        }

        private void UpdateBases()
        {
            basesBinding = new BindingList<PizzaBase>(repository.Bases);
            listBoxBases.DataSource = basesBinding;
            //basesBinding.ResetBindings();
        }

        //создание пиццы

        private void buttonCreatePizza_Click(object sender, EventArgs e)
        {
            if (!(listBoxBases.SelectedItem is PizzaBase pizzaBase))
            {
                MessageBox.Show("Выберите основу для пиццы");
                return;
            }

            List<Ingredient> selectedIngredients = checkedListBoxIngredients.CheckedItems.Cast<Ingredient>().ToList(); //LINQ
            repository.AddPizza(textPizzaName.Text, pizzaBase, selectedIngredients);
            UpdatePizzas();

            textPizzaName.Clear();
            foreach (int i in checkedListBoxIngredients.CheckedIndices)
            {
                checkedListBoxIngredients.SetItemChecked(i, false);
            }
        }

        private void UpdatePizzas()
        {
            pizzasBinding = new BindingList<Pizza>(repository.Pizzas);
            listBoxPizzas.DataSource = pizzasBinding;
            //pizzasBinding.ResetBindings();
        }

        //готовые пиццы

    }
}