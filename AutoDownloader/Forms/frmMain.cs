using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Timers;
using System.Net;
using System.Threading;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Microsoft.Win32;

namespace AutoDownloader
{
    public partial class frmMain : Form
    {
        InfoAdd Info = new InfoAdd();   //コントロール追加用インスタンス生成
        InifileUtils ini = new InifileUtils();
        WebClient downloadClient = null;
        private delegate void notifyDel();

        /// <summary>
        /// 初期化
        /// </summary>
        public frmMain()
        {
            /*------------------------
             二重起動チェック
            ------------------------*/
            if (System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                //すでに起動していると判断する
                MessageBox.Show(this, "既に起動しています", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }

            InitializeComponent();

            /*------------------------
             更新間隔等取得
            ------------------------*/
            if (System.IO.File.Exists(@"settings.ini")) //INIファイルが存在する
            {
                cmbInterval.Text = ini.getValueString("Interval", "time");

                if (ini.getValueString("Notify", "checked") == "true")
                {
                    chkNotify.Checked = true;
                }
                else
                {
                    chkNotify.Checked = false;
                }

                if (ini.getValueString("Autorun", "checked") == "true")
                {
                    chkAutorun.Checked = true;
                }
                else
                {
                    chkAutorun.Checked = false;
                }
            }
            //存在しない場合は作成
            else
            {
                Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                StreamWriter writer = new StreamWriter(@"settings.ini", true, sjisEnc);

                writer.WriteLine("[Interval]\r\ntime=1 時間\r\n\r\n[Notify]\r\nchecked=false\r\n\r\n[Autorun]\r\nchecked=false");
                writer.Close();

                ini = new InifileUtils();

                cmbInterval.Text = ini.getValueString("Interval", "time");

                if (ini.getValueString("Notify", "checked") == "true")
                {
                    chkNotify.Checked = true;
                }
                else
                {
                    chkNotify.Checked = false;
                }

                if (ini.getValueString("Autorun", "checked") == "true")
                {
                    chkAutorun.Checked = true;
                }
                else
                {
                    chkAutorun.Checked = false;
                }
            }

            /*------------------------
             データベース生成
            ------------------------*/
            using (global.conn = new SQLiteConnection(global.gDataSource))
            {
                try
                {
                    global.conn.Open();

                    // テーブルの作成
                    global.sql = "CREATE TABLE Settings (" +
                                 " no integer primary key," +
                                 " name text, " +
                                 " url text, " +
                                 " path text," +
                                 " exam"+
                                 " )";
                    
                    global.command = new SQLiteCommand(global.sql, global.conn);
                    global.command.ExecuteNonQuery();
                }
                catch (Exception) { }
                finally
                {
                    global.conn.Close();
                }
            }
        }

        /// <summary>
        /// 設定の読み込み
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            int ctlCount = pnlMain.Controls.Count;
            menuSettings.Enabled = false;

            /*------------------------
             起動時に一回だけ実行
            ------------------------*/
            if (!global.FirstRun_flg)
            {
                ShowInTaskbar = false;
                Hide();
                menuSettings.Enabled = true;

                notifyIcon1.ShowBalloonTip(5000, "お知らせ", "AutoDownloader へようこそ！\r\n講義の登録はこちらから行えます", ToolTipIcon.Info);

                Update_Check(0);    //アップデート確認

                //.oldファイル削除
                if (File.Exists("AutoDownloader.old"))
                {
                    File.Delete("AutoDownloader.old");
                }

                RefreshInterval.Enabled = true;
                global.FirstRun_flg = true;
            }

            /*------------------------
             データベースを元にフォームへ追加
            ------------------------*/
            pnlMain.Controls.Clear();

            using (global.conn = new SQLiteConnection(global.gDataSource))
            {
                try
                {
                    global.conn.Open();

                    global.sql = "select * from Settings";

                    global.command = new SQLiteCommand(global.sql, global.conn);
                    global.rd = global.command.ExecuteReader();
                    
                    while (global.rd.Read())
                    {
                        try
                        {
                            Info = new InfoAdd();

                            Info.Name = "InfoAdd" + int.Parse((ctlCount + global.rd.GetValue(global.ID).ToString())).ToString();
                            Info.lblName.Text = global.rd.GetValue(global.NAME).ToString();
                            Info.lblUrl.Text = global.rd.GetValue(global.URL).ToString();
                            Info.lblPath.Text = global.rd.GetValue(global.PATH).ToString();

                            pnlMain.Controls.Add(Info);
                        }
                        catch (Exception) { }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Notify.SendMailError(DateTime.Now, ex.Message, "frmMain - 147～171");
                }
                finally
                {
                    global.conn.Close();
                }
            }

            /*------------------------
             タイマセット
            ------------------------*/
            if (System.IO.File.Exists(@"settings.ini")) //INIファイルが存在する
            {
                switch (ini.getValueString("Interval", "time"))
                {
                    case "5 分":
                        RefreshInterval.Interval = 300000;
                        break;

                    case "10 分":
                        RefreshInterval.Interval = 600000;
                        break;

                    case "30 分":
                        RefreshInterval.Interval = 1800000;
                        break;

                    case "1 時間":
                        RefreshInterval.Interval = 3600000;
                        break;

                    case "6 時間":
                        RefreshInterval.Interval = 21600000;
                        break;

                    case "12 時間":
                        RefreshInterval.Interval = 43200000;
                        break;

                    case "1 日":
                        RefreshInterval.Interval = 86400000;
                        break;

                    default:
                        break;
                }
            }
            else
            {
                RefreshInterval.Interval = 3600000;
            }

            //RefreshInterval.Interval = 60000; //デバッグ用
            RefreshInterval.Enabled = true;

            ShowInTaskbar = false;
            Hide();

            menuSettings.Enabled = true;
        }

        /// <summary>
        /// アプリケーションの終了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// カラムの追加フォームを表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAdd FrmAdd = new frmAdd();
            FrmAdd.ShowDialog();

            Reload();
        }

