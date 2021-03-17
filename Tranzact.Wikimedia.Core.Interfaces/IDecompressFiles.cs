using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranzact.Wikimedia.Core.Interfaces
{
    public interface IDecompressFiles
    {
        void DecompressFilesByExtension(string extension);
    }
}
