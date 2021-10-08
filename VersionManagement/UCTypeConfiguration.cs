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
    public partial class UCTypeConfiguration : UserControl
    {
        //0=初始化，1=新增，2=编辑
        int ACTION = 0;

        public UCTypeConfiguration()
        {
            InitializeComponent();
        }

        private void UCTypeConfiguration_Load(object sender, EventArgs e)
        {
            //绑定DGV数据
            BindDGV();

            //新增/编辑类型配置默认隐藏
            GroupBoxAddEdit.Visible = false;
        }

        #region 重新绑定 类型信息 DGV数据
        /// <summary>
        /// 重新绑定 类型信息 DGV数据
        /// </summary>
        private void BindDGV()
        {
            DGV.Rows.Clear();
            List<string> list;
            list = VersionConfig.GetappSettingsSplitBySemicolon("Type", ';');
            DGV.Rows.Add(list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                List<string> detailslist = VersionConfig.GetappSettingsSplitBySemicolon(list[i], ';');
                //TypeCode 类型编码
                DGV.Rows[i].Cells["TypeCode"].Value = list[i].Split('_')[1];
                //TypeName 类型名称
                DGV.Rows[i].Cells["TypeName"].Value = detailslist[0];
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
                    if (DialogResult.OK == MessageBox.Show("确认删除类型编码：" + DGV.SelectedCells[0].Value.ToString() + "？", "确认删除？", MessageBoxButtons.OKCancel))
                    {
                        if (VersionConfig.DelappSettingsByValue("Type", "Type_" + DGV.SelectedCells[0].Value.ToString(), ';'))
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
                TextBoxTypeCode.Enabled = true;

                BtnAdd.Enabled = true;
                BtnEdit.Enabled = true;
                BtnDelete.Enabled = true;
            }
            else if (action == 1)
            {
                GroupBoxAddEdit.Text = "新增类型配置";
                TextBoxTypeCode.Text = "";
                TextBoxTypeName.Text = "";
                GroupBoxAddEdit.Visible = true;

                TextBoxTypeCode.Focus();

                BtnAdd.Enabled = false;
                BtnEdit.Enabled = false;
                BtnDelete.Enabled = false;
            }
            else if (action == 2)
            {
                GroupBoxAddEdit.Text = "编辑类型配置";
                TextBoxTypeCode.Text = DGV.SelectedCells[0].Value.ToString();
                TextBoxTypeCode.Enabled = false;
                TextBoxTypeName.Text = DGV.SelectedCells[1].Value.ToString();
                GroupBoxAddEdit.Visible = true;

                TextBoxTypeName.Focus();
                TextBoxTypeName.SelectionStart = TextBoxTypeName.Text.Length;

                BtnAdd.Enabled = false;
                BtnEdit.Enabled = false;
                BtnDelete.Enabled = false;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!(CheckHelper.IsStringContainsUnderscoreSemicolon(TextBoxTypeCode.Text.Trim()) && CheckHelper.IsStringContainsUnderscoreSemicolon(TextBoxTypeName.Text.Trim())))
            {
                MessageBox.Show(CheckHelper.messageUnderscoreSemicolon);
            }
            else
            {
                //0=初始化，1=新增，2=编辑
                if (ACTION == 1)
                {
                    //<add key="Type_BUG" value="BUG" />
                    //< add key = "Type_Optimization" value = "优化" />
                    //< add key = "Type_New" value = "新增" />
                    //获取所有Type
                    List<string> temp = VersionConfig.GetappSettingsSplitBySemicolon("Type", ';');
                    //校验重复
                    if (temp.Contains("Type_" + TextBoxTypeCode.Text.Trim()))
                    {
                        MessageBox.Show("已存在相同类型编码，请确认！");
                        TextBoxTypeCode.SelectAll();
                        TextBoxTypeCode.Focus();
                    }
                    else
                    {
                        bool modifyData = VersionConfig.EditappSettingsAddValue("Type", "Type_" + TextBoxTypeCode.Text.Trim(), ';');
                        bool addData = VersionConfig.AddappSettings("Type_" + TextBoxTypeCode.Text.Trim(), TextBoxTypeName.Text.Trim());
                        if (modifyData && addData)
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
                    bool editData = VersionConfig.AddappSettings("Type_" + TextBoxTypeCode.Text.Trim(), TextBoxTypeName.Text.Trim());
                    if (editData)
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