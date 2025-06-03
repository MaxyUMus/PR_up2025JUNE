using MaterialSkin.Controls;

namespace maxim_1
{
    partial class EditForm
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
            this.txtAddress = new MaterialSkin.Controls.MaterialTextBox();
            this.txtType = new MaterialSkin.Controls.MaterialTextBox();
            this.txtSquare = new MaterialSkin.Controls.MaterialTextBox();
            this.numRooms = new System.Windows.Forms.NumericUpDown();
            this.txtDistrict = new MaterialSkin.Controls.MaterialTextBox();
            this.numFloor = new System.Windows.Forms.NumericUpDown();
            this.txtPrice = new MaterialSkin.Controls.MaterialTextBox();
            this.txtOwner = new MaterialSkin.Controls.MaterialTextBox();
            this.txtPhone = new MaterialSkin.Controls.MaterialTextBox();
            this.dtpRegDate = new System.Windows.Forms.DateTimePicker();
            this.numYear = new System.Windows.Forms.NumericUpDown();
            this.cmbStatus = new MaterialSkin.Controls.MaterialComboBox();
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.btnCancel = new MaterialSkin.Controls.MaterialButton();
            this.lblStatus = new MaterialSkin.Controls.MaterialLabel();
            this.lblYear = new MaterialSkin.Controls.MaterialLabel();
            this.lblRooms = new MaterialSkin.Controls.MaterialLabel();
            this.lblFloor = new MaterialSkin.Controls.MaterialLabel();
            this.lblRegDate = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAddress
            // 
            this.txtAddress.AnimateReadOnly = false;
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddress.Depth = 0;
            this.txtAddress.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtAddress.Hint = "Адрес объекта";
            this.txtAddress.LeadingIcon = null;
            this.txtAddress.Location = new System.Drawing.Point(20, 80);
            this.txtAddress.MaxLength = 100;
            this.txtAddress.MouseState = MaterialSkin.MouseState.OUT;
            this.txtAddress.Multiline = false;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(600, 50);
            this.txtAddress.TabIndex = 0;
            this.txtAddress.Text = "";
            this.txtAddress.TrailingIcon = null;
            // 
            // txtType
            // 
            this.txtType.AnimateReadOnly = false;
            this.txtType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtType.Depth = 0;
            this.txtType.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtType.Hint = "Тип недвижимости";
            this.txtType.LeadingIcon = null;
            this.txtType.Location = new System.Drawing.Point(20, 150);
            this.txtType.MaxLength = 100;
            this.txtType.MouseState = MaterialSkin.MouseState.OUT;
            this.txtType.Multiline = false;
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(290, 50);
            this.txtType.TabIndex = 1;
            this.txtType.Text = "";
            this.txtType.TrailingIcon = null;
            // 
            // txtSquare
            // 
            this.txtSquare.AnimateReadOnly = false;
            this.txtSquare.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSquare.Depth = 0;
            this.txtSquare.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtSquare.Hint = "Площадь (м²)";
            this.txtSquare.LeadingIcon = null;
            this.txtSquare.Location = new System.Drawing.Point(330, 150);
            this.txtSquare.MaxLength = 10;
            this.txtSquare.MouseState = MaterialSkin.MouseState.OUT;
            this.txtSquare.Multiline = false;
            this.txtSquare.Name = "txtSquare";
            this.txtSquare.Size = new System.Drawing.Size(290, 50);
            this.txtSquare.TabIndex = 2;
            this.txtSquare.Text = "";
            this.txtSquare.TrailingIcon = null;
            // 
            // numRooms
            // 
            this.numRooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numRooms.Location = new System.Drawing.Point(330, 220);
            this.numRooms.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRooms.Name = "numRooms";
            this.numRooms.Size = new System.Drawing.Size(120, 30);
            this.numRooms.TabIndex = 4;
            this.numRooms.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtDistrict
            // 
            this.txtDistrict.AnimateReadOnly = false;
            this.txtDistrict.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDistrict.Depth = 0;
            this.txtDistrict.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtDistrict.Hint = "Район";
            this.txtDistrict.LeadingIcon = null;
            this.txtDistrict.Location = new System.Drawing.Point(20, 290);
            this.txtDistrict.MaxLength = 100;
            this.txtDistrict.MouseState = MaterialSkin.MouseState.OUT;
            this.txtDistrict.Multiline = false;
            this.txtDistrict.Name = "txtDistrict";
            this.txtDistrict.Size = new System.Drawing.Size(290, 50);
            this.txtDistrict.TabIndex = 5;
            this.txtDistrict.Text = "";
            this.txtDistrict.TrailingIcon = null;
            // 
            // numFloor
            // 
            this.numFloor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numFloor.Location = new System.Drawing.Point(330, 290);
            this.numFloor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFloor.Name = "numFloor";
            this.numFloor.Size = new System.Drawing.Size(120, 30);
            this.numFloor.TabIndex = 6;
            this.numFloor.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtPrice
            // 
            this.txtPrice.AnimateReadOnly = false;
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrice.Depth = 0;
            this.txtPrice.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPrice.Hint = "Цена (млн руб)";
            this.txtPrice.LeadingIcon = null;
            this.txtPrice.Location = new System.Drawing.Point(20, 360);
            this.txtPrice.MaxLength = 15;
            this.txtPrice.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPrice.Multiline = false;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(290, 50);
            this.txtPrice.TabIndex = 7;
            this.txtPrice.Text = "";
            this.txtPrice.TrailingIcon = null;
            // 
            // txtOwner
            // 
            this.txtOwner.AnimateReadOnly = false;
            this.txtOwner.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOwner.Depth = 0;
            this.txtOwner.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtOwner.Hint = "Владелец";
            this.txtOwner.LeadingIcon = null;
            this.txtOwner.Location = new System.Drawing.Point(20, 430);
            this.txtOwner.MaxLength = 150;
            this.txtOwner.MouseState = MaterialSkin.MouseState.OUT;
            this.txtOwner.Multiline = false;
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.Size = new System.Drawing.Size(290, 50);
            this.txtOwner.TabIndex = 8;
            this.txtOwner.Text = "";
            this.txtOwner.TrailingIcon = null;
            // 
            // txtPhone
            // 
            this.txtPhone.AnimateReadOnly = false;
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPhone.Depth = 0;
            this.txtPhone.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPhone.Hint = "Телефон владельца";
            this.txtPhone.LeadingIcon = null;
            this.txtPhone.Location = new System.Drawing.Point(330, 430);
            this.txtPhone.MaxLength = 20;
            this.txtPhone.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPhone.Multiline = false;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(290, 50);
            this.txtPhone.TabIndex = 9;
            this.txtPhone.Text = "";
            this.txtPhone.TrailingIcon = null;
            // 
            // dtpRegDate
            // 
            this.dtpRegDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpRegDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRegDate.Location = new System.Drawing.Point(330, 500);
            this.dtpRegDate.Name = "dtpRegDate";
            this.dtpRegDate.Size = new System.Drawing.Size(200, 30);
            this.dtpRegDate.TabIndex = 11;
            // 
            // numYear
            // 
            this.numYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numYear.Location = new System.Drawing.Point(330, 360);
            this.numYear.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numYear.Minimum = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Size = new System.Drawing.Size(120, 30);
            this.numYear.TabIndex = 12;
            this.numYear.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(20, 500);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(290, 33);
            this.cmbStatus.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSave.Depth = 0;
            this.btnSave.HighEmphasis = true;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(150, 560);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSave.Size = new System.Drawing.Size(150, 40);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "СОХРАНИТЬ";
            this.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSave.UseAccentColor = true;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = false;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCancel.Depth = 0;
            this.btnCancel.HighEmphasis = true;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(350, 560);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCancel.Size = new System.Drawing.Size(150, 40);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "ОТМЕНА";
            this.btnCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnCancel.UseAccentColor = true;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Depth = 0;
            this.lblStatus.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblStatus.Location = new System.Drawing.Point(17, 470);
            this.lblStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(53, 19);
            this.lblStatus.TabIndex = 15;
            this.lblStatus.Text = "Статус:";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Depth = 0;
            this.lblYear.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblYear.Location = new System.Drawing.Point(327, 330);
            this.lblYear.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(113, 19);
            this.lblYear.TabIndex = 16;
            this.lblYear.Text = "Год постройки:";
            // 
            // lblRooms
            // 
            this.lblRooms.AutoSize = true;
            this.lblRooms.Depth = 0;
            this.lblRooms.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblRooms.Location = new System.Drawing.Point(327, 200);
            this.lblRooms.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRooms.Name = "lblRooms";
            this.lblRooms.Size = new System.Drawing.Size(149, 19);
            this.lblRooms.TabIndex = 17;
            this.lblRooms.Text = "Количество комнат:";
            // 
            // lblFloor
            // 
            this.lblFloor.AutoSize = true;
            this.lblFloor.Depth = 0;
            this.lblFloor.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblFloor.Location = new System.Drawing.Point(327, 270);
            this.lblFloor.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblFloor.Name = "lblFloor";
            this.lblFloor.Size = new System.Drawing.Size(46, 19);
            this.lblFloor.TabIndex = 18;
            this.lblFloor.Text = "Этаж:";
            // 
            // lblRegDate
            // 
            this.lblRegDate.AutoSize = true;
            this.lblRegDate.Depth = 0;
            this.lblRegDate.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblRegDate.Location = new System.Drawing.Point(327, 470);
            this.lblRegDate.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblRegDate.Name = "lblRegDate";
            this.lblRegDate.Size = new System.Drawing.Size(165, 19);
            this.lblRegDate.TabIndex = 19;
            this.lblRegDate.Text = "Дата регистрации:";
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 620);
            this.Controls.Add(this.lblRegDate);
            this.Controls.Add(this.lblFloor);
            this.Controls.Add(this.lblRooms);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.numYear);
            this.Controls.Add(this.dtpRegDate);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtOwner);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.numFloor);
            this.Controls.Add(this.txtDistrict);
            this.Controls.Add(this.numRooms);
            this.Controls.Add(this.txtSquare);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.txtAddress);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditForm";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование объекта недвижимости";
            ((System.ComponentModel.ISupportInitialize)(this.numRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox txtAddress;
        private MaterialSkin.Controls.MaterialTextBox txtType;
        private MaterialSkin.Controls.MaterialTextBox txtSquare;
        private System.Windows.Forms.NumericUpDown numRooms;
        private MaterialSkin.Controls.MaterialTextBox txtDistrict;
        private System.Windows.Forms.NumericUpDown numFloor;
        private MaterialSkin.Controls.MaterialTextBox txtPrice;
        private MaterialSkin.Controls.MaterialTextBox txtOwner;
        private MaterialSkin.Controls.MaterialTextBox txtPhone;
        private System.Windows.Forms.DateTimePicker dtpRegDate;
        private System.Windows.Forms.NumericUpDown numYear;
        private MaterialComboBox cmbStatus;
        private MaterialSkin.Controls.MaterialButton btnSave;
        private MaterialSkin.Controls.MaterialButton btnCancel;
        private MaterialSkin.Controls.MaterialLabel lblStatus;
        private MaterialSkin.Controls.MaterialLabel lblYear;
        private MaterialSkin.Controls.MaterialLabel lblRooms;
        private MaterialSkin.Controls.MaterialLabel lblFloor;
        private MaterialSkin.Controls.MaterialLabel lblRegDate;
    }
}