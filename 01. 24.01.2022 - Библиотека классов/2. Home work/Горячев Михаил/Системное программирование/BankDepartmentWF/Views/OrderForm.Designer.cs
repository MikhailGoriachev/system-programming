namespace BankDepartmentWF.Views
{
    partial class OrderForm
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
            this.TbxSenderAccount = new System.Windows.Forms.TextBox();
            this.LblHeader = new System.Windows.Forms.Label();
            this.LblSenderAccount = new System.Windows.Forms.Label();
            this.LblReceiverAccount = new System.Windows.Forms.Label();
            this.TbxReceiverAccount = new System.Windows.Forms.TextBox();
            this.LblSenderAmount = new System.Windows.Forms.Label();
            this.LblReceiverAmount = new System.Windows.Forms.Label();
            this.NudSenderAmount = new System.Windows.Forms.NumericUpDown();
            this.NudReceiverAmount = new System.Windows.Forms.NumericUpDown();
            this.NudAmountPayment = new System.Windows.Forms.NumericUpDown();
            this.LblAmountPayment = new System.Windows.Forms.Label();
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NudSenderAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudReceiverAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudAmountPayment)).BeginInit();
            this.SuspendLayout();
            // 
            // TbxSenderAccount
            // 
            this.TbxSenderAccount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TbxSenderAccount.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TbxSenderAccount.Location = new System.Drawing.Point(32, 120);
            this.TbxSenderAccount.Name = "TbxSenderAccount";
            this.TbxSenderAccount.Size = new System.Drawing.Size(248, 26);
            this.TbxSenderAccount.TabIndex = 3;
            this.TbxSenderAccount.TabStop = false;
            this.TbxSenderAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TbxSenderAccount.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // LblHeader
            // 
            this.LblHeader.BackColor = System.Drawing.Color.Silver;
            this.LblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblHeader.ForeColor = System.Drawing.Color.Black;
            this.LblHeader.Location = new System.Drawing.Point(32, 16);
            this.LblHeader.Name = "LblHeader";
            this.LblHeader.Size = new System.Drawing.Size(520, 40);
            this.LblHeader.TabIndex = 2;
            this.LblHeader.Text = "Добавление платежа";
            this.LblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblSenderAccount
            // 
            this.LblSenderAccount.BackColor = System.Drawing.Color.Silver;
            this.LblSenderAccount.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblSenderAccount.ForeColor = System.Drawing.Color.Black;
            this.LblSenderAccount.Location = new System.Drawing.Point(32, 88);
            this.LblSenderAccount.Name = "LblSenderAccount";
            this.LblSenderAccount.Size = new System.Drawing.Size(248, 32);
            this.LblSenderAccount.TabIndex = 4;
            this.LblSenderAccount.Text = "Номер счёта плательщика";
            this.LblSenderAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblReceiverAccount
            // 
            this.LblReceiverAccount.BackColor = System.Drawing.Color.Silver;
            this.LblReceiverAccount.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblReceiverAccount.ForeColor = System.Drawing.Color.Black;
            this.LblReceiverAccount.Location = new System.Drawing.Point(304, 88);
            this.LblReceiverAccount.Name = "LblReceiverAccount";
            this.LblReceiverAccount.Size = new System.Drawing.Size(248, 32);
            this.LblReceiverAccount.TabIndex = 6;
            this.LblReceiverAccount.Text = "Номер счёта получателя";
            this.LblReceiverAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TbxReceiverAccount
            // 
            this.TbxReceiverAccount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TbxReceiverAccount.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TbxReceiverAccount.Location = new System.Drawing.Point(304, 120);
            this.TbxReceiverAccount.Name = "TbxReceiverAccount";
            this.TbxReceiverAccount.Size = new System.Drawing.Size(248, 26);
            this.TbxReceiverAccount.TabIndex = 5;
            this.TbxReceiverAccount.TabStop = false;
            this.TbxReceiverAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TbxReceiverAccount.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // LblSenderAmount
            // 
            this.LblSenderAmount.BackColor = System.Drawing.Color.Silver;
            this.LblSenderAmount.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblSenderAmount.ForeColor = System.Drawing.Color.Black;
            this.LblSenderAmount.Location = new System.Drawing.Point(32, 168);
            this.LblSenderAmount.Name = "LblSenderAmount";
            this.LblSenderAmount.Size = new System.Drawing.Size(248, 32);
            this.LblSenderAmount.TabIndex = 8;
            this.LblSenderAmount.Text = "Сумма на счёту плательщика";
            this.LblSenderAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblReceiverAmount
            // 
            this.LblReceiverAmount.BackColor = System.Drawing.Color.Silver;
            this.LblReceiverAmount.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblReceiverAmount.ForeColor = System.Drawing.Color.Black;
            this.LblReceiverAmount.Location = new System.Drawing.Point(304, 168);
            this.LblReceiverAmount.Name = "LblReceiverAmount";
            this.LblReceiverAmount.Size = new System.Drawing.Size(248, 32);
            this.LblReceiverAmount.TabIndex = 10;
            this.LblReceiverAmount.Text = "Сумма на счёту получателя";
            this.LblReceiverAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NudSenderAmount
            // 
            this.NudSenderAmount.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NudSenderAmount.Location = new System.Drawing.Point(32, 200);
            this.NudSenderAmount.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.NudSenderAmount.Name = "NudSenderAmount";
            this.NudSenderAmount.Size = new System.Drawing.Size(248, 26);
            this.NudSenderAmount.TabIndex = 11;
            this.NudSenderAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NudReceiverAmount
            // 
            this.NudReceiverAmount.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NudReceiverAmount.Location = new System.Drawing.Point(304, 200);
            this.NudReceiverAmount.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.NudReceiverAmount.Name = "NudReceiverAmount";
            this.NudReceiverAmount.Size = new System.Drawing.Size(248, 26);
            this.NudReceiverAmount.TabIndex = 12;
            this.NudReceiverAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NudAmountPayment
            // 
            this.NudAmountPayment.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NudAmountPayment.Location = new System.Drawing.Point(32, 280);
            this.NudAmountPayment.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.NudAmountPayment.Name = "NudAmountPayment";
            this.NudAmountPayment.Size = new System.Drawing.Size(248, 26);
            this.NudAmountPayment.TabIndex = 14;
            this.NudAmountPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LblAmountPayment
            // 
            this.LblAmountPayment.BackColor = System.Drawing.Color.Silver;
            this.LblAmountPayment.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblAmountPayment.ForeColor = System.Drawing.Color.Black;
            this.LblAmountPayment.Location = new System.Drawing.Point(32, 248);
            this.LblAmountPayment.Name = "LblAmountPayment";
            this.LblAmountPayment.Size = new System.Drawing.Size(248, 32);
            this.LblAmountPayment.TabIndex = 13;
            this.LblAmountPayment.Text = "Сумма на платежа";
            this.LblAmountPayment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnOk
            // 
            this.BtnOk.BackColor = System.Drawing.Color.YellowGreen;
            this.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnOk.Location = new System.Drawing.Point(304, 264);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(120, 39);
            this.BtnOk.TabIndex = 15;
            this.BtnOk.Text = "Добавить";
            this.BtnOk.UseVisualStyleBackColor = false;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.IndianRed;
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnCancel.Location = new System.Drawing.Point(432, 264);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(120, 39);
            this.BtnCancel.TabIndex = 16;
            this.BtnCancel.Text = "Отмена";
            this.BtnCancel.UseVisualStyleBackColor = false;
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(585, 331);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.NudAmountPayment);
            this.Controls.Add(this.LblAmountPayment);
            this.Controls.Add(this.NudReceiverAmount);
            this.Controls.Add(this.NudSenderAmount);
            this.Controls.Add(this.LblReceiverAmount);
            this.Controls.Add(this.LblSenderAmount);
            this.Controls.Add(this.LblReceiverAccount);
            this.Controls.Add(this.TbxReceiverAccount);
            this.Controls.Add(this.LblSenderAccount);
            this.Controls.Add(this.TbxSenderAccount);
            this.Controls.Add(this.LblHeader);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить платеж";
            ((System.ComponentModel.ISupportInitialize)(this.NudSenderAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudReceiverAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudAmountPayment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbxSenderAccount;
        private System.Windows.Forms.Label LblHeader;
        private System.Windows.Forms.Label LblSenderAccount;
        private System.Windows.Forms.Label LblReceiverAccount;
        private System.Windows.Forms.TextBox TbxReceiverAccount;
        private System.Windows.Forms.Label LblSenderAmount;
        private System.Windows.Forms.Label LblReceiverAmount;
        private System.Windows.Forms.NumericUpDown NudSenderAmount;
        private System.Windows.Forms.NumericUpDown NudReceiverAmount;
        private System.Windows.Forms.NumericUpDown NudAmountPayment;
        private System.Windows.Forms.Label LblAmountPayment;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnCancel;
    }
}