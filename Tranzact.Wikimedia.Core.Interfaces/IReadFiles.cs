using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Wikimedia.Core.Entities;

namespace Tranzact.Wikimedia.Core.Interfaces
{
    public interface IReadFiles
    {
        Task<List<FileContentEntity>> ReadFileAsync(string path,string period);
    }
}