        /// <summary>
        /// チェックされたカラムの削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            int count = pnlMain.Controls.Count;
            int i = 0;
            int arrayCount = 0;
            
            Info = new InfoAdd();

            /*------------------------
             配列の要素計算
            ------------------------*/
            for(i = 0; i < 99; i++){
                if(global.ChkInfo[i] != null){
                    arrayCount++;
                }
            }

            /*------------------------
             チェックが入っていない場合はエラー
            ------------------------*/
            if (arrayCount == 0)
            {
                MessageBox.Show(this, "削除する項目が選択されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(this, 
                                                  arrayCount + "個のデータを削除しますか？",
                                                  "お知らせ",
                                                  MessageBoxButtons.YesNoCancel,
                                                  MessageBoxIcon.Exclamation,
                                                  MessageBoxDefaultButton.Button2);

            /*------------------------
             チェックされた項目を削除
            ------------------------*/
            if (result == DialogResult.Yes)
            {
                //フォームから削除
                for (i = 0; i < count; i++)
                {
                    if (pnlMain.Controls.IndexOfKey(global.ChkInfo[i]) > -1)
                    {
                        int dataNum = pnlMain.Controls.IndexOfKey(global.ChkInfo[i]);

                        global.sql = "delete from Settings where exam = '" + global.ChkInfo[i] + "'";

                        using (global.conn = new SQLiteConnection(global.gDataSource))
                        {
                            try
                            {
                                global.conn.Open();

                                global.command = new SQLiteCommand(global.sql, global.conn);
                                global.command.ExecuteNonQuery();

                                pnlMain.Controls.RemoveAt(pnlMain.Controls.IndexOfKey(global.ChkInfo[i]));
                                MessageBox.Show(this, "削除しました", "お知らせ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception) { }

                            global.conn.Close();
                        }
                    }
                }

                //配列をnullで初期化
                for (i = 0; i < 99; i++)
                {
                    global.ChkInfo[i] = null;
                }
            }
        }

        /// <summary>
        /// 設定画面表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuSettings_Click(object sender, EventArgs e)
        {
            ShowInTaskbar = true;
            Show();
            menuSettings.Enabled = false;
        }

        /// <summary>
        /// 設定の保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            RefreshInterval.Enabled = false;

            /*------------------------
             更新間隔出力
            ------------------------*/
            ini.setValue("Interval", "time", cmbInterval.Text);
            ini.setValue("Notify", "checked", (chkNotify.Checked) ? "true" : "false");
            ini.setValue("Autorun", "checked", (chkAutorun.Checked) ? "true" : "false");

            /*------------------------
             自動起動設定
            ------------------------*/
            if (ini.getValueString("Autorun", "checked") == "true")
            {
                SetCurrentVersionRun();
            }
            else
            {
                DelCurrentVersionRun();
            }

            /*------------------------
             タイマセット
            ------------------------*/
            if (System.IO.File.Exists(@"settings.ini")) //INIファイルが存在する
            {
                switch (ini.getValueString("Interval", "time"))
                {
                    case "5 分":
                        RefreshInterval.Interval = 300000;
                        break;

                    case "10 分":
                        RefreshInterval.Interval = 600000;
                        break;

                    case "30 分":
                        RefreshInterval.Interval = 1800000;
                        break;

                    case "1 時間":
                        RefreshInterval.Interval = 3600000;
                        break;

                    case "6 時間":
                        RefreshInterval.Interval = 21600000;
                        break;

                    case "12 時間":
                        RefreshInterval.Interval = 43200000;
                        break;

                    case "1 日":
                        RefreshInterval.Interval = 86400000;
                        break;

                    default:
                        break;
                }
            }
            else
            {
                RefreshInterval.Interval = 3600000;
            }

            //RefreshInterval.Interval = 60000; //デバッグ用
            RefreshInterval.Enabled = true;

            ShowInTaskbar = false;
            Hide();

            menuSettings.Enabled = true;
        }

        /// <summary>
        /// ソフトウェアについて表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ソフトウェアについてToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Information Info = new Information();
            Info.Show();
        }

