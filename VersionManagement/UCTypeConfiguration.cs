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
        public UCTypeConfiguration()
        {
            InitializeComponent();
        }

        private void UCTypeConfiguration_Load(object sender, EventArgs e)
        {
            BindDGV();
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
                DGV.Rows[i].Cells["TypeCode"].Value = list[i];
                //TypeName 类型名称
                DGV.Rows[i].Cells["TypeName"].Value = detailslist[0];
            }
            DGV.ClearSelection();
        }
        #endregion
    }
}
