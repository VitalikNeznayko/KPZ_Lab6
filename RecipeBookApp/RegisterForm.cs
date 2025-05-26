using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RecipeBookApp
{
    public partial class RegisterForm : Form
    {
        string defaultConnectionString = "Server=localhost;Database=recipebookdb;Uid=root;Pwd=;";
        string connectionString;
        
        public RegisterForm()
        {
            InitializeComponent();
            connectionString = defaultConnectionString;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Паролі не співпадають.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO users (username, password) VALUES (@username, @password)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", txtUsername.Text);
                        command.Parameters.AddWithValue("@password", txtPassword.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Реєстрація успішна!", "Підтвердження", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка з'єднання: {ex.Message}");
                }
            }
        }

        private void buttonAnotherBD_Click(object sender, EventArgs e)
        {
            panelChangeBD.Visible = true;
            MessageBox.Show("Ваша проблема пов'язана з БД. Спробуйте вказати інше з'єднання.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string server = textBoxServer.Text.Trim();
            string dataBase = textBoxDatabase.Text.Trim();
            string uId = textBoxUid.Text.Trim();
            string pwD = textBoxPwd.Text;

            if (string.IsNullOrWhiteSpace(server) || string.IsNullOrWhiteSpace(dataBase) ||
                string.IsNullOrWhiteSpace(uId))
            {
                MessageBox.Show("Будь ласка, заповніть усі поля (окрім паролю, якщо порожній).", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            connectionString = $"Server={server};Database={dataBase};Uid={uId};Pwd={pwD};";
            panelChangeBD.Visible = false;
            MessageBox.Show("Параметри з'єднання оновлено!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonClosePanel_Click(object sender, EventArgs e)
        {
            panelChangeBD.Visible = false;
        }
    }
}
