
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
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(3, 41);
            this.DGV.Name = "DGV";
            this.DGV.RowTemplate.Height = 23;
            this.DGV.Size = new System.Drawing.Size(794, 378);
            this.DGV.TabIndex = 4;
            // 
            // UCVersionInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.ComboBoxCorrespondingSystem);
            this.Controls.Add(this.LabelCorrespondingSystem);
            this.Controls.Add(this.ComboBoxVersionNumber);
            this.Controls.Add(this.LabelVersionNumber);
            this.Name = "UCVersionInformation";
            this.Size = new System.Drawing.Size(800, 422);
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
    }
}
