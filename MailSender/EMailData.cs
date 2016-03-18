using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    class EMailData
    {
        public readonly String name;
        public readonly String eMail;
        public List<String> mailList;

        public EMailData()
        {
            mailList = new List<String>();
        }

        public EMailData(String name, String eMail) : this()
        {
            this.name = name;
            foreach(var mail in eMail.Split(','))
            {
                mailList.Add(mail.Trim().TrimStart('<').TrimEnd('>'));
            }
        }
    }
}
