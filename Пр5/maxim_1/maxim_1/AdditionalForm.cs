using FontAwesome.Sharp;
using MaterialSkin;
using MaterialSkin.Controls;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
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
            LoadObjects();
        }

        private void InitializeMaterialSkin()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(
                Constants.AccentColor,
                Constants.AccentColor,
                Constants.AccentColor,
                Constants.SecondaryBackgroundColor,
                Methods.GetContrastTextShade(Constants.AccentColor));
        }

        private void InitializeForm()
        {
            status_bar_text.Text = "";
            timer = new Timer { Interval = 1000 };
            timer.Tick += Timer_Tick;
            this.Icon = new System.Drawing.Icon("images/app_icon.ico");
            go_back_button.Icon = IconChar.ArrowLeft.ToBitmap(
                Methods.GetContrastTextColor(Constants.AccentColor), 36);
        }

        private void LoadObjects()
        {
            try
            {
                items_panel.Controls.Clear();
                Constants.Connection.Open();

                string query = "SELECT * FROM objects";
                using (var cmd = new NpgsqlCommand(query, Constants.Connection))
                using (var reader = cmd.ExecuteReader())
                {
                    int topPosition = 20;
                    while (reader.Read())
                    {
                        var panel = CreateObjectPanel(reader, topPosition);
                        items_panel.Controls.Add(panel);
                        topPosition += panel.Height + 15;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Ошибка загрузки: {ex.Message}");
            }
            finally
            {
                Constants.Connection.Close();
            }
        }

        private Panel CreateObjectPanel(NpgsqlDataReader reader, int top)
        {
            var panel = new Panel
            {
                Size = new Size(720, 180),
                Location = new Point(20, top),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(15),
                Tag = reader["object_id"]
            };

            var info = new StringBuilder();
            info.AppendLine($"Адрес: {reader["object_address"]}");
            info.AppendLine($"Тип: {reader["property_type"]}");
            info.AppendLine($"Статус: {reader["object_status"]}");
            info.AppendLine($"Цена: {reader["price"]} млн");

            var infoLabel = new Label
            {
                Text = info.ToString(),
                Font = new Font("Arial", 10),
                Location = new Point(10, 10),
                AutoSize = true
            };

            var details = new StringBuilder();
            details.AppendLine($"Площадь: {reader["square"]} м²");
            details.AppendLine($"Комнат: {reader["room_count"]}");
            details.AppendLine($"Этаж: {reader["floor"]}");
            details.AppendLine($"Район: {reader["district"]}");

            var detailsLabel = new Label
            {
                Text = details.ToString(),
                Font = new Font("Arial", 9),
                Location = new Point(10, 90),
                AutoSize = true
            };
            var editButton = new MaterialButton
            {
                Text = "РЕДАКТИРОВАТЬ",
                Size = new Size(150, 36),
                Location = new Point(550, 120),
                Tag = reader["object_id"],
                UseAccentColor = true
            };
            editButton.Click += EditButton_Click;

            panel.Controls.Add(infoLabel);
            panel.Controls.Add(detailsLabel);
            panel.Controls.Add(editButton);

            return panel;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (sender is MaterialButton button && button.Tag != null)
            {
                int objectId = Convert.ToInt32(button.Tag);
                using (var editForm = new EditForm(objectId))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadObjects();
                    }
                }
            }
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
    }
}