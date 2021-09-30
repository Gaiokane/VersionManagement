using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VersionManagement.Helper;

namespace VersionManagement
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //加载默认图标
            this.Icon = Properties.Resources.ahx5z_4c0qe_002;

            //默认配置文件初始化
            DefaultConfig.Init();
            //默认配置文件读取配置
            DefaultConfigFill();

            //获取程序根目录
            string rootPath = Environment.CurrentDirectory;
            FileStream fileStream;
            //版本配置文件对应文件的初始化
            fileStream = File.Create(rootPath + "\\Version");
            //版本配置文件对应文件的初始化
            fileStream = File.Create(rootPath + "\\ExecutionStatus");
            fileStream.Close();

            //版本配置文件初始化
            VersionConfig.Init();

            //执行状态配置文件初始化
            ExecutionStatusConfig.Init();

            //初始化加载用户控件
            panel1.Controls.Clear();
            //UCTest uc = new UCTest();
            UCVersionInformation uc = new UCVersionInformation();
            panel1.Controls.Add(uc);
        }

        private void DefaultConfigFill()
        {
            //this.Text = DefaultConfig.DefaultFormText;
        }

        private void 版本信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UCVersionInformation uc = new UCVersionInformation();
            panel1.Controls.Add(uc);
        }

        private void 新增版本信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UCAddEditVersionInformation uc = new UCAddEditVersionInformation();
            panel1.Controls.Add(uc);
        }

        private void 版本配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UCVersionConfiguration uc = new UCVersionConfiguration();
            panel1.Controls.Add(uc);
        }

        private void 数据库配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UCDatabaseConfiguration uc = new UCDatabaseConfiguration();
            panel1.Controls.Add(uc);
        }

        private void 系统配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UCSystemConfiguration uc = new UCSystemConfiguration();
            panel1.Controls.Add(uc);
        }

        private void 类型配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            UCTypeConfiguration uc = new UCTypeConfiguration();
            panel1.Controls.Add(uc);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}