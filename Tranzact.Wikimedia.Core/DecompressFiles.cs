using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Wikimedia.Configuration;
using Tranzact.Wikimedia.Core.Interfaces;
using Tranzact.Wikimedia.Util;

namespace Tranzact.Wikimedia.Core
{
    public class DecompressFiles : IDecompressFiles
    {

        public void DecompressFilesByExtension( string extension)
        {
            string path = ConfigurationWikimedia.GetPath();

            DirectoryInfo directorySelected = new DirectoryInfo(path);

            foreach (FileInfo fileToDecompress in directorySelected.GetFiles("*.gz"))
            {
                DecompressFile.Decompress(fileToDecompress);
            }
        }
    }
}
