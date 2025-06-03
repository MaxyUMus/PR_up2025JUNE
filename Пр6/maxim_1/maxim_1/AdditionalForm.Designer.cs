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
            partnersPanel = new Panel();
            go_back_button = new FontAwesome.Sharp.IconButton();
            status_bar_text = new MaterialSkin.Controls.MaterialLabel();
            SuspendLayout();
            // 
            // partnersPanel
            // 
            partnersPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            partnersPanel.AutoScroll = true;
            partnersPanel.Location = new Point(6, 67);
            partnersPanel.Name = "partnersPanel";
            partnersPanel.Size = new Size(788, 498);
            partnersPanel.TabIndex = 0;
            // 
            // go_back_button
            // 
            go_back_button.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            go_back_button.FlatAppearance.BorderSize = 0;
            go_back_button.FlatStyle = FlatStyle.Flat;
            go_back_button.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            go_back_button.IconColor = Color.Black;
            go_back_button.IconFont = FontAwesome.Sharp.IconFont.Auto;
            go_back_button.IconSize = 23;
            go_back_button.ImageAlign = ContentAlignment.MiddleLeft;
            go_back_button.Location = new Point(708, 571);
            go_back_button.Name = "go_back_button";
            go_back_button.Size = new Size(86, 23);
            go_back_button.TabIndex = 1;
            go_back_button.Text = "Назад";
            go_back_button.TextAlign = ContentAlignment.MiddleRight;
            go_back_button.UseVisualStyleBackColor = true;
            go_back_button.Click += go_back_button_Click;
            // 
            // status_bar_text
            // 
            status_bar_text.AutoSize = true;
            status_bar_text.Depth = 0;
            status_bar_text.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            status_bar_text.Location = new Point(100, 20);
            status_bar_text.MouseState = MaterialSkin.MouseState.HOVER;
            status_bar_text.Name = "status_bar_text";
            status_bar_text.Size = new Size(1, 0);
            status_bar_text.TabIndex = 2;
            // 
            // AdditionalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(go_back_button);
            Controls.Add(status_bar_text);
            Controls.Add(partnersPanel);
            Name = "AdditionalForm";
            Text = "Партнеры компании";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Panel partnersPanel;
        private FontAwesome.Sharp.IconButton go_back_button;
        private MaterialSkin.Controls.MaterialLabel status_bar_text;
    }
}