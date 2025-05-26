using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RecipeBookApp
{
    public partial class AddRecipeForm : Form
    {
        private List<Tuple<int, string, string, int>> ingredients = new List<Tuple<int, string, string, int>>();

        public AddRecipeForm()
        {
            InitializeComponent();
            LoadExistingIngredients();
            SetupToolTips();
        }

        private void LoadExistingIngredients()
        {
            string connectionString = "Server=localhost;Database=recipebookdb;Uid=root;Pwd=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Id, Name, Calories FROM Ingredients";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32("Id");
                                string name = reader.GetString("Name");
                                int calories = reader.GetInt32("Calories");
                                lstExistingIngredients.Items.Add(new Ingredient(id, name, calories));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Виникла помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SetupToolTips()
        {
            toolTip.SetToolTip(txtIngredientName, "Назва інгредієнта");
            toolTip.SetToolTip(txtIngredientAmount, "Кількість у грамах");
            toolTip.SetToolTip(txtIngredientCalories, "Калорії на 100 грам");
        }


        private class Ingredient
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Calories { get; set; }

            public Ingredient(int id, string name, int calories)
            {
                Id = id;
                Name = name;
                Calories = calories;
            }

            public override string ToString()
            {
                return $"{Name} - {Calories} калорій";
            }
        }

        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            string ingredientName = txtIngredientName.Text.Trim();
            string ingredientAmount = txtIngredientAmount.Text.Trim();
            string ingredientCaloriesText = txtIngredientCalories.Text.Trim();

            if (string.IsNullOrEmpty(ingredientName))
            {
                MessageBox.Show("Будь ласка, введіть назву інгредієнта.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(ingredientAmount) || !int.TryParse(ingredientAmount, out int amount))
            {
                MessageBox.Show("Будь ласка, введіть правильну кількість грамів для інгредієнта.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(ingredientCaloriesText) || !int.TryParse(ingredientCaloriesText, out int ingredientCalories))
            {
                MessageBox.Show("Будь ласка, введіть правильну кількість калорій для інгредієнта.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ingredientId = -1;
            string ingredient = $"{ingredientName} - {ingredientAmount} грам - {ingredientCalories} калорій на 100г";
            ingredients.Add(new Tuple<int, string, string, int>(ingredientId, ingredientName, ingredientAmount, ingredientCalories));
            lstIngredients.Items.Add(ingredient);

            txtIngredientName.Clear();
            txtIngredientAmount.Clear();
            txtIngredientCalories.Clear();
        }

        private void lstExistingIngredients_DoubleClick(object sender, EventArgs e)
        {
            if (lstExistingIngredients.SelectedItem != null)
            {
                var selectedIngredient = (Ingredient)lstExistingIngredients.SelectedItem;
                int ingredientId = selectedIngredient.Id;
                string ingredientName = selectedIngredient.Name;
                int ingredientCalories = selectedIngredient.Calories;

                IngredientAmountForm amountForm = new IngredientAmountForm(ingredientName);
                if (amountForm.ShowDialog() == DialogResult.OK)
                {
                    string ingredientAmount = amountForm.IngredientAmount;
                    string ingredient = $"{ingredientName} - {ingredientAmount} грам - {ingredientCalories} калорій на 100г";
                    ingredients.Add(new Tuple<int, string, string, int>(ingredientId, ingredientName, ingredientAmount, ingredientCalories));
                    lstIngredients.Items.Add(ingredient);
                }
            }
        }

        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            if (!AreRequiredFieldsFilled())
            {
                MessageBox.Show("Будь ласка, заповніть всі обов'язкові поля.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int recipeId = AddRecipeToDatabase();

                AddIngredientsToRecipe(recipeId);

                MessageBox.Show("Рецепт успішно додано!", "Підтвердження", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool AreRequiredFieldsFilled()
        {
            return !string.IsNullOrWhiteSpace(txtName.Text)
                && !string.IsNullOrWhiteSpace(txtDescription.Text)
                && !string.IsNullOrWhiteSpace(txtCookingTime.Text)
                && !string.IsNullOrWhiteSpace(txtCategory.Text)
                && !string.IsNullOrWhiteSpace(txtTotalCalories.Text)
                && !string.IsNullOrWhiteSpace(txtInstructions.Text);
        }

        private int AddRecipeToDatabase()
        {
            string connectionString = "Server=localhost;Database=recipebookdb;Uid=root;Pwd=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
            INSERT INTO Recipes (Name, Description, CookingTime, Category, TotalCalories, CookingInstructions, VideoUrl, ImageUrl)
            VALUES (@Name, @Description, @CookingTime, @Category, @TotalCalories, @CookingInstructions, @VideoUrl, @ImageUrl);
            SELECT LAST_INSERT_ID();";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                    command.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                    command.Parameters.AddWithValue("@CookingTime", txtCookingTime.Text.Trim());
                    command.Parameters.AddWithValue("@Category", txtCategory.Text.Trim());
                    command.Parameters.AddWithValue("@TotalCalories", txtTotalCalories.Text.Trim());
                    command.Parameters.AddWithValue("@CookingInstructions", txtInstructions.Text.Trim());
                    command.Parameters.AddWithValue("@VideoUrl", txtVideoUrl.Text.Trim());
                    command.Parameters.AddWithValue("@ImageUrl", txtImageUrl.Text.Trim());

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        private void AddIngredientsToRecipe(int recipeId)
        {
            string connectionString = "Server=localhost;Database=recipebookdb;Uid=root;Pwd=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                foreach (var ingredient in ingredients)
                {
                    int ingredientId = ingredient.Item1;

                    if (ingredientId == -1)
                    {
                        ingredientId = InsertNewIngredient(connection, ingredient.Item2, ingredient.Item4);
                    }

                    InsertRecipeIngredient(connection, recipeId, ingredientId, ingredient.Item3);
                }
            }
        }

        private int InsertNewIngredient(MySqlConnection connection, string name, double calories)
        {
            string query = @"
        INSERT INTO Ingredients (Name, Calories)
        VALUES (@Name, @Calories);
        SELECT LAST_INSERT_ID();";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Calories", calories);
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        private void InsertRecipeIngredient(MySqlConnection connection, int recipeId, int ingredientId, string quantity)
        {
            string query = @"
        INSERT INTO RecipeIngredients (RecipeId, IngredientId, Quantity)
        VALUES (@RecipeId, @IngredientId, @Quantity)";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@RecipeId", recipeId);
                command.Parameters.AddWithValue("@IngredientId", ingredientId);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.ExecuteNonQuery();
            }
        }

        private void lstIngredients_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
