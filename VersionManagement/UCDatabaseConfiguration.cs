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
        public UCDatabaseConfiguration()
        {
            InitializeComponent();
        }

        private void UCDatabaseConfiguration_Load(object sender, EventArgs e)
        {
            BindDGV();
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
                DGV.Rows[i].Cells["DatabaseCode"].Value = list[i];
                //DatabaseName 数据库名
                DGV.Rows[i].Cells["DatabaseName"].Value = detailslist[0];
            }
            DGV.ClearSelection();
        }
        #endregion
    }
}