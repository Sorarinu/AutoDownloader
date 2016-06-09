using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using System.Net.Mail;
using NonMailNet;

namespace AutoDownloader
{
    /// <summary>
    /// エラーを開発者に送信する
    /// </summary>
    public partial class Notify
    {
        /// <summary>
        /// エラーをメール送信する
        /// </summary>
        /// <param name="dtToday">発生日時</param>
        /// <param name="messages">エラーメッセージ</param>
        /// <param name="place">発生個所</param>
        public static void SendMailError(DateTime dtToday, string messages, string place)
        {
            NonMailClass objNonMail = new NonMailClass();
            string senderMail = Properties.Resources.sender;
            string recipientMail = Properties.Resources.recipient;
            string subject = "AutoDownloader - Error Message";
            string body = "【発生日時】\r\n" + dtToday.ToString() + "\r\n\r\n【発生個所】\r\n" + place + "\r\n\r\n【エラーメッセージ】\r\n" + messages;
            
            DialogResult result = MessageBox.Show("予期せぬエラーが発生しました。\r\nエラーメッセージを開発者に送信しますか？\r\n\r\n送信される情報は開発以外の目的以外には使用いたしません。", "お知らせ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            switch (result)
            {
                case DialogResult.Yes:
                    try
                    {
                        objNonMail.SmtpSend(
                            "smtp.gmail.com", 465, Properties.Resources.user, Properties.Resources.pass,
                            "intsorarinu@gmail.com",
                            "webmaster@nxtg-t.net",
                            "",
                            "",
                            subject,
                            body,
                            "",
                            "LOGIN",
                            true,
                            "SSL");
            
                        MessageBox.Show("エラーメッセージが送信されました\r\n\r\nご協力ありがとうございました", "お知らせ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
            
                case DialogResult.No:
                    break;
            
                default:
                    break;
            }
        }

        /// <summary>
        /// 要望をメール送信する
        /// </summary>
        /// <param name="dtToday"></param>
        /// <param name="senderName"></param>
        /// <param name="messages"></param>
        public static bool SendMailDemand(DateTime dtToday, string senderName, string subj, string email, string messages)
        {
            NonMailClass objNonMail = new NonMailClass();
            string senderMail = Properties.Resources.sender;
            string recipientMail = Properties.Resources.recipient;
            string subject = "AutoDownloader - " + subj;
            string body = "【送信日時】\r\n" + dtToday.ToString() + "\r\n\r\n【送信者名】\r\n" + senderName + "\r\n\r\n【E-mail】\r\n" + email + "\r\n\r\n【メッセージ】\r\n" + messages;

            try
            {
                objNonMail.SmtpSend(
                    "smtp.gmail.com", 465, Properties.Resources.user, Properties.Resources.pass,
                    "intsorarinu@gmail.com",
                    "webmaster@nxtg-t.net",
                    "",
                    "",
                    subject,
                    body,
                    "",
                    "LOGIN",
                    true,
                    "SSL");

                MessageBox.Show("送信が完了しました。", "お知らせ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
