using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    class HospitalData
    {
        public readonly String Name;
        public readonly String Folder;
        public readonly String FileFormat;

        public HospitalData()
        { }

        public HospitalData(String Name, String Folder, String FileFormat)
        {
            this.Name = Name;
            this.Folder = Folder;
            this.FileFormat = FileFormat;
        }
    }
}
