namespace maxim_1
{
    partial class EditLoanForm
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
            txtReader = new Label();
            txtBook = new Label();
            txtLoanDate = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // txtReader
            // 
            txtReader.AutoSize = true;
            txtReader.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtReader.Location = new Point(12, 9);
            txtReader.Name = "txtReader";
            txtReader.Size = new Size(65, 28);
            txtReader.TabIndex = 0;
            txtReader.Text = "label1";
            // 
            // txtBook
            // 
            txtBook.AutoSize = true;
            txtBook.Font = new Font("Segoe UI", 12F);
            txtBook.Location = new Point(12, 54);
            txtBook.Name = "txtBook";
            txtBook.Size = new Size(65, 28);
            txtBook.TabIndex = 1;
            txtBook.Text = "label1";
            // 
            // txtLoanDate
            // 
            txtLoanDate.AutoSize = true;
            txtLoanDate.Font = new Font("Segoe UI", 12F);
            txtLoanDate.Location = new Point(12, 104);
            txtLoanDate.Name = "txtLoanDate";
            txtLoanDate.Size = new Size(65, 28);
            txtLoanDate.TabIndex = 2;
            txtLoanDate.Text = "label1";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 162);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(239, 29);
            btnSave.TabIndex = 3;
            btnSave.Text = "Пометить как возвращенную";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(257, 162);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(113, 29);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // EditLoanForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 203);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtLoanDate);
            Controls.Add(txtBook);
            Controls.Add(txtReader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "EditLoanForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Редактирование выдачи";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label txtReader;
        private Label txtBook;
        private Label txtLoanDate;
        private Button btnSave;
        private Button btnCancel;
    }
}