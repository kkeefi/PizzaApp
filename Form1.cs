using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using PizzaConstructor.Models;
using PizzaConstructor.Repositories;

namespace PizzaConstructor
{
    public partial class Form1 : Form
    {
        private PizzaRepository repository = new PizzaRepository();
        private OrderRepository orderRepository = new OrderRepository();

        public Form1()
        {
            InitializeComponent();
            repository.LoadDefaultData();
            InitializeBindings();
        }

        private BindingList<Ingredient> ingredientsBinding;
        private BindingList<PizzaBase> basesBinding;
        private BindingList<Pizza> pizzasBinding;
        private BindingList<Border> bordersBinding;
        private BindingList<Order> ordersBinding;
        private BindingList<OrderItem> currentOrderItems;
        private BindingList<Pizza> firstPartBinding;
        private BindingList<Pizza> secondPartBinding;

        private void InitializeBindings()
        {
            ingredientsBinding = new BindingList<Ingredient>(repository.Ingredients);
            basesBinding = new BindingList<PizzaBase>(repository.Bases);
            pizzasBinding = new BindingList<Pizza>(repository.Pizzas);
            bordersBinding = new BindingList<Border>(repository.Borders);
            ordersBinding = new BindingList<Order>(orderRepository.Orders);
            currentOrderItems = new BindingList<OrderItem>();
            firstPartBinding = new BindingList<Pizza>(repository.Pizzas.ToList());
            secondPartBinding = new BindingList<Pizza>(repository.Pizzas.ToList());

            checkedListBoxIngredients.DataSource = ingredientsBinding;
            checkedListBoxIngredients.DisplayMember = "ToString";

            checkedListBoxBorderIngredients.DataSource = ingredientsBinding;
            checkedListBoxBorderIngredients.DisplayMember = "Name";

            checkedListBoxIngrisientsCustomPizza.DataSource = ingredientsBinding;
            checkedListBoxIngrisientsCustomPizza.DisplayMember = "ToString";

            checkedListBoxFilterIngredients.DataSource = ingredientsBinding;
            checkedListBoxFilterIngredients.DisplayMember = "Name";

            listBoxIngredients.DataSource = ingredientsBinding;
            listBoxIngredients.DisplayMember = "ToString";

            listBoxBases.DataSource = basesBinding;
            listBoxBases.DisplayMember = "ToString";

            comboBoxBases.DataSource = basesBinding;
            comboBoxBases.DisplayMember = "Name";

            comboBoxBaseCustomPizza.DataSource = basesBinding;
            comboBoxBaseCustomPizza.DisplayMember = "Name";

            checkedListBoxAllowed.DataSource = pizzasBinding;
            checkedListBoxAllowed.DisplayMember = "Name";

            checkedListBoxFilterPizzas.DataSource = pizzasBinding;
            checkedListBoxFilterPizzas.DisplayMember = "Name";

            checkedListBoxDisallowed.DisplayMember = "Name";

            listBoxPizzas.DataSource = pizzasBinding;
            listBoxPizzas.DisplayMember = null;

            listBoxAvailablePizzas.DataSource = pizzasBinding;
            listBoxAvailablePizzas.DisplayMember = "Name";

            listBoxFilterPizzas.DataSource = firstPartBinding;
            listBoxFilterOrders.DisplayMember = "ToString";

            comboBoxFirstPart.DataSource = firstPartBinding;
            comboBoxFirstPart.DisplayMember = "Name";

            comboBoxSecondPart.DataSource = secondPartBinding;
            comboBoxSecondPart.DisplayMember = "Name";

            listBoxBorders.DataSource = bordersBinding;
            listBoxBorders.DisplayMember = null;

            listBoxPizzaForBorder.DataSource = pizzasBinding;
            listBoxPizzaForBorder.DisplayMember = "Name";

            listBoxBorderForPizza.DataSource = bordersBinding;
            listBoxBorderForPizza.DisplayMember = "Name";

            checkedListBoxFilterBorders.DataSource = bordersBinding;
            checkedListBoxFilterBorders.DisplayMember = "Name";

            listBoxOrders.DataSource = ordersBinding;
            listBoxOrders.DisplayMember = "ToString";

            listBoxPizzasInOrder.DataSource = currentOrderItems;
            listBoxPizzasInOrder.DisplayMember = "PizzaNameWithSize";

            listBoxFilterOrders.DataSource = ordersBinding;
            listBoxFilterOrders.DisplayMember = "ToString";

            comboBoxBasicPizzaSize.DataSource = Enum.GetValues(typeof(PizzaSize));
            comboBoxComboPizzaSize.DataSource = Enum.GetValues(typeof(PizzaSize));
            comboBoxCustomPizzaSize.DataSource = Enum.GetValues(typeof(PizzaSize));
        }

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
            ingredientsBinding.ResetBindings();
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
            basesBinding.ResetBindings();
            comboBoxBases.DataSource = basesBinding;
        }

