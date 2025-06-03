using FontAwesome.Sharp;
using MaterialSkin.Controls;

namespace maxim_1
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            table_view = new DataGridView();
            tables_box = new MaterialComboBox();
            btn_save = new IconButton();
            btn_delete = new IconButton();
            status_bar = new StatusStrip();
            status_bar_text = new ToolStripStatusLabel();
            icon_box = new PictureBox();
            go_to_additional_button = new MaterialButton();
            ((System.ComponentModel.ISupportInitialize)table_view).BeginInit();
            status_bar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icon_box).BeginInit();
            SuspendLayout();
            // 
            // table_view
            // 
            table_view.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            table_view.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            table_view.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            table_view.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table_view.Location = new Point(11, 87);
            table_view.Name = "table_view";
            table_view.RowHeadersWidth = 51;
            table_view.Size = new Size(843, 433);
            table_view.TabIndex = 0;
            // 
            // tables_box
            // 
            tables_box.AutoResize = false;
            tables_box.BackColor = Color.FromArgb(255, 255, 255);
            tables_box.Depth = 0;
            tables_box.DrawMode = DrawMode.OwnerDrawVariable;
            tables_box.DropDownHeight = 174;
            tables_box.DropDownStyle = ComboBoxStyle.DropDownList;
            tables_box.DropDownWidth = 121;
            tables_box.Font = new Font("Times New Roman", 10.2F);
            tables_box.ForeColor = Color.FromArgb(222, 0, 0, 0);
            tables_box.IntegralHeight = false;
            tables_box.ItemHeight = 43;
            tables_box.Location = new Point(11, 32);
            tables_box.MaxDropDownItems = 4;
            tables_box.MouseState = MaterialSkin.MouseState.OUT;
            tables_box.Name = "tables_box";
            tables_box.Size = new Size(422, 49);
            tables_box.StartIndex = 0;
            tables_box.TabIndex = 1;
            tables_box.SelectedIndexChanged += tables_box_SelectedIndexChanged;
            // 
            // btn_save
            // 
            btn_save.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_save.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_save.FlatStyle = FlatStyle.Flat;
            btn_save.Font = new Font("Times New Roman", 10.2F);
            btn_save.IconChar = IconChar.Save;
            btn_save.IconColor = Color.Black;
            btn_save.IconFont = IconFont.Auto;
            btn_save.IconSize = 27;
            btn_save.Location = new Point(11, 529);
            btn_save.Margin = new Padding(5, 5, 5, 5);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(31, 36);
            btn_save.TabIndex = 2;
            btn_save.TextAlign = ContentAlignment.MiddleRight;
            btn_save.UseVisualStyleBackColor = false;
            btn_save.Click += btn_save_Click;
            // 
            // btn_delete
            // 
            btn_delete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_delete.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_delete.FlatStyle = FlatStyle.Flat;
            btn_delete.Font = new Font("Times New Roman", 10.2F);
            btn_delete.IconChar = IconChar.Trash;
            btn_delete.IconColor = Color.Black;
            btn_delete.IconFont = IconFont.Auto;
            btn_delete.IconSize = 27;
            btn_delete.Location = new Point(51, 529);
            btn_delete.Margin = new Padding(5, 5, 5, 5);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(31, 36);
            btn_delete.TabIndex = 3;
            btn_delete.TextAlign = ContentAlignment.MiddleRight;
            btn_delete.UseVisualStyleBackColor = false;
            btn_delete.Click += btn_delete_Click;
            // 
            // status_bar
            // 
            status_bar.ImageScalingSize = new Size(20, 20);
            status_bar.Items.AddRange(new ToolStripItem[] { status_bar_text });
            status_bar.Location = new Point(3, 571);
            status_bar.Name = "status_bar";
            status_bar.Size = new Size(988, 25);
            status_bar.TabIndex = 4;
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
            icon_box.Location = new Point(862, 43);
            icon_box.Name = "icon_box";
            icon_box.Size = new Size(126, 147);
            icon_box.TabIndex = 8;
            icon_box.TabStop = false;
            // 
            // go_to_additional_button
            // 
            go_to_additional_button.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            go_to_additional_button.AutoSize = false;
            go_to_additional_button.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            go_to_additional_button.Density = MaterialButton.MaterialButtonDensity.Default;
            go_to_additional_button.Depth = 0;
            go_to_additional_button.Font = new Font("Times New Roman", 10.2F);
            go_to_additional_button.HighEmphasis = true;
            go_to_additional_button.Icon = null;
            go_to_additional_button.Location = new Point(91, 529);
            go_to_additional_button.Margin = new Padding(5, 5, 5, 5);
            go_to_additional_button.MouseState = MaterialSkin.MouseState.HOVER;
            go_to_additional_button.Name = "go_to_additional_button";
            go_to_additional_button.NoAccentTextColor = Color.Empty;
            go_to_additional_button.Size = new Size(122, 36);
            go_to_additional_button.TabIndex = 9;
            go_to_additional_button.Text = "Соискатели";
            go_to_additional_button.Type = MaterialButton.MaterialButtonType.Contained;
            go_to_additional_button.UseAccentColor = false;
            go_to_additional_button.UseVisualStyleBackColor = false;
            go_to_additional_button.Click += go_to_additional_button_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(994, 599);
            Controls.Add(go_to_additional_button);
            Controls.Add(icon_box);
            Controls.Add(status_bar);
            Controls.Add(btn_delete);
            Controls.Add(btn_save);
            Controls.Add(tables_box);
            Controls.Add(table_view);
            FormStyle = FormStyles.ActionBar_None;
            Name = "MainForm";
            Padding = new Padding(3, 24, 3, 3);
            Text = "Главная форма";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)table_view).EndInit();
            status_bar.ResumeLayout(false);
            status_bar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)icon_box).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView table_view;
        private MaterialComboBox tables_box;
        private FontAwesome.Sharp.IconButton btn_save;
        private FontAwesome.Sharp.IconButton btn_delete;
        private StatusStrip status_bar;
        private ToolStripStatusLabel status_bar_text;
        private PictureBox icon_box;
        private MaterialButton go_to_additional_button;
    }
}
