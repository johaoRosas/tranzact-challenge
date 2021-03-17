using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranzact.Wikimedia.Core.Entities
{
    public class Codedentity
    {
        public string code { get; set; }
        public string description { get; set; }
        public List<string> listSubdomains { get; set; }
    }
}
