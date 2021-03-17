using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Wikimedia.Core.Entities;
using Tranzact.Wikimedia.Core.Interfaces;
using Tranzact.Wikimedia.Util;

namespace Tranzact.Wikimedia.Core
{
    public class ProccessData : IProcessData
    {
        static IReadFiles ReadFiles;
        static IGroupList GroupList;
        static IReadFileCodes ReadFileCodes;
        static IProcessConversionData ProcessConversionData;

        public async Task<IEnumerable<FileContentEntity>> ProcessDataByDomainLanguage(IList<WikimediaEntity> listDownload)
        {
            ReadFiles = new ReadFiles();
            GroupList = new GroupList();
            ReadFileCodes = new ReadFileCodes();
            ProcessConversionData = new ProcessConversionData();

            var list = new List<FileContentEntity>();



            var codes = ReadFileCodes.getListCodes();
            
            foreach (var item in listDownload)
            {
                var result = await ReadFiles.ReadFileAsync(item.localPath,item.hour);

                var processedList = ProcessConversionData.ConvertDataToProcess(result, codes);

                var listGroup = GroupList.GetGroupedList(processedList); 

                var maxViewCont = listGroup.GetMax(item => item.viewCount);
                maxViewCont.period = item.hour;
                list.Add(maxViewCont); 

            }


            return list; 
            
        }

        public async Task<IEnumerable<FileContentEntity>> ProcessDataByPage(IList<WikimediaEntity> listDownload)
        {
            ReadFiles = new ReadFiles();
            GroupList = new GroupList();
            ReadFileCodes = new ReadFileCodes();
            ProcessConversionData = new ProcessConversionData();

            var list = new List<FileContentEntity>();



            var codes = ReadFileCodes.getListCodes();

            foreach (var item in listDownload)
            {
                var result = await ReadFiles.ReadFileAsync(item.localPath, item.hour);

                var processedList = ProcessConversionData.ConvertDataToProcess(result, codes);

                var listGroup = GroupList.GetGroupedListByPage(processedList);

                var maxViewCont = listGroup.GetMax(item => item.viewCount);
                maxViewCont.period = item.hour;
                list.Add(maxViewCont);

            }


            return list;

        }
    }
}
