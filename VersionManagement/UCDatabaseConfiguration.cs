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
    public partial class UCDatabaseConfiguration : UserControl
    {
        //0=初始化，1=新增，2=编辑
        int ACTION = 0;

        public UCDatabaseConfiguration()
        {
            InitializeComponent();
        }

        private void UCDatabaseConfiguration_Load(object sender, EventArgs e)
        {
            //绑定DGV数据
            BindDGV();

            //新增/编辑数据库配置默认隐藏
            GroupBoxAddEdit.Visible = false;
        }

        #region 重新绑定 数据库信息 DGV数据
        /// <summary>
        /// 重新绑定 数据库信息 DGV数据
        /// </summary>
        private void BindDGV()
        {
            DGV.Rows.Clear();
            List<string> list;
            list = DefaultConfig.GetappSettingsSplitBySemicolon("Database", ';');
            DGV.Rows.Add(list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                List<string> detailslist = DefaultConfig.GetappSettingsSplitBySemicolon(list[i], ';');
                //DatabaseCode 数据库编码
                DGV.Rows[i].Cells["DatabaseCode"].Value = list[i].Split('_')[1];
                //DatabaseName 数据库名
                DGV.Rows[i].Cells["DatabaseName"].Value = detailslist[0];
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
                    if (DialogResult.OK == MessageBox.Show("确认删除数据库编码：" + DGV.SelectedCells[0].Value.ToString() + "？", "确认删除？", MessageBoxButtons.OKCancel))
                    {
                        if (DefaultConfig.DelappSettingsByValue("Database", "Database_" + DGV.SelectedCells[0].Value.ToString(), ';'))
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
                TextBoxDatabaseCode.Enabled = true;

                BtnAdd.Enabled = true;
                BtnEdit.Enabled = true;
                BtnDelete.Enabled = true;
            }
            else if (action == 1)
            {
                GroupBoxAddEdit.Text = "新增数据库配置";
                TextBoxDatabaseCode.Text = "";
                TextBoxDatabaseName.Text = "";
                GroupBoxAddEdit.Visible = true;

                TextBoxDatabaseCode.Focus();

                BtnAdd.Enabled = false;
                BtnEdit.Enabled = false;
                BtnDelete.Enabled = false;
            }
            else if (action == 2)
            {
                GroupBoxAddEdit.Text = "编辑数据库配置";
                TextBoxDatabaseCode.Text = DGV.SelectedCells[0].Value.ToString();
                TextBoxDatabaseCode.Enabled = false;
                TextBoxDatabaseName.Text = DGV.SelectedCells[1].Value.ToString();
                GroupBoxAddEdit.Visible = true;

                TextBoxDatabaseName.Focus();
                TextBoxDatabaseName.SelectionStart = TextBoxDatabaseName.Text.Length;

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
                //<add key="Database" value="Database_BaseData;Database_Air;" />
                //< add key = "Database_BaseData" value = "AMS_BaseData" />
                //获取所有Database
                List<string> temp = DefaultConfig.GetappSettingsSplitBySemicolon("Database", ';');
                //校验重复
                if (temp.Contains("Database_" + TextBoxDatabaseCode.Text.Trim()))
                {
                    MessageBox.Show("已存在相同类型编码，请确认！");
                    TextBoxDatabaseCode.SelectAll();
                    TextBoxDatabaseCode.Focus();
                }
                else
                {
                    bool modifyVersion = DefaultConfig.EditappSettingsAddValue("Database", "Database_" + TextBoxDatabaseCode.Text.Trim(), ';');
                    bool addVerison = DefaultConfig.AddappSettings("Database_" + TextBoxDatabaseCode.Text.Trim(), TextBoxDatabaseName.Text.Trim() + ";");
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
                bool editVerison = DefaultConfig.AddappSettings("Database_" + TextBoxDatabaseCode.Text.Trim(), TextBoxDatabaseName.Text.Trim() + ";");
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