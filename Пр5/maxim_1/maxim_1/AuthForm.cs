using FontAwesome.Sharp;
using MaterialSkin;
using MaterialSkin.Controls;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Timer = System.Windows.Forms.Timer;

namespace maxim_1
{
    public partial class AuthForm : MaterialForm
    {
        private bool showPassword = false;

        private Timer timer;
        private int counter = 0;
        public AuthForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(
                Constants.AccentColor,
                Constants.AccentColor,
                Constants.AccentColor,
                Constants.SecondaryBackgroundColor,
                Methods.GetContrastTextShade(Constants.AccentColor));

            login_textBox.KeyPress += textBox_KeyPress;
            password_textBox.KeyPress += textBox_KeyPress;

            timer = new Timer
            {
                Interval = 1000
            };
            timer.Tick += Timer_Tick;
            statusbar_text.Text = "";
            this.Icon = new System.Drawing.Icon("images/app_icon.ico");
            show_password_button.Icon = IconChar.Eye.ToBitmap(Color.Black, 24);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            counter++;
            if (counter >= 3)
            {
                timer.Stop();
                statusbar_text.Text = "";
            }
        }

        private void show_password_button_Click(object sender, EventArgs e)
        {
            showPassword = !showPassword;
            password_textBox.UseSystemPasswordChar = !showPassword;
            ShowStatusMessage(showPassword ? "Пароль показан" : "Пароль скрыт");
            show_password_button.Icon = (showPassword) ? IconChar.EyeSlash.ToBitmap(Color.Black, 24) : IconChar.Eye.ToBitmap(Color.Black, 24);
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            string login = login_textBox.Text;
            string password = password_textBox.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                ShowStatusMessage("Логин или пароль не может быть пустым!");
                return;
            }

            try
            {
                Constants.Connection.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select count(*) from employees where login=@login and password=@password;", Constants.Connection);
                cmd.Parameters.AddWithValue("login", login);
                cmd.Parameters.AddWithValue("password", password);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                Constants.Connection.Close();

                if (count == 0)
                {
                    ShowStatusMessage($"Пользователь с логином '{login}' и паролем '{password}' не найден!");
                    return;
                }


                ShowStatusMessage("Вход успешен!");
                MainForm form = new MainForm();
                form.Show();
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clipboard.SetText(ex.Message);
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\t' || e.KeyChar == ' ' || e.KeyChar == '\n' || e.KeyChar == '\r')
            {
                ShowStatusMessage("Вы не можете ввести данный символ");
                e.Handled = true;
            }
        }

        private void ShowStatusMessage(string message)
        {
            statusbar_text.Text = message;
            counter = 0;
            timer.Start();
        }
    }
}
