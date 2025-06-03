using MaterialSkin;
using MaterialSkin.Controls;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace maxim_1
{
    public partial class EditForm : MaterialForm
    {
        private readonly int objectId;
        private readonly NpgsqlConnection conn = Constants.Connection;

        public EditForm(int objectId)
        {
            InitializeComponent();
            this.objectId = objectId;
            InitializeMaterialSkin();
            LoadObjectData();
            InitializeStatusComboBox();
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

        private void LoadObjectData()
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM objects WHERE object_id = @id";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("id", objectId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtAddress.Text = reader["object_address"].ToString();
                            txtType.Text = reader["property_type"].ToString();
                            txtSquare.Text = reader["square"].ToString();
                            numRooms.Value = Convert.ToInt32(reader["room_count"]);
                            txtDistrict.Text = reader["district"].ToString();
                            numFloor.Value = Convert.ToInt32(reader["floor"]);
                            txtPrice.Text = reader["price"].ToString();
                            txtOwner.Text = reader["owner_name"].ToString();
                            txtPhone.Text = reader["phone"].ToString();
                            dtpRegDate.Value = Convert.ToDateTime(reader["registration_date"]);
                            numYear.Value = Convert.ToInt32(reader["construction_year"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clipboard.SetText(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void InitializeStatusComboBox()
        {
            var statusValues = Methods.GetEnumValues("status_enum");
            cmbStatus.DataSource = statusValues;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                conn.Open();
                string updateQuery = @"
                    UPDATE objects SET
                        object_status = @status::status_enum,
                        square = @square,
                        room_count = @rooms,
                        object_address = @address,
                        construction_year = @year,
                        district = @district,
                        floor = @floor,
                        price = @price,
                        property_type = @type,
                        owner_name = @owner,
                        phone = @phone,
                        registration_date = @regdate
                    WHERE object_id = @id";

                using (var cmd = new NpgsqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("status", cmbStatus.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("square", txtSquare.Text);
                    cmd.Parameters.AddWithValue("rooms", (int)numRooms.Value);
                    cmd.Parameters.AddWithValue("address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("year", (int)numYear.Value);
                    cmd.Parameters.AddWithValue("district", txtDistrict.Text);
                    cmd.Parameters.AddWithValue("floor", (int)numFloor.Value);
                    cmd.Parameters.AddWithValue("price", decimal.Parse(txtPrice.Text));
                    cmd.Parameters.AddWithValue("type", txtType.Text);
                    cmd.Parameters.AddWithValue("owner", txtOwner.Text);
                    cmd.Parameters.AddWithValue("phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("regdate", dtpRegDate.Value);
                    cmd.Parameters.AddWithValue("id", objectId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clipboard.SetText(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Адрес объекта не может быть пустым", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Укажите корректную цену", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Methods.ValidatePhoneNumber(txtPhone.Text))
            {
                MessageBox.Show("Укажите телефон в формате +7(XXX)XXX-XXXX", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}