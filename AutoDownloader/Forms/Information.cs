using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoDownloader
{
    public partial class Information : Form
    {
        public Information()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Twitterページ表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lnkName.LinkVisited = true;
            System.Diagnostics.Process.Start("https://twitter.com/int_sorarinu");
        }

        /// <summary>
        /// 閉じる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
