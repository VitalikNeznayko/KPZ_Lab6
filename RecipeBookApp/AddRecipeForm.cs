using MySql.Data.MySqlClient;
using RecipeBookApp.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RecipeBookApp
{
    public partial class AddRecipeForm : Form
    {
        private readonly List<Tuple<int, string, string, int>> ingredients = new();
        private const string connectionString = "Server=localhost;Database=recipebookdb;Uid=root;Pwd=;";

        public AddRecipeForm()
        {
            InitializeComponent();
            LoadExistingIngredients();
            SetupToolTips();
        }

        private void LoadExistingIngredients()
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    const string query = "SELECT Id, Name, Calories FROM Ingredients";
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            int id = rdr.GetInt32("Id");
                            string name = rdr.GetString("Name");
                            int calories = rdr.GetInt32("Calories");
                            lstExistingIngredients.Items.Add(new Ingredient(id, name, calories));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не вдалося завантажити інгредієнти: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            public int Id { get; }
            public string Name { get; }
            public int Calories { get; }

            public Ingredient(int id, string name, int calories)
            {
                Id = id;
                Name = name;
                Calories = calories;
            }

            public override string ToString() => $"{Name} — {Calories} ккал";
        }

        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIngredientName.Text)
                || !int.TryParse(txtIngredientAmount.Text, out int amt)
                || !int.TryParse(txtIngredientCalories.Text, out int cal))
            {
                MessageBox.Show("Перевірте правильність введених даних для інгредієнта.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ingredients.Add(Tuple.Create(-1, txtIngredientName.Text.Trim(), txtIngredientAmount.Text.Trim(), cal));
            lstIngredients.Items.Add($"{txtIngredientName.Text.Trim()} — {amt} г — {cal} ккал/100г");

            txtIngredientName.Clear();
            txtIngredientAmount.Clear();
            txtIngredientCalories.Clear();
        }

        private void lstExistingIngredients_DoubleClick(object sender, EventArgs e)
        {
            if (lstExistingIngredients.SelectedItem is Ingredient ing)
            {
                using var amountForm = new IngredientAmountForm(ing.Name);
                if (amountForm.ShowDialog() == DialogResult.OK
                    && int.TryParse(amountForm.IngredientAmount, out int qty))
                {
                    ingredients.Add(Tuple.Create(ing.Id, ing.Name, amountForm.IngredientAmount, ing.Calories));
                    lstIngredients.Items.Add($"{ing.Name} — {qty} г — {ing.Calories} ккал/100г");
                }
            }
        }

        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string description = txtDescription.Text.Trim();
            string cookingTimeText = txtCookingTime.Text.Trim();
            string category = txtCategory.Text.Trim();
            string totalCaloriesText = txtTotalCalories.Text.Trim();
            string instructions = txtInstructions.Text.Trim();

            if (!RecipeValidator.Validate(
                    name,
                    description,
                    cookingTimeText,
                    category,
                    totalCaloriesText,
                    instructions,
                    out int cookingTime,
                    out int totalCalories,
                    out string errorMessage))
            {
                MessageBox.Show(errorMessage, "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    const string insertRecipe = @"
                        INSERT INTO Recipes
                            (Name, Description, CookingTime, Category, TotalCalories, CookingInstructions, VideoUrl, ImageUrl)
                        VALUES
                            (@Name, @Description, @CookingTime, @Category, @TotalCalories, @CookingInstructions, @VideoUrl, @ImageUrl);
                        SELECT LAST_INSERT_ID();";

                    using (var cmd = new MySqlCommand(insertRecipe, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@CookingTime", cookingTime);
                        cmd.Parameters.AddWithValue("@Category", category);
                        cmd.Parameters.AddWithValue("@TotalCalories", totalCalories);
                        cmd.Parameters.AddWithValue("@CookingInstructions", instructions);
                        cmd.Parameters.AddWithValue("@VideoUrl", txtVideoUrl.Text.Trim());
                        cmd.Parameters.AddWithValue("@ImageUrl", txtImageUrl.Text.Trim());

                        int recipeId = Convert.ToInt32(cmd.ExecuteScalar());

                        foreach (var ing in ingredients)
                        {
                            int ingId = ing.Item1;
                            if (ingId == -1)
                            {
                                const string insertIng = @"
                                    INSERT INTO Ingredients (Name, Calories)
                                    VALUES (@Name, @Calories);
                                    SELECT LAST_INSERT_ID();";
                                using var cmdIng = new MySqlCommand(insertIng, conn);
                                cmdIng.Parameters.AddWithValue("@Name", ing.Item2);
                                cmdIng.Parameters.AddWithValue("@Calories", ing.Item4);
                                ingId = Convert.ToInt32(cmdIng.ExecuteScalar());
                            }

                            const string insertLink = @"
                                INSERT INTO RecipeIngredients (RecipeId, IngredientId, Quantity)
                                VALUES (@RecipeId, @IngredientId, @Quantity)";
                            using var cmdLink = new MySqlCommand(insertLink, conn);
                            cmdLink.Parameters.AddWithValue("@RecipeId", recipeId);
                            cmdLink.Parameters.AddWithValue("@IngredientId", ingId);
                            cmdLink.Parameters.AddWithValue("@Quantity", ing.Item3);
                            cmdLink.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Рецепт успішно додано!", "Підтвердження", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при збереженні рецепту: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}