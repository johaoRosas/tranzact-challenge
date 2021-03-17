using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranzact.Wikimedia.Core.Entities
{
    public class WikimediaEntity
    {
        public string name { get; set; }
        public string year { get; set; }
        public string month { get; set; }
        public string day { get; set; }
        public string hour { get; set; }
        public string extension { get; set; }
        public string localPath { get; set; }
        public string nameFile
        {
            get
            {
                return name + "-" + year + month + day + "-" + hour + "0000";
            }
        }


        public string path
        {
            get
            {
                return year + "/" + year + "-" + month + "/" + nameFile + extension;
            }
        }
    }
}
