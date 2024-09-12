using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Письма.UserClasses
{
    public class StringPair
    {
        public StringPair(string emailAddress, string name)
        {
            EmailAddress = String.IsNullOrEmpty(emailAddress) ?
                throw new Exception("Нельзя вставлять пробелы или пустое значение! ") :
                emailAddress;

            Name = String.IsNullOrEmpty(name) ?
               throw new Exception("Нельзя вставлять пробелы или пустое значение! ") :
               name;
        }
        public string EmailAddress { get; set; }
        public string Name { get; set; }
    }
}
