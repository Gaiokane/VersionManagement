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
        //版本对应系统详情key
        public string DETAILMAINGUID = "";
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
            ComboBoxCorrespondingDatabase.Items.Add("");
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
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "选择SQL文件",
                Filter = "SQL文件(*.sql)|*.sql"
            };
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
                //MessageBox.Show(DETAILMAINGUID);

                //先判断是否有 Detail_版本号_对应系统_Ids（Detail_V100_Base_Ids）
                //没有则新增，值默认0
                //有则取出来
                //将取出的Ids+1后拼上Detail_版本号_对应系统_保存
                //更新Ids

                //拼接所选版本
                string detailversion = "Detail_" + ComboBoxVersionNumber.SelectedItem.ToString();
                //拼接所选版本对应系统的Key
                string detailmainkey = detailversion + "_" + VersionConfig.GetappSettingsKeyByValue("System", ';', ComboBoxCorrespondingSystem.SelectedItem.ToString()).Split('_')[1];
                //拼接所选版本对应系统Ids的Key
                string detailmainguid = detailmainkey + "_Ids";
                //获取Ids对应Value
                string ids = VersionConfig.GetappSettings(detailmainguid);
                //如果Ids为空，说明第一次新增，初始化Value为0
                if (string.IsNullOrEmpty(ids) && !VersionConfig.AddappSettings(detailmainguid, "0"))
                {
                    //报错则提示
                    MessageBox.Show("初始化Ids错误");
                }
                //在原Ids上+1生成新Ids
                int newIds = Convert.ToInt32(VersionConfig.GetappSettings(detailmainguid)) + 1;
                //拼接所选版本对应系统Ids的新Key
                string newdetailmainguid = detailmainkey + "_" + newIds.ToString();

                //value中内容以;隔开
                string addValue =
                    //第一项为类型（存编码）
                    VersionConfig.GetappSettingsKeyByValue("Type", ';', ComboBoxType.SelectedItem.ToString()) + ";" +
                    //第二项为排序值
                    TextBoxOrderNum.Text.Trim() + ";" +
                    //第三项为发布内容
                    TextBoxPublishContent.Text.Trim() + ";" +
                    //第四项为详细描述
                    RichTextBoxDescription.Text.Trim() + ";" +
                    //第五项为备注
                    RichTextBoxRemark.Text.Trim() + ";" +
                    //第六项为对应数据库（存编码）
                    DefaultConfig.GetappSettingsKeyByValue("Database", ';', ComboBoxCorrespondingDatabase.SelectedItem.ToString()) + ";" +
                    //第七项为SQL脚本
                    TextBoxSQLScriptPath.Text.Trim() + ";";

                bool addDetails;
                //Details中不存在Detail_版本号，则新增
                if (!VersionConfig.IsappSettingsValueExistsBySemicolon("Details", ';', detailversion))
                {
                    addDetails = VersionConfig.EditappSettingsAddValue("Details", detailversion, ';');
                }

                bool addDetailVersion;
                //不存在Detail_版本号，新增
                if (!VersionConfig.IsappSettingsExists(detailversion))
                {
                    addDetailVersion = VersionConfig.AddappSettings(detailversion, detailmainkey + ";");
                }
                //存在，修改Detail_版本号值，存对应系统
                else
                {
                    //如果Value中没有重复项，则新增
                    if (!VersionConfig.IsappSettingsValueExistsBySemicolon(detailversion, ';', detailmainkey))
                    {
                        addDetailVersion = VersionConfig.EditappSettingsAddValue(detailversion, detailmainkey, ';');
                    }
                    //有重复项
                    else
                    {
                        addDetailVersion = true;
                    }
                }

                bool addDetailVersionSystem;
                //不存在Detail_版本_对应系统，新增
                if (!VersionConfig.IsappSettingsExists(detailmainkey))
                {
                    addDetailVersionSystem = VersionConfig.AddappSettings(detailmainkey, newdetailmainguid + ";");
                }
                //存在，修改Detail_版本_对应系统值，存Detail_版本_对应系统_Ids
                else
                {
                    addDetailVersionSystem = VersionConfig.EditappSettingsAddValue(detailmainkey, newdetailmainguid, ';');
                }


                //新增版本对应系统详情
                bool addDetail = VersionConfig.AddappSettings(newdetailmainguid, addValue);
                //更新Ids
                bool modifyIds = VersionConfig.EditappSettings(detailmainguid, newIds.ToString());
                if (addDetailVersion && addDetailVersionSystem && addDetail && modifyIds)
                {
                    MessageBox.Show("新增成功！");
                    //恢复控件状态
                    SetAddEditControlState(ACTION);
                }
                else
                {
                    MessageBox.Show("新增失败！");
                }
            }
            //0=初始化/新增，1=编辑
            else if (ACTION == 1)
            {
                //MessageBox.Show(DETAILMAINGUID);

                //value中内容以;隔开
                string editValue =
                    //第一项为类型（存编码）
                    VersionConfig.GetappSettingsKeyByValue("Type", ';', ComboBoxType.SelectedItem.ToString()) + ";" +
                    //第二项为排序值
                    TextBoxOrderNum.Text.Trim() + ";" +
                    //第三项为发布内容
                    TextBoxPublishContent.Text.Trim() + ";" +
                    //第四项为详细描述
                    RichTextBoxDescription.Text.Trim() + ";" +
                    //第五项为备注
                    RichTextBoxRemark.Text.Trim() + ";" +
                    //第六项为对应数据库（存编码）
                    DefaultConfig.GetappSettingsKeyByValue("Database", ';', ComboBoxCorrespondingDatabase.SelectedItem.ToString()) + ";" +
                    //第七项为SQL脚本
                    TextBoxSQLScriptPath.Text.Trim() + ";";
                bool editDetail = VersionConfig.AddappSettings(DETAILMAINGUID, editValue);
                if (editDetail)
                {
                    MessageBox.Show("编辑成功！");
                }
                else
                {
                    MessageBox.Show("编辑失败！");
                }
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            //修改控件状态
            SetAddEditControlState(ACTION);
        }
    }
}