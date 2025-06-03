using FontAwesome.Sharp;
using MaterialSkin;
using MaterialSkin.Controls;
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
    public partial class MainForm : MaterialForm
    {
        private NpgsqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private Timer timer;
        private int counter = 0;

        public AdditionalForm additionalForm;

        public MainForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(
                Constants.AccentColor,
                Constants.AccentColor,
                Constants.AccentColor,
                Constants.SecondaryBackgroundColor,
                Methods.GetContrastTextShade(Constants.AccentColor));
            Init();
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

        private void ShowStatusMessage(string message)
        {
            status_bar_text.Text = message;
            counter = 0;
            timer.Start();
        }

        private void Init()
        {
            List<string> tables = Methods.GetDatabaseTables();

            tables_box.Items.Clear();
            tables_box.Items.AddRange(tables.ToArray());
            tables_box.DropDownStyle = ComboBoxStyle.DropDownList;
            tables_box.SelectedIndex = 0;

            status_bar_text.Text = "";

            timer = new Timer
            {
                Interval = 1000
            };
            timer.Tick += Timer_Tick;

            this.Icon = new System.Drawing.Icon("images/app_icon.ico");
            btn_save.Icon = IconChar.FloppyDisk.ToBitmap(Methods.GetContrastTextColor(Constants.AccentColor), 36);
            btn_delete.Icon = IconChar.Trash.ToBitmap(Methods.GetContrastTextColor(Constants.AccentColor), 36);
        }

        private void tables_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            table_view.DataSource = null;
            dataAdapter = new NpgsqlDataAdapter($"SELECT * FROM {tables_box.Text}", Constants.Connection);
            dataTable = new DataTable();

            NpgsqlCommandBuilder commandBuilder = new NpgsqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(dataTable);

            table_view.DataSource = dataTable;
            table_view.Columns[0].Visible = false;

            Dictionary<string, DataTable> fkData = new Dictionary<string, DataTable>();
            Dictionary<string, List<string>> enumColumns = new Dictionary<string, List<string>>();

            var columnsInfo = Methods.GetTableColumnsInfo(tables_box.Text);

            for (int i = 1; i < dataTable.Columns.Count; i++)
            {
                DataColumn column = dataTable.Columns[i];
                if (column.ColumnName.EndsWith("_id"))
                {
                    string relatedTable = column.ColumnName.Replace("_id", "s");
                    if (Methods.TableExists(relatedTable))
                    {
                        try
                        {
                            var fkAdapter = new NpgsqlDataAdapter($"SELECT * FROM {relatedTable}", Constants.Connection);
                            DataTable fkTable = new DataTable();
                            fkAdapter.Fill(fkTable);
                            fkData.Add(column.ColumnName, fkTable);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Clipboard.SetText(ex.Message);
                        }
                    }
                }

                var columnInfo = columnsInfo.FirstOrDefault(c => c.ColumnName == column.ColumnName);
                if (columnInfo != null && columnInfo.IsEnum)
                {
                    var enumValues = Methods.GetEnumValues(columnInfo.EnumTypeName);
                    enumColumns.Add(column.ColumnName, enumValues);
                }
            }

            foreach (var fk in fkData)
            {
                if (table_view.Columns.Contains(fk.Key))
                {
                    string col_name = fk.Key.Replace("_id", "");
                    if (fk.Value.Columns.Contains(col_name + "_name"))
                    {
                        col_name += "_name";
                    }
                    else if (fk.Value.Columns.Contains(col_name + "_fullname"))
                    {
                        col_name += "_fullname";
                    }
                    else if (fk.Value.Columns.Contains(col_name + "_address"))
                    {
                        col_name += "_address";
                    }

                    DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn
                    {
                        DataSource = fk.Value,
                        DisplayMember = col_name,
                        ValueMember = fk.Key,
                        DataPropertyName = fk.Key,
                        HeaderText = col_name.Replace("_", " "),
                        FlatStyle = FlatStyle.Flat
                    };

                    int columnIndex = table_view.Columns[fk.Key].Index;
                    table_view.Columns.Remove(fk.Key);
                    table_view.Columns.Insert(columnIndex, combo);
                }
            }

            foreach (var enumCol in enumColumns)
            {
                if (table_view.Columns.Contains(enumCol.Key))
                {
                    DataTable enumTable = new DataTable();
                    enumTable.Columns.Add("Value", typeof(string));
                    enumTable.Columns.Add("Display", typeof(string));

                    foreach (var value in enumCol.Value)
                    {
                        enumTable.Rows.Add(value, value);
                    }

                    DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn
                    {
                        DataSource = enumTable,
                        ValueMember = "Value",
                        DisplayMember = "Display",
                        DataPropertyName = enumCol.Key,
                        HeaderText = enumCol.Key.Replace("_", " "),
                        FlatStyle = FlatStyle.Flat
                    };

                    int columnIndex = table_view.Columns[enumCol.Key].Index;
                    table_view.Columns.Remove(enumCol.Key);
                    table_view.Columns.Insert(columnIndex, combo);
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                dataAdapter.Update(dataTable);
                ShowStatusMessage("Изменения успешно сохранены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clipboard.SetText(ex.Message);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (table_view.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in table_view.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        table_view.Rows.Remove(row);
                    }
                }

                try
                {
                    dataAdapter.Update(dataTable);
                    ShowStatusMessage("Строки успешно удалены!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clipboard.SetText(ex.Message);
                }
            }
            else
            {
                ShowStatusMessage("Сначала выберите строки!");
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit();
        }

        private void go_to_additional_button_Click(object sender, EventArgs e)
        {
            if (additionalForm == null)
                additionalForm = new AdditionalForm(this);

            additionalForm.Show();
            this.Hide();
        }
    }
}
