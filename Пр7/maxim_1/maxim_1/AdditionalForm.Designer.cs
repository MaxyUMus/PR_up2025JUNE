namespace maxim_1
{
    partial class AdditionalForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            go_back_button = new MaterialSkin.Controls.MaterialButton();
            status_bar_text = new MaterialSkin.Controls.MaterialLabel();
            panel1 = new Panel();
            checkNumberLabel = new MaterialSkin.Controls.MaterialLabel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            purchaseDatePicker = new DateTimePicker();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            buyerComboBox = new MaterialSkin.Controls.MaterialComboBox();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            productComboBox = new MaterialSkin.Controls.MaterialComboBox();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            quantityTextBox = new MaterialSkin.Controls.MaterialTextBox();
            addToCartButton = new MaterialSkin.Controls.MaterialButton();
            cartDataGridView = new DataGridView();
            removeFromCartButton = new MaterialSkin.Controls.MaterialButton();
            clearCartButton = new MaterialSkin.Controls.MaterialButton();
            totalLabel = new MaterialSkin.Controls.MaterialLabel();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            statusComboBox = new MaterialSkin.Controls.MaterialComboBox();
            materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            priorityComboBox = new MaterialSkin.Controls.MaterialComboBox();
            deliveryCheckBox = new MaterialSkin.Controls.MaterialCheckbox();
            deliveryDatePicker = new DateTimePicker();
            materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            deliveryPerformerTextBox = new MaterialSkin.Controls.MaterialTextBox();
            savePurchaseButton = new MaterialSkin.Controls.MaterialButton();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cartDataGridView).BeginInit();
            SuspendLayout();
            // 
            // go_back_button
            // 
            go_back_button.AutoSize = false;
            go_back_button.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            go_back_button.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            go_back_button.Depth = 0;
            go_back_button.HighEmphasis = true;
            go_back_button.Icon = null;
            go_back_button.Location = new Point(906, 5);
            go_back_button.Margin = new Padding(5, 9, 5, 9);
            go_back_button.MouseState = MaterialSkin.MouseState.HOVER;
            go_back_button.Name = "go_back_button";
            go_back_button.NoAccentTextColor = Color.Empty;
            go_back_button.Size = new Size(148, 28);
            go_back_button.TabIndex = 0;
            go_back_button.Text = "Назад";
            go_back_button.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            go_back_button.UseAccentColor = false;
            go_back_button.UseVisualStyleBackColor = true;
            go_back_button.Click += go_back_button_Click;
            // 
            // status_bar_text
            // 
            status_bar_text.AutoSize = true;
            status_bar_text.Depth = 0;
            status_bar_text.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            status_bar_text.Location = new Point(179, 23);
            status_bar_text.Margin = new Padding(4, 0, 4, 0);
            status_bar_text.MouseState = MaterialSkin.MouseState.HOVER;
            status_bar_text.Name = "status_bar_text";
            status_bar_text.Size = new Size(1, 0);
            status_bar_text.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(go_back_button);
            panel1.Controls.Add(status_bar_text);
            panel1.Controls.Add(checkNumberLabel);
            panel1.Controls.Add(materialLabel1);
            panel1.Controls.Add(purchaseDatePicker);
            panel1.Location = new Point(4, 4);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1059, 90);
            panel1.TabIndex = 2;
            // 
            // checkNumberLabel
            // 
            checkNumberLabel.AutoSize = true;
            checkNumberLabel.Depth = 0;
            checkNumberLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            checkNumberLabel.Location = new Point(4, 4);
            checkNumberLabel.Margin = new Padding(4, 0, 4, 0);
            checkNumberLabel.MouseState = MaterialSkin.MouseState.HOVER;
            checkNumberLabel.Name = "checkNumberLabel";
            checkNumberLabel.Size = new Size(97, 19);
            checkNumberLabel.TabIndex = 3;
            checkNumberLabel.Text = "Номер чека: ";
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(4, 50);
            materialLabel1.Margin = new Padding(4, 0, 4, 0);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(95, 19);
            materialLabel1.TabIndex = 5;
            materialLabel1.Text = "Дата заказа";
            // 
            // purchaseDatePicker
            // 
            purchaseDatePicker.Location = new Point(107, 47);
            purchaseDatePicker.Margin = new Padding(4, 5, 4, 5);
            purchaseDatePicker.Name = "purchaseDatePicker";
            purchaseDatePicker.Size = new Size(265, 27);
            purchaseDatePicker.TabIndex = 4;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(3, 99);
            materialLabel2.Margin = new Padding(4, 0, 4, 0);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(90, 19);
            materialLabel2.TabIndex = 6;
            materialLabel2.Text = "Покупатель";
            // 
            // buyerComboBox
            // 
            buyerComboBox.AutoResize = false;
            buyerComboBox.BackColor = Color.FromArgb(255, 255, 255);
            buyerComboBox.Depth = 0;
            buyerComboBox.DrawMode = DrawMode.OwnerDrawVariable;
            buyerComboBox.DropDownHeight = 174;
            buyerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            buyerComboBox.DropDownWidth = 121;
            buyerComboBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            buyerComboBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            buyerComboBox.FormattingEnabled = true;
            buyerComboBox.IntegralHeight = false;
            buyerComboBox.ItemHeight = 43;
            buyerComboBox.Location = new Point(3, 123);
            buyerComboBox.Margin = new Padding(4, 5, 4, 5);
            buyerComboBox.MaxDropDownItems = 4;
            buyerComboBox.MouseState = MaterialSkin.MouseState.OUT;
            buyerComboBox.Name = "buyerComboBox";
            buyerComboBox.Size = new Size(361, 49);
            buyerComboBox.StartIndex = 0;
            buyerComboBox.TabIndex = 7;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(3, 177);
            materialLabel3.Margin = new Padding(4, 0, 4, 0);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(47, 19);
            materialLabel3.TabIndex = 8;
            materialLabel3.Text = "Товар";
            // 
            // productComboBox
            // 
            productComboBox.AutoResize = false;
            productComboBox.BackColor = Color.FromArgb(255, 255, 255);
            productComboBox.Depth = 0;
            productComboBox.DrawMode = DrawMode.OwnerDrawVariable;
            productComboBox.DropDownHeight = 174;
            productComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            productComboBox.DropDownWidth = 121;
            productComboBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            productComboBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            productComboBox.FormattingEnabled = true;
            productComboBox.IntegralHeight = false;
            productComboBox.ItemHeight = 43;
            productComboBox.Location = new Point(3, 201);
            productComboBox.Margin = new Padding(4, 5, 4, 5);
            productComboBox.MaxDropDownItems = 4;
            productComboBox.MouseState = MaterialSkin.MouseState.OUT;
            productComboBox.Name = "productComboBox";
            productComboBox.Size = new Size(361, 49);
            productComboBox.StartIndex = 0;
            productComboBox.TabIndex = 9;
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(3, 255);
            materialLabel4.Margin = new Padding(4, 0, 4, 0);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(89, 19);
            materialLabel4.TabIndex = 10;
            materialLabel4.Text = "Количество";
            // 
            // quantityTextBox
            // 
            quantityTextBox.AnimateReadOnly = false;
            quantityTextBox.BorderStyle = BorderStyle.None;
            quantityTextBox.Depth = 0;
            quantityTextBox.Font = new Font("Microsoft Sans Serif", 9.6F);
            quantityTextBox.Hint = "Количество";
            quantityTextBox.LeadingIcon = null;
            quantityTextBox.Location = new Point(3, 279);
            quantityTextBox.Margin = new Padding(4, 5, 4, 5);
            quantityTextBox.MaxLength = 50;
            quantityTextBox.MouseState = MaterialSkin.MouseState.OUT;
            quantityTextBox.Multiline = false;
            quantityTextBox.Name = "quantityTextBox";
            quantityTextBox.Size = new Size(133, 50);
            quantityTextBox.TabIndex = 11;
            quantityTextBox.Text = "1";
            quantityTextBox.TrailingIcon = null;
            // 
            // addToCartButton
            // 
            addToCartButton.AutoSize = false;
            addToCartButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addToCartButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            addToCartButton.Depth = 0;
            addToCartButton.HighEmphasis = true;
            addToCartButton.Icon = null;
            addToCartButton.Location = new Point(6, 555);
            addToCartButton.Margin = new Padding(5, 9, 5, 9);
            addToCartButton.MouseState = MaterialSkin.MouseState.HOVER;
            addToCartButton.Name = "addToCartButton";
            addToCartButton.NoAccentTextColor = Color.Empty;
            addToCartButton.Size = new Size(267, 55);
            addToCartButton.TabIndex = 12;
            addToCartButton.Text = "Добавить в корзину";
            addToCartButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            addToCartButton.UseAccentColor = false;
            addToCartButton.UseVisualStyleBackColor = true;
            addToCartButton.Click += addToCartButton_Click;
            // 
            // cartDataGridView
            // 
            cartDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            cartDataGridView.Location = new Point(372, 104);
            cartDataGridView.Margin = new Padding(4, 5, 4, 5);
            cartDataGridView.Name = "cartDataGridView";
            cartDataGridView.RowHeadersWidth = 51;
            cartDataGridView.Size = new Size(691, 241);
            cartDataGridView.TabIndex = 13;
            // 
            // removeFromCartButton
            // 
            removeFromCartButton.AutoSize = false;
            removeFromCartButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            removeFromCartButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            removeFromCartButton.Depth = 0;
            removeFromCartButton.HighEmphasis = true;
            removeFromCartButton.Icon = null;
            removeFromCartButton.Location = new Point(283, 555);
            removeFromCartButton.Margin = new Padding(5, 9, 5, 9);
            removeFromCartButton.MouseState = MaterialSkin.MouseState.HOVER;
            removeFromCartButton.Name = "removeFromCartButton";
            removeFromCartButton.NoAccentTextColor = Color.Empty;
            removeFromCartButton.Size = new Size(267, 55);
            removeFromCartButton.TabIndex = 14;
            removeFromCartButton.Text = "Удалить из корзины";
            removeFromCartButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            removeFromCartButton.UseAccentColor = false;
            removeFromCartButton.UseVisualStyleBackColor = true;
            removeFromCartButton.Click += removeFromCartButton_Click;
            // 
            // clearCartButton
            // 
            clearCartButton.AutoSize = false;
            clearCartButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            clearCartButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            clearCartButton.Depth = 0;
            clearCartButton.HighEmphasis = true;
            clearCartButton.Icon = null;
            clearCartButton.Location = new Point(560, 555);
            clearCartButton.Margin = new Padding(5, 9, 5, 9);
            clearCartButton.MouseState = MaterialSkin.MouseState.HOVER;
            clearCartButton.Name = "clearCartButton";
            clearCartButton.NoAccentTextColor = Color.Empty;
            clearCartButton.Size = new Size(264, 55);
            clearCartButton.TabIndex = 15;
            clearCartButton.Text = "Очистить корзину";
            clearCartButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            clearCartButton.UseAccentColor = false;
            clearCartButton.UseVisualStyleBackColor = true;
            clearCartButton.Click += clearCartButton_Click;
            // 
            // totalLabel
            // 
            totalLabel.AutoSize = true;
            totalLabel.Depth = 0;
            totalLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            totalLabel.Location = new Point(183, 255);
            totalLabel.Margin = new Padding(4, 0, 4, 0);
            totalLabel.MouseState = MaterialSkin.MouseState.HOVER;
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new Size(53, 19);
            totalLabel.TabIndex = 16;
            totalLabel.Text = "Итого: ";
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(3, 334);
            materialLabel5.Margin = new Padding(4, 0, 4, 0);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(52, 19);
            materialLabel5.TabIndex = 17;
            materialLabel5.Text = "Статус";
            // 
            // statusComboBox
            // 
            statusComboBox.AutoResize = false;
            statusComboBox.BackColor = Color.FromArgb(255, 255, 255);
            statusComboBox.Depth = 0;
            statusComboBox.DrawMode = DrawMode.OwnerDrawVariable;
            statusComboBox.DropDownHeight = 174;
            statusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            statusComboBox.DropDownWidth = 121;
            statusComboBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            statusComboBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            statusComboBox.FormattingEnabled = true;
            statusComboBox.IntegralHeight = false;
            statusComboBox.ItemHeight = 43;
            statusComboBox.Items.AddRange(new object[] { "новый", "в обработке", "выполнен", "отменен" });
            statusComboBox.Location = new Point(4, 363);
            statusComboBox.Margin = new Padding(4, 5, 4, 5);
            statusComboBox.MaxDropDownItems = 4;
            statusComboBox.MouseState = MaterialSkin.MouseState.OUT;
            statusComboBox.Name = "statusComboBox";
            statusComboBox.Size = new Size(265, 49);
            statusComboBox.StartIndex = 0;
            statusComboBox.TabIndex = 18;
            // 
            // materialLabel6
            // 
            materialLabel6.AutoSize = true;
            materialLabel6.Depth = 0;
            materialLabel6.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel6.Location = new Point(276, 334);
            materialLabel6.Margin = new Padding(4, 0, 4, 0);
            materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.Size = new Size(81, 19);
            materialLabel6.TabIndex = 19;
            materialLabel6.Text = "Приоритет";
            // 
            // priorityComboBox
            // 
            priorityComboBox.AutoResize = false;
            priorityComboBox.BackColor = Color.FromArgb(255, 255, 255);
            priorityComboBox.Depth = 0;
            priorityComboBox.DrawMode = DrawMode.OwnerDrawVariable;
            priorityComboBox.DropDownHeight = 174;
            priorityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            priorityComboBox.DropDownWidth = 121;
            priorityComboBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            priorityComboBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            priorityComboBox.FormattingEnabled = true;
            priorityComboBox.IntegralHeight = false;
            priorityComboBox.ItemHeight = 43;
            priorityComboBox.Items.AddRange(new object[] { "низкий", "средний", "высокий", "срочный" });
            priorityComboBox.Location = new Point(276, 363);
            priorityComboBox.Margin = new Padding(4, 5, 4, 5);
            priorityComboBox.MaxDropDownItems = 4;
            priorityComboBox.MouseState = MaterialSkin.MouseState.OUT;
            priorityComboBox.Name = "priorityComboBox";
            priorityComboBox.Size = new Size(265, 49);
            priorityComboBox.StartIndex = 0;
            priorityComboBox.TabIndex = 20;
            // 
            // deliveryCheckBox
            // 
            deliveryCheckBox.AutoSize = true;
            deliveryCheckBox.Depth = 0;
            deliveryCheckBox.Location = new Point(4, 417);
            deliveryCheckBox.Margin = new Padding(0);
            deliveryCheckBox.MouseLocation = new Point(-1, -1);
            deliveryCheckBox.MouseState = MaterialSkin.MouseState.HOVER;
            deliveryCheckBox.Name = "deliveryCheckBox";
            deliveryCheckBox.ReadOnly = false;
            deliveryCheckBox.Ripple = true;
            deliveryCheckBox.Size = new Size(108, 37);
            deliveryCheckBox.TabIndex = 21;
            deliveryCheckBox.Text = "Доставка";
            deliveryCheckBox.UseVisualStyleBackColor = true;
            deliveryCheckBox.CheckedChanged += deliveryCheckBox_CheckedChanged;
            // 
            // deliveryDatePicker
            // 
            deliveryDatePicker.Enabled = false;
            deliveryDatePicker.Location = new Point(130, 454);
            deliveryDatePicker.Margin = new Padding(4, 5, 4, 5);
            deliveryDatePicker.Name = "deliveryDatePicker";
            deliveryDatePicker.Size = new Size(265, 27);
            deliveryDatePicker.TabIndex = 22;
            // 
            // materialLabel7
            // 
            materialLabel7.AutoSize = true;
            materialLabel7.Depth = 0;
            materialLabel7.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel7.Location = new Point(8, 454);
            materialLabel7.Margin = new Padding(4, 0, 4, 0);
            materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel7.Name = "materialLabel7";
            materialLabel7.Size = new Size(114, 19);
            materialLabel7.TabIndex = 23;
            materialLabel7.Text = "Дата доставки";
            // 
            // deliveryPerformerTextBox
            // 
            deliveryPerformerTextBox.AnimateReadOnly = false;
            deliveryPerformerTextBox.BorderStyle = BorderStyle.None;
            deliveryPerformerTextBox.Depth = 0;
            deliveryPerformerTextBox.Enabled = false;
            deliveryPerformerTextBox.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            deliveryPerformerTextBox.Hint = "Исполнитель доставки";
            deliveryPerformerTextBox.LeadingIcon = null;
            deliveryPerformerTextBox.Location = new Point(1, 491);
            deliveryPerformerTextBox.Margin = new Padding(4, 5, 4, 5);
            deliveryPerformerTextBox.MaxLength = 50;
            deliveryPerformerTextBox.MouseState = MaterialSkin.MouseState.OUT;
            deliveryPerformerTextBox.Multiline = false;
            deliveryPerformerTextBox.Name = "deliveryPerformerTextBox";
            deliveryPerformerTextBox.Size = new Size(540, 50);
            deliveryPerformerTextBox.TabIndex = 24;
            deliveryPerformerTextBox.Text = "";
            deliveryPerformerTextBox.TrailingIcon = null;
            // 
            // savePurchaseButton
            // 
            savePurchaseButton.AutoSize = false;
            savePurchaseButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            savePurchaseButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            savePurchaseButton.Depth = 0;
            savePurchaseButton.HighEmphasis = true;
            savePurchaseButton.Icon = null;
            savePurchaseButton.Location = new Point(834, 555);
            savePurchaseButton.Margin = new Padding(5, 9, 5, 9);
            savePurchaseButton.MouseState = MaterialSkin.MouseState.HOVER;
            savePurchaseButton.Name = "savePurchaseButton";
            savePurchaseButton.NoAccentTextColor = Color.Empty;
            savePurchaseButton.Size = new Size(225, 55);
            savePurchaseButton.TabIndex = 25;
            savePurchaseButton.Text = "Сохранить покупку";
            savePurchaseButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            savePurchaseButton.UseAccentColor = false;
            savePurchaseButton.UseVisualStyleBackColor = true;
            savePurchaseButton.Click += savePurchaseButton_Click;
            // 
            // AdditionalForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 614);
            Controls.Add(savePurchaseButton);
            Controls.Add(deliveryPerformerTextBox);
            Controls.Add(materialLabel7);
            Controls.Add(deliveryDatePicker);
            Controls.Add(deliveryCheckBox);
            Controls.Add(priorityComboBox);
            Controls.Add(materialLabel6);
            Controls.Add(statusComboBox);
            Controls.Add(materialLabel5);
            Controls.Add(totalLabel);
            Controls.Add(clearCartButton);
            Controls.Add(removeFromCartButton);
            Controls.Add(cartDataGridView);
            Controls.Add(addToCartButton);
            Controls.Add(quantityTextBox);
            Controls.Add(materialLabel4);
            Controls.Add(productComboBox);
            Controls.Add(materialLabel3);
            Controls.Add(buyerComboBox);
            Controls.Add(materialLabel2);
            Controls.Add(panel1);
            FormStyle = FormStyles.StatusAndActionBar_None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "AdditionalForm";
            Padding = new Padding(3, 0, 4, 5);
            Sizable = false;
            Text = "Оформление покупки";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cartDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        private MaterialSkin.Controls.MaterialButton go_back_button;
        private MaterialSkin.Controls.MaterialLabel status_bar_text;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialLabel checkNumberLabel;
        private System.Windows.Forms.DateTimePicker purchaseDatePicker;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialComboBox buyerComboBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialComboBox productComboBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialTextBox quantityTextBox;
        private MaterialSkin.Controls.MaterialButton addToCartButton;
        private System.Windows.Forms.DataGridView cartDataGridView;
        private MaterialSkin.Controls.MaterialButton removeFromCartButton;
        private MaterialSkin.Controls.MaterialButton clearCartButton;
        private MaterialSkin.Controls.MaterialLabel totalLabel;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialComboBox statusComboBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialComboBox priorityComboBox;
        private MaterialSkin.Controls.MaterialCheckbox deliveryCheckBox;
        private System.Windows.Forms.DateTimePicker deliveryDatePicker;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialTextBox deliveryPerformerTextBox;
        private MaterialSkin.Controls.MaterialButton savePurchaseButton;
    }
}