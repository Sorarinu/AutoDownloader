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
    public partial class frmDemand : Form
    {
        public frmDemand()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 要望をメール送信する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            bool result;

            if (txtSenderName.Text != "" && txtEmailAddress.Text != "" && txtSubject.Text != "" && txtBody.Text != "")
            {
               result = Notify.SendMailDemand(DateTime.Now, txtSenderName.Text, txtSubject.Text, txtEmailAddress.Text, txtBody.Text);

               if (result == true) this.Close();
            }
            else
            {
                MessageBox.Show("必要事項が入力されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// キャンセルボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
