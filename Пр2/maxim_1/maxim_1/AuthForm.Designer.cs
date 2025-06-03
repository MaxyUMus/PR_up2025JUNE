namespace maxim_1
{
    partial class AuthForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthForm));
            login_button = new Button();
            status_bar = new StatusStrip();
            statusbar_text = new ToolStripStatusLabel();
            login_textBox = new TextBox();
            password_textBox = new TextBox();
            show_password_button = new Button();
            panel1 = new Panel();
            icon_box = new PictureBox();
            status_bar.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icon_box).BeginInit();
            SuspendLayout();
            // 
            // login_button
            // 
            login_button.Anchor = AnchorStyles.None;
            login_button.BackColor = Constants.AccentColor;
            login_button.ForeColor = Constants.GetContrastTextColor(Constants.AccentColor);
            login_button.Font = new Font("Times New Roman", 10.2F);
            login_button.Location = new Point(99, 278);
            login_button.Name = "login_button";
            login_button.Size = new Size(94, 29);
            login_button.TabIndex = 0;
            login_button.Text = "Войти";
            login_button.UseVisualStyleBackColor = false;
            login_button.Click += login_button_Click;
            // 
            // status_bar
            // 
            status_bar.ImageScalingSize = new Size(20, 20);
            status_bar.Items.AddRange(new ToolStripItem[] { statusbar_text });
            status_bar.Location = new Point(0, 425);
            status_bar.Name = "status_bar";
            status_bar.Size = new Size(800, 25);
            status_bar.TabIndex = 1;
            status_bar.Text = "statusStrip1";
            // 
            // statusbar_text
            // 
            statusbar_text.Font = new Font("Times New Roman", 10.2F);
            statusbar_text.Name = "statusbar_text";
            statusbar_text.Size = new Size(35, 19);
            statusbar_text.Text = "text";
            // 
            // login_textBox
            // 
            login_textBox.Anchor = AnchorStyles.None;
            login_textBox.Font = new Font("Times New Roman", 10.2F);
            login_textBox.BackColor = Constants.SecondaryBackgroundColor;
            login_textBox.Location = new Point(29, 177);
            login_textBox.Name = "login_textBox";
            login_textBox.PlaceholderText = "Логин...";
            login_textBox.Size = new Size(249, 27);
            login_textBox.TabIndex = 1;
            // 
            // password_textBox
            // 
            password_textBox.Anchor = AnchorStyles.None;
            password_textBox.Font = new Font("Times New Roman", 10.2F);
            password_textBox.BackColor = Constants.SecondaryBackgroundColor;
            password_textBox.Location = new Point(29, 221);
            password_textBox.Name = "password_textBox";
            password_textBox.PlaceholderText = "Пароль...";
            password_textBox.Size = new Size(214, 27);
            password_textBox.TabIndex = 2;
            password_textBox.UseSystemPasswordChar = true;
            // 
            // show_password_button
            // 
            show_password_button.Anchor = AnchorStyles.None;
            show_password_button.BackgroundImage = Properties.Resources.show_password_icon;
            show_password_button.BackgroundImageLayout = ImageLayout.Zoom;
            show_password_button.Location = new Point(249, 221);
            show_password_button.Name = "show_password_button";
            show_password_button.Size = new Size(29, 29);
            show_password_button.TabIndex = 3;
            show_password_button.TabStop = false;
            show_password_button.UseVisualStyleBackColor = true;
            show_password_button.Click += show_password_button_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(icon_box);
            panel1.Controls.Add(show_password_button);
            panel1.Controls.Add(login_button);
            panel1.Controls.Add(password_textBox);
            panel1.Controls.Add(login_textBox);
            panel1.Location = new Point(245, 90);
            panel1.Name = "panel1";
            panel1.Size = new Size(295, 310);
            panel1.TabIndex = 7;
            // 
            // icon_box
            // 
            icon_box.Anchor = AnchorStyles.None;
            icon_box.BackgroundImage = Properties.Resources.app_icon;
            icon_box.BackgroundImageLayout = ImageLayout.Zoom;
            icon_box.Location = new Point(85, 16);
            icon_box.Name = "icon_box";
            icon_box.Size = new Size(126, 126);
            icon_box.TabIndex = 7;
            icon_box.TabStop = false;
            // 
            // AuthForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(status_bar);
            BackColor = Constants.PrimaryBackgroundColor;
            Icon = new Icon("images/app_icon.ico");
            Name = "AuthForm";
            Text = "Авторизация";
            status_bar.ResumeLayout(false);
            status_bar.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icon_box).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button login_button;
        private StatusStrip status_bar;
        private ToolStripStatusLabel statusbar_text;
        private TextBox login_textBox;
        private TextBox password_textBox;
        private Button show_password_button;
        private Panel panel1;
        private PictureBox icon_box;
    }
}