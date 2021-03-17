using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Wikimedia.Core.Entities;

namespace Tranzact.Wikimedia.Core.Interfaces
{
    public interface IProcessData
    {
        Task<IEnumerable<FileContentEntity>> ProcessDataByDomainLanguage(IList<WikimediaEntity> listDownload);

        Task<IEnumerable<FileContentEntity>> ProcessDataByPage(IList<WikimediaEntity> listDownload);
    }
}
