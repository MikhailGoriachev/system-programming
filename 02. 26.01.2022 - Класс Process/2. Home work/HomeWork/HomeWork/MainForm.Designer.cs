namespace HomeWork
{
    partial class MainForm
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
            this.PrcMain = new System.Diagnostics.Process();
            this.MnsMain = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.управлениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.GbxHistoryProc = new System.Windows.Forms.GroupBox();
            this.LviHistory = new System.Windows.Forms.ListView();
            this.ClmProcName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClmFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClmDateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StsMain = new System.Windows.Forms.StatusStrip();
            this.LblAmountElem = new System.Windows.Forms.ToolStripStatusLabel();
            this.OfdMain = new System.Windows.Forms.OpenFileDialog();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnStartProcess = new System.Windows.Forms.ToolStripButton();
            this.TsiClear = new System.Windows.Forms.ToolStripButton();
            this.запускПроцессаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьСписокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MnsMain.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.GbxHistoryProc.SuspendLayout();
            this.StsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // PrcMain
            // 
            this.PrcMain.StartInfo.Domain = "";
            this.PrcMain.StartInfo.LoadUserProfile = false;
            this.PrcMain.StartInfo.Password = null;
            this.PrcMain.StartInfo.StandardErrorEncoding = null;
            this.PrcMain.StartInfo.StandardOutputEncoding = null;
            this.PrcMain.StartInfo.UserName = "";
            this.PrcMain.SynchronizingObject = this;
            // 
            // MnsMain
            // 
            this.MnsMain.BackColor = System.Drawing.Color.Aquamarine;
            this.MnsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.MnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.управлениеToolStripMenuItem});
            this.MnsMain.Location = new System.Drawing.Point(0, 0);
            this.MnsMain.Name = "MnsMain";
            this.MnsMain.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.MnsMain.Size = new System.Drawing.Size(949, 24);
            this.MnsMain.TabIndex = 0;
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnExit});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // BtnExit
            // 
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.BtnExit.Size = new System.Drawing.Size(151, 22);
            this.BtnExit.Text = "Выход";
            this.BtnExit.Click += new System.EventHandler(this.Exit_Command);
            // 
            // управлениеToolStripMenuItem
            // 
            this.управлениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.запускПроцессаToolStripMenuItem,
            this.toolStripMenuItem1,
            this.очиститьСписокToolStripMenuItem});
            this.управлениеToolStripMenuItem.Name = "управлениеToolStripMenuItem";
            this.управлениеToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.управлениеToolStripMenuItem.Text = "Управление";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnStartProcess,
            this.toolStripSeparator1,
            this.TsiClear});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(949, 39);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // GbxHistoryProc
            // 
            this.GbxHistoryProc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GbxHistoryProc.Controls.Add(this.LviHistory);
            this.GbxHistoryProc.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GbxHistoryProc.ForeColor = System.Drawing.Color.White;
            this.GbxHistoryProc.Location = new System.Drawing.Point(16, 72);
            this.GbxHistoryProc.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GbxHistoryProc.Name = "GbxHistoryProc";
            this.GbxHistoryProc.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GbxHistoryProc.Size = new System.Drawing.Size(920, 428);
            this.GbxHistoryProc.TabIndex = 2;
            this.GbxHistoryProc.TabStop = false;
            this.GbxHistoryProc.Text = " История процессов ";
            // 
            // LviHistory
            // 
            this.LviHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LviHistory.BackColor = System.Drawing.Color.Silver;
            this.LviHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClmProcName,
            this.ClmFileName,
            this.ClmDateTime});
            this.LviHistory.HideSelection = false;
            this.LviHistory.Location = new System.Drawing.Point(8, 24);
            this.LviHistory.Name = "LviHistory";
            this.LviHistory.Size = new System.Drawing.Size(904, 396);
            this.LviHistory.TabIndex = 0;
            this.LviHistory.UseCompatibleStateImageBehavior = false;
            this.LviHistory.View = System.Windows.Forms.View.Details;
            // 
            // ClmProcName
            // 
            this.ClmProcName.Text = "Название процесса";
            this.ClmProcName.Width = 233;
            // 
            // ClmFileName
            // 
            this.ClmFileName.Text = "Название файла";
            this.ClmFileName.Width = 384;
            // 
            // ClmDateTime
            // 
            this.ClmDateTime.Text = "Дата и время запуска";
            this.ClmDateTime.Width = 273;
            // 
            // StsMain
            // 
            this.StsMain.BackColor = System.Drawing.Color.Aquamarine;
            this.StsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LblAmountElem});
            this.StsMain.Location = new System.Drawing.Point(0, 504);
            this.StsMain.Name = "StsMain";
            this.StsMain.Size = new System.Drawing.Size(949, 22);
            this.StsMain.TabIndex = 3;
            this.StsMain.Text = "statusStrip1";
            // 
            // LblAmountElem
            // 
            this.LblAmountElem.Name = "LblAmountElem";
            this.LblAmountElem.Size = new System.Drawing.Size(194, 17);
            this.LblAmountElem.Text = "Количество процессов:  значение";
            // 
            // OfdMain
            // 
            this.OfdMain.Filter = "Файлы EXE (*.exe)|*.exe|Все файлы (*.*)|*.*";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // BtnStartProcess
            // 
            this.BtnStartProcess.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnStartProcess.Image = global::HomeWork.Properties.Resources.application_go;
            this.BtnStartProcess.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnStartProcess.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.BtnStartProcess.Name = "BtnStartProcess";
            this.BtnStartProcess.Size = new System.Drawing.Size(36, 36);
            this.BtnStartProcess.Text = "Запуск приложения...";
            this.BtnStartProcess.Click += new System.EventHandler(this.StartProcess_Command);
            // 
            // TsiClear
            // 
            this.TsiClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsiClear.Image = global::HomeWork.Properties.Resources.table_delete;
            this.TsiClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsiClear.Name = "TsiClear";
            this.TsiClear.Size = new System.Drawing.Size(36, 36);
            this.TsiClear.Text = "Очистить список";
            this.TsiClear.Click += new System.EventHandler(this.Clear_Command);
            // 
            // запускПроцессаToolStripMenuItem
            // 
            this.запускПроцессаToolStripMenuItem.Image = global::HomeWork.Properties.Resources.application_go;
            this.запускПроцессаToolStripMenuItem.Name = "запускПроцессаToolStripMenuItem";
            this.запускПроцессаToolStripMenuItem.Size = new System.Drawing.Size(196, 38);
            this.запускПроцессаToolStripMenuItem.Text = "Запуск процесса...";
            this.запускПроцессаToolStripMenuItem.Click += new System.EventHandler(this.StartProcess_Command);
            // 
            // очиститьСписокToolStripMenuItem
            // 
            this.очиститьСписокToolStripMenuItem.Image = global::HomeWork.Properties.Resources.table_delete;
            this.очиститьСписокToolStripMenuItem.Name = "очиститьСписокToolStripMenuItem";
            this.очиститьСписокToolStripMenuItem.Size = new System.Drawing.Size(196, 38);
            this.очиститьСписокToolStripMenuItem.Text = "Очистить список";
            this.очиститьСписокToolStripMenuItem.Click += new System.EventHandler(this.Clear_Command);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(193, 6);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(949, 526);
            this.Controls.Add(this.StsMain);
            this.Controls.Add(this.GbxHistoryProc);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.MnsMain);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.MnsMain;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Домашнее задание на 31.01.2022";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MnsMain.ResumeLayout(false);
            this.MnsMain.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.GbxHistoryProc.ResumeLayout(false);
            this.StsMain.ResumeLayout(false);
            this.StsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Diagnostics.Process PrcMain;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.MenuStrip MnsMain;
        private System.Windows.Forms.GroupBox GbxHistoryProc;
        private System.Windows.Forms.ListView LviHistory;
        private System.Windows.Forms.ColumnHeader ClmProcName;
        private System.Windows.Forms.ColumnHeader ClmFileName;
        private System.Windows.Forms.ColumnHeader ClmDateTime;
        private System.Windows.Forms.StatusStrip StsMain;
        private System.Windows.Forms.ToolStripStatusLabel LblAmountElem;
        private System.Windows.Forms.ToolStripButton BtnStartProcess;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem управлениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запускПроцессаToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog OfdMain;
        private System.Windows.Forms.ToolStripMenuItem BtnExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton TsiClear;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem очиститьСписокToolStripMenuItem;
    }
}

