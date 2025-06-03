using Microsoft.VisualBasic.Logging;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace maxim_1
{
    public partial class AdditionalForm : Form
    {
        private NpgsqlConnection conn = new NpgsqlConnection(Constants.ConnectionString);

        private Timer timer;
        private int counter = 0;
        private const int BaseCashback = 10;
        private const int DiscountCashback = 20;
        private MainForm mainForm;
        public AdditionalForm(MainForm mainForm)
        {
            InitializeComponent();
            InitializeHeader();
            status_bar_text.Text = "";

            timer = new Timer
            {
                Interval = 1000
            };
            timer.Tick += Timer_Tick;

            this.mainForm = mainForm;
            LoadVisitorsWithCashback();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            counter++;
            if (counter >= 3)
            {
                timer.Stop();
                status_bar_text.Text = "";
                counter = 0;
            }
        }
        
        private void InitializeHeader()
        {
            var headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.Pink,
            };

            var promoLabel = new Label
            {
                Text = "Акция! Скидка 20% в будни 12:00-14:00 | Кешбэк 10% на все услуги",
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            headerPanel.Controls.Add(promoLabel);
            Controls.Add(headerPanel);
            items_panel.AutoScroll = true;
        }

        private void LoadVisitorsWithCashback()
        {
            const string query = @"
                SELECT 
                    v.visitor_id, -- Добавляем идентификатор посетителя
                    v.visitor_name, 
                    v.phone, 
                    v.bonus_points,
                    EXISTS (
                        SELECT 1 
                        FROM reservations r 
                        WHERE r.visitor_id = v.visitor_id 
                            AND EXTRACT(DOW FROM r.datetime) BETWEEN 1 AND 5 
                            AND r.datetime::time BETWEEN '12:00' AND '14:00'
                    ) as has_discount
                FROM visitors v
                ORDER BY v.bonus_points DESC";

            try
            {
                items_panel.Controls.Clear();
                conn.Open();

                using var cmd = new NpgsqlCommand(query, conn);
                using var reader = cmd.ExecuteReader();

                int yPos = 20;
                while (reader.Read())
                {
                    int visitorId = Convert.ToInt32(reader["visitor_id"]);
                    var cashback = reader.GetBoolean(4) ? DiscountCashback : BaseCashback;
                    var card = CreateVisitorCard(
                        visitorId,
                        reader["visitor_name"].ToString(),
                        reader["phone"].ToString(),
                        Convert.ToInt32(reader["bonus_points"]),
                        cashback,
                        yPos
                    );
                    items_panel.Controls.Add(card);
                    yPos += card.Height + 15;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                status_bar_text.Text = $"Ошибка загрузки данных: {ex.Message}";
                counter = 0;
                timer.Start();
            }
        }


        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            mainForm.Show();
            mainForm.additionalForm = null;
        }

        private void go_back_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private Panel CreateVisitorCard(int visitorId, string name, string phone, int points, int cashbackPercent, int top)
        {
            var card = new Panel
            {
                Size = new Size(720, 80),
                Location = new Point(20, top),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(15),
                Tag = visitorId
            };

            var nameLabel = new Label
            {
                Text = name,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };

            var phoneLabel = new Label
            {
                Text = phone,
                Location = new Point(10, 40),
                AutoSize = true
            };

            var pointsLabel = new Label
            {
                Text = $"Баллы: {points}",
                Location = new Point(500, 10),
                AutoSize = true
            };

            var cashbackLabel = new Label
            {
                Text = $"Кешбэк: {cashbackPercent}%",
                ForeColor = cashbackPercent == DiscountCashback ? Color.Green : Color.DarkBlue,
                Location = new Point(500, 40),
                AutoSize = true
            };

            var editButton = new Button
            {
                Text = "✎",
                Font = new Font("Arial", 10, FontStyle.Bold),
                Size = new Size(30, 30),
                Location = new Point(650, 25),
                Tag = visitorId,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.LightGray
            };
            editButton.FlatAppearance.BorderSize = 0;
            editButton.Click += EditButton_Click;

            card.Controls.AddRange(new Control[] {
                nameLabel, phoneLabel, pointsLabel, cashbackLabel, editButton
            });
            return card;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is int visitorId)
            {
                using var editForm = new EditVisitorForm(visitorId);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadVisitorsWithCashback();
                }
            }
        }
    }
}
