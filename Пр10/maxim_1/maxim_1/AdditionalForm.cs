using MaterialSkin;
using MaterialSkin.Controls;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace maxim_1
{
    public partial class AdditionalForm : MaterialForm
    {
        private System.Windows.Forms.Timer timer;
        private int counter = 0;
        private MainForm mainForm;

        public AdditionalForm(MainForm mainForm)
        {
            InitializeComponent();
            InitializeMaterialSkin();
            InitializeForm();
            this.mainForm = mainForm;
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
            timer = new System.Windows.Forms.Timer { Interval = 1000 };
            timer.Tick += Timer_Tick;
            this.Icon = new System.Drawing.Icon("images/app_icon.ico");
            dateFilter.Value = DateTime.Today;
            dateFilter.Visible = toggleFilters.Checked;
        }

        private void LoadData()
        {
            try
            {
                clientsPanel.Controls.Clear();
                Constants.Connection.Open();

                string query = @"SELECT 
                                client_fullname, 
                                client_phone_number, 
                                agreement_date,
                                COUNT(agreement_id) as agreement_count, 
                                SUM(summ) as total_summ 
                               FROM agreements";

                if (toggleFilters.Checked)
                {
                    query += $" WHERE agreement_date = '{dateFilter.Value:yyyy-MM-dd}'";
                }

                query += " GROUP BY client_fullname, client_phone_number, agreement_date";

                using (var cmd = new NpgsqlCommand(query, Constants.Connection))
                using (var reader = cmd.ExecuteReader())
                {
                    int topPosition = 20;
                    while (reader.Read())
                    {
                        var panel = CreateClientPanel(
                            reader["client_fullname"].ToString(),
                            reader["client_phone_number"].ToString(),
                            reader["agreement_count"].ToString(),
                            reader["agreement_date"].ToString(),
                            decimal.Parse(reader["total_summ"].ToString()),
                            topPosition
                        );
                        clientsPanel.Controls.Add(panel);
                        topPosition += panel.Height + 15;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Ошибка загрузки данных: {ex.Message}");
            }
            finally
            {
                Constants.Connection.Close();
            }
        }

        private Panel CreateClientPanel(string fullName, string phone, string agreementCount, string agreement_date, decimal totalSum, int top)
        {
            var panel = new Panel
            {
                Size = new Size(720, 140),
                Location = new Point(20, top),
                BackColor = System.Drawing.Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(15)
            };

            var info = new System.Text.StringBuilder();
            info.AppendLine($"ФИО клиента: {fullName}");
            info.AppendLine($"Телефон: {phone}");
            info.AppendLine($"Количество договоров: {agreementCount}");
            info.AppendLine($"Дата последнего договора: {agreement_date}");
            info.AppendLine($"Общая сумма: {totalSum} руб.");
            info.AppendLine($"Скидка: {CalculateDiscount(totalSum) * 100}%");

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

        private decimal CalculateDiscount(decimal totalSum)
        {
            if (totalSum > 100000) return 0.15m;
            if (totalSum > 50000) return 0.10m;
            if (totalSum > 10000) return 0.05m;
            return 0m;
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

        private void go_back_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toggleFilters_CheckedChanged(object sender, EventArgs e)
        {
            dateFilter.Visible = toggleFilters.Checked;
            LoadData();
        }

        private void dateFilter_ValueChanged(object sender, EventArgs e)
        {
            if (toggleFilters.Checked)
            {
                LoadData();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            mainForm.Show();
            mainForm.additionalForm = null;
        }
    }
}