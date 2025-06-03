using MaterialSkin;
using MaterialSkin.Controls;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
namespace maxim_1
{
    public partial class AdditionalForm : MaterialForm
    {
        private Timer timer;
        private int counter = 0;
        private MainForm mainForm;

        public AdditionalForm(MainForm mainForm)
        {
            InitializeComponent();
            InitializeMaterialSkin();
            InitializeForm();
            this.mainForm = mainForm;
            LoadClubs();
            LoadData();
        }

        private void InitializeMaterialSkin()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = Constants.ColorScheme;
        }

        private void InitializeForm()
        {
            status_bar_text.Text = "";
            timer = new Timer { Interval = 1000 };
            timer.Tick += Timer_Tick;
            this.Icon = new System.Drawing.Icon("images/app_icon.ico");
        }

        private void LoadClubs()
        {
            try
            {
                clubsComboBox.Items.Clear();
                Constants.Connection.Open();
                string query = "SELECT club_name FROM clubs ORDER BY club_name";
                using (var cmd = new NpgsqlCommand(query, Constants.Connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clubsComboBox.Items.Add(reader["club_name"].ToString());
                    }
                }
                Constants.Connection.Close();
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Ошибка загрузки клубов: {ex.Message}");
                Constants.Connection.Close();
            }
        }

        private void LoadData()
        {
            try
            {
                visitorsPanel.Controls.Clear();
                Constants.Connection.Open();

                string query = @"SELECT 
                                c.client_fullname,
                                EXTRACT(YEAR FROM AGE(CURRENT_DATE, c.client_birth_date)) as age,
                                cl.club_name,
                                MAX(v.move_date) as last_visit_date,
                                SUM(v.days_num) as total_visits,
                                SUM(get_fish_price(v.trout, 'Форель', v.move_date) + 
                                    get_fish_price(v.silver_carp, 'Толстолобик', v.move_date) + 
                                    get_fish_price(v.carp, 'Карп', v.move_date) + 
                                    get_fish_price(v.crucian_carp, 'Карась', v.move_date)) as total_amount
                            FROM visits v
                            JOIN clients c ON c.client_id = v.client_id
                            JOIN clubs cl ON cl.club_id = c.club_id";

                if (filterToggle.Checked)
                {
                    query += $" WHERE v.move_date = '{visitDatePicker.Value:yyyy-MM-dd}'";
                    if (clubsComboBox.SelectedItem != null)
                        query += $" AND cl.club_name = '{clubsComboBox.SelectedItem}'";
                }

                query += " GROUP BY c.client_fullname, age, cl.club_name, c.client_id ORDER BY c.client_fullname";

                using (var cmd = new NpgsqlCommand(query, Constants.Connection))
                using (var reader = cmd.ExecuteReader())
                {
                    int topPosition = 20;
                    while (reader.Read())
                    {
                        var panel = CreateVisitorPanel(
                            reader["client_fullname"].ToString(),
                            reader["age"].ToString(),
                            reader["club_name"].ToString(),
                            reader["last_visit_date"].ToString(),
                            reader["total_visits"].ToString(),
                            reader["total_amount"].ToString(),
                            topPosition
                        );
                        visitorsPanel.Controls.Add(panel);
                        topPosition += panel.Height + 15;
                    }
                }
                Constants.Connection.Close();
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Ошибка загрузки данных: {ex.Message}");
                Constants.Connection.Close();
            }
        }

        private Panel CreateVisitorPanel(string fullName, string age, string club, string lastVisit, string visitsCount, string totalAmount, int top)
        {
            var panel = new Panel
            {
                Size = new Size(720, 180),
                Location = new Point(20, top),
                BackColor = System.Drawing.Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(15)
            };

            decimal amount = decimal.TryParse(totalAmount, out decimal result) ? result : 0;
            string discount = CalculateDiscount(amount);

            var info = new StringBuilder();
            info.AppendLine($"ФИО: {fullName}");
            info.AppendLine();
            info.AppendLine($"Возраст: {age}");
            info.AppendLine();
            info.AppendLine($"Клуб: {club}");
            info.AppendLine();
            info.AppendLine($"Дата последнего заезда: {lastVisit}");
            info.AppendLine();
            info.AppendLine($"Количество посещений: {visitsCount}");
            info.AppendLine();
            info.AppendLine($"Общая сумма: {totalAmount} руб.");
            info.AppendLine($"Скидка: {discount}");

            var infoLabel = new Label
            {
                Text = info.ToString(),
                Font = new Font("Arial", 10),
                Location = new Point(10, 10),
                AutoSize = true
            };

            panel.Controls.Add(infoLabel);
            return panel;
        }

        private string CalculateDiscount(decimal totalAmount)
        {
            if (totalAmount > 10000) return "15%";
            if (totalAmount > 7000) return "10%";
            if (totalAmount > 5000) return "5%";
            return "0%";
        }

        private void ShowStatusMessage(string message)
        {
            status_bar_text.Text = message;
            counter = 0;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            counter++;
            if (counter >= 3)
            {
                timer.Stop();
                status_bar_text.Text = "";
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            mainForm.Show();
            mainForm.additionalForm = null;
        }

        private void clubsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filterToggle.Checked) LoadData();
        }

        private void visitDatePicker_ValueChanged(object sender, EventArgs e)
        {
            if (filterToggle.Checked) LoadData();
        }

        private void filterToggle_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}