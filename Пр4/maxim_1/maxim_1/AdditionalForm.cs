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
        private List<Product> cartProducts = new List<Product>();
        private decimal totalSum = 0;
        private int totalItems = 0;

        public AdditionalForm(MainForm mainForm)
        {
            InitializeComponent();
            InitializeMaterialSkin();
            InitializeForm();
            this.mainForm = mainForm;
            LoadProducts();
            UpdateCartSummary();
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
            go_back_button.Icon = IconChar.ArrowLeft.ToBitmap(
                Methods.GetContrastTextColor(Constants.SecondaryBackgroundColor), 36);

            discountComboBox.Items.AddRange(new object[] { "0%", "5%", "10%", "15%", "20%" });
            discountComboBox.SelectedIndex = 0;
            status_bar_text.Text = "";
        }

        private void LoadProducts()
        {
            try
            {
                productsPanel.Controls.Clear();
                Constants.Connection.Open();

                string query = "SELECT * FROM products WHERE product_stock_amount > 0 ORDER BY product_name";
                using (var cmd = new NpgsqlCommand(query, Constants.Connection))
                using (var reader = cmd.ExecuteReader())
                {
                    int topPosition = 20;
                    while (reader.Read())
                    {
                        var panel = CreateProductPanel(reader, topPosition);
                        productsPanel.Controls.Add(panel);
                        topPosition += panel.Height + 15;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Ошибка загрузки товаров: {ex.Message}");
            }
            finally
            {
                Constants.Connection.Close();
            }
        }

        private Panel CreateProductPanel(NpgsqlDataReader reader, int top)
        {
            var panel = new Panel
            {
                Size = new Size(720, 180),
                Location = new Point(20, top),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(15),
                Tag = reader["product_id"]
            };

            var info = new StringBuilder();
            info.AppendLine($"Название: {reader["product_name"]}");
            info.AppendLine($"Производитель: {reader["product_producer"]}");
            info.AppendLine($"Цена: {reader["product_price"]} руб.");
            info.AppendLine($"На складе: {reader["product_stock_amount"]} {reader["produtc_unit"]}");

            var infoLabel = new Label
            {
                Text = info.ToString(),
                Font = new Font("Arial", 10),
                Location = new Point(10, 10),
                AutoSize = true
            };

            var details = new StringBuilder();
            details.AppendLine($"Категория: {reader["product_category"]}");
            details.AppendLine($"Упаковка: {reader["product_package"]}");
            details.AppendLine($"Размер: {reader["product_size"]}");
            details.AppendLine($"Годен до: {reader["product_expiration_date"]:dd.MM.yyyy}");

            var detailsLabel = new Label
            {
                Text = details.ToString(),
                Font = new Font("Arial", 9),
                Location = new Point(10, 90),
                AutoSize = true
            };

            var quantityNumeric = new NumericUpDown
            {
                Minimum = 1,
                Maximum = Convert.ToDecimal(reader["product_stock_amount"]),
                Value = 1,
                Size = new Size(60, 20),
                Location = new Point(550, 30)
            };

            var addButton = new MaterialButton
            {
                Text = "ДОБАВИТЬ",
                Size = new Size(150, 36),
                Location = new Point(550, 70),
                Tag = reader["product_id"],
                UseAccentColor = true
            };
            addButton.Click += AddToCartButton_Click;

            panel.Controls.Add(infoLabel);
            panel.Controls.Add(detailsLabel);
            panel.Controls.Add(quantityNumeric);
            panel.Controls.Add(addButton);

            return panel;
        }

        private void AddToCartButton_Click(object sender, EventArgs e)
        {
            if (sender is MaterialButton button && button.Tag != null)
            {
                try
                {
                    int productId = Convert.ToInt32(button.Tag);
                    var panel = button.Parent as Panel;
                    var quantityControl = panel.Controls.OfType<NumericUpDown>().First();
                    int quantity = Convert.ToInt32(quantityControl.Value);

                    Constants.Connection.Open();
                    string query = "SELECT * FROM products WHERE product_id = @productId";
                    using (var cmd = new NpgsqlCommand(query, Constants.Connection))
                    {
                        cmd.Parameters.AddWithValue("@productId", productId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var product = new Product
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("product_id")),
                                    Name = reader.GetString(reader.GetOrdinal("product_name")),
                                    Price = reader.GetInt32(reader.GetOrdinal("product_price")),
                                    Quantity = quantity
                                };

                                var existingProduct = cartProducts.FirstOrDefault(p => p.Id == productId);
                                if (existingProduct != null)
                                {
                                    existingProduct.Quantity += quantity;
                                }
                                else
                                {
                                    cartProducts.Add(product);
                                }

                                UpdateCartSummary();
                                ShowStatusMessage($"Товар добавлен в корзину: {product.Name} x{quantity}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowStatusMessage($"Ошибка добавления товара: {ex.Message}");
                }
                finally
                {
                    Constants.Connection.Close();
                }
            }
        }

        private void UpdateCartSummary()
        {
            totalSum = cartProducts.Sum(p => p.Price * p.Quantity);
            totalItems = cartProducts.Sum(p => p.Quantity);

            decimal discount = GetDiscountPercentage();
            decimal discountAmount = totalSum * discount;
            decimal finalSum = totalSum - discountAmount;

            totalSumLabel.Text = $"Сумма: {totalSum:N2} руб.";
            discountLabel.Text = $"Скидка: {discount * 100}% ({discountAmount:N2} руб.)";
            finalSumLabel.Text = $"Итого: {finalSum:N2} руб.";
            itemsCountLabel.Text = $"Товаров: {totalItems}";

            UpdateCartList();
        }

        private decimal GetDiscountPercentage()
        {
            if (discountComboBox.SelectedItem != null)
            {
                string discountText = discountComboBox.SelectedItem.ToString().Replace("%", "");
                if (decimal.TryParse(discountText, out decimal discount))
                {
                    return discount / 100;
                }
            }
            return 0;
        }

        private void UpdateCartList()
        {
            cartItemsPanel.Controls.Clear();

            int topPosition = 10;
            foreach (var product in cartProducts)
            {
                var panel = new Panel
                {
                    Size = new Size(500, 40),
                    Location = new Point(10, topPosition),
                    BackColor = Color.WhiteSmoke,
                    BorderStyle = BorderStyle.FixedSingle
                };

                var nameLabel = new Label
                {
                    Text = $"{product.Name} x{product.Quantity}",
                    Location = new Point(5, 10),
                    AutoSize = true
                };

                var priceLabel = new Label
                {
                    Text = $"{product.Price * product.Quantity} руб.",
                    Location = new Point(360, 10),
                    AutoSize = true
                };

                var removeButton = new MaterialButton
                {
                    Text = "X",
                    Size = new Size(30, 30),
                    AutoSize = false,
                    Location = new Point(460, 5),
                    Tag = product.Id,
                    UseAccentColor = true
                };
                removeButton.Click += RemoveFromCartButton_Click;

                panel.Controls.Add(nameLabel);
                panel.Controls.Add(priceLabel);
                panel.Controls.Add(removeButton);

                cartItemsPanel.Controls.Add(panel);
                topPosition += panel.Height + 5;
            }
        }

        private void RemoveFromCartButton_Click(object sender, EventArgs e)
        {
            if (sender is MaterialButton button && button.Tag != null)
            {
                int productId = Convert.ToInt32(button.Tag);
                var productToRemove = cartProducts.FirstOrDefault(p => p.Id == productId);
                if (productToRemove != null)
                {
                    cartProducts.Remove(productToRemove);
                    UpdateCartSummary();
                    ShowStatusMessage($"Товар удален из корзины: {productToRemove.Name}");
                }
            }
        }

        private void discountComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCartSummary();
        }

        private void checkoutButton_Click(object sender, EventArgs e)
        {
            if (cartProducts.Count == 0)
            {
                ShowStatusMessage("Корзина пуста. Добавьте товары.");
                return;
            }

            try
            {
                Constants.Connection.Open();
                using (var transaction = Constants.Connection.BeginTransaction())
                {
                    try
                    {
                        string saleQuery = @"INSERT INTO sales (sale_date, employee_id, amount, summ) 
                                          VALUES (@date, @employeeId, @amount, @summ) RETURNING sale_id";
                        decimal discount = GetDiscountPercentage();
                        decimal finalSum = totalSum * (1 - discount);

                        using (var cmd = new NpgsqlCommand(saleQuery, Constants.Connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@date", DateTime.Now);
                            cmd.Parameters.AddWithValue("@employeeId", mainForm.CurrentEmployeeId);
                            cmd.Parameters.AddWithValue("@amount", totalItems);
                            cmd.Parameters.AddWithValue("@summ", finalSum);

                            int saleId = Convert.ToInt32(cmd.ExecuteScalar());

                            foreach (var product in cartProducts)
                            {
                                string saleListItemQuery = @"INSERT INTO sale_lists (sale_list_number, product_id, amount) 
                                                         VALUES (@number, @productId, @amount) RETURNING sale_list_id";
                                using (var itemCmd = new NpgsqlCommand(saleListItemQuery, Constants.Connection, transaction))
                                {
                                    itemCmd.Parameters.AddWithValue("@number", saleId);
                                    itemCmd.Parameters.AddWithValue("@productId", product.Id);
                                    itemCmd.Parameters.AddWithValue("@amount", product.Quantity);
                                    int saleListItemId = Convert.ToInt32(itemCmd.ExecuteScalar());

                                    string linkQuery = "UPDATE sales SET sale_list_id = @listId WHERE sale_id = @saleId";
                                    using (var linkCmd = new NpgsqlCommand(linkQuery, Constants.Connection, transaction))
                                    {
                                        linkCmd.Parameters.AddWithValue("@listId", saleListItemId);
                                        linkCmd.Parameters.AddWithValue("@saleId", saleId);
                                        linkCmd.ExecuteNonQuery();
                                    }
                                }

                                string updateStockQuery = "UPDATE products SET product_stock_amount = product_stock_amount - @quantity WHERE product_id = @productId";
                                using (var stockCmd = new NpgsqlCommand(updateStockQuery, Constants.Connection, transaction))
                                {
                                    stockCmd.Parameters.AddWithValue("@quantity", product.Quantity);
                                    stockCmd.Parameters.AddWithValue("@productId", product.Id);
                                    stockCmd.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit();
                        cartProducts.Clear();
                        UpdateCartSummary();
                        LoadProducts();
                        ShowStatusMessage("Продажа успешно оформлена!");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        ShowStatusMessage($"Ошибка оформления продажи: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowStatusMessage($"Ошибка подключения: {ex.Message}");
            }
            finally
            {
                Constants.Connection.Close();
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

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}