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
        public UCVersionConfiguration()
        {
            InitializeComponent();
        }

        private void UCVersionConfiguration_Load(object sender, EventArgs e)
        {
            BindDGV();
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
    }
}