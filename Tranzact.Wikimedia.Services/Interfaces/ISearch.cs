using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Tranzact.Wikimedia.Services.Models;

namespace Tranzact.Wikimedia.Services.IService
{
    public interface ISearch
    {
        Task<WikimediaDto> DownloadFileAsync(WikimediaDto doc);

        Task<List<WikimediaDto>> DownloadMultipleFilesAsync(IList<WikimediaDto> doclist);
    }
}
