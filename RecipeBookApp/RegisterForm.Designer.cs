namespace RecipeBookApp
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.buttonAnotherBD = new System.Windows.Forms.Button();
            this.panelChangeBD = new System.Windows.Forms.Panel();
            this.textBoxPwd = new System.Windows.Forms.TextBox();
            this.textBoxUid = new System.Windows.Forms.TextBox();
            this.textBoxDatabase = new System.Windows.Forms.TextBox();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonClosePanel = new System.Windows.Forms.Button();
            this.panelChangeBD.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsername.Location = new System.Drawing.Point(160, 60);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(169, 23);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Логін користувача:";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsername.Location = new System.Drawing.Point(382, 54);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(301, 30);
            this.txtUsername.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPassword.Location = new System.Drawing.Point(160, 100);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(78, 23);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Пароль:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(382, 94);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(301, 30);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblConfirmPassword.Location = new System.Drawing.Point(160, 140);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(188, 23);
            this.lblConfirmPassword.TabIndex = 4;
            this.lblConfirmPassword.Text = "Підтвердити пароль:";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtConfirmPassword.Location = new System.Drawing.Point(382, 134);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(301, 30);
            this.txtConfirmPassword.TabIndex = 5;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.LightGreen;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegister.Location = new System.Drawing.Point(255, 194);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(277, 43);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Зареєструватися";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // buttonAnotherBD
            // 
            this.buttonAnotherBD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonAnotherBD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAnotherBD.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonAnotherBD.Location = new System.Drawing.Point(255, 243);
            this.buttonAnotherBD.Name = "buttonAnotherBD";
            this.buttonAnotherBD.Size = new System.Drawing.Size(277, 43);
            this.buttonAnotherBD.TabIndex = 7;
            this.buttonAnotherBD.Text = "Не вдається зареєструватися";
            this.buttonAnotherBD.UseVisualStyleBackColor = false;
            this.buttonAnotherBD.Click += new System.EventHandler(this.buttonAnotherBD_Click);
            // 
            // panelChangeBD
            // 
            this.panelChangeBD.Controls.Add(this.buttonClosePanel);
            this.panelChangeBD.Controls.Add(this.button1);
            this.panelChangeBD.Controls.Add(this.label4);
            this.panelChangeBD.Controls.Add(this.label3);
            this.panelChangeBD.Controls.Add(this.label2);
            this.panelChangeBD.Controls.Add(this.label1);
            this.panelChangeBD.Controls.Add(this.textBoxPwd);
            this.panelChangeBD.Controls.Add(this.textBoxUid);
            this.panelChangeBD.Controls.Add(this.textBoxDatabase);
            this.panelChangeBD.Controls.Add(this.textBoxServer);
            this.panelChangeBD.Location = new System.Drawing.Point(51, 36);
            this.panelChangeBD.Name = "panelChangeBD";
            this.panelChangeBD.Size = new System.Drawing.Size(687, 285);
            this.panelChangeBD.TabIndex = 8;
            this.panelChangeBD.Visible = false;
            // 
            // textBoxPwd
            // 
            this.textBoxPwd.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxPwd.Location = new System.Drawing.Point(282, 142);
            this.textBoxPwd.Name = "textBoxPwd";
            this.textBoxPwd.Size = new System.Drawing.Size(301, 30);
            this.textBoxPwd.TabIndex = 9;
            this.textBoxPwd.UseSystemPasswordChar = true;
            // 
            // textBoxUid
            // 
            this.textBoxUid.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxUid.Location = new System.Drawing.Point(282, 106);
            this.textBoxUid.Name = "textBoxUid";
            this.textBoxUid.Size = new System.Drawing.Size(301, 30);
            this.textBoxUid.TabIndex = 9;
            this.textBoxUid.UseSystemPasswordChar = true;
            // 
            // textBoxDatabase
            // 
            this.textBoxDatabase.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxDatabase.Location = new System.Drawing.Point(282, 70);
            this.textBoxDatabase.Name = "textBoxDatabase";
            this.textBoxDatabase.Size = new System.Drawing.Size(301, 30);
            this.textBoxDatabase.TabIndex = 9;
            this.textBoxDatabase.UseSystemPasswordChar = true;
            // 
            // textBoxServer
            // 
            this.textBoxServer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxServer.Location = new System.Drawing.Point(282, 34);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(301, 30);
            this.textBoxServer.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(130, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "Сервер:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(130, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "База даних:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(130, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Логін в БД:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(130, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 23);
            this.label4.TabIndex = 12;
            this.label4.Text = "Пароль до БД:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(214, 193);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(277, 43);
            this.button1.TabIndex = 9;
            this.button1.Text = "Змінити дані підключення";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonClosePanel
            // 
            this.buttonClosePanel.BackColor = System.Drawing.Color.Silver;
            this.buttonClosePanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClosePanel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonClosePanel.Location = new System.Drawing.Point(638, 3);
            this.buttonClosePanel.Name = "buttonClosePanel";
            this.buttonClosePanel.Size = new System.Drawing.Size(49, 43);
            this.buttonClosePanel.TabIndex = 13;
            this.buttonClosePanel.Text = "X";
            this.buttonClosePanel.UseVisualStyleBackColor = false;
            this.buttonClosePanel.Click += new System.EventHandler(this.buttonClosePanel_Click);
            // 
            // RegisterForm
            // 
            this.ClientSize = new System.Drawing.Size(781, 338);
            this.Controls.Add(this.panelChangeBD);
            this.Controls.Add(this.buttonAnotherBD);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Name = "RegisterForm";
            this.Text = "Реєстрація";
            this.panelChangeBD.ResumeLayout(false);
            this.panelChangeBD.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button buttonAnotherBD;
        private System.Windows.Forms.Panel panelChangeBD;
        private System.Windows.Forms.TextBox textBoxPwd;
        private System.Windows.Forms.TextBox textBoxUid;
        private System.Windows.Forms.TextBox textBoxDatabase;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonClosePanel;
    }
}
