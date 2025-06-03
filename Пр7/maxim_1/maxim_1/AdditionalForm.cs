using FontAwesome.Sharp;
using MaterialSkin;
using MaterialSkin.Controls;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace maxim_1
{
    public partial class AdditionalForm : MaterialForm
    {
        private System.Windows.Forms.Timer timer;
        private int counter = 0;
        private MainForm mainForm;
        private List<CartItem> cartItems = new List<CartItem>();
        private int nextCheckNumber = 2365899; // Starting from next available number

        public AdditionalForm(MainForm mainForm)
        {
            InitializeComponent();
            InitializeMaterialSkin();
            InitializeForm();
            this.mainForm = mainForm;
            LoadProducts();
            LoadBuyers();
            InitializeCart();
            GenerateNewCheckNumber();
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

            // Set default values
            purchaseDatePicker.Value = DateTime.Now;
            deliveryDatePicker.Value = DateTime.Now.AddDays(3);
            statusComboBox.SelectedIndex = 0;
            priorityComboBox.SelectedIndex = 1;
        }

        private void InitializeCart()
        {
            cartDataGridView.AutoGenerateColumns = false;
            cartDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductName",
                HeaderText = "Товар",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            cartDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Price",
                HeaderText = "Цена",
                Width = 100
            });
            cartDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "Количество",
                Width = 80
            });
            cartDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Total",
                HeaderText = "Сумма",
                Width = 100
            });

            UpdateCartTotal();
        }

        private void LoadProducts()
        {
            try
            {
                Constants.Connection.Open();
                string query = "SELECT product_id, product_name, product_price, product_quantity FROM products ORDER BY product_name";
                using (var cmd = new NpgsqlCommand(query, Constants.Connection))
                using (var adapter = new NpgsqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    productComboBox.DataSource = dt;
                    productComboBox.DisplayMember = "product_name";
                    productComboBox.ValueMember = "product_id";
                }
                ShowStatusMessage("Успех!");
                Constants.Connection.Close();
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Ошибка загрузки товаров: {ex.Message}");
                Constants.Connection.Close();
            }
        }

        private void LoadBuyers()
        {
            try
            {
                Constants.Connection.Open();
                string query = "SELECT buyer_id, buyer_fullname FROM buyers ORDER BY buyer_fullname";
                using (var cmd = new NpgsqlCommand(query, Constants.Connection))
                using (var adapter = new NpgsqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    buyerComboBox.DataSource = dt;
                    buyerComboBox.DisplayMember = "buyer_fullname";
                    buyerComboBox.ValueMember = "buyer_id";
                }
                Constants.Connection.Close();
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Ошибка загрузки покупателей: {ex.Message}");
                Constants.Connection.Close();
            }
        }

        private void GenerateNewCheckNumber()
        {
            checkNumberLabel.Text = $"Номер чека: {nextCheckNumber++}";
        }

        private void addToCartButton_Click(object sender, EventArgs e)
        {
            if (productComboBox.SelectedValue == null || !int.TryParse(quantityTextBox.Text, out int quantity) || quantity <= 0)
            {
                ShowStatusMessage("Укажите товар и корректное количество");
                return;
            }

            DataRowView selectedProduct = (DataRowView)productComboBox.SelectedItem;
            int productId = (int)selectedProduct["product_id"];
            string productName = selectedProduct["product_name"].ToString();
            int price = (int)selectedProduct["product_price"];
            int availableQuantity = (int)selectedProduct["product_quantity"];

            if (quantity > availableQuantity)
            {
                ShowStatusMessage($"Недостаточно товара на складе. Доступно: {availableQuantity}");
                return;
            }

            // Check if product already in cart
            var existingItem = cartItems.FirstOrDefault(item => item.ProductId == productId);
            if (existingItem != null)
            {
                if (existingItem.Quantity + quantity > availableQuantity)
                {
                    ShowStatusMessage($"Недостаточно товара на складе. Уже в корзине: {existingItem.Quantity}, доступно: {availableQuantity}");
                    return;
                }
                existingItem.Quantity += quantity;
            }
            else
            {
                cartItems.Add(new CartItem
                {
                    ProductId = productId,
                    ProductName = productName,
                    Price = price,
                    Quantity = quantity
                });
            }

            RefreshCartGrid();
            UpdateCartTotal();
            quantityTextBox.Text = "1";
        }

        private void RefreshCartGrid()
        {
            cartDataGridView.DataSource = null;
            cartDataGridView.DataSource = cartItems.Select(item => new
            {
                ProductName = item.ProductName,
                Price = item.Price,
                Quantity = item.Quantity,
                Total = item.Price * item.Quantity
            }).ToList();
        }

        private void UpdateCartTotal()
        {
            decimal total = cartItems.Sum(item => item.Price * item.Quantity);
            totalLabel.Text = $"Итого: {total} руб.";
        }

        private void removeFromCartButton_Click(object sender, EventArgs e)
        {
            if (cartDataGridView.SelectedRows.Count > 0)
            {
                int selectedIndex = cartDataGridView.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < cartItems.Count)
                {
                    cartItems.RemoveAt(selectedIndex);
                    RefreshCartGrid();
                    UpdateCartTotal();
                }
            }
        }

        private void clearCartButton_Click(object sender, EventArgs e)
        {
            cartItems.Clear();
            RefreshCartGrid();
            UpdateCartTotal();
        }

        private void savePurchaseButton_Click(object sender, EventArgs e)
        {
            if (cartItems.Count == 0)
            {
                ShowStatusMessage("Корзина пуста");
                return;
            }

            try
            {
                Constants.Connection.Open();
                using (var transaction = Constants.Connection.BeginTransaction())
                {
                    try
                    {
                        int? buyerId = buyerComboBox.SelectedValue != null ? (int?)buyerComboBox.SelectedValue : null;
                        DateTime purchaseDate = purchaseDatePicker.Value;
                        DateTime? deliveryDate = deliveryCheckBox.Checked ? (DateTime?)deliveryDatePicker.Value : null;
                        string status = statusComboBox.SelectedItem?.ToString() ?? "новый";
                        string priority = priorityComboBox.SelectedItem?.ToString() ?? "средний";
                        string deliveryPerformer = deliveryPerformerTextBox.Text;

                        foreach (var item in cartItems)
                        {
                            string query = @"
                                INSERT INTO purchases (
                                    purchase_check_number, 
                                    product_id, 
                                    purchase_amount, 
                                    buyer_id, 
                                    purchase_date, 
                                    purchase_summ, 
                                    delivery_date, 
                                    delivery_performer, 
                                    purchase_status, 
                                    purchase_priority
                                ) VALUES (
                                    @checkNumber, 
                                    @productId, 
                                    @amount, 
                                    @buyerId, 
                                    @purchaseDate, 
                                    @summ, 
                                    @deliveryDate, 
                                    @deliveryPerformer, 
                                    @status, 
                                    @priority
                                )";

                            using (var cmd = new NpgsqlCommand(query, Constants.Connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@checkNumber", nextCheckNumber - 1);
                                cmd.Parameters.AddWithValue("@productId", item.ProductId);
                                cmd.Parameters.AddWithValue("@amount", item.Quantity);
                                cmd.Parameters.AddWithValue("@buyerId", buyerId ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@purchaseDate", purchaseDate);
                                cmd.Parameters.AddWithValue("@summ", item.Price * item.Quantity);
                                cmd.Parameters.AddWithValue("@deliveryDate", deliveryDate ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@deliveryPerformer", string.IsNullOrEmpty(deliveryPerformer) ? (object)DBNull.Value : deliveryPerformer);
                                cmd.Parameters.AddWithValue("@status", status);
                                cmd.Parameters.AddWithValue("@priority", priority);

                                cmd.ExecuteNonQuery();
                            }

                            // Update product quantity
                            string updateQuery = "UPDATE products SET product_quantity = product_quantity - @quantity WHERE product_id = @productId";
                            using (var updateCmd = new NpgsqlCommand(updateQuery, Constants.Connection, transaction))
                            {
                                updateCmd.Parameters.AddWithValue("@quantity", item.Quantity);
                                updateCmd.Parameters.AddWithValue("@productId", item.ProductId);
                                updateCmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        ShowStatusMessage("Покупка успешно сохранена");

                        // Clear cart and generate new check number
                        cartItems.Clear();
                        RefreshCartGrid();
                        UpdateCartTotal();
                        GenerateNewCheckNumber();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        ShowStatusMessage($"Ошибка сохранения покупки: {ex.Message}");
                    }
                }
                Constants.Connection.Close();
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Ошибка: {ex.Message}");
                Constants.Connection.Close();
            }
        }

        private void deliveryCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            deliveryDatePicker.Enabled = deliveryCheckBox.Checked;
            deliveryPerformerTextBox.Enabled = deliveryCheckBox.Checked;
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

    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}