        /// <summary>
        /// リストの再読み込み
        /// </summary>
        public void Reload()
        {
            int ctlCount = pnlMain.Controls.Count;

            pnlMain.Controls.Clear();

            using (global.conn = new SQLiteConnection(global.gDataSource))
            {
                try
                {
                    global.conn.Open();

                    global.sql = "select * from Settings";

                    global.command = new SQLiteCommand(global.sql, global.conn);
                    global.rd = global.command.ExecuteReader();

                    while (global.rd.Read())
                    {
                        try
                        {
                            Info = new InfoAdd();

                            //フォームにデータを追加
                            Info.Name = "InfoAdd" + int.Parse((ctlCount + global.rd.GetValue(global.ID).ToString())).ToString();
                            Info.lblName.Text = global.rd.GetValue(global.NAME).ToString();
                            Info.lblUrl.Text = global.rd.GetValue(global.URL).ToString();
                            Info.lblPath.Text = global.rd.GetValue(global.PATH).ToString();

                            pnlMain.Controls.Add(Info);
                        }
                        catch (Exception) { }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Notify.SendMailError(DateTime.Now, ex.Message, "frmMain - 400～425");
                }
                finally
                {
                    global.conn.Close();
                }
            }
        }

        /// <summary>
        /// ダウンロード進行状況通知（試験実装）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void downloadClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            ///
            /// 試験実装中
            /// 動作確認時はコメント外す
            ///

            /*if (int.Parse(e.ProgressPercentage.ToString()) % 20 == 0)
            {
                new Thread(
                    new ThreadStart(
                        delegate
                        {
                            Invoke(
                                (notifyDel)delegate
                            { // 匿名メソッドを Del 型にキャストし, それを呼び出す。
                                notifyIcon1.ShowBalloonTip(5000, "お知らせ", e.ProgressPercentage.ToString() + "% (" + e.TotalBytesToReceive.ToString() + "byte 中 " + e.BytesReceived.ToString() + "byte) ダウンロードが完了しました", ToolTipIcon.Info); // コントロールの操作
                            }
                            );
                        }
                    )
                ).Start();
            }*/
        }

        /// <summary>
        /// ダウンロード完了時の動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void downloadClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            DateTime dtNow = DateTime.Now;
            
            new Thread(
                new ThreadStart(
                    delegate
                    {
                        Invoke(
                            (notifyDel)delegate
                            { 
                                if (e.Error != null)
                                {
                                    notifyIcon1.ShowBalloonTip(5000, "お知らせ", "Error: " + e.Error.Message, ToolTipIcon.Error);
                                }
                                else if (e.Cancelled)
                                {
                                    notifyIcon1.ShowBalloonTip(5000, "お知らせ", "キャンセルされました", ToolTipIcon.Info);
                                }
                                else
                                {
                                    notifyIcon1.ShowBalloonTip(5000, "お知らせ", "講義資料のダウンロードが完了しました\r\n" + dtNow.ToString(), ToolTipIcon.Info);
                                }
                            }
                        );
                    }
                )
            ).Start();

            downloadClient = null;
        }

        /// <summary>
        /// タイマ動作、データの更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshInterval_Tick(object sender, EventArgs e)
        {
            Download_DataFile(0);
        }

