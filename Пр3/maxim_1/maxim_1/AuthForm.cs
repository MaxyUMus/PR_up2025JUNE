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
    public partial class AuthForm : Form
    {
        private bool showPassword = false;
        private NpgsqlConnection conn = new NpgsqlConnection(Constants.ConnectionString);

        private Timer timer;
        private int counter = 0;
        public AuthForm()
        {
            InitializeComponent();
            login_textBox.KeyPress += textBox_KeyPress;
            password_textBox.KeyPress += textBox_KeyPress;

            timer = new Timer
            {
                Interval = 1000
            };
            timer.Tick += Timer_Tick;
            statusbar_text.Text = "";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            counter++;
            if (counter >= 3)
            {
                timer.Stop();
                statusbar_text.Text = "";
                counter = 0;
            }
        }

        private void show_password_button_Click(object sender, EventArgs e)
        {
            showPassword = !showPassword;
            password_textBox.UseSystemPasswordChar = !showPassword;
            statusbar_text.Text = (showPassword) ? "Пароль показан" : "Пароль скрыт";
            counter = 0;
            timer.Start();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            string login = login_textBox.Text;
            string password = password_textBox.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                statusbar_text.Text = "Логин или пароль не может быть пустым!";
                counter = 0;
                timer.Start();
                return;
            }

            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select count(*) from workers where worker_login=@login and worker_password=@password;", conn);
            cmd.Parameters.AddWithValue("login", login);
            cmd.Parameters.AddWithValue("password", password);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();

            if (count == 0)
            {
                statusbar_text.Text = $"Пользователь с логином '{login}' и паролем '{password}' не найден!";
                counter = 0;
                timer.Start();
                return;
            }

            statusbar_text.Text = "Вход успешен!";
            counter = 0;
            timer.Start();
            MainForm form = new MainForm();
            form.Show();
            Hide();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\t' || e.KeyChar == ' ' || e.KeyChar == '\n' || e.KeyChar == '\r')
            {
                statusbar_text.Text = "Вы не можете ввести данный символ";
                counter = 0;
                timer.Start();
                e.Handled = true;
            }
        }
    }
}
