using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranzact.Wikimedia.Services.Models
{
    public class WikimediaDto
    { 
        public string name { get; set; }
        public string year { get; set; }
        public string month { get; set; }
        public string day { get; set; }
        public string hour { get; set; }
        public string extension { get; set; }
        public string path { get; set; }
        public string nameFile { get; set; }
        public string localPath { get; set; }
    }
}