        private void buttonCreatePizza_Click(object sender, EventArgs e)
        {
            PizzaBase pizzaBase = comboBoxBaseCustomPizza.SelectedItem as PizzaBase;
            List<Ingredient> selectedIngredients = 
                checkedListBoxIngredients.CheckedItems.
                Cast<Ingredient>().
                ToList();
            repository.AddPizza(textPizzaName.Text, pizzaBase, selectedIngredients);
            UpdatePizzas();

            textPizzaName.Clear();
            foreach (int i in checkedListBoxIngredients.CheckedIndices)
            {
                checkedListBoxIngredients.SetItemChecked(i, false);
            }
        }

        private void buttonChangePizza_Click(object sender, EventArgs e)
        {
            Pizza pizza = listBoxPizzas.SelectedItem as Pizza;
            PizzaBase pizzaBase = comboBoxBases.SelectedItem as PizzaBase;
            List<Ingredient> selectedIngredients =
                checkedListBoxIngredients.CheckedItems
                .Cast<Ingredient>()
                .ToList();
            repository.ChangePizza(textPizzaName.Text, pizzaBase, selectedIngredients, pizza.Id);
            UpdatePizzas();
        }

        private void buttonDeletePizza_Click(object sender, EventArgs e)
        {
            if (listBoxPizzas.SelectedItem is Pizza PizzaToDelete)
            {
                repository.RemovePizza(PizzaToDelete.Id);
                UpdatePizzas();
            }
        }

        private void UpdatePizzas()
        {
            pizzasBinding.ResetBindings();

            firstPartBinding.Clear();
            secondPartBinding.Clear();

            foreach (var pizza in repository.Pizzas)
            {
                firstPartBinding.Add(pizza);
                secondPartBinding.Add(pizza);
            }
        }

