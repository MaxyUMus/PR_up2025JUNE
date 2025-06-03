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
    public partial class EditVisitorForm : Form
    {
        private readonly int visitorId;

        public EditVisitorForm(int visitorId)
        {
            this.visitorId = visitorId;
            InitializeComponent();
            LoadVisitorData();
        }

        private void LoadVisitorData()
        {
            using var conn = new NpgsqlConnection(Constants.ConnectionString);
            conn.Open();

            const string query = "SELECT visitor_name, phone, bonus_points FROM visitors WHERE visitor_id = @id";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("id", visitorId);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtName.Text = reader["visitor_name"].ToString();
                txtPhone.Text = reader["phone"].ToString();
                numPoints.Value = Convert.ToInt32(reader["bonus_points"]);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Имя посетителя не может быть пустым");
                return;
            }

            using var conn = new NpgsqlConnection(Constants.ConnectionString);
            conn.Open();

            const string updateQuery = @"
                UPDATE visitors 
                SET visitor_name = @name, 
                    phone = @phone, 
                    bonus_points = @points 
                WHERE visitor_id = @id";

            using var cmd = new NpgsqlCommand(updateQuery, conn);
            cmd.Parameters.AddWithValue("name", txtName.Text.Trim());
            cmd.Parameters.AddWithValue("phone", txtPhone.Text.Trim());
            cmd.Parameters.AddWithValue("points", (int)numPoints.Value);
            cmd.Parameters.AddWithValue("id", visitorId);

            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Не удалось обновить данные посетителя");
            }
        }
    }
}