        /// <summary>
        /// アップデートチェック
        /// </summary>
        /// <param name="state">
        /// 0 : 起動時
        /// 1 : アップデート確認ボタン動作時
        /// </param>
        private void Update_Check(int state)
        {
            string ver;
            string updatetxt;
            string addfiletxt_tmp;
            string[] addfiletxt;
            char[] delimiterChars = {'\r', '\n'};
            int iCompare;

            try
            {
                /*------------------------
                 バージョン取得
                ------------------------*/
                WebClient wc = new WebClient();
                Stream st = wc.OpenRead("http://www.nxtg-t.net/downloads/AutoDownloader/version.txt");
                StreamReader sr = new StreamReader(st, Encoding.GetEncoding("shift_jis"));

                ver = sr.ReadLine();

                st.Close();
                wc.Dispose();

                /*------------------------
                 アップデート内容取得
                ------------------------*/
                wc = new WebClient();
                st = wc.OpenRead("http://www.nxtg-t.net/downloads/AutoDownloader/" + ver + "/update.txt");
                sr = new StreamReader(st, Encoding.GetEncoding(51932));

                updatetxt = sr.ReadToEnd();

                st.Close();
                wc.Dispose();

                /*------------------------
                 追加ファイル取得
                ------------------------*/
                ArrayList al = new ArrayList();
                wc = new WebClient();
                st = wc.OpenRead("http://www.nxtg-t.net/downloads/AutoDownloader/" + ver + "/addfiles.txt");
                sr = new StreamReader(st, Encoding.GetEncoding(51932));

                addfiletxt_tmp = sr.ReadToEnd();
                addfiletxt = addfiletxt_tmp.Split(delimiterChars);

                foreach (string tmp in addfiletxt)
                {
                    if (tmp != "")
                    {
                        al.Add(tmp);
                    }
                }

                addfiletxt = (string[])al.ToArray(typeof(string));

                st.Close();
                wc.Dispose();

                /*------------------------
                 サーバデータとバージョン比較
                ------------------------*/
                iCompare = string.CompareOrdinal(Application.ProductVersion, ver);

                if (iCompare < 0)
                {
                    frmUpdateDialog frmUpdate = new frmUpdateDialog(Application.ProductVersion, ver, updatetxt, addfiletxt);
                    frmUpdate.Show();
                }
                else
                {
                    switch (state)
                    {
                        case 0:
                            break;

                        case 1:
                            MessageBox.Show(this, "お使いのソフトウェアは最新です\r\n更新の必要はありません", "お知らせ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// アップデートチェック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 最新バージョンの確認ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update_Check(1);
        }

        /// <summary>
        /// 設定画面上部の終了ボタン動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 終了ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 設定画面上部のバージョン確認ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void autoDownloaderのバージョン情報ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Information Info = new Information();
            Info.Show();
        }

        /// <summary>
        /// 設定画面上部のアップデートチェックボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 最新バージョンの確認ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Update_Check(1);
        }

        /// <summary>
        /// メールフォームを出す
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 開発者への要望ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDemand demand = new frmDemand();
            demand.Show();
        }

        /// <summary>
        /// フォーム終了時のダイアログ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(this,
                                                  "終了するとデータのダウンロードは行われなくなります\r\n終了しますか？",
                                                  "お知らせ",
                                                  MessageBoxButtons.YesNoCancel,
                                                  MessageBoxIcon.Exclamation,
                                                  MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No || result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 講義サイトからファイルをダウンロードする
        /// </summary>
        /// <param name="state">0:定期　1:手動</param>
        private void Download_DataFile(int state)
        {
            int count = 0;
            Regex reg = new Regex("<a href=\"(?<url>.*?)\".*?>(?<text>.*?)</a>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            string anchor = "<a href=\"(?<url>.*?)\".*?>(?<text>.*?)</a>";
            string url = "";
            string htmlUrl = "";
            string html = "";
            string fileName = "";
            DateTime dtNow = DateTime.Now;
            WebClient wc = new WebClient();
            Regex re = new Regex(anchor, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            /*------------------------
             データベースのデータ数取得
            ------------------------*/
            using (global.conn = new SQLiteConnection(global.gDataSource))
            {
                try
                {
                    global.conn.Open();

                    global.sql = "select count(*) from Settings";

                    global.command = new SQLiteCommand(global.sql, global.conn);
                    global.rd = global.command.ExecuteReader();

                    while (global.rd.Read())
                    {
                        try
                        {
                            count = int.Parse(global.rd.GetValue(0).ToString());
                        }
                        catch (Exception) { }
                    }
                }
                catch (Exception) { }
                finally
                {
                    global.conn.Close();
                }
            }

            if (count == 0){
                if (state == 0) return;
                else if (state == 1)
                {
                    MessageBox.Show(this, "講義データを登録してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            /*------------------------
             ダウンロード処理
            ------------------------*/
            for (int i = 0; i < count; i++)
            {
                using (global.conn = new SQLiteConnection(global.gDataSource))
                {
                    try
                    {
                        global.conn.Open();

                        global.sql = "select * from Settings";

                        global.command = new SQLiteCommand(global.sql, global.conn);
                        global.rd = global.command.ExecuteReader();

                        while (global.rd.Read())
                        {
                            try
                            {
                                url = global.rd.GetValue(global.URL).ToString();

                                //htmlからファイルのURLを取得
                                html = wc.DownloadString(url);

                                for (Match m = re.Match(html); m.Success; m = m.NextMatch())
                                {
                                    htmlUrl = m.Groups["url"].Value;

                                    //ダウンロード基のURL
                                    if (htmlUrl.Substring(0, 1) == ".")
                                    {
                                        htmlUrl.Remove(0, 1);
                                    }
                                    else if (htmlUrl.Substring(0, 2) == "./")
                                    {
                                        htmlUrl.Remove(0, 2);
                                    }

                                    Uri u = new Uri(global.rd.GetValue(global.URL) + htmlUrl);

                                    //保存先
                                    fileName = global.rd.GetValue(global.PATH) + Path.GetFileName(global.rd.GetValue(global.URL) + htmlUrl);

                                    //ダウンロード
                                    if (Path.GetExtension(global.rd.GetValue(global.URL) + htmlUrl) == ".pdf" || Path.GetExtension(global.rd.GetValue(global.URL) + htmlUrl) == ".ppt" || Path.GetExtension(global.rd.GetValue(global.URL) + htmlUrl) == ".pptx" || Path.GetExtension(global.rd.GetValue(global.URL) + htmlUrl) == ".doc" || Path.GetExtension(global.rd.GetValue(global.URL) + htmlUrl) == ".docx" || Path.GetExtension(global.rd.GetValue(global.URL) + htmlUrl) == ".xls" || Path.GetExtension(global.rd.GetValue(global.URL) + htmlUrl) == ".xlsx")
                                    {
                                        if (!File.Exists(fileName))
                                        {
                                            downloadClient = new System.Net.WebClient();
                                            //downloadClient.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(downloadClient_DownloadProgressChanged);
                                            //downloadClient.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(downloadClient_DownloadFileCompleted);
                                            downloadClient.DownloadFileAsync(u, fileName);
                                        }
                                    }
                                }
                            }
                            catch (Exception) { }
                        }
                    }
                    catch (Exception) { }
                    finally
                    {
                        global.conn.Close();
                    }
                }
            }

            if (System.IO.File.Exists(@"settings.ini")) //INIファイルが存在する
            {
                if (ini.getValueString("Notify", "checked") == "true")
                {
                    /*------------------------
                     ダウンロード完了通知
                    ------------------------*/
                    new Thread(
                        new ThreadStart(
                            delegate
                            {
                                Invoke(
                                    (notifyDel)delegate
                                    {
                                        notifyIcon1.ShowBalloonTip(5000, "お知らせ", "講義資料のダウンロードが完了しました\r\n" + dtNow.ToString(), ToolTipIcon.Info);
                                    }
                                );
                            }
                        )
                    ).Start();
                }
            }
            downloadClient = null;
        }

        /// <summary>
        /// メニューの更新ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 今すぐデータを取得するToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Download_DataFile(1);
        }

        /// <summary>
        /// 手動ダウンロード開始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Download_DataFile(1);
        }

        /// <summary>
        /// CurrentUserのRunにアプリケーションの実行ファイルパスを登録する
        /// </summary>
        public void SetCurrentVersionRun()
        {
            try
            {
                //Runキーを開く
                RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                //値の名前に製品名、値のデータに実行ファイルのパスを指定し、書き込む
                regkey.SetValue(Application.ProductName, "\"" + Application.ExecutablePath + "\"");
                //閉じる
                regkey.Close();
            }
            catch (Exception) { }
        }

        /// <summary>
        /// レジストリ削除
        /// </summary>
        public void DelCurrentVersionRun()
        {
            try
            {
                //Runキーを開く
                RegistryKey regkey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                //削除
                regkey.DeleteValue(Application.ProductName);
                //閉じる
                regkey.Close();
            }
            catch (Exception) { }
        }
    }
}
