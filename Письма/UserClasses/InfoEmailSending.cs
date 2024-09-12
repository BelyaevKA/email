using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Письма.UserClasses
{
    public class InfoEmailSending
    {
        public InfoEmailSending(string smtpClientAdress,
            StringPair emailAdressForm,
            string emailPassword,
            StringPair emailAdressTo,
            string subject,
            string body) 
        {
            SmtpClientAdress = String.IsNullOrWhiteSpace(smtpClientAdress) ?
                throw new Exception("Нельзя вставлять пробелы или пустое значение! ") :
                smtpClientAdress;
            EmailAdressForm = emailAdressForm ?? throw new ArgumentNullException (nameof(emailAdressForm));

            EmailPassword = string.IsNullOrWhiteSpace(emailPassword) ?
                throw new Exception("Нельзя вставлять пробелы или пустое значение! ") :
                emailPassword;
            EmailAdressTo = emailAdressTo ?? throw new ArgumentNullException(nameof(emailAdressTo));
            Subject = subject ?? throw new ArgumentNullException (nameof(subject));
            Body = body ?? throw new ArgumentNullException (nameof(body));
        }
        public string SmtpClientAdress { get; set; }
        public StringPair EmailAdressForm { get; set; } 
        public string EmailPassword { get; set; }
        public StringPair EmailAdressTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
