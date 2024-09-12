using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Linq.Expressions;

namespace Письма.UserClasses
{

        public class SendingEmail
        {
            private InfoEmailSending InfoEmailSending { get; set; }

            public SendingEmail(InfoEmailSending infoEmailSending)
            {
                InfoEmailSending = infoEmailSending ?? 
                    throw new ArgumentNullException(nameof(infoEmailSending));
            }
            public void Send() 
            {
                try
                {
                    SmtpClient mySmtpClient = new SmtpClient(InfoEmailSending.SmtpClientAdress);

                    mySmtpClient.UseDefaultCredentials = false;
                    mySmtpClient.EnableSsl = true;

                    NetworkCredential basicAuthenticationInfo = new NetworkCredential(
                        InfoEmailSending.EmailAdressForm.EmailAddress,
                        InfoEmailSending.EmailPassword);

                    mySmtpClient.Credentials = basicAuthenticationInfo;
                    MailAddress from = new MailAddress
                        (
                        InfoEmailSending.EmailAdressForm.EmailAddress,
                        InfoEmailSending.EmailAdressForm.Name);

                    MailAddress to = new MailAddress(
                        InfoEmailSending.EmailAdressTo.EmailAddress,
                        InfoEmailSending.EmailAdressTo.Name);

                    MailMessage myMail = new MailMessage(from, to);
                    MailAddress replyTo = new MailAddress(InfoEmailSending.EmailAdressForm.EmailAddress);

                    myMail.ReplyToList.Add(replyTo);
                    Encoding encoding = Encoding.UTF8;
                    myMail.Subject = InfoEmailSending.Subject;
                    myMail.SubjectEncoding = encoding;
                    myMail.Body = InfoEmailSending.Body;
                    myMail.BodyEncoding = encoding;
                    mySmtpClient.Send(myMail);
                }
                catch(Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
            
    
}
