using FontAwesome.Sharp;
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
            LoadPosts();
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

            // Настройка многострочного поля
            materialTextBoxOtherInfo.Multiline = true;
            materialTextBoxOtherInfo.ScrollBars = (RichTextBoxScrollBars)ScrollBars.Vertical;
        }

        private void LoadPosts()
        {
            materialComboBoxPost.Items.Clear();
            try
            {
                Constants.Connection.Open();
                string query = "SELECT DISTINCT aspirant_post FROM aspirants";
                using (var cmd = new NpgsqlCommand(query, Constants.Connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        materialComboBoxPost.Items.Add(reader.GetString(0));
                    }
                }
                Constants.Connection.Close();
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Ошибка загрузки должностей: {ex.Message}");
                Constants.Connection.Close();
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            panelResults.Controls.Clear();

            string query = "SELECT * FROM aspirants WHERE 1=1";
            var parameters = new Dictionary<string, object>();

            // Добавляем условия фильтрации
            if (!string.IsNullOrEmpty(materialComboBoxPost.Text))
            {
                query += " AND aspirant_post ILIKE @post";
                parameters.Add("@post", $"%{materialComboBoxPost.Text}%");
            }

            if (!string.IsNullOrEmpty(materialTextBoxQualification.Text))
            {
                query += " AND aspirant_qualification ILIKE @qualification";
                parameters.Add("@qualification", $"%{materialTextBoxQualification.Text}%");
            }

            if (!string.IsNullOrEmpty(materialTextBoxEducation.Text))
            {
                query += " AND aspirant_education ILIKE @education";
                parameters.Add("@education", $"%{materialTextBoxEducation.Text}%");
            }

            if (!string.IsNullOrEmpty(materialTextBoxExperience.Text) &&
                int.TryParse(materialTextBoxExperience.Text, out int exp))
            {
                query += " AND aspirant_exp = @exp";
                parameters.Add("@exp", exp);
            }

            if (!string.IsNullOrEmpty(materialTextBoxOtherInfo.Text))
            {
                query += " AND aspirant_other_info ILIKE @otherInfo";
                parameters.Add("@otherInfo", $"%{materialTextBoxOtherInfo.Text}%");
            }

            try
            {
                Constants.Connection.Open();
                using (var cmd = new NpgsqlCommand(query, Constants.Connection))
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        int yPos = 10;
                        while (reader.Read())
                        {
                            Panel card = CreateAspirantCard(reader);
                            card.Location = new Point(10, yPos);
                            yPos += card.Height + 10;
                            panelResults.Controls.Add(card);
                        }

                        if (yPos == 10)
                        {
                            ShowStatusMessage("Соискатели не найдены");
                        }
                    }
                }
                Constants.Connection.Close();
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Ошибка поиска: {ex.Message}");
                Constants.Connection.Close();
            }
        }

        private Panel CreateAspirantCard(NpgsqlDataReader reader)
        {
            // Рассчитываем возраст
            DateTime birthDate = reader.GetDateTime(reader.GetOrdinal("aspirant_birth_date"));
            int age = DateTime.Now.Year - birthDate.Year;
            if (birthDate > DateTime.Now.AddYears(-age)) age--;

            // Преобразуем пол
            string gender = reader["aspirant_gender"].ToString() == "м" ? "Мужской" :
                          reader["aspirant_gender"].ToString() == "ж" ? "Женский" : "Не указан";

            // Получаем статус
            string status = GetAspirantStatus(reader.GetInt32(0));

            Panel panel = new Panel
            {
                Width = panelResults.Width - 25,
                Height = 220,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            StringBuilder info = new StringBuilder();
            info.AppendLine($"ФИО: {reader["aspirant_fullname"]}");
            info.AppendLine($"Возраст: {age}");
            info.AppendLine($"Пол: {gender}");
            info.AppendLine($"Должность: {reader["aspirant_post"]}");
            info.AppendLine($"Образование: {reader["aspirant_education"]}");
            info.AppendLine($"Квалификация: {reader["aspirant_qualification"]}");
            info.AppendLine($"Предполагаемая з/пл: {reader["aspirant_salary"]} руб.");
            info.AppendLine($"Стаж: {reader["aspirant_exp"]} лет");
            info.AppendLine($"Дата заполнения: {Convert.ToDateTime(reader["aspirant_filling_date"]):dd.MM.yyyy}");
            info.AppendLine($"Статус: {status}");
            info.AppendLine($"Доп. информация: {reader["aspirant_other_info"]}");

            Label label = new Label
            {
                Text = info.ToString(),
                Font = new Font("Arial", 10),
                AutoSize = true,
                Location = new Point(10, 10)
            };

            panel.Controls.Add(label);
            return panel;
        }

        private string GetAspirantStatus(int aspirantId)
        {
            string status = "Активен";
            try
            {
                Constants.Connection.Open();
                string query = @"
                    SELECT deal_status 
                    FROM deals 
                    WHERE aspirant_id = @id 
                    ORDER BY deal_date DESC 
                    LIMIT 1";

                using (var cmd = new NpgsqlCommand(query, Constants.Connection))
                {
                    cmd.Parameters.AddWithValue("@id", aspirantId);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        status = result.ToString();
                    }
                }
                Constants.Connection.Close();
            }
            catch
            {
                // В случае ошибки оставляем статус по умолчанию
            }
            return status;
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
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            mainForm.additionalForm = null;
            mainForm.Show();
        }
    }
}