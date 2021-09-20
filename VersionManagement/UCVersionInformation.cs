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
        public UCVersionInformation()
        {
            InitializeComponent();
        }

        private void UCVersionInformation_Load(object sender, EventArgs e)
        {
            //版本号下拉框修改样式
            ComboBoxVersionNumber.DropDownStyle = ComboBoxStyle.DropDownList;
            //对应系统下拉框修改样式
            ComboBoxCorrespondingSystem.DropDownStyle = ComboBoxStyle.DropDownList;

            //重新绑定版本号下拉框数据
            BindComboBoxVersionNumber();
            //重新绑定对应系统下拉框数据
            BindComboBoxCorrespondingSystem();

            //DGV表头居中
            DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //DGV内容居中
            DGV.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            #region DGV测试数据
            DGV.Rows.Add(5);
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
            #endregion
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
            ComboBoxCorrespondingSystem.Items.Clear();
            List<string> list;
            list = VersionConfig.GetappSettingsSplitBySemicolon("System", ';');
            //将list中元素倒叙
            list.Reverse();
            foreach (var item in list)
            {
                ComboBoxCorrespondingSystem.Items.Add(VersionConfig.GetappSettings(item));
            }
            if (ComboBoxCorrespondingSystem.Items.Count > 0)
            {
                ComboBoxCorrespondingSystem.SelectedIndex = 0;
            }
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
                MessageBox.Show("执行\r\n序号：" + DGV.Rows[e.RowIndex].Cells[0].Value + "\r\n对应系统：" + DGV.Rows[e.RowIndex].Cells[1].Value);
            }
            //编辑
            if (e.ColumnIndex == 10)
            {
                MessageBox.Show("编辑\r\n序号：" + DGV.Rows[e.RowIndex].Cells[0].Value + "\r\n对应系统：" + DGV.Rows[e.RowIndex].Cells[1].Value);
            }
            //删除
            if (e.ColumnIndex == 11)
            {
                MessageBox.Show("删除\r\n序号：" + DGV.Rows[e.RowIndex].Cells[0].Value + "\r\n对应系统：" + DGV.Rows[e.RowIndex].Cells[1].Value);
            }
        }
    }
}