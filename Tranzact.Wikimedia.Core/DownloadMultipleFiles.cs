using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Wikimedia.Core.Entities;
using Tranzact.Wikimedia.Core.Interfaces;
using Tranzact.Wikimedia.Infrastructure;
using Tranzact.Wikimedia.Infrastructure.Interfaces;
using Tranzact.Wikimedia.Services.Implementation;
using Tranzact.Wikimedia.Services.IService;

namespace Tranzact.Wikimedia.Core
{
    public class DownloadMultipleFiles : IDownloadMultipleFiles
    {  
        static IMapper mapper;
        static ISearch search;

        public async Task<IList<WikimediaEntity>> DownloadMultipleFilesAsync(IList<WikimediaEntity> list)
        {

            //if (list == null || list.Count == 0)
            //    throw new ArgumentException("The parameter is invalid", nameof(list));

            search = new WikiMediaSearch();
            mapper = new Mapper();

            var filesDto = (from r in list.ToList() select mapper.MapFromEntityToDto(r)).ToList();

            var result = await  search.DownloadMultipleFilesAsync(filesDto);

            var filesEntities = (from r in result.ToList() select mapper.MapFromDtoToEntity(r)).ToList();

            return filesEntities;
        }


        //results.Add(new WikimediaEntity
        //{
        //    day = "14",
        //    month = "03",
        //    year = "2021",
        //    extension = ".gz",
        //    hour = "15",
        //    name = "pageviews",
        //});

        //results.Add(new WikimediaEntity
        //{
        //    day = "14",
        //    month = "03",
        //    year = "2021",
        //    extension = ".gz",
        //    hour = "16",
        //    name = "pageviews"
        //});
        //results.Add(new WikimediaEntity
        //{
        //    day = "14",
        //    month = "03",
        //    year = "2021",
        //    extension = ".gz",
        //    hour = "17",
        //    name = "pageviews"
        //});
    }
}
