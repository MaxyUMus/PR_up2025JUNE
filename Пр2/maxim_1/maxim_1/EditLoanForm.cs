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

namespace maxim_1
{
    public partial class EditLoanForm : Form
    {
        private int loanId;
        private NpgsqlConnection conn = new NpgsqlConnection(Constants.ConnectionString);

        public EditLoanForm(int loanId)
        {
            InitializeComponent();
            this.loanId = loanId;
            LoadLoanData();
        }

        private void LoadLoanData()
        {
            conn.Open();
            string query = @"SELECT 
                r.reader_name, 
                b.book_name, 
                l.loan_date 
            FROM loans l
            JOIN readers r ON l.reader_id = r.reader_id
            JOIN books b ON l.book_id = b.book_id
            WHERE l.loan_id = @loanId";

            using (var cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@loanId", loanId);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtReader.Text = reader["reader_name"].ToString();
                        txtBook.Text = reader["book_name"].ToString();
                        txtLoanDate.Text = Convert.ToDateTime(reader["loan_date"]).ToString("dd.MM.yyyy");
                    }
                }
            }
            conn.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            conn.Open();
            string updateQuery = "UPDATE loans SET return_date = @returnDate WHERE loan_id = @loanId";

            using (var cmd = new NpgsqlCommand(updateQuery, conn))
            {
                cmd.Parameters.AddWithValue("@returnDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@loanId", loanId);
                cmd.ExecuteNonQuery();
            }

            conn.Close();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
