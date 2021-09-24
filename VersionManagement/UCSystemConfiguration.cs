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
    public partial class UCSystemConfiguration : UserControl
    {
        //0=初始化，1=新增，2=编辑
        int ACTION = 0;

        public UCSystemConfiguration()
        {
            InitializeComponent();
        }

        private void UCSystemConfiguration_Load(object sender, EventArgs e)
        {
            //绑定DGV数据
            BindDGV();

            //新增/编辑版本默认隐藏
            GroupBoxAddEdit.Visible = false;
        }

        #region 重新绑定 系统信息 DGV数据
        /// <summary>
        /// 重新绑定 系统信息 DGV数据
        /// </summary>
        private void BindDGV()
        {
            DGV.Rows.Clear();
            List<string> list;
            list = VersionConfig.GetappSettingsSplitBySemicolon("System", ';');
            DGV.Rows.Add(list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                List<string> detailslist = VersionConfig.GetappSettingsSplitBySemicolon(list[i], ';');
                //SystemCode 系统编码
                DGV.Rows[i].Cells["SystemCode"].Value = list[i];
                //SystemName 系统名称
                DGV.Rows[i].Cells["SystemName"].Value = detailslist[0];
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
                    if (DialogResult.OK == MessageBox.Show("确认删除系统编码：" + DGV.SelectedCells[0].Value.ToString() + "？", "确认删除？", MessageBoxButtons.OKCancel))
                    {
                        if (VersionConfig.DelappSettingsByValue("System", DGV.SelectedCells[0].Value.ToString(), ';'))
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
                TextBoxSystemCode.Enabled = true;

                BtnAdd.Enabled = true;
                BtnEdit.Enabled = true;
                BtnDelete.Enabled = true;
            }
            else if (action == 1)
            {
                GroupBoxAddEdit.Text = "新增系统配置";
                TextBoxSystemCode.Text = "";
                TextBoxSystemName.Text = "";
                GroupBoxAddEdit.Visible = true;

                TextBoxSystemCode.Focus();

                BtnAdd.Enabled = false;
                BtnEdit.Enabled = false;
                BtnDelete.Enabled = false;
            }
            else if (action == 2)
            {
                GroupBoxAddEdit.Text = "编辑系统配置";
                //版本号 版本说明 发布时间
                TextBoxSystemCode.Text = DGV.SelectedCells[0].Value.ToString();
                TextBoxSystemCode.Enabled = false;
                TextBoxSystemName.Text = DGV.SelectedCells[1].Value.ToString();
                GroupBoxAddEdit.Visible = true;

                TextBoxSystemName.Focus();
                TextBoxSystemName.SelectionStart = TextBoxSystemName.Text.Length;

                BtnAdd.Enabled = false;
                BtnEdit.Enabled = false;
                BtnDelete.Enabled = false;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //0=初始化，1=新增，2=编辑
            if (ACTION == 1)
            {
                //<add key="System" value="System_Base;System_Air;" />
                //<add key="System_Base" value="基础" />
                //获取所有Version
                List<string> temp = VersionConfig.GetappSettingsSplitBySemicolon("System", ';');
                //校验重复
                if (temp.Contains("System_" + TextBoxSystemCode.Text.Trim()))
                {
                    MessageBox.Show("已存在相同系统编码，请确认！");
                    TextBoxSystemCode.SelectAll();
                    TextBoxSystemCode.Focus();
                }
                else
                {
                    bool modifyVersion = VersionConfig.EditappSettingsAddValue("System", "System_" + TextBoxSystemCode.Text.Trim(), ';');
                    bool addVerison = VersionConfig.AddappSettings("System_" + TextBoxSystemCode.Text.Trim(), TextBoxSystemName.Text.Trim() + ";");
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
                bool editVerison = VersionConfig.AddappSettings(TextBoxSystemCode.Text.Trim(), TextBoxSystemName.Text.Trim() + ";");
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