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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.status = new System.Windows.Forms.StatusStrip();
            this.tssPosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.mainGrid = new System.Windows.Forms.DataGridView();
            this.panelSearching = new System.Windows.Forms.Panel();
            this.status.SuspendLayout();
            this.gridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainGrid)).BeginInit();
            this.panelSearching.SuspendLayout();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.BackColor = System.Drawing.Color.Snow;
            this.status.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssPosition});
            this.status.Location = new System.Drawing.Point(0, 339);
            this.status.Name = "status";
            this.status.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.status.Size = new System.Drawing.Size(784, 22);
            this.status.SizingGrip = false;
            this.status.Stretch = false;
            this.status.TabIndex = 0;
            this.status.Text = "Position 0/0";
            // 
            // tssPosition
            // 
            this.tssPosition.Name = "tssPosition";
            this.tssPosition.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.tssPosition.Size = new System.Drawing.Size(88, 17);
            this.tssPosition.Text = "Position: 0/0";
            // 
            // contextMenu
            // 
            this.contextMenu.AllowMerge = false;
            this.contextMenu.BackColor = System.Drawing.Color.White;
            this.contextMenu.DropShadowEnabled = false;
            this.contextMenu.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenu.ShowImageMargin = false;
            this.contextMenu.ShowItemToolTips = false;
            this.contextMenu.Size = new System.Drawing.Size(36, 4);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            // 
            // tbSearch
            // 
            this.tbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSearch.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSearch.Location = new System.Drawing.Point(8, 8);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(768, 24);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // gridPanel
            // 
            this.gridPanel.Controls.Add(this.mainGrid);
            this.gridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPanel.Location = new System.Drawing.Point(0, 40);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Padding = new System.Windows.Forms.Padding(8, 8, 8, 2);
            this.gridPanel.Size = new System.Drawing.Size(784, 299);
            this.gridPanel.TabIndex = 4;
            // 
            // mainGrid
            // 
            this.mainGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.mainGrid.BackgroundColor = System.Drawing.Color.Snow;
            this.mainGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mainGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.mainGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainGrid.ContextMenuStrip = this.contextMenu;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.mainGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.mainGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.mainGrid.Location = new System.Drawing.Point(8, 8);
            this.mainGrid.MultiSelect = false;
            this.mainGrid.Name = "mainGrid";
            this.mainGrid.RowHeadersVisible = false;
            this.mainGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mainGrid.Size = new System.Drawing.Size(768, 289);
            this.mainGrid.TabIndex = 0;
            this.mainGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainGrid_CellDoubleClick);
            this.mainGrid.SelectionChanged += new System.EventHandler(this.mainGrid_SelectionChanged);
            this.mainGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainGrid_KeyDown);
            this.mainGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainGrid_MouseDown);
            // 
            // panelSearching
            // 
            this.panelSearching.BackColor = System.Drawing.Color.Snow;
            this.panelSearching.Controls.Add(this.tbSearch);
            this.panelSearching.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearching.Location = new System.Drawing.Point(0, 0);
            this.panelSearching.Name = "panelSearching";
            this.panelSearching.Padding = new System.Windows.Forms.Padding(8, 8, 8, 0);
            this.panelSearching.Size = new System.Drawing.Size(784, 40);
            this.panelSearching.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(this.status);
            this.Controls.Add(this.panelSearching);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Very Lite SQLite DB Browser";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.gridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainGrid)).EndInit();
            this.panelSearching.ResumeLayout(false);
            this.panelSearching.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip status;
		private System.Windows.Forms.ToolStripStatusLabel tssPosition;
		private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.Panel panelSearching;
        private System.Windows.Forms.DataGridView mainGrid;
    }
}

