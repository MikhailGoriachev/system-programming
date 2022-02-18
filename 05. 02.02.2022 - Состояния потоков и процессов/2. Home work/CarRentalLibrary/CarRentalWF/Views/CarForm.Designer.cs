namespace CarRentalWF.Views
{
    partial class CarForm
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
            this.LblHeader = new System.Windows.Forms.Label();
            this.LblBrand = new System.Windows.Forms.Label();
            this.LblColor = new System.Windows.Forms.Label();
            this.LblPlate = new System.Windows.Forms.Label();
            this.LblYear = new System.Windows.Forms.Label();
            this.LblPay = new System.Windows.Forms.Label();
            this.CmbBrand = new System.Windows.Forms.ComboBox();
            this.CmbColor = new System.Windows.Forms.ComboBox();
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtbCancel = new System.Windows.Forms.Button();
            this.NudRental = new System.Windows.Forms.NumericUpDown();
            this.LblRental = new System.Windows.Forms.Label();
            this.TbxPlate = new System.Windows.Forms.TextBox();
            this.NudYear = new System.Windows.Forms.NumericUpDown();
            this.NudPay = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NudRental)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudPay)).BeginInit();
            this.SuspendLayout();
            // 
            // LblHeader
            // 
            this.LblHeader.BackColor = System.Drawing.Color.Silver;
            this.LblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblHeader.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblHeader.Location = new System.Drawing.Point(0, 0);
            this.LblHeader.Name = "LblHeader";
            this.LblHeader.Size = new System.Drawing.Size(657, 40);
            this.LblHeader.TabIndex = 0;
            this.LblHeader.Text = "Добавление автомобиля";
            this.LblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblBrand
            // 
            this.LblBrand.BackColor = System.Drawing.Color.Silver;
            this.LblBrand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblBrand.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblBrand.Location = new System.Drawing.Point(24, 64);
            this.LblBrand.Name = "LblBrand";
            this.LblBrand.Size = new System.Drawing.Size(272, 32);
            this.LblBrand.TabIndex = 1;
            this.LblBrand.Text = "Модель";
            this.LblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblColor
            // 
            this.LblColor.BackColor = System.Drawing.Color.Silver;
            this.LblColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblColor.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblColor.Location = new System.Drawing.Point(24, 152);
            this.LblColor.Name = "LblColor";
            this.LblColor.Size = new System.Drawing.Size(272, 32);
            this.LblColor.TabIndex = 2;
            this.LblColor.Text = "Цвет";
            this.LblColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblPlate
            // 
            this.LblPlate.BackColor = System.Drawing.Color.Silver;
            this.LblPlate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblPlate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblPlate.Location = new System.Drawing.Point(24, 240);
            this.LblPlate.Name = "LblPlate";
            this.LblPlate.Size = new System.Drawing.Size(272, 32);
            this.LblPlate.TabIndex = 3;
            this.LblPlate.Text = "Госномер";
            this.LblPlate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblYear
            // 
            this.LblYear.BackColor = System.Drawing.Color.Silver;
            this.LblYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblYear.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblYear.Location = new System.Drawing.Point(360, 64);
            this.LblYear.Name = "LblYear";
            this.LblYear.Size = new System.Drawing.Size(272, 32);
            this.LblYear.TabIndex = 4;
            this.LblYear.Text = "Год выпуска";
            this.LblYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblPay
            // 
            this.LblPay.BackColor = System.Drawing.Color.Silver;
            this.LblPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblPay.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblPay.Location = new System.Drawing.Point(360, 152);
            this.LblPay.Name = "LblPay";
            this.LblPay.Size = new System.Drawing.Size(272, 32);
            this.LblPay.TabIndex = 5;
            this.LblPay.Text = "Страховая стоимость";
            this.LblPay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CmbBrand
            // 
            this.CmbBrand.BackColor = System.Drawing.Color.LightGray;
            this.CmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBrand.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CmbBrand.FormattingEnabled = true;
            this.CmbBrand.Location = new System.Drawing.Point(24, 96);
            this.CmbBrand.Name = "CmbBrand";
            this.CmbBrand.Size = new System.Drawing.Size(272, 26);
            this.CmbBrand.TabIndex = 0;
            // 
            // CmbColor
            // 
            this.CmbColor.BackColor = System.Drawing.Color.LightGray;
            this.CmbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbColor.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CmbColor.FormattingEnabled = true;
            this.CmbColor.Location = new System.Drawing.Point(24, 184);
            this.CmbColor.Name = "CmbColor";
            this.CmbColor.Size = new System.Drawing.Size(272, 26);
            this.CmbColor.TabIndex = 1;
            // 
            // BtnOk
            // 
            this.BtnOk.BackColor = System.Drawing.Color.YellowGreen;
            this.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOk.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnOk.Location = new System.Drawing.Point(360, 320);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(128, 40);
            this.BtnOk.TabIndex = 5;
            this.BtnOk.Text = "Добавить";
            this.BtnOk.UseVisualStyleBackColor = false;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtbCancel
            // 
            this.BtbCancel.BackColor = System.Drawing.Color.IndianRed;
            this.BtbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtbCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtbCancel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtbCancel.Location = new System.Drawing.Point(504, 320);
            this.BtbCancel.Name = "BtbCancel";
            this.BtbCancel.Size = new System.Drawing.Size(128, 40);
            this.BtbCancel.TabIndex = 6;
            this.BtbCancel.Text = "Отмена";
            this.BtbCancel.UseVisualStyleBackColor = false;
            // 
            // NudRental
            // 
            this.NudRental.BackColor = System.Drawing.Color.LightGray;
            this.NudRental.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NudRental.Location = new System.Drawing.Point(360, 272);
            this.NudRental.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NudRental.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudRental.Name = "NudRental";
            this.NudRental.Size = new System.Drawing.Size(272, 27);
            this.NudRental.TabIndex = 7;
            this.NudRental.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudRental.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LblRental
            // 
            this.LblRental.BackColor = System.Drawing.Color.Silver;
            this.LblRental.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblRental.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblRental.Location = new System.Drawing.Point(360, 240);
            this.LblRental.Name = "LblRental";
            this.LblRental.Size = new System.Drawing.Size(272, 32);
            this.LblRental.TabIndex = 8;
            this.LblRental.Text = "Стоимость / день";
            this.LblRental.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TbxPlate
            // 
            this.TbxPlate.BackColor = System.Drawing.Color.LightGray;
            this.TbxPlate.Font = new System.Drawing.Font("Verdana", 12F);
            this.TbxPlate.Location = new System.Drawing.Point(24, 272);
            this.TbxPlate.Name = "TbxPlate";
            this.TbxPlate.Size = new System.Drawing.Size(272, 27);
            this.TbxPlate.TabIndex = 9;
            // 
            // NudYear
            // 
            this.NudYear.BackColor = System.Drawing.Color.LightGray;
            this.NudYear.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NudYear.Location = new System.Drawing.Point(360, 96);
            this.NudYear.Maximum = new decimal(new int[] {
            2022,
            0,
            0,
            0});
            this.NudYear.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.NudYear.Name = "NudYear";
            this.NudYear.Size = new System.Drawing.Size(272, 27);
            this.NudYear.TabIndex = 10;
            this.NudYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudYear.Value = new decimal(new int[] {
            2015,
            0,
            0,
            0});
            // 
            // NudPay
            // 
            this.NudPay.BackColor = System.Drawing.Color.LightGray;
            this.NudPay.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NudPay.Location = new System.Drawing.Point(360, 184);
            this.NudPay.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NudPay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudPay.Name = "NudPay";
            this.NudPay.Size = new System.Drawing.Size(272, 27);
            this.NudPay.TabIndex = 11;
            this.NudPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudPay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(657, 372);
            this.Controls.Add(this.NudPay);
            this.Controls.Add(this.NudYear);
            this.Controls.Add(this.TbxPlate);
            this.Controls.Add(this.NudRental);
            this.Controls.Add(this.LblRental);
            this.Controls.Add(this.BtbCancel);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.CmbColor);
            this.Controls.Add(this.CmbBrand);
            this.Controls.Add(this.LblPay);
            this.Controls.Add(this.LblYear);
            this.Controls.Add(this.LblPlate);
            this.Controls.Add(this.LblColor);
            this.Controls.Add(this.LblBrand);
            this.Controls.Add(this.LblHeader);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление автомобиля";
            ((System.ComponentModel.ISupportInitialize)(this.NudRental)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudPay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblHeader;
        private System.Windows.Forms.Label LblBrand;
        private System.Windows.Forms.Label LblColor;
        private System.Windows.Forms.Label LblPlate;
        private System.Windows.Forms.Label LblYear;
        private System.Windows.Forms.Label LblPay;
        private System.Windows.Forms.ComboBox CmbBrand;
        private System.Windows.Forms.ComboBox CmbColor;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtbCancel;
        private System.Windows.Forms.NumericUpDown NudRental;
        private System.Windows.Forms.Label LblRental;
        private System.Windows.Forms.TextBox TbxPlate;
        private System.Windows.Forms.NumericUpDown NudYear;
        private System.Windows.Forms.NumericUpDown NudPay;
    }
}