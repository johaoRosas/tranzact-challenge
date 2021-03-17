using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranzact.Wikimedia.Core.Entities
{
    public class FileContentEntity
    {
        public string domainCode { get; set; }
        public string pageTitle { get; set; }
        public string period { get; set; }
        public int viewCount { get; set; }
        public double size { get; set; }
        public string language { get; set; }
        public string domain  { get; set; }

 
    }
}
