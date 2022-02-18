namespace CarRentalWF.Views
{
    partial class RentalForm
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
            this.CmbBrand = new System.Windows.Forms.ComboBox();
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtbCancel = new System.Windows.Forms.Button();
            this.NudDuration = new System.Windows.Forms.NumericUpDown();
            this.LblDuration = new System.Windows.Forms.Label();
            this.CmbClient = new System.Windows.Forms.ComboBox();
            this.LblClient = new System.Windows.Forms.Label();
            this.TbxDate = new System.Windows.Forms.MaskedTextBox();
            this.LblDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NudDuration)).BeginInit();
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
            // BtnOk
            // 
            this.BtnOk.BackColor = System.Drawing.Color.YellowGreen;
            this.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOk.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnOk.Location = new System.Drawing.Point(336, 240);
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
            this.BtbCancel.Location = new System.Drawing.Point(480, 240);
            this.BtbCancel.Name = "BtbCancel";
            this.BtbCancel.Size = new System.Drawing.Size(128, 40);
            this.BtbCancel.TabIndex = 6;
            this.BtbCancel.Text = "Отмена";
            this.BtbCancel.UseVisualStyleBackColor = false;
            // 
            // NudDuration
            // 
            this.NudDuration.BackColor = System.Drawing.Color.LightGray;
            this.NudDuration.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NudDuration.Location = new System.Drawing.Point(336, 96);
            this.NudDuration.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.NudDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudDuration.Name = "NudDuration";
            this.NudDuration.Size = new System.Drawing.Size(272, 27);
            this.NudDuration.TabIndex = 7;
            this.NudDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudDuration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LblDuration
            // 
            this.LblDuration.BackColor = System.Drawing.Color.Silver;
            this.LblDuration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblDuration.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblDuration.Location = new System.Drawing.Point(336, 64);
            this.LblDuration.Name = "LblDuration";
            this.LblDuration.Size = new System.Drawing.Size(272, 32);
            this.LblDuration.TabIndex = 8;
            this.LblDuration.Text = "Длительность";
            this.LblDuration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CmbClient
            // 
            this.CmbClient.BackColor = System.Drawing.Color.LightGray;
            this.CmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbClient.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CmbClient.FormattingEnabled = true;
            this.CmbClient.Location = new System.Drawing.Point(24, 184);
            this.CmbClient.Name = "CmbClient";
            this.CmbClient.Size = new System.Drawing.Size(272, 26);
            this.CmbClient.TabIndex = 12;
            // 
            // LblClient
            // 
            this.LblClient.BackColor = System.Drawing.Color.Silver;
            this.LblClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblClient.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblClient.Location = new System.Drawing.Point(24, 152);
            this.LblClient.Name = "LblClient";
            this.LblClient.Size = new System.Drawing.Size(272, 32);
            this.LblClient.TabIndex = 13;
            this.LblClient.Text = "Клиент";
            this.LblClient.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TbxDate
            // 
            this.TbxDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TbxDate.Location = new System.Drawing.Point(336, 184);
            this.TbxDate.Mask = "00/00/0000";
            this.TbxDate.Name = "TbxDate";
            this.TbxDate.Size = new System.Drawing.Size(272, 27);
            this.TbxDate.TabIndex = 14;
            this.TbxDate.ValidatingType = typeof(System.DateTime);
            // 
            // LblDate
            // 
            this.LblDate.BackColor = System.Drawing.Color.Silver;
            this.LblDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblDate.Location = new System.Drawing.Point(336, 152);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(272, 32);
            this.LblDate.TabIndex = 15;
            this.LblDate.Text = "Дата";
            this.LblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RentalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(657, 300);
            this.Controls.Add(this.TbxDate);
            this.Controls.Add(this.LblDate);
            this.Controls.Add(this.CmbClient);
            this.Controls.Add(this.LblClient);
            this.Controls.Add(this.NudDuration);
            this.Controls.Add(this.LblDuration);
            this.Controls.Add(this.BtbCancel);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.CmbBrand);
            this.Controls.Add(this.LblBrand);
            this.Controls.Add(this.LblHeader);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RentalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление автомобиля";
            ((System.ComponentModel.ISupportInitialize)(this.NudDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblHeader;
        private System.Windows.Forms.Label LblBrand;
        private System.Windows.Forms.ComboBox CmbBrand;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtbCancel;
        private System.Windows.Forms.NumericUpDown NudDuration;
        private System.Windows.Forms.Label LblDuration;
        private System.Windows.Forms.ComboBox CmbClient;
        private System.Windows.Forms.Label LblClient;
        private System.Windows.Forms.MaskedTextBox TbxDate;
        private System.Windows.Forms.Label LblDate;
    }
}