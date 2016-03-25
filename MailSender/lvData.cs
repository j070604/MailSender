using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    class lvData
    {
        public String hosName { get; set; }
        public String sendAlready { get; set; }
        public String sendable { get; set; }
        public String fileFormat { get; set; }
 
        public lvData()
        { }

        public lvData(String hosName, String sendAlready, String sendable)
        {
            this.hosName = hosName;
            this.sendAlready = sendAlready;
            this.sendable = sendable;
        }

        public lvData(String hosName, String sendAlready)
        {
            this.hosName = hosName;
            this.sendAlready = sendAlready;
        }
    }
}
