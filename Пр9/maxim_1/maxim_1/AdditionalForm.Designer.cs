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
            visitorsPanel = new Panel();
            clubsComboBox = new MaterialSkin.Controls.MaterialComboBox();
            visitDatePicker = new DateTimePicker();
            filterToggle = new MaterialSkin.Controls.MaterialSwitch();
            backButton = new MaterialSkin.Controls.MaterialButton();
            status_bar_text = new MaterialSkin.Controls.MaterialLabel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            SuspendLayout();
            // 
            // visitorsPanel
            // 
            visitorsPanel.AutoScroll = true;
            visitorsPanel.Location = new Point(16, 185);
            visitorsPanel.Margin = new Padding(4, 5, 4, 5);
            visitorsPanel.Name = "visitorsPanel";
            visitorsPanel.Size = new Size(1013, 738);
            visitorsPanel.TabIndex = 0;
            // 
            // clubsComboBox
            // 
            clubsComboBox.AutoResize = false;
            clubsComboBox.BackColor = Color.FromArgb(255, 255, 255);
            clubsComboBox.Depth = 0;
            clubsComboBox.DrawMode = DrawMode.OwnerDrawVariable;
            clubsComboBox.DropDownHeight = 174;
            clubsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            clubsComboBox.DropDownWidth = 121;
            clubsComboBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            clubsComboBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            clubsComboBox.FormattingEnabled = true;
            clubsComboBox.Hint = "Клуб";
            clubsComboBox.IntegralHeight = false;
            clubsComboBox.ItemHeight = 43;
            clubsComboBox.Location = new Point(400, 108);
            clubsComboBox.Margin = new Padding(4, 5, 4, 5);
            clubsComboBox.MaxDropDownItems = 4;
            clubsComboBox.MouseState = MaterialSkin.MouseState.OUT;
            clubsComboBox.Name = "clubsComboBox";
            clubsComboBox.Size = new Size(265, 49);
            clubsComboBox.StartIndex = 0;
            clubsComboBox.TabIndex = 1;
            clubsComboBox.SelectedIndexChanged += clubsComboBox_SelectedIndexChanged;
            // 
            // visitDatePicker
            // 
            visitDatePicker.Location = new Point(693, 123);
            visitDatePicker.Margin = new Padding(4, 5, 4, 5);
            visitDatePicker.Name = "visitDatePicker";
            visitDatePicker.Size = new Size(265, 27);
            visitDatePicker.TabIndex = 2;
            visitDatePicker.ValueChanged += visitDatePicker_ValueChanged;
            // 
            // filterToggle
            // 
            filterToggle.AutoSize = true;
            filterToggle.Depth = 0;
            filterToggle.Location = new Point(16, 123);
            filterToggle.Margin = new Padding(0);
            filterToggle.MouseLocation = new Point(-1, -1);
            filterToggle.MouseState = MaterialSkin.MouseState.HOVER;
            filterToggle.Name = "filterToggle";
            filterToggle.Ripple = true;
            filterToggle.Size = new Size(158, 37);
            filterToggle.TabIndex = 3;
            filterToggle.Text = "Фильтровать";
            filterToggle.UseVisualStyleBackColor = true;
            filterToggle.CheckedChanged += filterToggle_CheckedChanged;
            // 
            // backButton
            // 
            backButton.AutoSize = false;
            backButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            backButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            backButton.Depth = 0;
            backButton.HighEmphasis = true;
            backButton.Icon = null;
            backButton.Location = new Point(16, 938);
            backButton.Margin = new Padding(5, 9, 5, 9);
            backButton.MouseState = MaterialSkin.MouseState.HOVER;
            backButton.Name = "backButton";
            backButton.NoAccentTextColor = Color.Empty;
            backButton.Size = new Size(133, 55);
            backButton.TabIndex = 4;
            backButton.Text = "Назад";
            backButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            backButton.UseAccentColor = false;
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // status_bar_text
            // 
            status_bar_text.AutoSize = true;
            status_bar_text.Depth = 0;
            status_bar_text.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            status_bar_text.Location = new Point(16, 1000);
            status_bar_text.Margin = new Padding(4, 0, 4, 0);
            status_bar_text.MouseState = MaterialSkin.MouseState.HOVER;
            status_bar_text.Name = "status_bar_text";
            status_bar_text.Size = new Size(1, 0);
            status_bar_text.TabIndex = 5;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(693, 92);
            materialLabel1.Margin = new Padding(4, 0, 4, 0);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(95, 19);
            materialLabel1.TabIndex = 6;
            materialLabel1.Text = "Дата заезда";
            // 
            // AdditionalForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 1006);
            Controls.Add(materialLabel1);
            Controls.Add(status_bar_text);
            Controls.Add(backButton);
            Controls.Add(filterToggle);
            Controls.Add(visitDatePicker);
            Controls.Add(clubsComboBox);
            Controls.Add(visitorsPanel);
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AdditionalForm";
            Padding = new Padding(4, 98, 4, 5);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Посетители";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel visitorsPanel;
        private MaterialSkin.Controls.MaterialComboBox clubsComboBox;
        private System.Windows.Forms.DateTimePicker visitDatePicker;
        private MaterialSkin.Controls.MaterialSwitch filterToggle;
        private MaterialSkin.Controls.MaterialButton backButton;
        private MaterialSkin.Controls.MaterialLabel status_bar_text;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}