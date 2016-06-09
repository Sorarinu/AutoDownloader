using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace AutoDownloader
{
    public partial class InfoAdd : UserControl
    {
        /// <summary>
        /// 初期化
        /// </summary>
        public InfoAdd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// チェックされたコントロールを配列に格納
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkDel_CheckedChanged(object sender, EventArgs e)
        {
            int ctrlCount;  //コントロールの数

            //チェックがついていれば配列に追加、外れていれば削除
            if (chkDel.Checked == true)
            {
                ctrlCount = global.GetCtrlCount(sender); //コントロールの数取得
                global.ChkInfo[ctrlCount] = global.GetCtrlName(sender); //コントロールの名前
                Array.Sort(global.ChkInfo);
                Array.Reverse(global.ChkInfo);
            }
            else
            {
                //要素の番号取得
                int searchCnt = Array.IndexOf(global.ChkInfo, global.GetCtrlName(sender));

                if (searchCnt >= 0)
                {
                    global.ChkInfo[searchCnt] = null;
                    Array.Sort(global.ChkInfo);
                    Array.Reverse(global.ChkInfo);
                }
            }
        }
    }
}
