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
    public class ReadFiles : IReadFiles
    {
 

        public async Task<List<FileContentEntity>> ReadFileAsync(string path ,string period)
        {
            try
            {
                switch (path)
                {
                    case "": throw new ArgumentException("Empty path name is not legal.", nameof(path));
                    case null: throw new ArgumentNullException(nameof(path));
                }

                using var sourceStream = new FileStream(path, FileMode.Open,
                    FileAccess.Read, FileShare.Read,
                    bufferSize: 4096,
                    useAsync: true);
                using var streamReader = new StreamReader(sourceStream, Encoding.UTF8,
                    detectEncodingFromByteOrderMarks: true);
                // detectEncodingFromByteOrderMarks allows you to handle files with BOM correctly. 
                // Otherwise you may get chinese characters even when your text does not contain any
                int counter = 0;
                string line;
                var fileContentList = new List<FileContentEntity>();
                // Read the file and display it line by line.   
                while ((line = await streamReader.ReadLineAsync()) != null)
                {
                    var fileContent = new FileContentEntity();
                    string[] subs = line.Split(' '); 
                    fileContent.domainCode = subs[0];
                    fileContent.period = period;
                    fileContent.pageTitle = subs[1];
                    fileContent.viewCount = Int32.Parse(subs[2]);
                    fileContent.size = Double.Parse(subs[3]);
                    fileContentList.Add(fileContent);
                    counter++;
                }

                streamReader.Close();

                return fileContentList;//
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
