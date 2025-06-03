using MaterialSkin.Controls;

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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            status_bar_text = new MaterialLabel();
            go_back_button = new MaterialButton();
            productsPanel = new Panel();
            cartGroupBox = new MaterialCard();
            checkoutButton = new MaterialButton();
            finalSumLabel = new MaterialLabel();
            discountLabel = new MaterialLabel();
            totalSumLabel = new MaterialLabel();
            itemsCountLabel = new MaterialLabel();
            discountComboBox = new MaterialComboBox();
            cartItemsPanel = new Panel();
            tabControl = new MaterialTabControl();
            productsTab = new TabPage();
            cartTab = new TabPage();
            tabSelector = new MaterialTabSelector();
            cartGroupBox.SuspendLayout();
            tabControl.SuspendLayout();
            productsTab.SuspendLayout();
            cartTab.SuspendLayout();
            SuspendLayout();
            // 
            // status_bar_text
            // 
            status_bar_text.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            status_bar_text.AutoSize = true;
            status_bar_text.Depth = 0;
            status_bar_text.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            status_bar_text.Location = new Point(7, 666);
            status_bar_text.Margin = new Padding(4, 0, 4, 0);
            status_bar_text.MouseState = MaterialSkin.MouseState.HOVER;
            status_bar_text.Name = "status_bar_text";
            status_bar_text.Size = new Size(108, 19);
            status_bar_text.TabIndex = 2;
            status_bar_text.Text = "status_bar_text";
            // 
            // go_back_button
            // 
            go_back_button.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            go_back_button.AutoSize = false;
            go_back_button.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            go_back_button.Density = MaterialButton.MaterialButtonDensity.Default;
            go_back_button.Depth = 0;
            go_back_button.HighEmphasis = true;
            go_back_button.Icon = null;
            go_back_button.Location = new Point(766, 658);
            go_back_button.Margin = new Padding(4, 7, 4, 7);
            go_back_button.MouseState = MaterialSkin.MouseState.HOVER;
            go_back_button.Name = "go_back_button";
            go_back_button.NoAccentTextColor = Color.Empty;
            go_back_button.Size = new Size(140, 27);
            go_back_button.TabIndex = 3;
            go_back_button.Text = "Назад";
            go_back_button.Type = MaterialButton.MaterialButtonType.Contained;
            go_back_button.UseAccentColor = false;
            go_back_button.UseVisualStyleBackColor = true;
            go_back_button.Click += go_back_button_Click;
            // 
            // productsPanel
            // 
            productsPanel.AutoScroll = true;
            productsPanel.Dock = DockStyle.Fill;
            productsPanel.Location = new Point(4, 4);
            productsPanel.Margin = new Padding(4);
            productsPanel.Name = "productsPanel";
            productsPanel.Size = new Size(878, 560);
            productsPanel.TabIndex = 4;
            // 
            // cartGroupBox
            // 
            cartGroupBox.BackColor = Color.FromArgb(255, 255, 255);
            cartGroupBox.Controls.Add(checkoutButton);
            cartGroupBox.Controls.Add(finalSumLabel);
            cartGroupBox.Controls.Add(discountLabel);
            cartGroupBox.Controls.Add(totalSumLabel);
            cartGroupBox.Controls.Add(itemsCountLabel);
            cartGroupBox.Controls.Add(discountComboBox);
            cartGroupBox.Depth = 0;
            cartGroupBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cartGroupBox.Location = new Point(7, 7);
            cartGroupBox.Margin = new Padding(17, 16, 17, 16);
            cartGroupBox.MouseState = MaterialSkin.MouseState.HOVER;
            cartGroupBox.Name = "cartGroupBox";
            cartGroupBox.Padding = new Padding(17, 16, 17, 16);
            cartGroupBox.Size = new Size(872, 139);
            cartGroupBox.TabIndex = 5;
            // 
            // checkoutButton
            // 
            checkoutButton.AutoSize = false;
            checkoutButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            checkoutButton.Density = MaterialButton.MaterialButtonDensity.Default;
            checkoutButton.Depth = 0;
            checkoutButton.HighEmphasis = true;
            checkoutButton.Icon = null;
            checkoutButton.Location = new Point(641, 81);
            checkoutButton.Margin = new Padding(4, 7, 4, 7);
            checkoutButton.MouseState = MaterialSkin.MouseState.HOVER;
            checkoutButton.Name = "checkoutButton";
            checkoutButton.NoAccentTextColor = Color.Empty;
            checkoutButton.Size = new Size(210, 41);
            checkoutButton.TabIndex = 6;
            checkoutButton.Text = "ОФОРМИТЬ ПРОДАЖУ";
            checkoutButton.Type = MaterialButton.MaterialButtonType.Contained;
            checkoutButton.UseAccentColor = false;
            checkoutButton.UseVisualStyleBackColor = true;
            checkoutButton.Click += checkoutButton_Click;
            // 
            // finalSumLabel
            // 
            finalSumLabel.AutoSize = true;
            finalSumLabel.Depth = 0;
            finalSumLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            finalSumLabel.Location = new Point(350, 92);
            finalSumLabel.Margin = new Padding(4, 0, 4, 0);
            finalSumLabel.MouseState = MaterialSkin.MouseState.HOVER;
            finalSumLabel.Name = "finalSumLabel";
            finalSumLabel.Size = new Size(62, 19);
            finalSumLabel.TabIndex = 4;
            finalSumLabel.Text = "Итого: 0";
            // 
            // discountLabel
            // 
            discountLabel.AutoSize = true;
            discountLabel.Depth = 0;
            discountLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            discountLabel.Location = new Point(350, 58);
            discountLabel.Margin = new Padding(4, 0, 4, 0);
            discountLabel.MouseState = MaterialSkin.MouseState.HOVER;
            discountLabel.Name = "discountLabel";
            discountLabel.Size = new Size(74, 19);
            discountLabel.TabIndex = 3;
            discountLabel.Text = "Скидка: 0";
            // 
            // totalSumLabel
            // 
            totalSumLabel.AutoSize = true;
            totalSumLabel.Depth = 0;
            totalSumLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            totalSumLabel.Location = new Point(350, 23);
            totalSumLabel.Margin = new Padding(4, 0, 4, 0);
            totalSumLabel.MouseState = MaterialSkin.MouseState.HOVER;
            totalSumLabel.Name = "totalSumLabel";
            totalSumLabel.Size = new Size(69, 19);
            totalSumLabel.TabIndex = 2;
            totalSumLabel.Text = "Сумма: 0";
            // 
            // itemsCountLabel
            // 
            itemsCountLabel.AutoSize = true;
            itemsCountLabel.Depth = 0;
            itemsCountLabel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            itemsCountLabel.Location = new Point(24, 23);
            itemsCountLabel.Margin = new Padding(4, 0, 4, 0);
            itemsCountLabel.MouseState = MaterialSkin.MouseState.HOVER;
            itemsCountLabel.Name = "itemsCountLabel";
            itemsCountLabel.Size = new Size(82, 19);
            itemsCountLabel.TabIndex = 1;
            itemsCountLabel.Text = "Товаров: 0";
            // 
            // discountComboBox
            // 
            discountComboBox.AutoResize = false;
            discountComboBox.BackColor = Color.FromArgb(255, 255, 255);
            discountComboBox.Depth = 0;
            discountComboBox.DrawMode = DrawMode.OwnerDrawVariable;
            discountComboBox.DropDownHeight = 174;
            discountComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            discountComboBox.DropDownWidth = 121;
            discountComboBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            discountComboBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            discountComboBox.FormattingEnabled = true;
            discountComboBox.Hint = "Скидка";
            discountComboBox.IntegralHeight = false;
            discountComboBox.ItemHeight = 43;
            discountComboBox.Location = new Point(24, 58);
            discountComboBox.Margin = new Padding(4);
            discountComboBox.MaxDropDownItems = 4;
            discountComboBox.MouseState = MaterialSkin.MouseState.OUT;
            discountComboBox.Name = "discountComboBox";
            discountComboBox.Size = new Size(175, 49);
            discountComboBox.StartIndex = 0;
            discountComboBox.TabIndex = 0;
            discountComboBox.SelectedIndexChanged += discountComboBox_SelectedIndexChanged;
            // 
            // cartItemsPanel
            // 
            cartItemsPanel.AutoScroll = true;
            cartItemsPanel.Location = new Point(7, 150);
            cartItemsPanel.Margin = new Padding(4);
            cartItemsPanel.Name = "cartItemsPanel";
            cartItemsPanel.Size = new Size(872, 362);
            cartItemsPanel.TabIndex = 6;
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(productsTab);
            tabControl.Controls.Add(cartTab);
            tabControl.Depth = 0;
            tabControl.Location = new Point(20, 51);
            tabControl.Margin = new Padding(4);
            tabControl.MouseState = MaterialSkin.MouseState.HOVER;
            tabControl.Multiline = true;
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(894, 596);
            tabControl.TabIndex = 7;
            // 
            // productsTab
            // 
            productsTab.Controls.Add(productsPanel);
            productsTab.Location = new Point(4, 24);
            productsTab.Margin = new Padding(4);
            productsTab.Name = "productsTab";
            productsTab.Padding = new Padding(4);
            productsTab.Size = new Size(886, 568);
            productsTab.TabIndex = 0;
            productsTab.Text = "Товары";
            productsTab.UseVisualStyleBackColor = true;
            // 
            // cartTab
            // 
            cartTab.Controls.Add(cartGroupBox);
            cartTab.Controls.Add(cartItemsPanel);
            cartTab.Location = new Point(4, 24);
            cartTab.Margin = new Padding(4);
            cartTab.Name = "cartTab";
            cartTab.Padding = new Padding(4);
            cartTab.Size = new Size(886, 568);
            cartTab.TabIndex = 1;
            cartTab.Text = "Корзина";
            cartTab.UseVisualStyleBackColor = true;
            // 
            // tabSelector
            // 
            tabSelector.BaseTabControl = tabControl;
            tabSelector.CharacterCasing = MaterialTabSelector.CustomCharacterCasing.Normal;
            tabSelector.Depth = 0;
            tabSelector.Dock = DockStyle.Top;
            tabSelector.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            tabSelector.Location = new Point(3, 18);
            tabSelector.Margin = new Padding(3, 2, 3, 2);
            tabSelector.MouseState = MaterialSkin.MouseState.HOVER;
            tabSelector.Name = "tabSelector";
            tabSelector.Size = new Size(927, 36);
            tabSelector.TabIndex = 0;
            // 
            // AdditionalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(934, 692);
            Controls.Add(tabSelector);
            Controls.Add(tabControl);
            Controls.Add(go_back_button);
            Controls.Add(status_bar_text);
            FormStyle = FormStyles.ActionBar_None;
            Margin = new Padding(4);
            Name = "AdditionalForm";
            Padding = new Padding(3, 18, 4, 4);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Корзина";
            cartGroupBox.ResumeLayout(false);
            cartGroupBox.PerformLayout();
            tabControl.ResumeLayout(false);
            productsTab.ResumeLayout(false);
            cartTab.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialLabel status_bar_text;
        private MaterialSkin.Controls.MaterialButton go_back_button;
        private System.Windows.Forms.Panel productsPanel;
        private MaterialSkin.Controls.MaterialCard cartGroupBox;
        private MaterialSkin.Controls.MaterialComboBox discountComboBox;
        private MaterialSkin.Controls.MaterialLabel itemsCountLabel;
        private MaterialSkin.Controls.MaterialLabel totalSumLabel;
        private MaterialSkin.Controls.MaterialLabel discountLabel;
        private MaterialSkin.Controls.MaterialLabel finalSumLabel;
        private System.Windows.Forms.Panel cartItemsPanel;
        private MaterialSkin.Controls.MaterialButton checkoutButton;
        private MaterialSkin.Controls.MaterialTabControl tabControl;
        private MaterialTabSelector tabSelector;
        private System.Windows.Forms.TabPage productsTab;
        private System.Windows.Forms.TabPage cartTab;
    }
}