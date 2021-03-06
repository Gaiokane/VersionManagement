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
    public partial class UCVersionInformation : UserControl
    {
        //窗体传值 FormMain FormMain_Load
        //窗体传值 FormMain 版本信息ToolStripMenuItem_Click
        public Panel panel = new Panel();

        public UCVersionInformation()
        {
            InitializeComponent();
        }

        private void UCVersionInformation_Load(object sender, EventArgs e)
        {
            //版本号 下拉框修改样式
            ComboBoxVersionNumber.DropDownStyle = ComboBoxStyle.DropDownList;
            //对应系统 下拉框修改样式
            ComboBoxCorrespondingSystem.DropDownStyle = ComboBoxStyle.DropDownList;

            //重新绑定 版本号 下拉框数据
            BindComboBoxVersionNumber();
            //重新绑定 对应系统 下拉框数据
            BindComboBoxCorrespondingSystem();

            //DGV表头居中
            DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //DGV内容居中
            DGV.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //配合FormMain FormMain_Load/版本信息ToolStripMenuItem_Click uc.Dock/panel1.Anchor 使用，DGV跟随窗体大小动态变动
            DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            BindDGV();
        }

        #region 重新绑定 版本号 下拉框数据
        /// <summary>
        /// 重新绑定 版本号 下拉框数据
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

        #region 重新绑定 对应系统 下拉框数据
        /// <summary>
        /// 重新绑定 对应系统 下拉框数据
        /// </summary>
        private void BindComboBoxCorrespondingSystem()
        {
            //获取全部系统类型
            /*
            ComboBoxCorrespondingSystem.Items.Clear();
            ComboBoxCorrespondingSystem.Items.Add("全部");
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
            */

            //获取所选版本号对应系统类型
            ComboBoxCorrespondingSystem.Items.Clear();
            ComboBoxCorrespondingSystem.Items.Add("全部");
            //获取版本号下拉框所选内容 V100
            string selectVersionNum = ComboBoxVersionNumber.SelectedItem.ToString();
            //版本号前面拼上Detail_查所选版本对应系统 Detail_V100
            List<string> listversionDetail = VersionConfig.GetappSettingsSplitBySemicolon("Detail_" + selectVersionNum, ';');
            foreach (var item in listversionDetail)
            {
                //获取所选版本号对应系统后缀 Air
                string versionNumSystem = item.Split('_')[2];
                //根据对应系统编码查询出对应系统名称，添加到下拉框
                ComboBoxCorrespondingSystem.Items.Add(VersionConfig.GetappSettings("System_" + versionNumSystem));
            }
            if (ComboBoxCorrespondingSystem.Items.Count > 0)
            {
                ComboBoxCorrespondingSystem.SelectedIndex = 0;
            }
        }
        #endregion

        #region 重新绑定 版本详情 DGV数据
        /// <summary>
        /// 重新绑定 版本详情 DGV数据
        /// </summary>
        private void BindDGV()
        {
            DGV.Rows.Clear();

            #region DGV测试数据
            DGV.Rows.Add(6);
            DGV.Rows[0].Cells["No"].Value = "1";
            DGV.Rows[0].Cells["CorrespondingSystem"].Value = "环境空气";
            DGV.Rows[0].Cells["Type"].Value = "类型";
            DGV.Rows[0].Cells["PublishContent"].Value = "发布内容";
            DGV.Rows[0].Cells["Description"].Value = "详细描述";
            DGV.Rows[0].Cells["Remark"].Value = "备注";
            DGV.Rows[0].Cells["CorrespondingDatabase"].Value = "对应数据库";
            DGV.Rows[0].Cells["SQLScriptPath"].Value = "SQL脚本";
            DGV.Rows[0].Cells["IsExecuted"].Value = true;
            DGV.Rows[0].Cells["ExecuteSQLScript"].Value = "执行";
            DGV.Rows[0].Cells["Edit"].Value = "编辑";
            DGV.Rows[0].Cells["Delete"].Value = "删除";

            DGV.Rows[1].Cells["No"].Value = "2";
            DGV.Rows[1].Cells["CorrespondingSystem"].Value = "环境空气";
            DGV.Rows[1].Cells["Type"].Value = "类型";
            DGV.Rows[1].Cells["ExecuteSQLScript"].Value = "执行";
            DGV.Rows[1].Cells["Edit"].Value = "编辑";
            DGV.Rows[1].Cells["Delete"].Value = "删除";

            DGV.Rows[2].Cells["No"].Value = "3";
            DGV.Rows[2].Cells["CorrespondingSystem"].Value = "地表水";
            DGV.Rows[2].Cells["Type"].Value = "类型";
            DGV.Rows[2].Cells["ExecuteSQLScript"].Value = "执行";
            DGV.Rows[2].Cells["Edit"].Value = "编辑";
            DGV.Rows[2].Cells["Delete"].Value = "删除";

            DGV.Rows[3].Cells["No"].Value = "4";
            DGV.Rows[3].Cells["CorrespondingSystem"].Value = "环境空气";
            DGV.Rows[3].Cells["Type"].Value = "类型";
            DGV.Rows[3].Cells["ExecuteSQLScript"].Value = "执行";
            DGV.Rows[3].Cells["Edit"].Value = "编辑";
            DGV.Rows[3].Cells["Delete"].Value = "删除";

            DGV.Rows[4].Cells["No"].Value = "5";
            DGV.Rows[4].Cells["CorrespondingSystem"].Value = "基础";
            DGV.Rows[4].Cells["Type"].Value = "类型";
            DGV.Rows[4].Cells["ExecuteSQLScript"].Value = "执行";
            DGV.Rows[4].Cells["Edit"].Value = "编辑";
            DGV.Rows[4].Cells["Delete"].Value = "删除";

            DGV.Rows[5].Cells[0].Value = "6";
            DGV.Rows[5].Cells[1].Value = "";
            DGV.Rows[5].Cells[2].Value = "";
            #endregion

            #region 动态获取数据
            //配置文件中取出对应数据，总行数添加到dgv，遍历存到各列
            DGV.Rows.Clear();
            //版本号，去掉前缀
            //string VersionNumber = "V100";
            string VersionNumber = ComboBoxVersionNumber.SelectedItem.ToString();
            //对应系统，去掉前缀
            //string CorrespondingSystem = "Base";
            List<string> CorrespondingSystemList = new List<string>();
            if (ComboBoxCorrespondingSystem.Items.Count > 0)
            {
                CorrespondingSystemList.Add(ComboBoxCorrespondingSystem.SelectedItem.ToString());
            }
            if (CorrespondingSystemList.Count > 0 && CorrespondingSystemList[0] == "全部")
            {
                CorrespondingSystemList.Clear();
                foreach (var item in ComboBoxCorrespondingSystem.Items)
                {
                    CorrespondingSystemList.Add(item.ToString());
                }
                CorrespondingSystemList.Remove("全部");
            }
            foreach (var findValue in CorrespondingSystemList)
            {
                //获取对应系统下拉框所选项对应的key
                string SystemKey = VersionConfig.GetappSettingsKeyByValue("System", ';', findValue);
                string CorrespondingSystem = "";
                if (!string.IsNullOrEmpty(SystemKey))
                {
                    CorrespondingSystem = SystemKey.Split('_')[1];
                }

                //选择版本号+某一个系统
                List<string> list;
                string detailVersionSystem = "Detail_" + VersionNumber + "_" + CorrespondingSystem;
                list = VersionConfig.GetappSettingsSplitBySemicolon(detailVersionSystem, ';');
                //所选版本对应系统有版本信息
                if (list.Count > 0)
                {
                    DGV.Rows.Add(list.Count);
                    int checkCount;
                    if (DGV.Rows.Count == list.Count)
                    {
                        checkCount = 0;
                    }
                    else
                    {
                        checkCount = DGV.Rows.Count - list.Count;
                    }
                    for (int i = 0; i < list.Count; i++)
                    {
                        List<string> detailslist = VersionConfig.GetappSettingsSplitBySemicolon(list[i], ';', false);
                        //序号，按排序号排序后序号会乱，后面重新渲染
                        //DGV.Rows[i].Cells["No"].Value = i + 1;

                        //版本对应系统详情key，编辑根据该字段修改对应键值对
                        DGV.Rows[checkCount].Cells["DetailMainGuid"].Value = list[i];
                        //版本对应系统key，根据该字段删除对应值
                        DGV.Rows[checkCount].Cells["DetailVersionSystem"].Value = detailVersionSystem;
                        //对应系统
                        DGV.Rows[checkCount].Cells["CorrespondingSystem"].Value = VersionConfig.GetappSettings(SystemKey);
                        //类型
                        DGV.Rows[checkCount].Cells["Type"].Value = VersionConfig.GetappSettings(detailslist[0]);
                        //排序号，列表隐藏，用作数据排序
                        DGV.Rows[checkCount].Cells["SortNum"].Value = Convert.ToInt32(detailslist[1]);
                        //发布内容
                        DGV.Rows[checkCount].Cells["PublishContent"].Value = detailslist[2];
                        //详细描述
                        DGV.Rows[checkCount].Cells["Description"].Value = detailslist[3];
                        //备注
                        DGV.Rows[checkCount].Cells["Remark"].Value = detailslist[4];
                        //对应数据库
                        DGV.Rows[checkCount].Cells["CorrespondingDatabase"].Value = DefaultConfig.GetappSettings(detailslist[5]);
                        //SQL脚本
                        DGV.Rows[checkCount].Cells["SQLScriptPath"].Value = detailslist[6];
                        //是否已执行
                        string executionStatus = ExecutionStatusConfig.GetappSettings("ExecutionStatus_" + list[i]);
                        if (string.IsNullOrEmpty(executionStatus))
                        {
                            DGV.Rows[checkCount].Cells["IsExecuted"].Value = false;
                        }
                        else if (executionStatus.Split(';')[0] == "1")
                        {
                            DGV.Rows[checkCount].Cells["IsExecuted"].Value = true;
                        }
                        else
                        {
                            DGV.Rows[checkCount].Cells["IsExecuted"].Value = false;
                        }
                        //执行按钮文字
                        DGV.Rows[checkCount].Cells["ExecuteSQLScript"].Value = "执行";
                        //编辑按钮文字
                        DGV.Rows[checkCount].Cells["Edit"].Value = "编辑";
                        //删除按钮文字
                        DGV.Rows[checkCount].Cells["Delete"].Value = "删除";
                        checkCount++;
                    }
                    //列表按排序号降序显示
                    DGV.Sort(DGV.Columns["SortNum"], ListSortDirection.Descending);
                    //排序后对序号列重新渲染
                    for (int i = 0; i < DGV.Rows.Count; i++)
                    {
                        DGV.Rows[i].Cells["No"].Value = i + 1;
                    }
                }
            }
            #endregion

            DGV.ClearSelection();
        }
        #endregion

        //合并指定列相同单元格
        private void DGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // 序号合并单元格的集合
            List<int> MergeCellsList = new List<int> { 1, 2 };

            foreach (var MergeCells in MergeCellsList)
            {
                Brush gridBrush = new SolidBrush(this.DGV.GridColor);
                SolidBrush backBrush = new SolidBrush(e.CellStyle.BackColor);
                SolidBrush fontBrush = new SolidBrush(e.CellStyle.ForeColor);
                int cellheight;
                int fontheight;
                int cellwidth;
                int fontwidth;
                int countU = 0;
                int countD = 0;
                int count = 0;
                // 对第MergeCells列相同单元格进行合并
                if (e.ColumnIndex == MergeCells && e.RowIndex != -1)
                {
                    cellheight = e.CellBounds.Height;
                    fontheight = (int)e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Height;
                    cellwidth = e.CellBounds.Width;
                    fontwidth = (int)e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Width;
                    Pen gridLinePen = new Pen(gridBrush);
                    string curValue = e.Value == null ? "" : e.Value.ToString().Trim();
                    string curSelected = this.DGV.Rows[e.RowIndex].Cells[MergeCells].Value == null ? ""
                    : this.DGV.Rows[e.RowIndex].Cells[MergeCells].Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(curValue))
                    {
                        for (int i = e.RowIndex; i < this.DGV.Rows.Count; i++)
                        {
                            if (this.DGV.Rows[i].Cells[MergeCells].Value.ToString().Equals(curValue))
                            {
                                this.DGV.Rows[i].Cells[MergeCells].Selected = this.DGV.Rows[e.RowIndex].Selected;
                                this.DGV.Rows[i].Selected = this.DGV.Rows[e.RowIndex].Selected;
                                countD++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        for (int i = e.RowIndex; i >= 0; i--)
                        {
                            if (this.DGV.Rows[i].Cells[MergeCells].Value.ToString().Equals(curValue))
                            {
                                this.DGV.Rows[i].Cells[MergeCells].Selected = this.DGV.Rows[e.RowIndex].Selected;
                                this.DGV.Rows[i].Selected = this.DGV.Rows[e.RowIndex].Selected;
                                countU++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        count = countD + countU - 1;
                        if (count < 2) { return; }
                    }
                    if (this.DGV.Rows[e.RowIndex].Selected)
                    {
                        backBrush.Color = e.CellStyle.SelectionBackColor;
                        fontBrush.Color = e.CellStyle.SelectionForeColor;
                    }
                    e.Graphics.FillRectangle(backBrush, e.CellBounds);
                    e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + 10, e.CellBounds.Y - cellheight * (countU - 1) + (cellheight * count - fontheight) / 2);
                    if (countD == 1)
                    {
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                        count = 0;
                    }
                    // 画右边线
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                    e.Handled = true;
                }
            }
        }

        //执行、编辑、删除列点击事件
        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //执行
            if (e.ColumnIndex == 9)
            {
                //MessageBox.Show("执行\r\n序号：" + DGV.Rows[e.RowIndex].Cells[0].Value + "\r\n对应系统：" + DGV.Rows[e.RowIndex].Cells[1].Value);

                //获取程序根目录
                string rootPath = Environment.CurrentDirectory;
                //获取DGV中的SQL脚本名称
                string DGVSQLScriptPath = DGV.Rows[e.RowIndex].Cells["SQLScriptPath"].Value.ToString();
                //获取DGV中的对应数据库名称
                string CorrespondingDatabase = DGV.Rows[e.RowIndex].Cells["CorrespondingDatabase"].Value.ToString();
                //拼接SQL脚本完整路径
                string SQLScriptPath = rootPath + "\\SQLScripts\\" + DGVSQLScriptPath;

                //没有要执行的脚本
                if (string.IsNullOrEmpty(DGVSQLScriptPath))
                {
                    MessageBox.Show("没有要执行的脚本", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                //有脚本可执行
                else
                {
                    string executedKey = "ExecutionStatus_" + DGV.Rows[e.RowIndex].Cells["DetailMainGuid"].Value.ToString();
                    List<string> DBConn = DefaultConfig.GetappSettingsSplitBySemicolon("DatabaseConn", ';');
                    string executeCmd = @".\SQLCMD.EXE -S " + DBConn[0] + " -U " + DBConn[1] + " -P " + DBConn[2] + " -d " + CorrespondingDatabase + " -i " + SQLScriptPath;
                    //已执行
                    if (DGV.Rows[e.RowIndex].Cells["IsExecuted"].Value.ToString() == "True")
                    {
                        string executedCount = ExecutionStatusConfig.GetappSettingsSplitBySemicolon(executedKey, ';')[1];
                        if (DialogResult.OK == MessageBox.Show("该脚本已执行过 " + executedCount + " 次，是否再次执行？", "确认执行？", MessageBoxButtons.OKCancel))
                        {
                            //执行
                            string RunCmdResult = CMDHelper.RunCmd(rootPath, executeCmd);
                            if (string.IsNullOrEmpty(RunCmdResult) && ExecutionStatusConfig.EditappSettings(executedKey, "1;" + (Convert.ToInt32(executedCount) + 1).ToString()))
                            {
                                MessageBox.Show("执行成功！");
                            }
                            else
                            {
                                MessageBox.Show("执行失败！\r\n" + RunCmdResult);
                            }
                        }
                    }
                    //未执行
                    else
                    {
                        if (DialogResult.OK == MessageBox.Show("确认执行该脚本？", "确认执行？", MessageBoxButtons.OKCancel))
                        {
                            //执行
                            string RunCmdResult = CMDHelper.RunCmd(rootPath, executeCmd);
                            if (string.IsNullOrEmpty(RunCmdResult) && ExecutionStatusConfig.AddappSettings(executedKey, "1;1"))
                            {
                                MessageBox.Show("执行成功！");
                            }
                            else
                            {
                                MessageBox.Show("执行失败！\r\n" + RunCmdResult);
                            }
                        }
                    }
                    BindDGV();
                }
            }
            //编辑
            if (e.ColumnIndex == 10)
            {
                //MessageBox.Show("编辑\r\n序号：" + DGV.Rows[e.RowIndex].Cells[0].Value + "\r\n对应系统：" + DGV.Rows[e.RowIndex].Cells[1].Value);
                UCAddEditVersionInformation uc = new UCAddEditVersionInformation
                {
                    DETAILMAINGUID = DGV.Rows[e.RowIndex].Cells["DetailMainGuid"].Value.ToString(),
                    VERSIONNUMBER = ComboBoxVersionNumber.SelectedItem.ToString(),
                    CORRESPONDINGSYSTEM = DGV.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    TYPE = DGV.Rows[e.RowIndex].Cells[2].Value.ToString(),
                    ORDERNUM = DGV.Rows[e.RowIndex].Cells["SortNum"].Value.ToString(),
                    PUBLISHCONTENT = DGV.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    DESCRIPTION = DGV.Rows[e.RowIndex].Cells[4].Value.ToString(),
                    REMARK = DGV.Rows[e.RowIndex].Cells[5].Value.ToString(),
                    CORRESPONDINGDATABASE = DGV.Rows[e.RowIndex].Cells[6].Value.ToString(),
                    SQLSCRIPTPATH = DGV.Rows[e.RowIndex].Cells[7].Value.ToString(),
                    ACTION = 1
                };
                panel.Controls.Clear();
                panel.Controls.Add(uc);
            }
            //删除
            if (e.ColumnIndex == 11)
            {
                //MessageBox.Show("删除\r\n序号：" + DGV.Rows[e.RowIndex].Cells[0].Value + "\r\n对应系统：" + DGV.Rows[e.RowIndex].Cells[1].Value);
                if (DialogResult.OK == MessageBox.Show(
                    "对应系统：" + DGV.Rows[e.RowIndex].Cells["CorrespondingSystem"].Value.ToString() +
                    "\r\n类型：" + DGV.Rows[e.RowIndex].Cells["Type"].Value.ToString() +
                    "\r\n发布内容：" + DGV.Rows[e.RowIndex].Cells["PublishContent"].Value.ToString(),
                    "确认删除该项？", MessageBoxButtons.OKCancel))
                {
                    if (VersionConfig.DelappSettingsByValue(DGV.Rows[e.RowIndex].Cells["DetailVersionSystem"].Value.ToString(), DGV.Rows[e.RowIndex].Cells["DetailMainGuid"].Value.ToString(), ';'))
                    {
                        MessageBox.Show("删除成功！");
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
                    BindDGV();
                }
            }
        }

        private void ComboBoxVersionNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDGV();
            BindComboBoxCorrespondingSystem();
        }

        private void ComboBoxCorrespondingSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDGV();
        }
    }
}