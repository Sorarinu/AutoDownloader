using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoDownloader
{
    /// <summary>
    /// 疑似グローバル変数＋関数
    /// </summary>
    public partial class global
    {
        public static string[] ChkInfo = new string[99];
        public static bool FirstRun_flg = false;
        /*----------------------
        データベース関連
        ----------------------*/
        public const string DATABASE_NAME = "Settings.db";
        public const int ID = 0;
        public const int NAME = 1;
        public const int URL = 2;
        public const int PATH = 3;
        public const int EXAM = 4;
        public const int MAX = 99;
        public static string sql; //SQL文
        public static string gDataBaseFilePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), DATABASE_NAME);
        public static string gDataSource = "Data Source=" + Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), DATABASE_NAME) + ";Version=3";
        public static SQLiteCommand command;  // SQLコマンド
        public static SQLiteConnection conn;
        public static SQLiteDataReader rd;

        /// <summary>
        /// コントロールの数を返す
        /// </summary>
        /// <param name="sender"></param>
        /// <returns>コントロールの数</returns>
        public static int GetCtrlCount(object sender)
        {
            return ((((((CheckBox)sender).Parent).Parent).Parent).Parent).Controls.Count;
        }

        /// <summary>
        /// コントロールの名前を返す
        /// </summary>
        /// <param name="sender"></param>
        /// <returns>InfoAddの名前</returns>
        public static string GetCtrlName(object sender)
        {
            Point point = new Point(9, 12);
            string CtrlName = "";

            using (global.conn = new SQLiteConnection(global.gDataSource))
            {
                try
                {
                    global.conn.Open();

                    global.sql = "select * from Settings where name = '" + ((((CheckBox)sender).Parent).GetChildAtPoint(point)).Text + "'";

                    global.command = new SQLiteCommand(global.sql, global.conn);
                    global.rd = global.command.ExecuteReader();

                    while (global.rd.Read())
                    {
                        try
                        {
                            CtrlName = global.rd.GetValue(global.EXAM).ToString();
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

            return CtrlName;
        }
    }
}
