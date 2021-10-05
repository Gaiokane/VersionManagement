using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VersionManagement.Helper;

namespace VersionManagement
{
    public partial class UCAddEditVersionInformation : UserControl
    {
        //窗体传值 FormMain 新增版本信息ToolStripMenuItem_Click
        //0=初始化/新增，1=编辑
        public int ACTION = 0;

        //窗体传值 UCVersionInformation DGV_CellContentClick
        //版本号
        public string VERSIONNUMBER = "";
        //对应系统
        public string CORRESPONDINGSYSTEM = "";
        //类型
        public string TYPE = "";
        //排序值
        public string ORDERNUM = "";
        //发布内容
        public string PUBLISHCONTENT = "";
        //详细描述
        public string DESCRIPTION = "";
        //备注
        public string REMARK = "";
        //对应数据库
        public string CORRESPONDINGDATABASE = "";
        //SQL脚本
        public string SQLSCRIPTPATH = "";

        public UCAddEditVersionInformation()
        {
            InitializeComponent();
        }

        private void UCAddEditVersionInformation_Load(object sender, EventArgs e)
        {
            //下拉框修改样式 版本号
            ComboBoxVersionNumber.DropDownStyle = ComboBoxStyle.DropDownList;
            //下拉框修改样式 对应系统
            ComboBoxCorrespondingSystem.DropDownStyle = ComboBoxStyle.DropDownList;
            //下拉框修改样式 类型
            ComboBoxType.DropDownStyle = ComboBoxStyle.DropDownList;
            //下拉框修改样式 对应数据库
            ComboBoxCorrespondingDatabase.DropDownStyle = ComboBoxStyle.DropDownList;

            //RichTextBox增加右键菜单 详细描述
            _ = new RichTextBoxMenu(RichTextBoxDescription);
            //RichTextBox增加右键菜单 备注
            _ = new RichTextBoxMenu(RichTextBoxRemark);

            //文本框只读
            TextBoxSQLScriptPath.Enabled = false;

            //修改控件状态
            SetAddEditControlState(ACTION);
        }

        #region 重新绑定下拉框数据 版本号
        /// <summary>
        /// 重新绑定下拉框数据 版本号
        /// </summary>
        private void BindComboBoxVersionNumber()
        {
            ComboBoxVersionNumber.Items.Clear();
            List<string> list;
            list = VersionConfig.GetappSettingsSplitBySemicolon("Version", ';');
            //将list中元素倒叙
            list.Reverse();
            foreach (var item in list)
            {
                ComboBoxVersionNumber.Items.Add(item.Split('_')[1]);
            }
            if (ComboBoxVersionNumber.Items.Count > 0)
            {
                ComboBoxVersionNumber.SelectedIndex = 0;
            }
        }
        #endregion

        #region 重新绑定下拉框数据 对应系统
        /// <summary>
        /// 重新绑定下拉框数据 对应系统
        /// </summary>
        private void BindComboBoxCorrespondingSystem()
        {
            //获取全部系统类型
            ComboBoxCorrespondingSystem.Items.Clear();
            List<string> list = VersionConfig.GetappSettingsSplitBySemicolon("System", ';');
            //将list中元素倒叙
            list.Reverse();
            foreach (var item in list)
            {
                ComboBoxCorrespondingSystem.Items.Add(VersionConfig.GetappSettingsSplitBySemicolon(item, ';')[0]);
            }
            if (ComboBoxCorrespondingSystem.Items.Count > 0)
            {
                ComboBoxCorrespondingSystem.SelectedIndex = 0;
            }
        }
        #endregion

        #region 重新绑定下拉框数据 类型
        /// <summary>
        /// 重新绑定下拉框数据 类型
        /// </summary>
        private void BindComboBoxType()
        {
            ComboBoxType.Items.Clear();
            List<string> list = VersionConfig.GetappSettingsSplitBySemicolon("Type", ';');
            foreach (var item in list)
            {
                ComboBoxType.Items.Add(VersionConfig.GetappSettingsSplitBySemicolon(item, ';')[0]);
            }
            if (ComboBoxType.Items.Count > 0)
            {
                ComboBoxType.SelectedIndex = 0;
            }
        }
        #endregion

