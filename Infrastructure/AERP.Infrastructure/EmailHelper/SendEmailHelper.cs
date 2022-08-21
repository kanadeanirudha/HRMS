using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Configuration;
using System.Xml;
using System.Net.Mime;
using System.IO;
using AERP.Base.DTO;

namespace AERP.Infrastructure
{
    public class SendEmailHelper
    {
        /// <summary>
        /// Method to send email
        /// </summary>
        /// <param name="smtpConfig"></param>
        /// <param name="emailData"></param>
        /// <returns></returns>
        public static bool SendMail(Email emailData)
        {
            // SMTP Configurations
            MailMessage smail = new MailMessage();
            //Set the body of the mail to HTML
            smail.IsBodyHtml = true;

            //from Address
            string fromAddress = emailData.LoginUserMailID;//"sudhir.chintakrindi@valuelabs.net";//;
            emailData.FromAddress = fromAddress;

            //Adding the From Address and DisplayName to the MailMessage
            smail.From = new MailAddress(emailData.FromAddress, emailData.DisplayName);//From_Email

            if (!string.IsNullOrEmpty(emailData.ToAddress))
            {
                emailData.ToAddress = emailData.ToAddress.Substring(0, emailData.ToAddress.Length - 1);
                string[] toAddress = emailData.ToAddress.Split(';');
                foreach (string address in toAddress)
                {
                    smail.To.Add(address);
                }
            }
            //smail.To.Add("sudhir.chintakrindi@valuelabs.net");
            if (!string.IsNullOrEmpty(emailData.CcAddress))
            {
                emailData.CcAddress = emailData.CcAddress.Substring(0, emailData.CcAddress.Length - 1);
                string[] CCAddress = emailData.CcAddress.Split(';');
                foreach (string address in CCAddress)
                {
                    smail.CC.Add(address);
                }
            }

            if (!string.IsNullOrEmpty(emailData.BccAddress))
            {
                emailData.BccAddress = emailData.BccAddress.Substring(0, emailData.BccAddress.Length - 1);
                string[] BCCAddress = emailData.BccAddress.Split(';');
                foreach (string address in BCCAddress)
                {
                    smail.Bcc.Add(address);
                }
            }

            //Subject
            smail.Subject = emailData.Subject;
            //Body
            smail.Body = emailData.EmailBody;


            SmtpClient client = new SmtpClient();


            //RN Deperecated this so it uses the standard .Net MailSetting config
            client.Host = ConfigurationSettings.AppSettings["MailServer"].ToString();
            client.Port = Convert.ToInt32(ConfigurationSettings.AppSettings["ServerPortNumber"].ToString());
            String UserName = ConfigurationSettings.AppSettings["UserName"].ToString();
            String Password = ConfigurationSettings.AppSettings["Password"].ToString();

            //Credentials for SMTP Server
            client.Credentials = new System.Net.NetworkCredential(UserName, Password);

            try
            {
                client.Send(smail);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


    }
}
