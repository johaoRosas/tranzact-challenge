﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranzact.Wikimedia.Core.Entities
{
    public class WikResponseEntity
    {
        public string period { get; set; }
        public string language { get; set; }
        public string domain { get; set; }
        public int viewCount { get; set; }
    }
}
