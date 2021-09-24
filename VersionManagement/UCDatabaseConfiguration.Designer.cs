
namespace VersionManagement
{
    partial class UCDatabaseConfiguration
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
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.DatabaseCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatabaseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBoxAddEdit = new System.Windows.Forms.GroupBox();
            this.TextBoxDatabaseName = new System.Windows.Forms.TextBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxDatabaseCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.GroupBoxAddEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(165, 3);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(75, 23);
            this.BtnDelete.TabIndex = 6;
            this.BtnDelete.Text = "删除";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Location = new System.Drawing.Point(84, 3);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(75, 23);
            this.BtnEdit.TabIndex = 5;
            this.BtnEdit.Text = "编辑";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(3, 3);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 23);
            this.BtnAdd.TabIndex = 4;
            this.BtnAdd.Text = "新增";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.AllowUserToResizeRows = false;
            this.DGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DatabaseCode,
            this.DatabaseName});
            this.DGV.Location = new System.Drawing.Point(3, 32);
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersVisible = false;
            this.DGV.RowTemplate.Height = 23;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(794, 387);
            this.DGV.TabIndex = 7;
            // 
            // DatabaseCode
            // 
            this.DatabaseCode.HeaderText = "数据库编码";
            this.DatabaseCode.Name = "DatabaseCode";
            this.DatabaseCode.ReadOnly = true;
            this.DatabaseCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DatabaseCode.Width = 200;
            // 
            // DatabaseName
            // 
            this.DatabaseName.HeaderText = "数据库名";
            this.DatabaseName.Name = "DatabaseName";
            this.DatabaseName.ReadOnly = true;
            this.DatabaseName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DatabaseName.Width = 200;
            // 
            // GroupBoxAddEdit
            // 
            this.GroupBoxAddEdit.Controls.Add(this.TextBoxDatabaseName);
            this.GroupBoxAddEdit.Controls.Add(this.BtnCancel);
            this.GroupBoxAddEdit.Controls.Add(this.BtnSave);
            this.GroupBoxAddEdit.Controls.Add(this.label2);
            this.GroupBoxAddEdit.Controls.Add(this.TextBoxDatabaseCode);
            this.GroupBoxAddEdit.Controls.Add(this.label1);
            this.GroupBoxAddEdit.Location = new System.Drawing.Point(209, 156);
            this.GroupBoxAddEdit.Name = "GroupBoxAddEdit";
            this.GroupBoxAddEdit.Size = new System.Drawing.Size(383, 110);
            this.GroupBoxAddEdit.TabIndex = 14;
            this.GroupBoxAddEdit.TabStop = false;
            this.GroupBoxAddEdit.Text = "新增/编辑数据库配置";
            // 
            // TextBoxDatabaseName
            // 
            this.TextBoxDatabaseName.Location = new System.Drawing.Point(167, 44);
            this.TextBoxDatabaseName.Name = "TextBoxDatabaseName";
            this.TextBoxDatabaseName.Size = new System.Drawing.Size(120, 21);
            this.TextBoxDatabaseName.TabIndex = 8;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(194, 71);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(113, 71);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 6;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "数据库名：";
            // 
            // TextBoxDatabaseCode
            // 
            this.TextBoxDatabaseCode.Location = new System.Drawing.Point(167, 17);
            this.TextBoxDatabaseCode.Name = "TextBoxDatabaseCode";
            this.TextBoxDatabaseCode.Size = new System.Drawing.Size(120, 21);
            this.TextBoxDatabaseCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库编码：";
            // 
            // UCDatabaseConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GroupBoxAddEdit);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.BtnAdd);
            this.Name = "UCDatabaseConfiguration";
            this.Size = new System.Drawing.Size(800, 422);
            this.Load += new System.EventHandler(this.UCDatabaseConfiguration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.GroupBoxAddEdit.ResumeLayout(false);
            this.GroupBoxAddEdit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatabaseCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatabaseName;
        private System.Windows.Forms.GroupBox GroupBoxAddEdit;
        private System.Windows.Forms.TextBox TextBoxDatabaseName;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxDatabaseCode;
        private System.Windows.Forms.Label label1;
    }
}
