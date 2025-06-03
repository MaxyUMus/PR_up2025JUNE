using FontAwesome.Sharp;
using MaterialSkin;
using MaterialSkin.Controls;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media;
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
            LoadPartners();
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

        struct Partner 
        {
            public string partner_id;
            public string partner_type;
            public string partner_name;
            public string contact_person;
            public string phone;
            public string rating;
            public decimal totalSales;
        }

        private void LoadPartners()
        {
            try
            {
                partnersPanel.Controls.Clear();
                List<Partner> ps = new List<Partner>();
                Constants.Connection.Open();
                string query = "SELECT * FROM partners ORDER BY partner_name";
                using (var cmd = new NpgsqlCommand(query, Constants.Connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Partner p = new Partner();
                        p.partner_id = reader["partner_id"].ToString();
                        p.partner_type = reader["partner_type"].ToString();
                        p.partner_name = reader["partner_name"].ToString();
                        p.contact_person = reader["contact_person"].ToString();
                        p.phone = reader["phone"].ToString();
                        p.rating = reader["rating"].ToString();
                        ps.Add(p);
                        
                        
                    }
                }

                int topPosition = 20;
                for (int i = 0; i < ps.Count; i++)
                {
                    Partner p = ps[i];
                    p.totalSales = GetTotalSalesForPartner(Convert.ToInt32(p.partner_id));
                    var panel = CreatePartnerPanel(p.partner_id, p.partner_type, p.partner_name, p.contact_person, p.phone, p.rating, p.totalSales, topPosition);
                    partnersPanel.Controls.Add(panel);
                    topPosition += panel.Height + 15;
                }


                Constants.Connection.Close();
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Ошибка загрузки партнеров: {ex.Message}");
                Constants.Connection.Close();
            }
        }

        private Panel CreatePartnerPanel(string partner_id, string partner_type, string partner_name, string contact_person, string phone, string rating, decimal totalSales, int top)
        {
            var panel = new Panel
            {
                Size = new Size(720, 180),
                Location = new Point(20, top),
                BackColor = System.Drawing.Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(15),
                Tag = partner_id
            };
            decimal discount = CalculateDiscount(totalSales);

            var info = new StringBuilder();
            info.AppendLine($"{partner_type}/{partner_name} {discount * 100}%");
            info.AppendLine();
            info.AppendLine($"Контактное лицо: {contact_person}");
            info.AppendLine();
            info.AppendLine($"Телефон: {phone}");
            info.AppendLine();
            info.AppendLine($"Рейтинг: {rating}/10");

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

        private decimal GetTotalSalesForPartner(int partnerId)
        {
            decimal totalSales = 0;
            try
            {
                string query = "SELECT COALESCE(SUM(total_amount), 0) FROM sales WHERE partner_id = @partnerId";
                using (var cmd = new NpgsqlCommand(query, Constants.Connection))
                {
                    cmd.Parameters.AddWithValue("@partnerId", partnerId);
                    totalSales = Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage(ex.Message);
            }
            return totalSales;
        }

        private decimal CalculateDiscount(decimal totalSales)
        {
            if (totalSales > 300000) return 0.15m;
            if (totalSales > 50000) return 0.10m;
            if (totalSales > 10000) return 0.05m;
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            mainForm.Show();
            mainForm.additionalForm = null;
        }
    }
}