namespace VersionManagement
{
    partial class UCVersionInformation
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.LabelVersionNumber = new System.Windows.Forms.Label();
            this.ComboBoxVersionNumber = new System.Windows.Forms.ComboBox();
            this.LabelCorrespondingSystem = new System.Windows.Forms.Label();
            this.ComboBoxCorrespondingSystem = new System.Windows.Forms.ComboBox();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorrespondingSystem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PublishContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorrespondingDatabase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SQLScriptPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsExecuted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ExecuteSQLScript = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelVersionNumber
            // 
            this.LabelVersionNumber.AutoSize = true;
            this.LabelVersionNumber.Location = new System.Drawing.Point(10, 13);
            this.LabelVersionNumber.Name = "LabelVersionNumber";
            this.LabelVersionNumber.Size = new System.Drawing.Size(53, 12);
            this.LabelVersionNumber.TabIndex = 0;
            this.LabelVersionNumber.Text = "版本号：";
            // 
            // ComboBoxVersionNumber
            // 
            this.ComboBoxVersionNumber.FormattingEnabled = true;
            this.ComboBoxVersionNumber.Location = new System.Drawing.Point(69, 10);
            this.ComboBoxVersionNumber.Name = "ComboBoxVersionNumber";
            this.ComboBoxVersionNumber.Size = new System.Drawing.Size(121, 20);
            this.ComboBoxVersionNumber.TabIndex = 1;
            // 
            // LabelCorrespondingSystem
            // 
            this.LabelCorrespondingSystem.AutoSize = true;
            this.LabelCorrespondingSystem.Location = new System.Drawing.Point(196, 13);
            this.LabelCorrespondingSystem.Name = "LabelCorrespondingSystem";
            this.LabelCorrespondingSystem.Size = new System.Drawing.Size(65, 12);
            this.LabelCorrespondingSystem.TabIndex = 2;
            this.LabelCorrespondingSystem.Text = "对应系统：";
            // 
            // ComboBoxCorrespondingSystem
            // 
            this.ComboBoxCorrespondingSystem.FormattingEnabled = true;
            this.ComboBoxCorrespondingSystem.Location = new System.Drawing.Point(267, 10);
            this.ComboBoxCorrespondingSystem.Name = "ComboBoxCorrespondingSystem";
            this.ComboBoxCorrespondingSystem.Size = new System.Drawing.Size(121, 20);
            this.ComboBoxCorrespondingSystem.TabIndex = 3;
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.AllowUserToResizeRows = false;
            this.DGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.CorrespondingSystem,
            this.Type,
            this.PublishContent,
            this.Description,
            this.Remark,
            this.CorrespondingDatabase,
            this.SQLScriptPath,
            this.IsExecuted,
            this.ExecuteSQLScript,
            this.Edit,
            this.Delete});
            this.DGV.Location = new System.Drawing.Point(3, 41);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersVisible = false;
            this.DGV.RowTemplate.Height = 23;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGV.Size = new System.Drawing.Size(794, 378);
            this.DGV.TabIndex = 4;
            this.DGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellContentClick);
            this.DGV.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DGV_CellPainting);
            // 
            // No
            // 
            this.No.Frozen = true;
            this.No.HeaderText = "序号";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.No.Width = 40;
            // 
            // CorrespondingSystem
            // 
            this.CorrespondingSystem.Frozen = true;
            this.CorrespondingSystem.HeaderText = "对应系统";
            this.CorrespondingSystem.Name = "CorrespondingSystem";
            this.CorrespondingSystem.ReadOnly = true;
            this.CorrespondingSystem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CorrespondingSystem.Width = 70;
            // 
            // Type
            // 
            this.Type.Frozen = true;
            this.Type.HeaderText = "类型";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Type.Width = 50;
            // 
            // PublishContent
            // 
            this.PublishContent.Frozen = true;
            this.PublishContent.HeaderText = "发布内容";
            this.PublishContent.Name = "PublishContent";
            this.PublishContent.ReadOnly = true;
            this.PublishContent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Description
            // 
            this.Description.Frozen = true;
            this.Description.HeaderText = "详细描述";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Remark
            // 
            this.Remark.HeaderText = "备注";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            this.Remark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CorrespondingDatabase
            // 
            this.CorrespondingDatabase.HeaderText = "对应数据库";
            this.CorrespondingDatabase.Name = "CorrespondingDatabase";
            this.CorrespondingDatabase.ReadOnly = true;
            this.CorrespondingDatabase.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SQLScriptPath
            // 
            this.SQLScriptPath.HeaderText = "SQL脚本";
            this.SQLScriptPath.Name = "SQLScriptPath";
            this.SQLScriptPath.ReadOnly = true;
            this.SQLScriptPath.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // IsExecuted
            // 
            this.IsExecuted.HeaderText = "是否已执行";
            this.IsExecuted.Name = "IsExecuted";
            this.IsExecuted.ReadOnly = true;
            this.IsExecuted.Width = 80;
            // 
            // ExecuteSQLScript
            // 
            this.ExecuteSQLScript.HeaderText = "执行SQL脚本";
            this.ExecuteSQLScript.Name = "ExecuteSQLScript";
            this.ExecuteSQLScript.ReadOnly = true;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "编辑";
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Width = 40;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "删除";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Width = 40;
            // 
            // UCVersionInformation
            // 
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.ComboBoxCorrespondingSystem);
            this.Controls.Add(this.LabelCorrespondingSystem);
            this.Controls.Add(this.ComboBoxVersionNumber);
            this.Controls.Add(this.LabelVersionNumber);
            this.Name = "UCVersionInformation";
            this.Size = new System.Drawing.Size(800, 422);
            this.Load += new System.EventHandler(this.UCVersionInformation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelVersionNumber;
        private System.Windows.Forms.ComboBox ComboBoxVersionNumber;
        private System.Windows.Forms.Label LabelCorrespondingSystem;
        private System.Windows.Forms.ComboBox ComboBoxCorrespondingSystem;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorrespondingSystem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublishContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorrespondingDatabase;
        private System.Windows.Forms.DataGridViewTextBoxColumn SQLScriptPath;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsExecuted;
        private System.Windows.Forms.DataGridViewLinkColumn ExecuteSQLScript;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
    }
}
