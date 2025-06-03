namespace maxim_1
{
    partial class EditVisitorForm
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
            Size = new Size(350, 250);
            Text = "Редактирование посетителя";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;

            // Элементы формы
            txtName = new TextBox { Location = new Point(120, 30), Width = 180 };
            txtPhone = new TextBox { Location = new Point(120, 70), Width = 180 };
            numPoints = new NumericUpDown
            {
                Location = new Point(120, 110),
                Width = 100,
                Minimum = 0,
                Maximum = 10000
            };

            btnSave = new Button
            {
                Text = "Сохранить",
                Location = new Point(50, 160),
                Size = new Size(100, 30),
                DialogResult = DialogResult.OK
            };
            btnSave.Click += BtnSave_Click;

            btnCancel = new Button
            {
                Text = "Отмена",
                Location = new Point(180, 160),
                Size = new Size(100, 30),
                DialogResult = DialogResult.Cancel
            };

            // Метки
            var lblName = new Label { Text = "Имя:", Location = new Point(30, 33), AutoSize = true };
            var lblPhone = new Label { Text = "Телефон:", Location = new Point(30, 73), AutoSize = true };
            var lblPoints = new Label { Text = "Баллы:", Location = new Point(30, 113), AutoSize = true };

            Controls.AddRange(new Control[] {
                lblName, txtName,
                lblPhone, txtPhone,
                lblPoints, numPoints,
                btnSave, btnCancel
            });
        }

        #endregion

        private TextBox txtName;
        private TextBox txtPhone;
        private NumericUpDown numPoints;
        private Button btnSave;
        private Button btnCancel;
    }
}