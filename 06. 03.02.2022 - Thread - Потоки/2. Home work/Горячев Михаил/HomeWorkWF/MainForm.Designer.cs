namespace HomeWorkWF
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MnsMain = new System.Windows.Forms.MenuStrip();
            this.MniFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MniExit = new System.Windows.Forms.ToolStripMenuItem();
            this.StsMain = new System.Windows.Forms.StatusStrip();
            this.TstMain = new System.Windows.Forms.ToolStrip();
            this.TbcMain = new System.Windows.Forms.TabControl();
            this.TbpPoint1 = new System.Windows.Forms.TabPage();
            this.BtnNumbersInit = new System.Windows.Forms.Button();
            this.BtnSuffleNumbers = new System.Windows.Forms.Button();
            this.BtnSortNumbers = new System.Windows.Forms.Button();
            this.LviNumbers = new System.Windows.Forms.ListView();
            this.CmnValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TbpPoint2 = new System.Windows.Forms.TabPage();
            this.BtnNotebooksInit = new System.Windows.Forms.Button();
            this.BtnLoadNotebooks = new System.Windows.Forms.Button();
            this.BtnSaveAsNotebooks = new System.Windows.Forms.Button();
            this.BtnNotebooksShuffle = new System.Windows.Forms.Button();
            this.DgvNotebooks = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.processorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ramDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batteryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diagonalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defectDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ownerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notebookModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TbpPoint3 = new System.Windows.Forms.TabPage();
            this.BtnUpdateTextData = new System.Windows.Forms.Button();
            this.GbxDictionary = new System.Windows.Forms.GroupBox();
            this.DgvDictionary = new System.Windows.Forms.DataGridView();
            this.CmnKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmnVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BnsSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.GrbContent = new System.Windows.Forms.GroupBox();
            this.TbxText = new System.Windows.Forms.TextBox();
            this.OfdNotebooks = new System.Windows.Forms.OpenFileDialog();
            this.SfdMain = new System.Windows.Forms.SaveFileDialog();
            this.OfdTextFile = new System.Windows.Forms.OpenFileDialog();
            this.MniNumbers = new System.Windows.Forms.ToolStripMenuItem();
            this.MniNotebooks = new System.Windows.Forms.ToolStripMenuItem();
            this.MniDictionary = new System.Windows.Forms.ToolStripMenuItem();
            this.MniShuffleNumbers = new System.Windows.Forms.ToolStripMenuItem();
            this.MniSortNumbers = new System.Windows.Forms.ToolStripMenuItem();
            this.MniInitNumbers = new System.Windows.Forms.ToolStripMenuItem();
            this.MniLoadNotebooks = new System.Windows.Forms.ToolStripMenuItem();
            this.MniSaveAsNotebooks = new System.Windows.Forms.ToolStripMenuItem();
            this.MniInitNotebooks = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MniLoadDictionary = new System.Windows.Forms.ToolStripMenuItem();
            this.MniUpdateDictionary = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.MniShuffleNotebooks = new System.Windows.Forms.ToolStripMenuItem();
            this.MnsMain.SuspendLayout();
            this.TbcMain.SuspendLayout();
            this.TbpPoint1.SuspendLayout();
            this.TbpPoint2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvNotebooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notebookModelBindingSource)).BeginInit();
            this.TbpPoint3.SuspendLayout();
            this.GbxDictionary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDictionary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BnsSource)).BeginInit();
            this.GrbContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // MnsMain
            // 
            this.MnsMain.BackColor = System.Drawing.Color.Aquamarine;
            this.MnsMain.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MniFile,
            this.MniNumbers,
            this.MniNotebooks,
            this.MniDictionary});
            this.MnsMain.Location = new System.Drawing.Point(0, 0);
            this.MnsMain.Name = "MnsMain";
            this.MnsMain.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.MnsMain.Size = new System.Drawing.Size(933, 28);
            this.MnsMain.TabIndex = 0;
            // 
            // MniFile
            // 
            this.MniFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MniExit});
            this.MniFile.Name = "MniFile";
            this.MniFile.Size = new System.Drawing.Size(57, 24);
            this.MniFile.Text = "Файл";
            // 
            // MniExit
            // 
            this.MniExit.Name = "MniExit";
            this.MniExit.Size = new System.Drawing.Size(180, 24);
            this.MniExit.Text = "&Выход";
            this.MniExit.Click += new System.EventHandler(this.Exit_Command);
            // 
            // StsMain
            // 
            this.StsMain.BackColor = System.Drawing.Color.MediumAquamarine;
            this.StsMain.Location = new System.Drawing.Point(0, 428);
            this.StsMain.Name = "StsMain";
            this.StsMain.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.StsMain.Size = new System.Drawing.Size(933, 22);
            this.StsMain.TabIndex = 1;
            this.StsMain.Text = "statusStrip1";
            // 
            // TstMain
            // 
            this.TstMain.BackColor = System.Drawing.Color.MediumAquamarine;
            this.TstMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TstMain.Location = new System.Drawing.Point(0, 28);
            this.TstMain.Name = "TstMain";
            this.TstMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.TstMain.Size = new System.Drawing.Size(933, 25);
            this.TstMain.TabIndex = 2;
            this.TstMain.Text = "toolStrip1";
            // 
            // TbcMain
            // 
            this.TbcMain.Controls.Add(this.TbpPoint1);
            this.TbcMain.Controls.Add(this.TbpPoint2);
            this.TbcMain.Controls.Add(this.TbpPoint3);
            this.TbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbcMain.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TbcMain.Location = new System.Drawing.Point(0, 53);
            this.TbcMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TbcMain.Name = "TbcMain";
            this.TbcMain.SelectedIndex = 0;
            this.TbcMain.Size = new System.Drawing.Size(933, 375);
            this.TbcMain.TabIndex = 3;
            this.TbcMain.SelectedIndexChanged += new System.EventHandler(this.TbcMain_SelectedIndexChanged);
            // 
            // TbpPoint1
            // 
            this.TbpPoint1.BackColor = System.Drawing.Color.Gray;
            this.TbpPoint1.Controls.Add(this.BtnNumbersInit);
            this.TbpPoint1.Controls.Add(this.BtnSuffleNumbers);
            this.TbpPoint1.Controls.Add(this.BtnSortNumbers);
            this.TbpPoint1.Controls.Add(this.LviNumbers);
            this.TbpPoint1.Location = new System.Drawing.Point(4, 25);
            this.TbpPoint1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TbpPoint1.Name = "TbpPoint1";
            this.TbpPoint1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TbpPoint1.Size = new System.Drawing.Size(925, 346);
            this.TbpPoint1.TabIndex = 0;
            this.TbpPoint1.Text = "1. Числа";
            // 
            // BtnNumbersInit
            // 
            this.BtnNumbersInit.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BtnNumbersInit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNumbersInit.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnNumbersInit.Location = new System.Drawing.Point(296, 24);
            this.BtnNumbersInit.Name = "BtnNumbersInit";
            this.BtnNumbersInit.Size = new System.Drawing.Size(256, 40);
            this.BtnNumbersInit.TabIndex = 7;
            this.BtnNumbersInit.Text = "Сформировать список";
            this.BtnNumbersInit.UseVisualStyleBackColor = false;
            this.BtnNumbersInit.Click += new System.EventHandler(this.NumbersInit_Command);
            // 
            // BtnSuffleNumbers
            // 
            this.BtnSuffleNumbers.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BtnSuffleNumbers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSuffleNumbers.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnSuffleNumbers.Location = new System.Drawing.Point(296, 120);
            this.BtnSuffleNumbers.Name = "BtnSuffleNumbers";
            this.BtnSuffleNumbers.Size = new System.Drawing.Size(256, 40);
            this.BtnSuffleNumbers.TabIndex = 2;
            this.BtnSuffleNumbers.Text = "Перемешать числа";
            this.BtnSuffleNumbers.UseVisualStyleBackColor = false;
            this.BtnSuffleNumbers.Click += new System.EventHandler(this.ShuffleNumbers_Command);
            // 
            // BtnSortNumbers
            // 
            this.BtnSortNumbers.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BtnSortNumbers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSortNumbers.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnSortNumbers.Location = new System.Drawing.Point(296, 72);
            this.BtnSortNumbers.Name = "BtnSortNumbers";
            this.BtnSortNumbers.Size = new System.Drawing.Size(256, 40);
            this.BtnSortNumbers.TabIndex = 1;
            this.BtnSortNumbers.Text = "Сортировать числа по убыванию";
            this.BtnSortNumbers.UseVisualStyleBackColor = false;
            this.BtnSortNumbers.Click += new System.EventHandler(this.SortNumbers_Command);
            // 
            // LviNumbers
            // 
            this.LviNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LviNumbers.BackColor = System.Drawing.Color.DarkGray;
            this.LviNumbers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LviNumbers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CmnValue});
            this.LviNumbers.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LviNumbers.HideSelection = false;
            this.LviNumbers.Location = new System.Drawing.Point(24, 24);
            this.LviNumbers.Name = "LviNumbers";
            this.LviNumbers.Size = new System.Drawing.Size(240, 284);
            this.LviNumbers.TabIndex = 0;
            this.LviNumbers.UseCompatibleStateImageBehavior = false;
            this.LviNumbers.View = System.Windows.Forms.View.Details;
            // 
            // CmnValue
            // 
            this.CmnValue.Text = "Значение";
            this.CmnValue.Width = 235;
            // 
            // TbpPoint2
            // 
            this.TbpPoint2.BackColor = System.Drawing.Color.Gray;
            this.TbpPoint2.Controls.Add(this.BtnNotebooksInit);
            this.TbpPoint2.Controls.Add(this.BtnLoadNotebooks);
            this.TbpPoint2.Controls.Add(this.BtnSaveAsNotebooks);
            this.TbpPoint2.Controls.Add(this.BtnNotebooksShuffle);
            this.TbpPoint2.Controls.Add(this.DgvNotebooks);
            this.TbpPoint2.Location = new System.Drawing.Point(4, 25);
            this.TbpPoint2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TbpPoint2.Name = "TbpPoint2";
            this.TbpPoint2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TbpPoint2.Size = new System.Drawing.Size(925, 346);
            this.TbpPoint2.TabIndex = 1;
            this.TbpPoint2.Text = "2. Ремонт ноутбуков";
            // 
            // BtnNotebooksInit
            // 
            this.BtnNotebooksInit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnNotebooksInit.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BtnNotebooksInit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNotebooksInit.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnNotebooksInit.Location = new System.Drawing.Point(480, 281);
            this.BtnNotebooksInit.Name = "BtnNotebooksInit";
            this.BtnNotebooksInit.Size = new System.Drawing.Size(200, 40);
            this.BtnNotebooksInit.TabIndex = 6;
            this.BtnNotebooksInit.Text = "Сформировать список";
            this.BtnNotebooksInit.UseVisualStyleBackColor = false;
            this.BtnNotebooksInit.Click += new System.EventHandler(this.InitNotebooks_Command);
            // 
            // BtnLoadNotebooks
            // 
            this.BtnLoadNotebooks.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnLoadNotebooks.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BtnLoadNotebooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLoadNotebooks.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnLoadNotebooks.Location = new System.Drawing.Point(16, 281);
            this.BtnLoadNotebooks.Name = "BtnLoadNotebooks";
            this.BtnLoadNotebooks.Size = new System.Drawing.Size(200, 40);
            this.BtnLoadNotebooks.TabIndex = 5;
            this.BtnLoadNotebooks.Text = "Загрузить из файла...";
            this.BtnLoadNotebooks.UseVisualStyleBackColor = false;
            this.BtnLoadNotebooks.Click += new System.EventHandler(this.LoadNotebooks_Command);
            // 
            // BtnSaveAsNotebooks
            // 
            this.BtnSaveAsNotebooks.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnSaveAsNotebooks.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BtnSaveAsNotebooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveAsNotebooks.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnSaveAsNotebooks.Location = new System.Drawing.Point(248, 281);
            this.BtnSaveAsNotebooks.Name = "BtnSaveAsNotebooks";
            this.BtnSaveAsNotebooks.Size = new System.Drawing.Size(200, 40);
            this.BtnSaveAsNotebooks.TabIndex = 4;
            this.BtnSaveAsNotebooks.Text = "Сохранить в файл...";
            this.BtnSaveAsNotebooks.UseVisualStyleBackColor = false;
            this.BtnSaveAsNotebooks.Click += new System.EventHandler(this.SaveAsNotebooks_Command);
            // 
            // BtnNotebooksShuffle
            // 
            this.BtnNotebooksShuffle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnNotebooksShuffle.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BtnNotebooksShuffle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNotebooksShuffle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnNotebooksShuffle.Location = new System.Drawing.Point(712, 281);
            this.BtnNotebooksShuffle.Name = "BtnNotebooksShuffle";
            this.BtnNotebooksShuffle.Size = new System.Drawing.Size(200, 40);
            this.BtnNotebooksShuffle.TabIndex = 3;
            this.BtnNotebooksShuffle.Text = "Перемешать список";
            this.BtnNotebooksShuffle.UseVisualStyleBackColor = false;
            this.BtnNotebooksShuffle.Click += new System.EventHandler(this.ShuffleNotebooks_Command);
            // 
            // DgvNotebooks
            // 
            this.DgvNotebooks.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Silver;
            this.DgvNotebooks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DgvNotebooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvNotebooks.AutoGenerateColumns = false;
            this.DgvNotebooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvNotebooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvNotebooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.modelDataGridViewTextBoxColumn,
            this.processorDataGridViewTextBoxColumn,
            this.ramDataGridViewTextBoxColumn,
            this.batteryDataGridViewTextBoxColumn,
            this.diagonalDataGridViewTextBoxColumn,
            this.defectDataGridViewTextBoxColumn,
            this.ownerDataGridViewTextBoxColumn});
            this.DgvNotebooks.DataSource = this.notebookModelBindingSource;
            this.DgvNotebooks.Location = new System.Drawing.Point(16, 16);
            this.DgvNotebooks.MultiSelect = false;
            this.DgvNotebooks.Name = "DgvNotebooks";
            this.DgvNotebooks.ReadOnly = true;
            this.DgvNotebooks.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.DgvNotebooks.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DgvNotebooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvNotebooks.Size = new System.Drawing.Size(896, 249);
            this.DgvNotebooks.TabIndex = 1;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Имя устройства";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // modelDataGridViewTextBoxColumn
            // 
            this.modelDataGridViewTextBoxColumn.DataPropertyName = "Model";
            this.modelDataGridViewTextBoxColumn.HeaderText = "Модель";
            this.modelDataGridViewTextBoxColumn.Name = "modelDataGridViewTextBoxColumn";
            this.modelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // processorDataGridViewTextBoxColumn
            // 
            this.processorDataGridViewTextBoxColumn.DataPropertyName = "Processor";
            this.processorDataGridViewTextBoxColumn.HeaderText = "Процессор";
            this.processorDataGridViewTextBoxColumn.Name = "processorDataGridViewTextBoxColumn";
            this.processorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ramDataGridViewTextBoxColumn
            // 
            this.ramDataGridViewTextBoxColumn.DataPropertyName = "Ram";
            this.ramDataGridViewTextBoxColumn.HeaderText = "ОЗУ";
            this.ramDataGridViewTextBoxColumn.Name = "ramDataGridViewTextBoxColumn";
            this.ramDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // batteryDataGridViewTextBoxColumn
            // 
            this.batteryDataGridViewTextBoxColumn.DataPropertyName = "Battery";
            this.batteryDataGridViewTextBoxColumn.HeaderText = "Объём батареи";
            this.batteryDataGridViewTextBoxColumn.Name = "batteryDataGridViewTextBoxColumn";
            this.batteryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // diagonalDataGridViewTextBoxColumn
            // 
            this.diagonalDataGridViewTextBoxColumn.DataPropertyName = "Diagonal";
            this.diagonalDataGridViewTextBoxColumn.HeaderText = "Диагональ экрана";
            this.diagonalDataGridViewTextBoxColumn.Name = "diagonalDataGridViewTextBoxColumn";
            this.diagonalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // defectDataGridViewTextBoxColumn
            // 
            this.defectDataGridViewTextBoxColumn.DataPropertyName = "Defect";
            this.defectDataGridViewTextBoxColumn.HeaderText = "Описание неисправности";
            this.defectDataGridViewTextBoxColumn.Name = "defectDataGridViewTextBoxColumn";
            this.defectDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ownerDataGridViewTextBoxColumn
            // 
            this.ownerDataGridViewTextBoxColumn.DataPropertyName = "Owner";
            this.ownerDataGridViewTextBoxColumn.HeaderText = "Владелец";
            this.ownerDataGridViewTextBoxColumn.Name = "ownerDataGridViewTextBoxColumn";
            this.ownerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // notebookModelBindingSource
            // 
            this.notebookModelBindingSource.DataSource = typeof(TaskLibrary.Models.NotebookModel);
            // 
            // TbpPoint3
            // 
            this.TbpPoint3.BackColor = System.Drawing.Color.Gray;
            this.TbpPoint3.Controls.Add(this.BtnUpdateTextData);
            this.TbpPoint3.Controls.Add(this.GbxDictionary);
            this.TbpPoint3.Controls.Add(this.button1);
            this.TbpPoint3.Controls.Add(this.GrbContent);
            this.TbpPoint3.Location = new System.Drawing.Point(4, 25);
            this.TbpPoint3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TbpPoint3.Name = "TbpPoint3";
            this.TbpPoint3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TbpPoint3.Size = new System.Drawing.Size(925, 346);
            this.TbpPoint3.TabIndex = 2;
            this.TbpPoint3.Text = "3. Словарь";
            // 
            // BtnUpdateTextData
            // 
            this.BtnUpdateTextData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnUpdateTextData.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BtnUpdateTextData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUpdateTextData.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnUpdateTextData.Location = new System.Drawing.Point(224, 300);
            this.BtnUpdateTextData.Name = "BtnUpdateTextData";
            this.BtnUpdateTextData.Size = new System.Drawing.Size(200, 40);
            this.BtnUpdateTextData.TabIndex = 7;
            this.BtnUpdateTextData.Text = "Обновить данные";
            this.BtnUpdateTextData.UseVisualStyleBackColor = false;
            this.BtnUpdateTextData.Click += new System.EventHandler(this.UpdateTextData_Command);
            // 
            // GbxDictionary
            // 
            this.GbxDictionary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GbxDictionary.Controls.Add(this.DgvDictionary);
            this.GbxDictionary.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GbxDictionary.ForeColor = System.Drawing.Color.White;
            this.GbxDictionary.Location = new System.Drawing.Point(624, 8);
            this.GbxDictionary.Name = "GbxDictionary";
            this.GbxDictionary.Size = new System.Drawing.Size(288, 284);
            this.GbxDictionary.TabIndex = 5;
            this.GbxDictionary.TabStop = false;
            this.GbxDictionary.Text = " Частотный словарь ";
            // 
            // DgvDictionary
            // 
            this.DgvDictionary.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Silver;
            this.DgvDictionary.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.DgvDictionary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvDictionary.AutoGenerateColumns = false;
            this.DgvDictionary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvDictionary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDictionary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CmnKey,
            this.CmnVal});
            this.DgvDictionary.DataSource = this.BnsSource;
            this.DgvDictionary.Location = new System.Drawing.Point(8, 24);
            this.DgvDictionary.MultiSelect = false;
            this.DgvDictionary.Name = "DgvDictionary";
            this.DgvDictionary.ReadOnly = true;
            this.DgvDictionary.RowHeadersVisible = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.DgvDictionary.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.DgvDictionary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvDictionary.Size = new System.Drawing.Size(272, 252);
            this.DgvDictionary.TabIndex = 2;
            // 
            // CmnKey
            // 
            this.CmnKey.DataPropertyName = "Key";
            this.CmnKey.HeaderText = "Слово";
            this.CmnKey.Name = "CmnKey";
            this.CmnKey.ReadOnly = true;
            // 
            // CmnVal
            // 
            this.CmnVal.DataPropertyName = "Value";
            this.CmnVal.HeaderText = "Количество";
            this.CmnVal.Name = "CmnVal";
            this.CmnVal.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(8, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 40);
            this.button1.TabIndex = 6;
            this.button1.Text = "Открыть файл...";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.OpenText_Command);
            // 
            // GrbContent
            // 
            this.GrbContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrbContent.Controls.Add(this.TbxText);
            this.GrbContent.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GrbContent.ForeColor = System.Drawing.Color.White;
            this.GrbContent.Location = new System.Drawing.Point(8, 8);
            this.GrbContent.Name = "GrbContent";
            this.GrbContent.Size = new System.Drawing.Size(608, 284);
            this.GrbContent.TabIndex = 4;
            this.GrbContent.TabStop = false;
            this.GrbContent.Text = " Содержание файла ";
            // 
            // TbxText
            // 
            this.TbxText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxText.BackColor = System.Drawing.Color.LightGray;
            this.TbxText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbxText.Location = new System.Drawing.Point(8, 24);
            this.TbxText.Multiline = true;
            this.TbxText.Name = "TbxText";
            this.TbxText.ReadOnly = true;
            this.TbxText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TbxText.Size = new System.Drawing.Size(592, 252);
            this.TbxText.TabIndex = 3;
            this.TbxText.TabStop = false;
            // 
            // OfdNotebooks
            // 
            this.OfdNotebooks.DefaultExt = "json";
            this.OfdNotebooks.FileName = "notebooks.json";
            this.OfdNotebooks.Filter = "Файлы JSON (*.json)|*.json|Все файлы (*.*)|*.*";
            this.OfdNotebooks.InitialDirectory = "./App_Data/";
            // 
            // SfdMain
            // 
            this.SfdMain.DefaultExt = "json";
            this.SfdMain.FileName = "notebooks.json";
            this.SfdMain.Filter = "Файлы JSON (*.json)|*.json|Все файлы (*.*)|*.*";
            this.SfdMain.InitialDirectory = "./App_Data/";
            // 
            // OfdTextFile
            // 
            this.OfdTextFile.DefaultExt = "txt";
            this.OfdTextFile.FileName = "text.txt";
            this.OfdTextFile.Filter = "Файлы TXT (*.txt)|*.txt|Все файлы (*.*)|*.*";
            this.OfdTextFile.InitialDirectory = "./App_Data/";
            // 
            // MniNumbers
            // 
            this.MniNumbers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MniInitNumbers,
            this.MniShuffleNumbers,
            this.toolStripMenuItem3,
            this.MniSortNumbers});
            this.MniNumbers.Name = "MniNumbers";
            this.MniNumbers.Size = new System.Drawing.Size(78, 24);
            this.MniNumbers.Text = "1. Числа";
            // 
            // MniNotebooks
            // 
            this.MniNotebooks.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MniInitNotebooks,
            this.MniShuffleNotebooks,
            this.toolStripMenuItem1,
            this.MniSaveAsNotebooks,
            this.MniLoadNotebooks});
            this.MniNotebooks.Name = "MniNotebooks";
            this.MniNotebooks.Size = new System.Drawing.Size(162, 24);
            this.MniNotebooks.Text = "2. Ремонт ноутбуков";
            // 
            // MniDictionary
            // 
            this.MniDictionary.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MniLoadDictionary,
            this.toolStripMenuItem2,
            this.MniUpdateDictionary});
            this.MniDictionary.Name = "MniDictionary";
            this.MniDictionary.Size = new System.Drawing.Size(95, 24);
            this.MniDictionary.Text = "3. Словарь";
            // 
            // MniShuffleNumbers
            // 
            this.MniShuffleNumbers.Name = "MniShuffleNumbers";
            this.MniShuffleNumbers.Size = new System.Drawing.Size(311, 24);
            this.MniShuffleNumbers.Text = "Перемешать числа";
            this.MniShuffleNumbers.Click += new System.EventHandler(this.ShuffleNumbers_Command);
            // 
            // MniSortNumbers
            // 
            this.MniSortNumbers.Name = "MniSortNumbers";
            this.MniSortNumbers.Size = new System.Drawing.Size(311, 24);
            this.MniSortNumbers.Text = "Сортировать числа по убыванию";
            this.MniSortNumbers.Click += new System.EventHandler(this.SortNumbers_Command);
            // 
            // MniInitNumbers
            // 
            this.MniInitNumbers.Name = "MniInitNumbers";
            this.MniInitNumbers.Size = new System.Drawing.Size(311, 24);
            this.MniInitNumbers.Text = "Сформировать список";
            this.MniInitNumbers.Click += new System.EventHandler(this.NumbersInit_Command);
            // 
            // MniLoadNotebooks
            // 
            this.MniLoadNotebooks.Name = "MniLoadNotebooks";
            this.MniLoadNotebooks.Size = new System.Drawing.Size(235, 24);
            this.MniLoadNotebooks.Text = "Загрузить из файла...";
            this.MniLoadNotebooks.Click += new System.EventHandler(this.LoadNotebooks_Command);
            // 
            // MniSaveAsNotebooks
            // 
            this.MniSaveAsNotebooks.Name = "MniSaveAsNotebooks";
            this.MniSaveAsNotebooks.Size = new System.Drawing.Size(235, 24);
            this.MniSaveAsNotebooks.Text = "Сохранить в файл...";
            this.MniSaveAsNotebooks.Click += new System.EventHandler(this.SaveAsNotebooks_Command);
            // 
            // MniInitNotebooks
            // 
            this.MniInitNotebooks.Name = "MniInitNotebooks";
            this.MniInitNotebooks.Size = new System.Drawing.Size(235, 24);
            this.MniInitNotebooks.Text = "Сформировать список";
            this.MniInitNotebooks.Click += new System.EventHandler(this.InitNotebooks_Command);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(232, 6);
            // 
            // MniLoadDictionary
            // 
            this.MniLoadDictionary.Name = "MniLoadDictionary";
            this.MniLoadDictionary.Size = new System.Drawing.Size(204, 24);
            this.MniLoadDictionary.Text = "Открыть файл...";
            this.MniLoadDictionary.Click += new System.EventHandler(this.OpenText_Command);
            // 
            // MniUpdateDictionary
            // 
            this.MniUpdateDictionary.Name = "MniUpdateDictionary";
            this.MniUpdateDictionary.Size = new System.Drawing.Size(204, 24);
            this.MniUpdateDictionary.Text = "Обновить данные";
            this.MniUpdateDictionary.Click += new System.EventHandler(this.UpdateTextData_Command);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(201, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(308, 6);
            // 
            // MniShuffleNotebooks
            // 
            this.MniShuffleNotebooks.Name = "MniShuffleNotebooks";
            this.MniShuffleNotebooks.Size = new System.Drawing.Size(235, 24);
            this.MniShuffleNotebooks.Text = "Перемешать список";
            this.MniShuffleNotebooks.Click += new System.EventHandler(this.ShuffleNotebooks_Command);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(933, 450);
            this.Controls.Add(this.TbcMain);
            this.Controls.Add(this.TstMain);
            this.Controls.Add(this.StsMain);
            this.Controls.Add(this.MnsMain);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MnsMain;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Домашнее задание на 07.02.2022";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MnsMain.ResumeLayout(false);
            this.MnsMain.PerformLayout();
            this.TbcMain.ResumeLayout(false);
            this.TbpPoint1.ResumeLayout(false);
            this.TbpPoint2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvNotebooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notebookModelBindingSource)).EndInit();
            this.TbpPoint3.ResumeLayout(false);
            this.GbxDictionary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvDictionary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BnsSource)).EndInit();
            this.GrbContent.ResumeLayout(false);
            this.GrbContent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MnsMain;
        private System.Windows.Forms.ToolStripMenuItem MniFile;
        private System.Windows.Forms.ToolStripMenuItem MniExit;
        private System.Windows.Forms.StatusStrip StsMain;
        private System.Windows.Forms.ToolStrip TstMain;
        private System.Windows.Forms.TabControl TbcMain;
        private System.Windows.Forms.TabPage TbpPoint1;
        private System.Windows.Forms.TabPage TbpPoint2;
        private System.Windows.Forms.TabPage TbpPoint3;
        private System.Windows.Forms.ListView LviNumbers;
        private System.Windows.Forms.ColumnHeader CmnValue;
        private System.Windows.Forms.DataGridView DgvNotebooks;
        private System.Windows.Forms.Button BtnSuffleNumbers;
        private System.Windows.Forms.Button BtnSortNumbers;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn processorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ramDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn batteryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diagonalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn defectDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ownerDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource notebookModelBindingSource;
        private System.Windows.Forms.Button BtnNotebooksInit;
        private System.Windows.Forms.Button BtnLoadNotebooks;
        private System.Windows.Forms.Button BtnSaveAsNotebooks;
        private System.Windows.Forms.Button BtnNotebooksShuffle;
        private System.Windows.Forms.OpenFileDialog OfdNotebooks;
        private System.Windows.Forms.SaveFileDialog SfdMain;
        private System.Windows.Forms.Button BtnNumbersInit;
        private System.Windows.Forms.GroupBox GrbContent;
        private System.Windows.Forms.TextBox TbxText;
        private System.Windows.Forms.DataGridView DgvDictionary;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmnKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn CmnVal;
        private System.Windows.Forms.Button BtnUpdateTextData;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox GbxDictionary;
        private System.Windows.Forms.OpenFileDialog OfdTextFile;
        private System.Windows.Forms.BindingSource BnsSource;
        private System.Windows.Forms.ToolStripMenuItem MniNumbers;
        private System.Windows.Forms.ToolStripMenuItem MniNotebooks;
        private System.Windows.Forms.ToolStripMenuItem MniDictionary;
        private System.Windows.Forms.ToolStripMenuItem MniInitNumbers;
        private System.Windows.Forms.ToolStripMenuItem MniShuffleNumbers;
        private System.Windows.Forms.ToolStripMenuItem MniSortNumbers;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem MniInitNotebooks;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MniSaveAsNotebooks;
        private System.Windows.Forms.ToolStripMenuItem MniLoadNotebooks;
        private System.Windows.Forms.ToolStripMenuItem MniLoadDictionary;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem MniUpdateDictionary;
        private System.Windows.Forms.ToolStripMenuItem MniShuffleNotebooks;
    }
}

