using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Wikimedia.Configuration; 
using Tranzact.Wikimedia.Services.IService;
using Tranzact.Wikimedia.Services.Models;
using Tranzact.Wikimedia.Util;

namespace Tranzact.Wikimedia.Services.Implementation
{
    public class WikiMediaSearch : ISearch
    {
        static DateTime lastUpdate;
        static long lastBytes = 0; 
        public WikiMediaSearch()
        {
        }
        public async Task<List<WikimediaDto>> DownloadMultipleFilesAsync(IList<WikimediaDto> doclist)
        {
            var list = await Task.WhenAll(doclist.Select(doc => DownloadFileAsync(doc)));

            return list.ToList(); 

        }
        public async Task<WikimediaDto> DownloadFileAsync(WikimediaDto doc) 
        {
            try
            {
                string requestUrl = ConfigurationWikimedia.GetBaseUrl();
                string directory = ConfigurationWikimedia.GetPath();

                doc.localPath = directory + doc.nameFile ;

                Uri uri = new(requestUrl+ doc.path);

                var wc = new WebClient();

                wc.DownloadProgressChanged += (sender, args) =>
                {
                    if (args.ProgressPercentage==100)
                    {  
                        Console.WriteLine("termino la descarga!!"+ doc.nameFile);
                    }
                    Console.WriteLine(" {0} - {1} % " + doc.nameFile + " complete", ProgressChanged(args.BytesReceived), args.ProgressPercentage);
                }; 
                await wc.DownloadFileTaskAsync(uri, doc.localPath + doc.extension);
                   
                    
                return doc;
            }
            catch (Exception e)
            {

                throw;
            }
        
        }


         

        static long ProgressChanged(long bytes)
        {
            if (lastBytes == 0)
            {
                lastUpdate = DateTime.Now;
                lastBytes = bytes;
                return 0;
            }

            var now = DateTime.Now;
            var timeSpan = now - lastUpdate;
            var bytesChange = bytes - lastBytes;
            var bytesPerSecond = timeSpan.Seconds != 0 ? bytesChange / timeSpan.Seconds : 0;

            lastBytes = bytes;
            lastUpdate = now;

            return bytesPerSecond;
        }
    }
}
