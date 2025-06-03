using MaterialSkin.Controls;
namespace maxim_1
{
    partial class AdditionalForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            go_back_button = new MaterialButton();
            status_bar = new StatusStrip();
            status_bar_text = new ToolStripStatusLabel();
            icon_box = new PictureBox();
            items_panel = new FlowLayoutPanel();
            status_bar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icon_box).BeginInit();
            SuspendLayout();
            // 
            // go_back_button
            // 
            go_back_button.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            go_back_button.AutoSize = false;
            go_back_button.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            go_back_button.Density = MaterialButton.MaterialButtonDensity.Default;
            go_back_button.Depth = 0;
            go_back_button.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            go_back_button.HighEmphasis = true;
            go_back_button.Icon = null;
            go_back_button.Location = new Point(864, 527);
            go_back_button.Margin = new Padding(4, 6, 4, 6);
            go_back_button.MouseState = MaterialSkin.MouseState.HOVER;
            go_back_button.Name = "go_back_button";
            go_back_button.NoAccentTextColor = Color.Empty;
            go_back_button.Size = new Size(124, 36);
            go_back_button.TabIndex = 0;
            go_back_button.Text = "Назад";
            go_back_button.Type = MaterialButton.MaterialButtonType.Contained;
            go_back_button.UseAccentColor = false;
            go_back_button.UseVisualStyleBackColor = false;
            go_back_button.Click += go_back_button_Click;
            // 
            // status_bar
            // 
            status_bar.ImageScalingSize = new Size(20, 20);
            status_bar.Items.AddRange(new ToolStripItem[] { status_bar_text });
            status_bar.Location = new Point(3, 571);
            status_bar.Name = "status_bar";
            status_bar.Size = new Size(988, 25);
            status_bar.TabIndex = 1;
            status_bar.Text = "statusStrip1";
            // 
            // status_bar_text
            // 
            status_bar_text.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            status_bar_text.Name = "status_bar_text";
            status_bar_text.Size = new Size(35, 19);
            status_bar_text.Text = "text";
            // 
            // icon_box
            // 
            icon_box.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            icon_box.BackgroundImage = Properties.Resources.app_icon;
            icon_box.BackgroundImageLayout = ImageLayout.Zoom;
            icon_box.Location = new Point(863, 32);
            icon_box.Name = "icon_box";
            icon_box.Size = new Size(125, 125);
            icon_box.TabIndex = 2;
            icon_box.TabStop = false;
            // 
            // items_panel
            // 
            items_panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            items_panel.AutoScroll = true;
            items_panel.BorderStyle = BorderStyle.FixedSingle;
            items_panel.Location = new Point(9, 32);
            items_panel.Margin = new Padding(0);
            items_panel.Name = "items_panel";
            items_panel.Size = new Size(851, 531);
            items_panel.TabIndex = 3;
            // 
            // AdditionalForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(994, 599);
            Controls.Add(items_panel);
            Controls.Add(icon_box);
            Controls.Add(status_bar);
            Controls.Add(go_back_button);
            FormStyle = FormStyles.ActionBar_None;
            Name = "AdditionalForm";
            Padding = new Padding(3, 24, 3, 3);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Дополнительная форма";
            WindowState = FormWindowState.Maximized;
            status_bar.ResumeLayout(false);
            status_bar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icon_box).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialButton go_back_button;
        private StatusStrip status_bar;
        private ToolStripStatusLabel status_bar_text;
        private PictureBox icon_box;
        private FlowLayoutPanel items_panel;
    }
}