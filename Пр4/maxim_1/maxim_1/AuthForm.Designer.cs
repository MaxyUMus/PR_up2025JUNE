using FontAwesome.Sharp;
using MaterialSkin.Controls;
using maxim_1.Properties;
using Icon = System.Drawing.Icon;
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
            login_button = new MaterialButton();
            status_bar = new StatusStrip();
            statusbar_text = new ToolStripStatusLabel();
            login_textBox = new MaterialTextBox();
            password_textBox = new MaterialTextBox2();
            show_password_button = new MaterialButton();
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
            login_button.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            login_button.Density = MaterialButton.MaterialButtonDensity.Default;
            login_button.Depth = 0;
            login_button.Font = new Font("Times New Roman", 10.2F);
            login_button.HighEmphasis = true;
            login_button.Icon = null;
            login_button.Location = new Point(101, 233);
            login_button.Margin = new Padding(4, 4, 4, 4);
            login_button.MouseState = MaterialSkin.MouseState.HOVER;
            login_button.Name = "login_button";
            login_button.NoAccentTextColor = Color.Empty;
            login_button.Size = new Size(71, 36);
            login_button.TabIndex = 0;
            login_button.Text = "Войти";
            login_button.Type = MaterialButton.MaterialButtonType.Contained;
            login_button.UseAccentColor = false;
            login_button.UseVisualStyleBackColor = false;
            login_button.Click += login_button_Click;
            // 
            // status_bar
            // 
            status_bar.ImageScalingSize = new Size(20, 20);
            status_bar.Items.AddRange(new ToolStripItem[] { statusbar_text });
            status_bar.Location = new Point(3, 355);
            status_bar.Name = "status_bar";
            status_bar.Padding = new Padding(1, 0, 12, 0);
            status_bar.Size = new Size(694, 22);
            status_bar.TabIndex = 1;
            status_bar.Text = "statusStrip1";
            // 
            // statusbar_text
            // 
            statusbar_text.Font = new Font("Times New Roman", 10.2F);
            statusbar_text.Name = "statusbar_text";
            statusbar_text.Size = new Size(28, 17);
            statusbar_text.Text = "text";
            // 
            // login_textBox
            // 
            login_textBox.Anchor = AnchorStyles.None;
            login_textBox.AnimateReadOnly = false;
            login_textBox.BorderStyle = BorderStyle.None;
            login_textBox.Depth = 0;
            login_textBox.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            login_textBox.Hint = "Логин";
            login_textBox.LeadingIcon = null;
            login_textBox.Location = new Point(11, 131);
            login_textBox.Margin = new Padding(3, 2, 3, 2);
            login_textBox.MaxLength = 50;
            login_textBox.MouseState = MaterialSkin.MouseState.OUT;
            login_textBox.Multiline = false;
            login_textBox.Name = "login_textBox";
            login_textBox.Size = new Size(234, 50);
            login_textBox.TabIndex = 1;
            login_textBox.Text = "";
            login_textBox.TrailingIcon = null;
            // 
            // password_textBox
            // 
            password_textBox.Anchor = AnchorStyles.None;
            password_textBox.AnimateReadOnly = false;
            password_textBox.BackgroundImageLayout = ImageLayout.None;
            password_textBox.CharacterCasing = CharacterCasing.Normal;
            password_textBox.Depth = 0;
            password_textBox.Font = new Font("Times New Roman", 10.2F);
            password_textBox.HideSelection = true;
            password_textBox.Hint = "Пароль";
            password_textBox.LeadingIcon = null;
            password_textBox.Location = new Point(11, 185);
            password_textBox.Margin = new Padding(3, 2, 3, 2);
            password_textBox.MaxLength = 32767;
            password_textBox.MouseState = MaterialSkin.MouseState.OUT;
            password_textBox.Name = "password_textBox";
            password_textBox.PasswordChar = '●';
            password_textBox.PrefixSuffixText = null;
            password_textBox.ReadOnly = false;
            password_textBox.RightToLeft = RightToLeft.No;
            password_textBox.SelectedText = "";
            password_textBox.SelectionLength = 0;
            password_textBox.SelectionStart = 0;
            password_textBox.ShortcutsEnabled = true;
            password_textBox.Size = new Size(186, 48);
            password_textBox.TabIndex = 2;
            password_textBox.TabStop = false;
            password_textBox.TextAlign = HorizontalAlignment.Left;
            password_textBox.TrailingIcon = null;
            password_textBox.UseSystemPasswordChar = true;
            // 
            // show_password_button
            // 
            show_password_button.Anchor = AnchorStyles.None;
            show_password_button.AutoSize = false;
            show_password_button.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            show_password_button.Density = MaterialButton.MaterialButtonDensity.Default;
            show_password_button.Depth = 0;
            show_password_button.HighEmphasis = true;
            show_password_button.Icon = null;
            show_password_button.Location = new Point(203, 187);
            show_password_button.Margin = new Padding(4, 4, 4, 4);
            show_password_button.MouseState = MaterialSkin.MouseState.HOVER;
            show_password_button.Name = "show_password_button";
            show_password_button.NoAccentTextColor = Color.Empty;
            show_password_button.Size = new Size(42, 46);
            show_password_button.TabIndex = 3;
            show_password_button.TabStop = false;
            show_password_button.Type = MaterialButton.MaterialButtonType.Text;
            show_password_button.UseAccentColor = false;
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
            panel1.Location = new Point(214, 68);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(258, 273);
            panel1.TabIndex = 7;
            // 
            // icon_box
            // 
            icon_box.Anchor = AnchorStyles.None;
            icon_box.BackgroundImage = Resources.app_icon;
            icon_box.BackgroundImageLayout = ImageLayout.Zoom;
            icon_box.Location = new Point(73, 11);
            icon_box.Margin = new Padding(3, 2, 3, 2);
            icon_box.Name = "icon_box";
            icon_box.Size = new Size(110, 110);
            icon_box.TabIndex = 7;
            icon_box.TabStop = false;
            // 
            // AuthForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 379);
            Controls.Add(panel1);
            Controls.Add(status_bar);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AuthForm";
            Padding = new Padding(3, 48, 3, 2);
            StartPosition = FormStartPosition.CenterScreen;
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

        private MaterialButton login_button;
        private StatusStrip status_bar;
        private ToolStripStatusLabel statusbar_text;
        private MaterialTextBox login_textBox;
        private MaterialTextBox2 password_textBox;
        private MaterialButton show_password_button;
        private Panel panel1;
        private PictureBox icon_box;
    }
}