        private void listBoxPizzas_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxPizzaDetails.Items.Clear();
            Pizza pizza = listBoxPizzas.SelectedItem as Pizza;
            listBoxPizzaDetails.Items.Add("Основа:" + pizza.Base.Name + " - " + pizza.Base.Price + "руб." + "");
            listBoxPizzaDetails.Items.Add("Ингредиенты:");
            foreach (var ingredient in pizza.Ingredients)
            {
                listBoxPizzaDetails.Items.Add(ingredient.Name + " - " + ingredient.Price + "руб." + "");
            }
            if (pizza.PizzaBorder != null)
            {
                listBoxPizzaDetails.Items.Add("Бортик: " + pizza.PizzaBorder.Name + " - " + pizza.PizzaBorder.GetPrice() + "руб." + "");
                listBoxPizzaDetails.Items.Add("Ингредиенты бортика:");
                foreach (var ingredient in pizza.PizzaBorder.Ingredients)
                {
                    listBoxPizzaDetails.Items.Add(ingredient.Name + " - " + ingredient.Price + "руб." + "");
                }
            }
        }

        private void buttonAddBorder_Click(object sender, EventArgs e)
        {
            string name = textBorderName.Text;
            List<Ingredient> selectedIngredients =
                checkedListBoxBorderIngredients.CheckedItems
                .Cast<Ingredient>()
                .ToList();

            repository.AddBorder(name, selectedIngredients);
            UpdateBorders();
        }

        private void buttonAddBorderToPizza_Click(object sender, EventArgs e)
        {
            if (listBoxPizzas.SelectedItem is Pizza pizza && listBoxBorders.SelectedItem is Border border)
            {
                repository.AddBorderToPizza(pizza, border);
                UpdatePizzas();
            }
        }

        private void buttonSetAllowedPizzas_Click(object sender, EventArgs e)
        {
            if (listBoxBorders.SelectedItem is Border border)
            {
                List<Pizza> allowedPizzas
                    = checkedListBoxAllowed.CheckedItems
                    .Cast<Pizza>()
                    .ToList();
                repository.SetAllowedPizzas(border, allowedPizzas);
                UpdateBorders();
            }
        }

        private void buttonDeleteBorder_Click(object sender, EventArgs e)
        {
            if (listBoxBorders.SelectedItem is Border border)
            {
                repository.RemoveBorder(border.Id);
                UpdateBorders();
            }
        }

        private void UpdateBorders()
        {
            bordersBinding.ResetBindings();
        }

        private void listBoxBorders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxBorders.SelectedItem is Border border)
            {
                textBorderName.Text = border.Name;
                for (int i = 0; i < checkedListBoxBorderIngredients.Items.Count; i++)
                {
                    Ingredient ingredient = checkedListBoxBorderIngredients.Items[i] as Ingredient;
                    checkedListBoxBorderIngredients.SetItemChecked(i, border.Ingredients.Contains(ingredient));
                }

                for (int i = 0; i < checkedListBoxAllowed.Items.Count; i++)
                {
                    Pizza pizza = checkedListBoxAllowed.Items[i] as Pizza;
                    checkedListBoxAllowed.SetItemChecked(i, border.AllowedPizzas.Contains(pizza.Id));
                }

                List<Pizza> disallowedPizzas = repository.GetDisallowedPizzas(border);
                checkedListBoxDisallowed.DataSource = null;
                checkedListBoxDisallowed.DataSource = disallowedPizzas;
                checkedListBoxDisallowed.Enabled = false;
            }
        }

        private void UpdateCurrentOrderItems()
        {
            listBoxPizzasInOrder.DataSource = null;
            listBoxPizzasInOrder.DataSource = currentOrderItems;
        }

        private void buttonAddPizzaToOrder_Click(object sender, EventArgs e)
        {
            if (listBoxAvailablePizzas.SelectedItem is Pizza pizza)
            {
                bool doubleIngredients = checkBoxDouble.Checked;
                PizzaSize size = (PizzaSize)comboBoxBasicPizzaSize.SelectedItem;

                OrderItem item = new OrderItem
                {
                    Pizza = pizza,
                    Size = size,
                    DoubleIngredients = doubleIngredients
                };

                currentOrderItems.Add(item);
            }
        }
        private void buttonAddCustomPizza_Click(object sender, EventArgs e)
        {
            string customName = textBoxNameCustomPizza.Text;
            PizzaBase selectedBase = comboBoxBaseCustomPizza.SelectedItem as PizzaBase;
            List<Ingredient> selectedIngredients = 
                checkedListBoxIngrisientsCustomPizza.CheckedItems.
                Cast<Ingredient>().
                ToList();

            Pizza customPizza = new Pizza(customName, selectedBase);
            customPizza.Ingredients.AddRange(selectedIngredients);

            PizzaSize size = (PizzaSize)comboBoxCustomPizzaSize.SelectedItem;

            OrderItem item = new OrderItem
            {
                Pizza = customPizza,
                Size = size,
                DoubleIngredients = false
            };

            currentOrderItems.Add(item);

            textBoxNameCustomPizza.Clear();
        }

        private void buttonAddHalfPizzaCombo_Click(object sender, EventArgs e)
        {
            Pizza first = comboBoxFirstPart.SelectedItem as Pizza;
            Pizza second = comboBoxSecondPart.SelectedItem as Pizza;

            if (first == second)
            {
                MessageBox.Show("Нельзя выбрать одну и ту же пиццу для двух половин");
                return;
            }

            if (first.Base.Id != second.Base.Id)
            {
                MessageBox.Show("Нельзя объединить пиццы на разных основах");
                return;
            }

            Pizza combinedPizza = new Pizza($"Комбо: {first.Name} + {second.Name}", first.Base);

            combinedPizza.Ingredients.AddRange(first.Ingredients.Select(i => new Ingredient(i.Name, i.Price / 2)));
            combinedPizza.Ingredients.AddRange(second.Ingredients.Select(i => new Ingredient(i.Name, i.Price / 2)));

            currentOrderItems.Add(new OrderItem
            {
                Pizza = combinedPizza,
                Size = (PizzaSize)comboBoxComboPizzaSize.SelectedItem,
                DoubleIngredients = false
            });
        }


        private void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            string comment = textBoxOrderComment.Text;
            DateTime scheduledTime = dateTimePickerOrderTime.Value;

            Order newOrder = orderRepository.CreateOrder(currentOrderItems.ToList(), comment, scheduledTime);
            ordersBinding.ResetBindings();

            currentOrderItems.Clear();
            UpdateCurrentOrderItems();

            textBoxOrderComment.Clear();
            dateTimePickerOrderTime.Value = DateTime.Now;
        }


        private void buttonFilterPizzas_Click(object sender, EventArgs e)
        {
            var filtered = repository.Pizzas.AsEnumerable();

            var selectedIngredients = 
                checkedListBoxFilterIngredients.CheckedItems.
                Cast<Ingredient>().
                ToList();
            if (selectedIngredients.Count > 0)
            {
                filtered = filtered.Where(p => selectedIngredients.All(ing => p.Ingredients.Contains(ing)
                              || (p.PizzaBorder != null && p.PizzaBorder.Ingredients.Contains(ing))));
            }

            var selectedBorders = 
                checkedListBoxFilterBorders.CheckedItems.
                Cast<Border>().
                ToList();
            if (selectedBorders.Count > 0)
            {
                filtered = filtered.Where(p => p.PizzaBorder != null && selectedBorders.Contains(p.PizzaBorder));
            }

            listBoxFilterPizzas.DataSource = null;
            listBoxFilterPizzas.DataSource = filtered.ToList();
        }

        private void buttonFilterOrders_Click(object sender, EventArgs e)
        {
            var filtered = orderRepository.Orders.AsEnumerable();

            DateTime filterDate = dateTimePickerFilter.Value.Date;
            filtered = filtered.Where(p => p.OrderDate.Date == filterDate);

            var selectedPizzas = 
                checkedListBoxFilterPizzas.CheckedItems.
                Cast<Pizza>().
                ToList();
            if (selectedPizzas.Count > 0)
                filtered = filtered.Where(o => o.Items.Any(i => selectedPizzas.Contains(i.Pizza)));

            listBoxFilterOrders.DataSource = null;
            listBoxFilterOrders.DataSource = filtered.ToList();
        }

        private void buttonResetFilters_Click(object sender, EventArgs e)
        {
            listBoxFilterPizzas.DataSource = repository.Pizzas.ToList();
            listBoxFilterOrders.DataSource = orderRepository.Orders.ToList();
            checkedListBoxFilterIngredients.ClearSelected();
            checkedListBoxFilterBorders.ClearSelected();
            checkedListBoxFilterPizzas.ClearSelected();
        }


        private void ShowOrderDetails(Order order)
        {
            listBoxOrderDetails.Items.Clear();

            foreach (var item in order.Items)
            {
                string doubleString = "";
                if (item.DoubleIngredients)
                {
                    doubleString = " (удвоенные ингридиенты)";
                }
                listBoxOrderDetails.Items.Add($"{item.Pizza.Name} {item.Size}{doubleString} - {item.GetPrice():F2} руб.");
            }
            listBoxOrderDetails.Items.Add($"Комментарий: {order.Comment}");
            listBoxOrderDetails.Items.Add($"Дата заказа: {order.OrderDate}");
            if (order.ScheduledTime.HasValue)
                listBoxOrderDetails.Items.Add($"Отложено на: {order.ScheduledTime.Value}");
            listBoxOrderDetails.Items.Add($"Итого: {order.GetTotalPrice:F2} руб.");
        }

        private void listBoxOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowOrderDetails(listBoxOrders.SelectedItem as Order);
        }

    }
}