        #region 重新绑定下拉框数据 对应数据库
        /// <summary>
        /// 重新绑定下拉框数据 对应数据库
        /// </summary>
        private void BindComboBoxCorrespondingDatabase()
        {
            ComboBoxCorrespondingDatabase.Items.Clear();
            List<string> list = DefaultConfig.GetappSettingsSplitBySemicolon("Database", ';');
            foreach (var item in list)
            {
                ComboBoxCorrespondingDatabase.Items.Add(DefaultConfig.GetappSettingsSplitBySemicolon(item, ';')[0]);
            }
            if (ComboBoxCorrespondingDatabase.Items.Count > 0)
            {
                ComboBoxCorrespondingDatabase.SelectedIndex = 0;
            }
        }
        #endregion

        private void SetAddEditControlState(int action)
        {
            //0=初始化/新增，1=编辑
            if (action == 0)
            {
                groupBox1.Text = "新增版本信息";

                //重新绑定下拉框数据 版本号
                BindComboBoxVersionNumber();
                //重新绑定下拉框数据 对应系统
                BindComboBoxCorrespondingSystem();
                //重新绑定下拉框数据 类型
                BindComboBoxType();
                //重新绑定下拉框数据 对应数据库
                BindComboBoxCorrespondingDatabase();

                //默认值 排序值
                TextBoxOrderNum.Text = "0";
                //默认值 发布内容
                TextBoxPublishContent.Text = "";
                //默认值 详细描述
                RichTextBoxDescription.Text = "";
                //默认值 备注
                RichTextBoxRemark.Text = "";
                //默认值 SQL脚本
                TextBoxSQLScriptPath.Text = "";

                //控件获取焦点
                TextBoxPublishContent.Focus();

                //是否可编辑 版本号
                ComboBoxVersionNumber.Enabled = true;
                //是否可编辑 对应系统
                ComboBoxCorrespondingSystem.Enabled = true;
            }
            //0=初始化/新增，1=编辑
            else if (action == 1)
            {
                groupBox1.Text = "编辑版本信息";

                //重新绑定下拉框数据 版本号
                BindComboBoxVersionNumber();
                //重新绑定下拉框数据 对应系统
                BindComboBoxCorrespondingSystem();
                //重新绑定下拉框数据 类型
                BindComboBoxType();
                //重新绑定下拉框数据 对应数据库
                BindComboBoxCorrespondingDatabase();

                //默认值 版本号
                ComboBoxVersionNumber.SelectedItem = VERSIONNUMBER;
                //默认值 对应系统
                ComboBoxCorrespondingSystem.SelectedItem = CORRESPONDINGSYSTEM;
                //默认值 类型
                ComboBoxType.SelectedItem = TYPE;
                //默认值 排序值
                TextBoxOrderNum.Text = ORDERNUM;
                //默认值 发布内容
                TextBoxPublishContent.Text = PUBLISHCONTENT;
                //默认值 详细描述
                RichTextBoxDescription.Text = DESCRIPTION;
                //默认值 备注
                RichTextBoxRemark.Text = REMARK;
                //默认值 对应数据库
                ComboBoxCorrespondingDatabase.SelectedItem = CORRESPONDINGDATABASE;
                //默认值 SQL脚本
                TextBoxSQLScriptPath.Text = SQLSCRIPTPATH;

                //是否可编辑 版本号
                ComboBoxVersionNumber.Enabled = false;
                //是否可编辑 对应系统
                ComboBoxCorrespondingSystem.Enabled = false;
            }
        }

        private void BtnSQLScriptPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择SQL文件";
            openFileDialog.Filter = "SQL文件(*.sql)|*.sql";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                TextBoxSQLScriptPath.Text = openFileDialog.FileName;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //0=初始化/新增，1=编辑
            if (ACTION == 0)
            {

            }
            //0=初始化/新增，1=编辑
            else if (ACTION == 1)
            {

            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            //修改控件状态
            SetAddEditControlState(ACTION);
        }
    }
}