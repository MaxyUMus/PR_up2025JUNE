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
        private MainForm mainForm;
        public AdditionalForm(MainForm mainForm)
        {
            InitializeComponent();
            conn.Open();
            status_bar_text.Text = "";

            timer = new Timer
            {
                Interval = 1000
            };
            timer.Tick += Timer_Tick;

            this.mainForm = mainForm;
            LoadData();
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

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            mainForm.Show();
            mainForm.additionalForm = null;
            conn.Close();
        }

        private void go_back_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadData()
        {
            items_panel.Controls.Clear();

            string query = @"SELECT 
                l.loan_id, -- Добавляем идентификатор выдачи
                r.reader_id,
                r.reader_name,
                r.phone,
                b.author,
                b.book_name,
                l.quantity,
                l.loan_date,
                l.return_date,
                COALESCE(lo.overdue_days, 0) as overdue_days
            FROM readers r
            JOIN loans l ON r.reader_id = l.reader_id
            JOIN books b ON l.book_id = b.book_id
            LEFT JOIN loan_with_overdue lo ON l.loan_id = lo.loan_id
            WHERE l.return_date IS NULL
            ORDER BY r.reader_id;";
            using (var cmd = new NpgsqlCommand(query, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int loanId = Convert.ToInt32(reader["loan_id"]);
                    int readerId = Convert.ToInt32(reader["reader_id"]);
                    string readerName = reader["reader_name"].ToString();
                    string phone = reader["phone"].ToString();
                    string author = reader["author"].ToString();
                    string bookName = reader["book_name"].ToString();
                    int quantity = Convert.ToInt32(reader["quantity"]);
                    DateTime loanDate = Convert.ToDateTime(reader["loan_date"]);
                    int overdueDays = Convert.ToInt32(reader["overdue_days"]);

                    string returnStatus = reader["return_date"] is DBNull ?
                        $"Срок сдачи: {(14 - (DateTime.Now - loanDate).Days)} дней" :
                        "Возвращено";

                    AddVisibleItem(loanId, readerId, readerName, phone, author, bookName,
                               quantity, loanDate, returnStatus, overdueDays);
                }
            }
        }


        private void AddVisibleItem(int loanId, int readerId, string readerName, string phone, string author,
                        string bookName, int quantity, DateTime loanDate,
                        string returnStatus, int overdueDays)
        {
            Panel itemPanel = new Panel
            {
                Tag = loanId,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(8, 8),
                Size = new Size(630, 120),
                BackColor = Constants.PrimaryBackgroundColor,
                Cursor = Cursors.Hand
            };

            itemPanel.DoubleClick += (sender, e) =>
            {
                EditLoanForm editForm = new EditLoanForm(loanId);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            };

            itemPanel.Controls.Add(new Label
            {
                AutoSize = true,
                Font = new Font("Times New Roman", 13.8F),
                Location = new Point(6, 6),
                Text = $"{readerName}"
            });

            itemPanel.Controls.Add(new Label
            {
                AutoSize = true,
                Font = new Font("Times New Roman", 10.2F),
                Location = new Point(6, 34),
                Text = $"Номер телефона: {phone}"
            });

            itemPanel.Controls.Add(new Label
            {
                AutoSize = true,
                Font = new Font("Times New Roman", 10.2F),
                Location = new Point(6, 53),
                Text = $"{author} - {bookName}"
            });

            itemPanel.Controls.Add(new Label
            {
                AutoSize = true,
                Font = new Font("Times New Roman", 10.2F),
                Location = new Point(6, 72),
                Text = $"Количество: {quantity} | Выдано: {loanDate:dd.MM.yyyy}"
            });

            itemPanel.Controls.Add(new Label
            {
                AutoSize = true,
                Font = new Font("Times New Roman", 10.2F, FontStyle.Bold),
                Location = new Point(6, 91),
                ForeColor = overdueDays > 0 ? Color.Red : Color.Black,
                Text = returnStatus == "Возвращено" ? returnStatus : $"Задолженность: {overdueDays} дней"
            });

            items_panel.Controls.Add(itemPanel);
        }

    }
}
