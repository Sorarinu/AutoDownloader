using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoDownloader
{
    public partial class frmUpdateDialog : Form
    {
        string _NowVersion = "";
        string _NewVersion = "";
        string _updatetxt = "";
        string[] _addfiletxt;
        WebClient versionUpdate = null;
        frmProgress frmProg;
        int i = 1;  //ファイルの現在のダウンロード数

        public frmUpdateDialog(string NowVersion, string NewVersion, string updatetxt, string[] addfiletxt)
        {
            InitializeComponent();

            _NowVersion = NowVersion;
            _NewVersion = NewVersion;
            _updatetxt = updatetxt;
            _addfiletxt = addfiletxt;
        }

        /// <summary>
        /// 内容出力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmUpdateDialog_Load(object sender, EventArgs e)
        {
            lblNowVersion.Text = _NowVersion;
            lblNewVersion.Text = _NewVersion;
            txtUpdates.Text = _updatetxt;

            frmProg = new frmProgress(_addfiletxt.Count().ToString());
            frmProg.TopMost = true;
            frmProg.ShowInTaskbar = false;
            frmProg.Show();
            frmProg.Visible = false;
        }

        /// <summary>
        /// キャンセル
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// アップデート開始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            UpdateProcess();
        }

        private void UpdateProcess()
        {
            frmProg.Show();

            try
            {
                int pid = System.Diagnostics.Process.GetCurrentProcess().Id;

                /*------------------------
                 旧ファイルを.oldへ
                ------------------------*/
                File.Delete("AutoDownloader.old");
                File.Move("AutoDownloader.exe", "AutoDownloader.old");

                /*------------------------
                 新ファイルダウンロード
                ------------------------*/
                foreach (string fileName in _addfiletxt)
                {
                    try
                    {
                        /*if (download_state == false)
                        {
                            download_state = true;
                        */
                            //ダウンロード元URL
                            Uri u = new Uri("http://www.nxtg-t.net/downloads/AutoDownloader/" + _NewVersion + "/" + fileName);

                            versionUpdate = new System.Net.WebClient();
                            versionUpdate.DownloadProgressChanged += versionUpdate_DownloadProgressChanged;
                            versionUpdate.DownloadFileCompleted += versionUpdate_DownloadFileCompleted;


                            versionUpdate.DownloadFileAsync(u, fileName);
                        /*}
                        else
                        {
                            await Task.Delay(1000);
                        }*/
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "バージョンアップに失敗しました\r\n\r\nエラー:" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frmProg.Close();
                File.Move("AutoDownloader.old", "AutoDownloader.exe");
                Notify.SendMailError(DateTime.Now, ex.Message, "frmMain - 697～722");
                return;
            }
        }

        /// <summary>
        /// プログレスバーに進捗を出力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void versionUpdate_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //System.Threading.Thread.Sleep(100);

            frmProg.progressBar1.Value = e.ProgressPercentage;
            frmProg.lblProgress.Text = frmProg.progressBar1.Value.ToString() + "%";
            frmProg.lblCurrent.Text = i.ToString();

            //await Task.Delay(500);
            //await Task.Delay(2000);
            
        }

        /// <summary>
        /// ダウンロード数増加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void versionUpdate_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //await Task.Delay(1000);
            //System.Threading.Thread.Sleep(500);
            

            frmProg.lblCurrent.Text = i.ToString();

            if (i == _addfiletxt.Count())
            {
                //完了通知
                MessageBox.Show(this, "ダウンロードが完了しました\r\n最新バージョンに更新するため再起動します", "お知らせ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmProg.Close();

                Application.Restart();
            }
            else
            {
                i++;
            }
        }
    }
}
