using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace AutoDownloader
{
    public partial class frmAdd : Form
    {
        frmMain frm = new frmMain();
        InfoAdd Info = new InfoAdd();

        public frmAdd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォルダパス自動入力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.Description = "フォルダを指定してください";  //上部タイトル
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.SelectedPath = @"C:\Windows";
            fbd.ShowNewFolderButton = true;

            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                txtPath.Text = fbd.SelectedPath + "\\";
            }
        }

        /// <summary>
        /// データベース登録
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int ctlCount = frm.pnlMain.Controls.Count;

            if (txtName.Text == "" || txtURL.Text == "" || txtPath.Text == "")
            {
                MessageBox.Show(this, "入力に誤りがあります", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            /*------------------------
             登録
            ------------------------*/
            using (global.conn = new SQLiteConnection(global.gDataSource))
            {
                try
                {
                    global.conn.Open();

                    global.sql = "insert into Settings (name, url, path) values ( " +
                                 "'" + txtName.Text + "'," +
                                 "'" + txtURL.Text + "'," +
                                 "'" + txtPath.Text + "'" +
                                 ")";

                    global.command = new SQLiteCommand(global.sql, global.conn);
                    global.command.ExecuteNonQuery();

                    /*------------------------
                     データベースのexamを更新
                    ------------------------*/
                    frm.pnlMain.Controls.Clear();

                    try
                    {
                        global.sql = "select * from Settings";

                        global.command = new SQLiteCommand(global.sql, global.conn);
                        global.rd = global.command.ExecuteReader();

                        while (global.rd.Read())
                        {
                            try
                            {
                                global.sql = "update Settings set exam = 'InfoAdd" + int.Parse((ctlCount + global.rd.GetValue(global.ID).ToString())).ToString() + "' where no = " + global.rd.GetValue(global.ID).ToString();
                                global.command = new SQLiteCommand(global.sql, global.conn);
                                global.command.ExecuteNonQuery();
                            }
                            catch (Exception) { }
                        }
                    }
                    catch (Exception){ }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Error : " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Notify.SendMailError(DateTime.Now, ex.Message, "frmAdd - 64～101");
                }
                finally
                {
                    global.conn.Close();
                    frm.Dispose();
                    this.Close();
                }

                MessageBox.Show(this, "登録が完了しました", "お知らせ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// フォームを閉じる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            frm.Dispose();
            this.Close();
        }
    }
}
