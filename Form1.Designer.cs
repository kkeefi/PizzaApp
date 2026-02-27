namespace PizzaConstructor
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDeleteIngredient = new System.Windows.Forms.Button();
            this.buttonEditIngredient = new System.Windows.Forms.Button();
            this.buttonAddIngredient = new System.Windows.Forms.Button();
            this.textIngredientPrice = new System.Windows.Forms.TextBox();
            this.textIngredientName = new System.Windows.Forms.TextBox();
            this.listBoxIngredients = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonCreatePizza = new System.Windows.Forms.Button();
            this.checkedListBoxIngredients = new System.Windows.Forms.CheckedListBox();
            this.comboBoxBases = new System.Windows.Forms.ComboBox();
            this.textPizzaName = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBoxPizzas = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonDeleteBase = new System.Windows.Forms.Button();
            this.buttonEditBase = new System.Windows.Forms.Button();
            this.buttonAddBase = new System.Windows.Forms.Button();
            this.textBasePrice = new System.Windows.Forms.TextBox();
            this.textBaseName = new System.Windows.Forms.TextBox();
            this.listBoxBases = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonDeleteIngredient);
            this.groupBox1.Controls.Add(this.buttonEditIngredient);
            this.groupBox1.Controls.Add(this.buttonAddIngredient);
            this.groupBox1.Controls.Add(this.textIngredientPrice);
            this.groupBox1.Controls.Add(this.textIngredientName);
            this.groupBox1.Controls.Add(this.listBoxIngredients);
            this.groupBox1.Location = new System.Drawing.Point(35, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 321);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ингредиенты";
            // 
            // buttonDeleteIngredient
            // 
            this.buttonDeleteIngredient.Location = new System.Drawing.Point(79, 258);
            this.buttonDeleteIngredient.Name = "buttonDeleteIngredient";
            this.buttonDeleteIngredient.Size = new System.Drawing.Size(91, 23);
            this.buttonDeleteIngredient.TabIndex = 5;
            this.buttonDeleteIngredient.Text = "Удалить";
            this.buttonDeleteIngredient.UseVisualStyleBackColor = true;
            this.buttonDeleteIngredient.Click += new System.EventHandler(this.buttonDeleteIngredient_Click);
            // 
            // buttonEditIngredient
            // 
            this.buttonEditIngredient.Location = new System.Drawing.Point(79, 229);
            this.buttonEditIngredient.Name = "buttonEditIngredient";
            this.buttonEditIngredient.Size = new System.Drawing.Size(91, 23);
            this.buttonEditIngredient.TabIndex = 4;
            this.buttonEditIngredient.Text = "Изменить";
            this.buttonEditIngredient.UseVisualStyleBackColor = true;
            // 
            // buttonAddIngredient
            // 
            this.buttonAddIngredient.Location = new System.Drawing.Point(79, 200);
            this.buttonAddIngredient.Name = "buttonAddIngredient";
            this.buttonAddIngredient.Size = new System.Drawing.Size(91, 23);
            this.buttonAddIngredient.TabIndex = 3;
            this.buttonAddIngredient.Text = "Добавить";
            this.buttonAddIngredient.UseVisualStyleBackColor = true;
            // 
            // textIngredientPrice
            // 
            this.textIngredientPrice.Location = new System.Drawing.Point(20, 144);
            this.textIngredientPrice.Name = "textIngredientPrice";
            this.textIngredientPrice.Size = new System.Drawing.Size(100, 22);
            this.textIngredientPrice.TabIndex = 2;
            // 
            // textIngredientName
            // 
            this.textIngredientName.Location = new System.Drawing.Point(20, 115);
            this.textIngredientName.Name = "textIngredientName";
            this.textIngredientName.Size = new System.Drawing.Size(100, 22);
            this.textIngredientName.TabIndex = 1;
            // 
            // listBoxIngredients
            // 
            this.listBoxIngredients.FormattingEnabled = true;
            this.listBoxIngredients.ItemHeight = 16;
            this.listBoxIngredients.Location = new System.Drawing.Point(20, 31);
            this.listBoxIngredients.Name = "listBoxIngredients";
            this.listBoxIngredients.Size = new System.Drawing.Size(150, 68);
            this.listBoxIngredients.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonCreatePizza);
            this.groupBox3.Controls.Add(this.checkedListBoxIngredients);
            this.groupBox3.Controls.Add(this.comboBoxBases);
            this.groupBox3.Controls.Add(this.textPizzaName);
            this.groupBox3.Location = new System.Drawing.Point(590, 35);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(300, 321);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Создание пиццы";
            // 
            // buttonCreatePizza
            // 
            this.buttonCreatePizza.Location = new System.Drawing.Point(91, 278);
            this.buttonCreatePizza.Name = "buttonCreatePizza";
            this.buttonCreatePizza.Size = new System.Drawing.Size(125, 23);
            this.buttonCreatePizza.TabIndex = 4;
            this.buttonCreatePizza.Text = "Создать пиццу";
            this.buttonCreatePizza.UseVisualStyleBackColor = true;
            this.buttonCreatePizza.Click += new System.EventHandler(this.buttonCreatePizza_Click);
            // 
            // checkedListBoxIngredients
            // 
            this.checkedListBoxIngredients.FormattingEnabled = true;
            this.checkedListBoxIngredients.Location = new System.Drawing.Point(20, 115);
            this.checkedListBoxIngredients.Name = "checkedListBoxIngredients";
            this.checkedListBoxIngredients.Size = new System.Drawing.Size(162, 123);
            this.checkedListBoxIngredients.TabIndex = 3;
            // 
            // comboBoxBases
            // 
            this.comboBoxBases.FormattingEnabled = true;
            this.comboBoxBases.Location = new System.Drawing.Point(20, 75);
            this.comboBoxBases.Name = "comboBoxBases";
            this.comboBoxBases.Size = new System.Drawing.Size(121, 24);
            this.comboBoxBases.TabIndex = 2;
            // 
            // textPizzaName
            // 
            this.textPizzaName.Location = new System.Drawing.Point(20, 31);
            this.textPizzaName.Name = "textPizzaName";
            this.textPizzaName.Size = new System.Drawing.Size(121, 22);
            this.textPizzaName.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listBoxPizzas);
            this.groupBox4.Location = new System.Drawing.Point(920, 35);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 321);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Готовые пиццы";
            // 
            // listBoxPizzas
            // 
            this.listBoxPizzas.FormattingEnabled = true;
            this.listBoxPizzas.ItemHeight = 16;
            this.listBoxPizzas.Location = new System.Drawing.Point(7, 31);
            this.listBoxPizzas.Name = "listBoxPizzas";
            this.listBoxPizzas.Size = new System.Drawing.Size(187, 228);
            this.listBoxPizzas.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonDeleteBase);
            this.groupBox2.Controls.Add(this.buttonEditBase);
            this.groupBox2.Controls.Add(this.buttonAddBase);
            this.groupBox2.Controls.Add(this.textBasePrice);
            this.groupBox2.Controls.Add(this.textBaseName);
            this.groupBox2.Controls.Add(this.listBoxBases);
            this.groupBox2.Location = new System.Drawing.Point(314, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(247, 321);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Основы";
            // 
            // buttonDeleteBase
            // 
            this.buttonDeleteBase.Location = new System.Drawing.Point(81, 258);
            this.buttonDeleteBase.Name = "buttonDeleteBase";
            this.buttonDeleteBase.Size = new System.Drawing.Size(91, 23);
            this.buttonDeleteBase.TabIndex = 6;
            this.buttonDeleteBase.Text = "Удалить";
            this.buttonDeleteBase.UseVisualStyleBackColor = true;
            // 
            // buttonEditBase
            // 
            this.buttonEditBase.Location = new System.Drawing.Point(81, 229);
            this.buttonEditBase.Name = "buttonEditBase";
            this.buttonEditBase.Size = new System.Drawing.Size(91, 23);
            this.buttonEditBase.TabIndex = 6;
            this.buttonEditBase.Text = "Изменить";
            this.buttonEditBase.UseVisualStyleBackColor = true;
            // 
            // buttonAddBase
            // 
            this.buttonAddBase.Location = new System.Drawing.Point(81, 200);
            this.buttonAddBase.Name = "buttonAddBase";
            this.buttonAddBase.Size = new System.Drawing.Size(91, 23);
            this.buttonAddBase.TabIndex = 4;
            this.buttonAddBase.Text = "Добавить";
            this.buttonAddBase.UseVisualStyleBackColor = true;
            // 
            // textBasePrice
            // 
            this.textBasePrice.Location = new System.Drawing.Point(19, 144);
            this.textBasePrice.Name = "textBasePrice";
            this.textBasePrice.Size = new System.Drawing.Size(100, 22);
            this.textBasePrice.TabIndex = 2;
            // 
            // textBaseName
            // 
            this.textBaseName.Location = new System.Drawing.Point(19, 115);
            this.textBaseName.Name = "textBaseName";
            this.textBaseName.Size = new System.Drawing.Size(100, 22);
            this.textBaseName.TabIndex = 1;
            // 
            // listBoxBases
            // 
            this.listBoxBases.FormattingEnabled = true;
            this.listBoxBases.ItemHeight = 16;
            this.listBoxBases.Location = new System.Drawing.Point(19, 31);
            this.listBoxBases.Name = "listBoxBases";
            this.listBoxBases.Size = new System.Drawing.Size(165, 68);
            this.listBoxBases.TabIndex = 0;
            this.listBoxBases.SelectedIndexChanged += new System.EventHandler(this.listBoxBases_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 405);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "Form1";
            this.Text = "Pizza";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBoxIngredients;
        private System.Windows.Forms.TextBox textIngredientPrice;
        private System.Windows.Forms.TextBox textIngredientName;
        private System.Windows.Forms.Button buttonDeleteIngredient;
        private System.Windows.Forms.Button buttonEditIngredient;
        private System.Windows.Forms.Button buttonAddIngredient;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonCreatePizza;
        private System.Windows.Forms.CheckedListBox checkedListBoxIngredients;
        private System.Windows.Forms.ComboBox comboBoxBases;
        private System.Windows.Forms.TextBox textPizzaName;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox listBoxPizzas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBoxBases;
        private System.Windows.Forms.TextBox textBaseName;
        private System.Windows.Forms.TextBox textBasePrice;
        private System.Windows.Forms.Button buttonDeleteBase;
        private System.Windows.Forms.Button buttonEditBase;
        private System.Windows.Forms.Button buttonAddBase;
    }
}

