using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using RecipeBookApp.Services;

namespace RecipeBookApp
{
    public partial class EditRecipeForm : Form
    {
        private readonly int recipeId;
        private const string connectionString = "Server=localhost;Database=recipebookdb;Uid=root;Pwd=;";

        public EditRecipeForm(int id)
        {
            InitializeComponent();
            recipeId = id;
            LoadRecipeDetails();
        }

        private void LoadRecipeDetails()
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                const string query = @"
                    SELECT Name, Description, CookingTime, Category, TotalCalories, CookingInstructions
                      FROM Recipes
                     WHERE Id = @id";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", recipeId);
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            txtName.Text = rdr["Name"].ToString();
                            txtDescription.Text = rdr["Description"].ToString();
                            txtCookingTime.Text = rdr["CookingTime"].ToString();
                            txtCategory.Text = rdr["Category"].ToString();
                            txtTotalCalories.Text = rdr["TotalCalories"].ToString();
                            txtInstructions.Text = rdr["CookingInstructions"].ToString();
                        }
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
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
                    const string update = @"
                        UPDATE Recipes
                           SET Name                = @name,
                               Description         = @description,
                               CookingTime         = @cookingTime,
                               Category            = @category,
                               TotalCalories       = @totalCalories,
                               CookingInstructions = @instructions
                         WHERE Id = @id";
                    using (var cmd = new MySqlCommand(update, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", recipeId);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@cookingTime", cookingTime);
                        cmd.Parameters.AddWithValue("@category", category);
                        cmd.Parameters.AddWithValue("@totalCalories", totalCalories);
                        cmd.Parameters.AddWithValue("@instructions", instructions);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Рецепт успішно оновлено!", "Підтвердження", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла помилка при збереженні: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
