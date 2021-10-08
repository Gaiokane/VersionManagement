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
    public partial class UCVersionConfiguration : UserControl
    {
        //0=初始化，1=新增，2=编辑
        int ACTION = 0;

        public UCVersionConfiguration()
        {
            InitializeComponent();
        }

        private void UCVersionConfiguration_Load(object sender, EventArgs e)
        {
            //绑定DGV数据
            BindDGV();

            //新增/编辑版本配置默认隐藏
            GroupBoxAddEdit.Visible = false;

            //新增/编辑版本配置-RichTextBox增加右键菜单
            _ = new RichTextBoxMenu(RichTextBoxVersionDescription);

            //新增/编辑版本配置-发布时间格式
            DateTimePickerReleaseDate.Format = DateTimePickerFormat.Custom;
            DateTimePickerReleaseDate.CustomFormat = "yyyy-MM-dd";
        }

        #region 重新绑定 版本信息 DGV数据
        /// <summary>
        /// 重新绑定 版本信息 DGV数据
        /// </summary>
        private void BindDGV()
        {
            DGV.Rows.Clear();
            List<string> list;
            list = VersionConfig.GetappSettingsSplitBySemicolon("Version", ';');
            DGV.Rows.Add(list.Count);
            //将list中元素倒叙
            list.Reverse();
            for (int i = 0; i < list.Count; i++)
            {
                List<string> detailslist = VersionConfig.GetappSettingsSplitBySemicolon(list[i], ';');
                //VersionNumber 版本号
                DGV.Rows[i].Cells["VersionNumber"].Value = list[i].Split('_')[1];
                //VersionDescription 版本说明
                DGV.Rows[i].Cells["VersionDescription"].Value = detailslist[0];
                //ReleaseDate 发布时间
                DGV.Rows[i].Cells["ReleaseDate"].Value = detailslist[1];
            }
            DGV.ClearSelection();
        }
        #endregion

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            //0=初始化，1=新增，2=编辑
            ACTION = 1;
            //修改控件状态
            SetAddEditControlState(ACTION);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (DGV.Rows.Count == 0)
            {
                MessageBox.Show("没有要编辑的数据！");
            }
            else
            {
                if (DGV.SelectedRows.Count == 0)
                {
                    MessageBox.Show("请选择要编辑的数据！");
                }
                else
                {
                    //0=初始化，1=新增，2=编辑
                    ACTION = 2;
                    //修改控件状态
                    SetAddEditControlState(ACTION);
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (DGV.Rows.Count == 0)
            {
                MessageBox.Show("没有要删除的数据！");
            }
            else
            {
                if (DGV.SelectedRows.Count == 0)
                {
                    MessageBox.Show("请选择要删除的数据！");
                }
                else
                {
                    if (DialogResult.OK == MessageBox.Show("确认删除版本号：" + DGV.SelectedCells[0].Value.ToString() + "？", "确认删除？", MessageBoxButtons.OKCancel))
                    {
                        if (VersionConfig.DelappSettingsByValue("Version", "Version_" + DGV.SelectedCells[0].Value.ToString(), ';'))
                        {
                            MessageBox.Show("删除成功！");
                            BindDGV();
                        }
                        else
                        {
                            MessageBox.Show("删除失败！");
                            BindDGV();
                        }
                    }
                }
            }
        }

        private void SetAddEditControlState(int action)
        {
            //0=初始化，1=新增，2=编辑
            if (action == 0)
            {
                GroupBoxAddEdit.Visible = false;
                TextBoxVersionNumber.Enabled = true;

                BtnAdd.Enabled = true;
                BtnEdit.Enabled = true;
                BtnDelete.Enabled = true;
            }
            else if (action == 1)
            {
                GroupBoxAddEdit.Text = "新增版本配置";
                TextBoxVersionNumber.Text = "";
                DateTimePickerReleaseDate.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                RichTextBoxVersionDescription.Text = "";
                GroupBoxAddEdit.Visible = true;

                TextBoxVersionNumber.Focus();

                BtnAdd.Enabled = false;
                BtnEdit.Enabled = false;
                BtnDelete.Enabled = false;
            }
            else if (action == 2)
            {
                GroupBoxAddEdit.Text = "编辑版本配置";
                TextBoxVersionNumber.Text = DGV.SelectedCells[0].Value.ToString();
                TextBoxVersionNumber.Enabled = false;
                DateTimePickerReleaseDate.Value = Convert.ToDateTime(DGV.SelectedCells[2].Value.ToString());
                RichTextBoxVersionDescription.Text = DGV.SelectedCells[1].Value.ToString();
                GroupBoxAddEdit.Visible = true;

                RichTextBoxVersionDescription.Focus();
                RichTextBoxVersionDescription.SelectionStart = RichTextBoxVersionDescription.Text.Length;

                BtnAdd.Enabled = false;
                BtnEdit.Enabled = false;
                BtnDelete.Enabled = false;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!(CheckHelper.IsStringContainsUnderscoreSemicolon(TextBoxVersionNumber.Text.Trim()) && CheckHelper.IsStringContainsUnderscoreSemicolon(RichTextBoxVersionDescription.Text.Trim())))
            {
                MessageBox.Show(CheckHelper.messageUnderscoreSemicolon);
            }
            else
            {
                //0=初始化，1=新增，2=编辑
                if (ACTION == 1)
                {
                    //< add key = "Version" value = "Version_V5.0.0;Version_V5.0.1" />
                    //< add key = "Version_V5.0.0" value = "V5.0.0初始版本;2021-07-31;" />
                    //获取所有Version
                    List<string> temp = VersionConfig.GetappSettingsSplitBySemicolon("Version", ';');
                    //校验重复
                    if (temp.Contains("Version_" + TextBoxVersionNumber.Text.Trim()))
                    {
                        MessageBox.Show("已存在相同版本号，请确认！");
                        TextBoxVersionNumber.SelectAll();
                        TextBoxVersionNumber.Focus();
                    }
                    else
                    {
                        bool modifyVersion = VersionConfig.EditappSettingsAddValue("Version", "Version_" + TextBoxVersionNumber.Text.Trim(), ';');
                        bool addVerison = VersionConfig.AddappSettings("Version_" + TextBoxVersionNumber.Text.Trim(), RichTextBoxVersionDescription.Text.Trim() + ";" + DateTimePickerReleaseDate.Value.ToString("yyyy-MM-dd") + ";");
                        if (modifyVersion && addVerison)
                        {
                            MessageBox.Show("新增成功！");
                            //恢复控件状态
                            SetAddEditControlState(0);
                        }
                        else
                        {
                            MessageBox.Show("新增失败！");
                        }
                    }
                }
                else if (ACTION == 2)
                {
                    bool editVerison = VersionConfig.AddappSettings("Version_" + TextBoxVersionNumber.Text.Trim(), RichTextBoxVersionDescription.Text.Trim() + ";" + DateTimePickerReleaseDate.Value.ToString("yyyy-MM-dd") + ";");
                    if (editVerison)
                    {
                        MessageBox.Show("编辑成功！");
                        //恢复控件状态
                        SetAddEditControlState(0);
                    }
                    else
                    {
                        MessageBox.Show("编辑失败！");
                    }

                }
                BindDGV();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            //0=初始化，1=新增，2=编辑
            ACTION = 0;
            //修改控件状态
            SetAddEditControlState(ACTION);
            BindDGV();
        }
    }
}