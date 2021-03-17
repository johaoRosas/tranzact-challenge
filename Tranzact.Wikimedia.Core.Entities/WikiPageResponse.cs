
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranzact.Wikimedia.Core.Entities
{
    public class WikiPageResponse
    {
        public string period { get; set; }
        public string page { get; set; } 
        public int viewCount { get; set; }
    }
}
