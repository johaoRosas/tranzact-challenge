using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tranzact.Wikimedia.Core;
using Tranzact.Wikimedia.Core.Entities;
using Tranzact.Wikimedia.Core.Interfaces;

namespace TranzactChallenge
{
    class Program
    {
 
        static void Main(string[] args)
        {
             
            MainAsync().GetAwaiter().GetResult();
        }

        static IDownloadMultipleFiles DownloadMultipleFiles;
        static ISearchFiles SearchFiles;
        static IDecompressFiles DecompressFiles;
        static IProcessData ProccessData;
        static IReport Report;

        public static List<string> Reports { get; private set; }
        static async Task MainAsync()
        {
            IList<WikimediaEntity> files = new List<WikimediaEntity>();

            SearchFiles = new SearchFiles();
            DownloadMultipleFiles = new DownloadMultipleFiles();
            DecompressFiles = new DecompressFiles();
            ProccessData = new ProccessData();
            Report = new Report();
             
           //var folderDetails = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);


            files = SearchFiles.GetLastFiles(3);

            var resultDownload = await DownloadMultipleFiles.DownloadMultipleFilesAsync(files);

            DecompressFiles.DecompressFilesByExtension(".gz");


            Console.WriteLine("Procesando información , espere un momento por favor");

            var data =  await ProccessData.ProcessDataByDomainLanguage(resultDownload);
            var reportLanguageDomain =  Report.GetReportByLanguageDomain(data);

            int cont = 0;

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            foreach (var item in reportLanguageDomain)
            {
                if (cont == 0)
                {
                    Console.WriteLine("Period     Language     Domain     ViewCount");
                }

                Console.WriteLine(item.period + "       " + item.language + "         " + item.domain + "        " + item.viewCount);

                cont++;
            }

            Console.WriteLine("Procesando información del siguiente reporte, espere un momento por favor.......");
            var dataPage = await ProccessData.ProcessDataByPage(resultDownload);
            var reportPage =  Report.GetReportByPage(dataPage);


            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            cont = 0;
            foreach (var item in reportPage)
            {
                if (cont == 0)
                {
                    Console.WriteLine("Period     Page         ViewCount");
                }

                Console.WriteLine(item.period + "       " + item.page + "         " + item.viewCount    );

                cont++;
            }



            //Reports.ForEach(report => Console.WriteLine(report));
            Console.ReadLine();


        }

    }
}
