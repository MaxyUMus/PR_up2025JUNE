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
            clientsPanel = new Panel();
            go_back_button = new MaterialSkin.Controls.MaterialButton();
            status_bar_text = new MaterialSkin.Controls.MaterialLabel();
            toggleFilters = new MaterialSkin.Controls.MaterialCheckbox();
            dateFilter = new DateTimePicker();
            SuspendLayout();
            // 
            // clientsPanel
            // 
            clientsPanel.AutoScroll = true;
            clientsPanel.Location = new Point(8, 108);
            clientsPanel.Margin = new Padding(4, 5, 4, 5);
            clientsPanel.Name = "clientsPanel";
            clientsPanel.Size = new Size(1051, 566);
            clientsPanel.TabIndex = 0;
            // 
            // go_back_button
            // 
            go_back_button.AutoSize = false;
            go_back_button.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            go_back_button.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            go_back_button.Depth = 0;
            go_back_button.HighEmphasis = true;
            go_back_button.Icon = null;
            go_back_button.Location = new Point(8, 709);
            go_back_button.Margin = new Padding(5, 9, 5, 9);
            go_back_button.MouseState = MaterialSkin.MouseState.HOVER;
            go_back_button.Name = "go_back_button";
            go_back_button.NoAccentTextColor = Color.Empty;
            go_back_button.Size = new Size(133, 55);
            go_back_button.TabIndex = 1;
            go_back_button.Text = "Назад";
            go_back_button.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            go_back_button.UseAccentColor = false;
            go_back_button.UseVisualStyleBackColor = true;
            go_back_button.Click += go_back_button_Click;
            // 
            // status_bar_text
            // 
            status_bar_text.Depth = 0;
            status_bar_text.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            status_bar_text.Location = new Point(150, 709);
            status_bar_text.Margin = new Padding(4, 0, 4, 0);
            status_bar_text.MouseState = MaterialSkin.MouseState.HOVER;
            status_bar_text.Name = "status_bar_text";
            status_bar_text.Size = new Size(909, 55);
            status_bar_text.TabIndex = 2;
            status_bar_text.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // toggleFilters
            // 
            toggleFilters.AutoSize = true;
            toggleFilters.Depth = 0;
            toggleFilters.Location = new Point(8, 70);
            toggleFilters.Margin = new Padding(0);
            toggleFilters.MouseLocation = new Point(-1, -1);
            toggleFilters.MouseState = MaterialSkin.MouseState.HOVER;
            toggleFilters.Name = "toggleFilters";
            toggleFilters.ReadOnly = false;
            toggleFilters.Ripple = true;
            toggleFilters.Size = new Size(152, 37);
            toggleFilters.TabIndex = 3;
            toggleFilters.Text = "Фильтр по дате";
            toggleFilters.UseVisualStyleBackColor = true;
            toggleFilters.CheckedChanged += toggleFilters_CheckedChanged;
            // 
            // dateFilter
            // 
            dateFilter.Format = DateTimePickerFormat.Short;
            dateFilter.Location = new Point(164, 80);
            dateFilter.Margin = new Padding(4, 5, 4, 5);
            dateFilter.Name = "dateFilter";
            dateFilter.Size = new Size(159, 27);
            dateFilter.TabIndex = 4;
            dateFilter.ValueChanged += dateFilter_ValueChanged;
            // 
            // AdditionalForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1067, 769);
            Controls.Add(dateFilter);
            Controls.Add(toggleFilters);
            Controls.Add(status_bar_text);
            Controls.Add(go_back_button);
            Controls.Add(clientsPanel);
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "AdditionalForm";
            Padding = new Padding(4, 98, 4, 5);
            Sizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Клиенты и договоры";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel clientsPanel;
        private MaterialSkin.Controls.MaterialButton go_back_button;
        private MaterialSkin.Controls.MaterialLabel status_bar_text;
        private MaterialSkin.Controls.MaterialCheckbox toggleFilters;
        private System.Windows.Forms.DateTimePicker dateFilter;
    }
}