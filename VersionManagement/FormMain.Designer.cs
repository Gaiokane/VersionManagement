
namespace VersionManagement
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.版本信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新增版本信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.版本配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.类型配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.版本信息ToolStripMenuItem,
            this.新增版本信息ToolStripMenuItem,
            this.配置ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 版本信息ToolStripMenuItem
            // 
            this.版本信息ToolStripMenuItem.Name = "版本信息ToolStripMenuItem";
            this.版本信息ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.版本信息ToolStripMenuItem.Text = "版本信息";
            this.版本信息ToolStripMenuItem.Click += new System.EventHandler(this.版本信息ToolStripMenuItem_Click);
            // 
            // 新增版本信息ToolStripMenuItem
            // 
            this.新增版本信息ToolStripMenuItem.Name = "新增版本信息ToolStripMenuItem";
            this.新增版本信息ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.新增版本信息ToolStripMenuItem.Text = "新增版本信息";
            this.新增版本信息ToolStripMenuItem.Click += new System.EventHandler(this.新增版本信息ToolStripMenuItem_Click);
            // 
            // 配置ToolStripMenuItem
            // 
            this.配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.版本配置ToolStripMenuItem,
            this.数据库配置ToolStripMenuItem,
            this.系统配置ToolStripMenuItem,
            this.类型配置ToolStripMenuItem});
            this.配置ToolStripMenuItem.Name = "配置ToolStripMenuItem";
            this.配置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.配置ToolStripMenuItem.Text = "配置";
            // 
            // 版本配置ToolStripMenuItem
            // 
            this.版本配置ToolStripMenuItem.Name = "版本配置ToolStripMenuItem";
            this.版本配置ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.版本配置ToolStripMenuItem.Text = "版本配置";
            this.版本配置ToolStripMenuItem.Click += new System.EventHandler(this.版本配置ToolStripMenuItem_Click);
            // 
            // 数据库配置ToolStripMenuItem
            // 
            this.数据库配置ToolStripMenuItem.Name = "数据库配置ToolStripMenuItem";
            this.数据库配置ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.数据库配置ToolStripMenuItem.Text = "数据库配置";
            this.数据库配置ToolStripMenuItem.Click += new System.EventHandler(this.数据库配置ToolStripMenuItem_Click);
            // 
            // 系统配置ToolStripMenuItem
            // 
            this.系统配置ToolStripMenuItem.Name = "系统配置ToolStripMenuItem";
            this.系统配置ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.系统配置ToolStripMenuItem.Text = "系统配置";
            this.系统配置ToolStripMenuItem.Click += new System.EventHandler(this.系统配置ToolStripMenuItem_Click);
            // 
            // 类型配置ToolStripMenuItem
            // 
            this.类型配置ToolStripMenuItem.Name = "类型配置ToolStripMenuItem";
            this.类型配置ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.类型配置ToolStripMenuItem.Text = "类型配置";
            this.类型配置ToolStripMenuItem.Click += new System.EventHandler(this.类型配置ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 422);
            this.panel1.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 版本信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新增版本信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 版本配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据库配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 类型配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
    }
}