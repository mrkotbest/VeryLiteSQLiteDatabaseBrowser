namespace SQLiteApp
{
	partial class MainForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tssPosition = new System.Windows.Forms.ToolStripStatusLabel();
			this.gbOperations = new System.Windows.Forms.GroupBox();
			this.panelOperations = new System.Windows.Forms.TableLayoutPanel();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnMoveLast = new System.Windows.Forms.Button();
			this.btnMoveNext = new System.Windows.Forms.Button();
			this.btnMovePrevious = new System.Windows.Forms.Button();
			this.btnMoveFirst = new System.Windows.Forms.Button();
			this.tbPhone = new System.Windows.Forms.TextBox();
			this.lblPhone = new System.Windows.Forms.Label();
			this.tbEmail = new System.Windows.Forms.TextBox();
			this.lblEmail = new System.Windows.Forms.Label();
			this.tbJobTitle = new System.Windows.Forms.TextBox();
			this.lblJobTitle = new System.Windows.Forms.Label();
			this.tbLastName = new System.Windows.Forms.TextBox();
			this.lblLastName = new System.Windows.Forms.Label();
			this.tbFirstName = new System.Windows.Forms.TextBox();
			this.lblFirstName = new System.Windows.Forms.Label();
			this.tbAutoId = new System.Windows.Forms.TextBox();
			this.lblAutoId = new System.Windows.Forms.Label();
			this.gbGridView = new System.Windows.Forms.GroupBox();
			this.panelGrid = new System.Windows.Forms.Panel();
			this.mainGrid = new System.Windows.Forms.DataGridView();
			this.panelSearching = new System.Windows.Forms.FlowLayoutPanel();
			this.tbSearch = new System.Windows.Forms.TextBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.statusStrip1.SuspendLayout();
			this.gbOperations.SuspendLayout();
			this.panelOperations.SuspendLayout();
			this.gbGridView.SuspendLayout();
			this.panelGrid.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.mainGrid)).BeginInit();
			this.panelSearching.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssPosition});
			this.statusStrip1.Location = new System.Drawing.Point(0, 339);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
			this.statusStrip1.Size = new System.Drawing.Size(684, 22);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.Stretch = false;
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "\"\"";
			// 
			// tssPosition
			// 
			this.tssPosition.Name = "tssPosition";
			this.tssPosition.Size = new System.Drawing.Size(80, 17);
			this.tssPosition.Text = "Position: 0/0";
			// 
			// gbOperations
			// 
			this.gbOperations.Controls.Add(this.panelOperations);
			this.gbOperations.Controls.Add(this.btnMoveLast);
			this.gbOperations.Controls.Add(this.btnMoveNext);
			this.gbOperations.Controls.Add(this.btnMovePrevious);
			this.gbOperations.Controls.Add(this.btnMoveFirst);
			this.gbOperations.Controls.Add(this.tbPhone);
			this.gbOperations.Controls.Add(this.lblPhone);
			this.gbOperations.Controls.Add(this.tbEmail);
			this.gbOperations.Controls.Add(this.lblEmail);
			this.gbOperations.Controls.Add(this.tbJobTitle);
			this.gbOperations.Controls.Add(this.lblJobTitle);
			this.gbOperations.Controls.Add(this.tbLastName);
			this.gbOperations.Controls.Add(this.lblLastName);
			this.gbOperations.Controls.Add(this.tbFirstName);
			this.gbOperations.Controls.Add(this.lblFirstName);
			this.gbOperations.Controls.Add(this.tbAutoId);
			this.gbOperations.Controls.Add(this.lblAutoId);
			this.gbOperations.Dock = System.Windows.Forms.DockStyle.Left;
			this.gbOperations.Location = new System.Drawing.Point(0, 0);
			this.gbOperations.Name = "gbOperations";
			this.gbOperations.Size = new System.Drawing.Size(247, 339);
			this.gbOperations.TabIndex = 1;
			this.gbOperations.TabStop = false;
			// 
			// panelOperations
			// 
			this.panelOperations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panelOperations.ColumnCount = 3;
			this.panelOperations.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.panelOperations.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.panelOperations.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.panelOperations.Controls.Add(this.btnDelete, 0, 0);
			this.panelOperations.Controls.Add(this.btnRefresh, 0, 1);
			this.panelOperations.Controls.Add(this.btnAdd, 1, 0);
			this.panelOperations.Controls.Add(this.btnSave, 2, 0);
			this.panelOperations.Controls.Add(this.btnExit, 2, 1);
			this.panelOperations.Location = new System.Drawing.Point(12, 229);
			this.panelOperations.Margin = new System.Windows.Forms.Padding(0);
			this.panelOperations.Name = "panelOperations";
			this.panelOperations.Padding = new System.Windows.Forms.Padding(3);
			this.panelOperations.RowCount = 2;
			this.panelOperations.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.panelOperations.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.panelOperations.Size = new System.Drawing.Size(224, 66);
			this.panelOperations.TabIndex = 25;
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelete.BackColor = System.Drawing.Color.IndianRed;
			this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.btnDelete.Location = new System.Drawing.Point(3, 3);
			this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(72, 25);
			this.btnDelete.TabIndex = 24;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = false;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRefresh.BackColor = System.Drawing.Color.Plum;
			this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnRefresh.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.btnRefresh.Location = new System.Drawing.Point(3, 33);
			this.btnRefresh.Margin = new System.Windows.Forms.Padding(0);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(72, 25);
			this.btnRefresh.TabIndex = 22;
			this.btnRefresh.Text = "Refresh";
			this.btnRefresh.UseVisualStyleBackColor = false;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.BackColor = System.Drawing.Color.CornflowerBlue;
			this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.btnAdd.Location = new System.Drawing.Point(75, 3);
			this.btnAdd.Margin = new System.Windows.Forms.Padding(0);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(72, 25);
			this.btnAdd.TabIndex = 20;
			this.btnAdd.Text = "Add New";
			this.btnAdd.UseVisualStyleBackColor = false;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.BackColor = System.Drawing.Color.MediumSeaGreen;
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.btnSave.Location = new System.Drawing.Point(147, 3);
			this.btnSave.Margin = new System.Windows.Forms.Padding(0);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(74, 25);
			this.btnSave.TabIndex = 21;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = false;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnExit
			// 
			this.btnExit.BackColor = System.Drawing.Color.Crimson;
			this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnExit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.btnExit.Location = new System.Drawing.Point(147, 33);
			this.btnExit.Margin = new System.Windows.Forms.Padding(0);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(74, 25);
			this.btnExit.TabIndex = 23;
			this.btnExit.Text = "Close";
			this.btnExit.UseVisualStyleBackColor = false;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnMoveLast
			// 
			this.btnMoveLast.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMoveLast.Location = new System.Drawing.Point(174, 192);
			this.btnMoveLast.Name = "btnMoveLast";
			this.btnMoveLast.Size = new System.Drawing.Size(62, 23);
			this.btnMoveLast.TabIndex = 18;
			this.btnMoveLast.Text = ">|";
			this.btnMoveLast.UseVisualStyleBackColor = true;
			this.btnMoveLast.Click += new System.EventHandler(this.btnMoveLast_Click);
			// 
			// btnMoveNext
			// 
			this.btnMoveNext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMoveNext.Location = new System.Drawing.Point(120, 192);
			this.btnMoveNext.Name = "btnMoveNext";
			this.btnMoveNext.Size = new System.Drawing.Size(62, 23);
			this.btnMoveNext.TabIndex = 17;
			this.btnMoveNext.Text = ">";
			this.btnMoveNext.UseVisualStyleBackColor = true;
			this.btnMoveNext.Click += new System.EventHandler(this.btnMoveNext_Click);
			// 
			// btnMovePrevious
			// 
			this.btnMovePrevious.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMovePrevious.Location = new System.Drawing.Point(66, 192);
			this.btnMovePrevious.Name = "btnMovePrevious";
			this.btnMovePrevious.Size = new System.Drawing.Size(62, 23);
			this.btnMovePrevious.TabIndex = 16;
			this.btnMovePrevious.Text = "<";
			this.btnMovePrevious.UseVisualStyleBackColor = true;
			this.btnMovePrevious.Click += new System.EventHandler(this.btnMovePrevious_Click);
			// 
			// btnMoveFirst
			// 
			this.btnMoveFirst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMoveFirst.Location = new System.Drawing.Point(12, 192);
			this.btnMoveFirst.Name = "btnMoveFirst";
			this.btnMoveFirst.Size = new System.Drawing.Size(62, 23);
			this.btnMoveFirst.TabIndex = 15;
			this.btnMoveFirst.Text = "|<";
			this.btnMoveFirst.UseVisualStyleBackColor = true;
			this.btnMoveFirst.Click += new System.EventHandler(this.btnMoveFirst_Click);
			// 
			// tbPhone
			// 
			this.tbPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbPhone.Location = new System.Drawing.Point(71, 156);
			this.tbPhone.Name = "tbPhone";
			this.tbPhone.Size = new System.Drawing.Size(165, 20);
			this.tbPhone.TabIndex = 14;
			// 
			// lblPhone
			// 
			this.lblPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPhone.AutoSize = true;
			this.lblPhone.Location = new System.Drawing.Point(9, 158);
			this.lblPhone.Name = "lblPhone";
			this.lblPhone.Size = new System.Drawing.Size(38, 13);
			this.lblPhone.TabIndex = 13;
			this.lblPhone.Text = "Phone";
			// 
			// tbEmail
			// 
			this.tbEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbEmail.Location = new System.Drawing.Point(71, 130);
			this.tbEmail.Name = "tbEmail";
			this.tbEmail.Size = new System.Drawing.Size(165, 20);
			this.tbEmail.TabIndex = 12;
			// 
			// lblEmail
			// 
			this.lblEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEmail.AutoSize = true;
			this.lblEmail.Location = new System.Drawing.Point(9, 132);
			this.lblEmail.Name = "lblEmail";
			this.lblEmail.Size = new System.Drawing.Size(35, 13);
			this.lblEmail.TabIndex = 11;
			this.lblEmail.Text = "E-mail";
			// 
			// tbJobTitle
			// 
			this.tbJobTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbJobTitle.Location = new System.Drawing.Point(71, 104);
			this.tbJobTitle.Name = "tbJobTitle";
			this.tbJobTitle.Size = new System.Drawing.Size(165, 20);
			this.tbJobTitle.TabIndex = 10;
			// 
			// lblJobTitle
			// 
			this.lblJobTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblJobTitle.AutoSize = true;
			this.lblJobTitle.Location = new System.Drawing.Point(9, 106);
			this.lblJobTitle.Name = "lblJobTitle";
			this.lblJobTitle.Size = new System.Drawing.Size(47, 13);
			this.lblJobTitle.TabIndex = 9;
			this.lblJobTitle.Text = "Job Title";
			// 
			// tbLastName
			// 
			this.tbLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbLastName.Location = new System.Drawing.Point(71, 78);
			this.tbLastName.Name = "tbLastName";
			this.tbLastName.Size = new System.Drawing.Size(165, 20);
			this.tbLastName.TabIndex = 8;
			// 
			// lblLastName
			// 
			this.lblLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblLastName.AutoSize = true;
			this.lblLastName.Location = new System.Drawing.Point(9, 80);
			this.lblLastName.Name = "lblLastName";
			this.lblLastName.Size = new System.Drawing.Size(58, 13);
			this.lblLastName.TabIndex = 7;
			this.lblLastName.Text = "Last Name";
			// 
			// tbFirstName
			// 
			this.tbFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbFirstName.Location = new System.Drawing.Point(71, 52);
			this.tbFirstName.Name = "tbFirstName";
			this.tbFirstName.Size = new System.Drawing.Size(165, 20);
			this.tbFirstName.TabIndex = 6;
			// 
			// lblFirstName
			// 
			this.lblFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblFirstName.AutoSize = true;
			this.lblFirstName.Location = new System.Drawing.Point(9, 54);
			this.lblFirstName.Name = "lblFirstName";
			this.lblFirstName.Size = new System.Drawing.Size(57, 13);
			this.lblFirstName.TabIndex = 5;
			this.lblFirstName.Text = "First Name";
			// 
			// tbAutoId
			// 
			this.tbAutoId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbAutoId.Location = new System.Drawing.Point(71, 26);
			this.tbAutoId.Name = "tbAutoId";
			this.tbAutoId.Size = new System.Drawing.Size(165, 20);
			this.tbAutoId.TabIndex = 4;
			// 
			// lblAutoId
			// 
			this.lblAutoId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblAutoId.AutoSize = true;
			this.lblAutoId.Location = new System.Drawing.Point(9, 28);
			this.lblAutoId.Name = "lblAutoId";
			this.lblAutoId.Size = new System.Drawing.Size(41, 13);
			this.lblAutoId.TabIndex = 3;
			this.lblAutoId.Text = "Auto Id";
			// 
			// gbGridView
			// 
			this.gbGridView.Controls.Add(this.panelGrid);
			this.gbGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gbGridView.Location = new System.Drawing.Point(247, 0);
			this.gbGridView.Name = "gbGridView";
			this.gbGridView.Size = new System.Drawing.Size(437, 339);
			this.gbGridView.TabIndex = 2;
			this.gbGridView.TabStop = false;
			// 
			// panelGrid
			// 
			this.panelGrid.Controls.Add(this.mainGrid);
			this.panelGrid.Controls.Add(this.panelSearching);
			this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelGrid.Location = new System.Drawing.Point(3, 16);
			this.panelGrid.Name = "panelGrid";
			this.panelGrid.Size = new System.Drawing.Size(431, 320);
			this.panelGrid.TabIndex = 4;
			// 
			// mainGrid
			// 
			this.mainGrid.AllowUserToAddRows = false;
			this.mainGrid.AllowUserToDeleteRows = false;
			this.mainGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.mainGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.mainGrid.BackgroundColor = System.Drawing.Color.White;
			this.mainGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.mainGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainGrid.GridColor = System.Drawing.SystemColors.Control;
			this.mainGrid.Location = new System.Drawing.Point(0, 30);
			this.mainGrid.Name = "mainGrid";
			this.mainGrid.ReadOnly = true;
			this.mainGrid.Size = new System.Drawing.Size(431, 290);
			this.mainGrid.TabIndex = 0;
			this.mainGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.mainGrid_CellMouseClick);
			// 
			// panelSearching
			// 
			this.panelSearching.Controls.Add(this.tbSearch);
			this.panelSearching.Controls.Add(this.btnSearch);
			this.panelSearching.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelSearching.Location = new System.Drawing.Point(0, 0);
			this.panelSearching.Name = "panelSearching";
			this.panelSearching.Size = new System.Drawing.Size(431, 30);
			this.panelSearching.TabIndex = 3;
			// 
			// tbSearch
			// 
			this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbSearch.Location = new System.Drawing.Point(3, 3);
			this.tbSearch.Name = "tbSearch";
			this.tbSearch.Size = new System.Drawing.Size(354, 24);
			this.tbSearch.TabIndex = 1;
			// 
			// btnSearch
			// 
			this.btnSearch.BackColor = System.Drawing.Color.Gold;
			this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.btnSearch.Location = new System.Drawing.Point(363, 3);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(63, 24);
			this.btnSearch.TabIndex = 2;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = false;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(684, 361);
			this.Controls.Add(this.gbGridView);
			this.Controls.Add(this.gbOperations);
			this.Controls.Add(this.statusStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(700, 400);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Very Lite SQLite DB Browser";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.gbOperations.ResumeLayout(false);
			this.gbOperations.PerformLayout();
			this.panelOperations.ResumeLayout(false);
			this.gbGridView.ResumeLayout(false);
			this.panelGrid.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.mainGrid)).EndInit();
			this.panelSearching.ResumeLayout(false);
			this.panelSearching.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel tssPosition;
		private System.Windows.Forms.GroupBox gbOperations;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnMoveLast;
		private System.Windows.Forms.Button btnMoveNext;
		private System.Windows.Forms.Button btnMovePrevious;
		private System.Windows.Forms.Button btnMoveFirst;
		private System.Windows.Forms.TextBox tbPhone;
		private System.Windows.Forms.Label lblPhone;
		private System.Windows.Forms.TextBox tbEmail;
		private System.Windows.Forms.Label lblEmail;
		private System.Windows.Forms.TextBox tbJobTitle;
		private System.Windows.Forms.Label lblJobTitle;
		private System.Windows.Forms.TextBox tbLastName;
		private System.Windows.Forms.Label lblLastName;
		private System.Windows.Forms.TextBox tbFirstName;
		private System.Windows.Forms.Label lblFirstName;
		private System.Windows.Forms.TextBox tbAutoId;
		private System.Windows.Forms.Label lblAutoId;
		private System.Windows.Forms.GroupBox gbGridView;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.DataGridView mainGrid;
		private System.Windows.Forms.TextBox tbSearch;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Panel panelGrid;
		private System.Windows.Forms.FlowLayoutPanel panelSearching;
		private System.Windows.Forms.TableLayoutPanel panelOperations;
	}
}

