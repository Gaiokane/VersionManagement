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
        public UCSystemConfiguration()
        {
            InitializeComponent();
        }

        private void UCSystemConfiguration_Load(object sender, EventArgs e)
        {
            BindDGV();
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
    }
}