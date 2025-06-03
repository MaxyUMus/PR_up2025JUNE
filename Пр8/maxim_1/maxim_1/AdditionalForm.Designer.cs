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
            materialComboBoxPost = new MaterialSkin.Controls.MaterialComboBox();
            materialTextBoxQualification = new MaterialSkin.Controls.MaterialTextBox();
            materialTextBoxEducation = new MaterialSkin.Controls.MaterialTextBox();
            materialTextBoxExperience = new MaterialSkin.Controls.MaterialTextBox();
            materialTextBoxOtherInfo = new MaterialSkin.Controls.MaterialTextBox();
            materialButtonSearch = new MaterialSkin.Controls.MaterialButton();
            panelResults = new Panel();
            go_back_button = new FontAwesome.Sharp.IconButton();
            status_bar_text = new MaterialSkin.Controls.MaterialLabel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            SuspendLayout();
            // 
            // materialComboBoxPost
            // 
            materialComboBoxPost.AutoResize = false;
            materialComboBoxPost.BackColor = Color.FromArgb(255, 255, 255);
            materialComboBoxPost.Depth = 0;
            materialComboBoxPost.DrawMode = DrawMode.OwnerDrawVariable;
            materialComboBoxPost.DropDownHeight = 174;
            materialComboBoxPost.DropDownStyle = ComboBoxStyle.DropDownList;
            materialComboBoxPost.DropDownWidth = 121;
            materialComboBoxPost.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialComboBoxPost.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialComboBoxPost.FormattingEnabled = true;
            materialComboBoxPost.IntegralHeight = false;
            materialComboBoxPost.ItemHeight = 43;
            materialComboBoxPost.Location = new Point(12, 100);
            materialComboBoxPost.Margin = new Padding(3, 4, 3, 4);
            materialComboBoxPost.MaxDropDownItems = 4;
            materialComboBoxPost.MouseState = MaterialSkin.MouseState.OUT;
            materialComboBoxPost.Name = "materialComboBoxPost";
            materialComboBoxPost.Size = new Size(250, 49);
            materialComboBoxPost.StartIndex = 0;
            materialComboBoxPost.TabIndex = 0;
            // 
            // materialTextBoxQualification
            // 
            materialTextBoxQualification.AnimateReadOnly = false;
            materialTextBoxQualification.BorderStyle = BorderStyle.None;
            materialTextBoxQualification.Depth = 0;
            materialTextBoxQualification.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBoxQualification.LeadingIcon = null;
            materialTextBoxQualification.Location = new Point(268, 100);
            materialTextBoxQualification.Margin = new Padding(3, 4, 3, 4);
            materialTextBoxQualification.MaxLength = 50;
            materialTextBoxQualification.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBoxQualification.Multiline = false;
            materialTextBoxQualification.Name = "materialTextBoxQualification";
            materialTextBoxQualification.Size = new Size(200, 50);
            materialTextBoxQualification.TabIndex = 1;
            materialTextBoxQualification.Text = "";
            materialTextBoxQualification.TrailingIcon = null;
            // 
            // materialTextBoxEducation
            // 
            materialTextBoxEducation.AnimateReadOnly = false;
            materialTextBoxEducation.BorderStyle = BorderStyle.None;
            materialTextBoxEducation.Depth = 0;
            materialTextBoxEducation.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBoxEducation.LeadingIcon = null;
            materialTextBoxEducation.Location = new Point(474, 100);
            materialTextBoxEducation.Margin = new Padding(3, 4, 3, 4);
            materialTextBoxEducation.MaxLength = 50;
            materialTextBoxEducation.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBoxEducation.Multiline = false;
            materialTextBoxEducation.Name = "materialTextBoxEducation";
            materialTextBoxEducation.Size = new Size(200, 50);
            materialTextBoxEducation.TabIndex = 2;
            materialTextBoxEducation.Text = "";
            materialTextBoxEducation.TrailingIcon = null;
            // 
            // materialTextBoxExperience
            // 
            materialTextBoxExperience.AnimateReadOnly = false;
            materialTextBoxExperience.BorderStyle = BorderStyle.None;
            materialTextBoxExperience.Depth = 0;
            materialTextBoxExperience.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBoxExperience.LeadingIcon = null;
            materialTextBoxExperience.Location = new Point(680, 100);
            materialTextBoxExperience.Margin = new Padding(3, 4, 3, 4);
            materialTextBoxExperience.MaxLength = 3;
            materialTextBoxExperience.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBoxExperience.Multiline = false;
            materialTextBoxExperience.Name = "materialTextBoxExperience";
            materialTextBoxExperience.Size = new Size(100, 50);
            materialTextBoxExperience.TabIndex = 3;
            materialTextBoxExperience.Text = "";
            materialTextBoxExperience.TrailingIcon = null;
            // 
            // materialTextBoxOtherInfo
            // 
            materialTextBoxOtherInfo.AnimateReadOnly = false;
            materialTextBoxOtherInfo.BorderStyle = BorderStyle.None;
            materialTextBoxOtherInfo.Depth = 0;
            materialTextBoxOtherInfo.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBoxOtherInfo.LeadingIcon = null;
            materialTextBoxOtherInfo.Location = new Point(12, 188);
            materialTextBoxOtherInfo.Margin = new Padding(3, 4, 3, 4);
            materialTextBoxOtherInfo.MaxLength = 500;
            materialTextBoxOtherInfo.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBoxOtherInfo.Name = "materialTextBoxOtherInfo";
            materialTextBoxOtherInfo.Size = new Size(768, 50);
            materialTextBoxOtherInfo.TabIndex = 4;
            materialTextBoxOtherInfo.Text = "";
            materialTextBoxOtherInfo.TrailingIcon = null;
            // 
            // materialButtonSearch
            // 
            materialButtonSearch.AutoSize = false;
            materialButtonSearch.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButtonSearch.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButtonSearch.Depth = 0;
            materialButtonSearch.HighEmphasis = true;
            materialButtonSearch.Icon = null;
            materialButtonSearch.Location = new Point(786, 188);
            materialButtonSearch.Margin = new Padding(4, 8, 4, 8);
            materialButtonSearch.MouseState = MaterialSkin.MouseState.HOVER;
            materialButtonSearch.Name = "materialButtonSearch";
            materialButtonSearch.NoAccentTextColor = Color.Empty;
            materialButtonSearch.Size = new Size(138, 125);
            materialButtonSearch.TabIndex = 5;
            materialButtonSearch.Text = "Поиск";
            materialButtonSearch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButtonSearch.UseAccentColor = false;
            materialButtonSearch.UseVisualStyleBackColor = true;
            materialButtonSearch.Click += buttonSearch_Click;
            // 
            // panelResults
            // 
            panelResults.AutoScroll = true;
            panelResults.Location = new Point(12, 325);
            panelResults.Margin = new Padding(3, 4, 3, 4);
            panelResults.Name = "panelResults";
            panelResults.Size = new Size(912, 675);
            panelResults.TabIndex = 6;
            // 
            // go_back_button
            // 
            go_back_button.FlatAppearance.BorderSize = 0;
            go_back_button.FlatStyle = FlatStyle.Flat;
            go_back_button.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            go_back_button.IconColor = Color.Black;
            go_back_button.IconFont = FontAwesome.Sharp.IconFont.Auto;
            go_back_button.IconSize = 40;
            go_back_button.Location = new Point(874, 75);
            go_back_button.Margin = new Padding(3, 4, 3, 4);
            go_back_button.Name = "go_back_button";
            go_back_button.Size = new Size(50, 62);
            go_back_button.TabIndex = 7;
            go_back_button.UseVisualStyleBackColor = true;
            go_back_button.Click += go_back_button_Click;
            // 
            // status_bar_text
            // 
            status_bar_text.Depth = 0;
            status_bar_text.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            status_bar_text.Location = new Point(12, 1006);
            status_bar_text.MouseState = MaterialSkin.MouseState.HOVER;
            status_bar_text.Name = "status_bar_text";
            status_bar_text.Size = new Size(912, 31);
            status_bar_text.TabIndex = 8;
            status_bar_text.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(12, 75);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(86, 19);
            materialLabel1.TabIndex = 9;
            materialLabel1.Text = "Должность";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(268, 75);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(113, 19);
            materialLabel2.TabIndex = 10;
            materialLabel2.Text = "Квалификация";
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(474, 75);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(100, 19);
            materialLabel3.TabIndex = 11;
            materialLabel3.Text = "Образование";
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(680, 75);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(40, 19);
            materialLabel4.TabIndex = 12;
            materialLabel4.Text = "Стаж";
            // 
            // materialLabel5
            // 
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(12, 162);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(135, 19);
            materialLabel5.TabIndex = 13;
            materialLabel5.Text = "Доп. информация";
            // 
            // AdditionalForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(936, 1050);
            Controls.Add(materialLabel5);
            Controls.Add(materialLabel4);
            Controls.Add(materialLabel3);
            Controls.Add(materialLabel2);
            Controls.Add(materialLabel1);
            Controls.Add(status_bar_text);
            Controls.Add(go_back_button);
            Controls.Add(panelResults);
            Controls.Add(materialButtonSearch);
            Controls.Add(materialTextBoxOtherInfo);
            Controls.Add(materialTextBoxExperience);
            Controls.Add(materialTextBoxEducation);
            Controls.Add(materialTextBoxQualification);
            Controls.Add(materialComboBoxPost);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AdditionalForm";
            Padding = new Padding(3, 80, 3, 4);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Поиск соискателей";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialComboBox materialComboBoxPost;
        private MaterialSkin.Controls.MaterialTextBox materialTextBoxQualification;
        private MaterialSkin.Controls.MaterialTextBox materialTextBoxEducation;
        private MaterialSkin.Controls.MaterialTextBox materialTextBoxExperience;
        private MaterialSkin.Controls.MaterialTextBox materialTextBoxOtherInfo;
        private MaterialSkin.Controls.MaterialButton materialButtonSearch;
        private System.Windows.Forms.Panel panelResults;
        private FontAwesome.Sharp.IconButton go_back_button;
        private MaterialSkin.Controls.MaterialLabel status_bar_text;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
    }
}