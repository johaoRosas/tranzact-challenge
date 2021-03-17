using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Wikimedia.Core.Entities;
using Tranzact.Wikimedia.Core.Interfaces;

namespace Tranzact.Wikimedia.Core
{
    public class ReadFileCodes : IReadFileCodes
    {
        
        public List<Codedentity> getListCodes()
        { 
            var json = File.ReadAllText("CodesEntity.json");
            var codes = JsonConvert.DeserializeObject<CodesEntity>(json);
            return codes.list;
        }
    }
}
