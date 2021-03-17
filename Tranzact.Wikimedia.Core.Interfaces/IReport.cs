using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Wikimedia.Core.Entities;

namespace Tranzact.Wikimedia.Core.Interfaces
{
    public interface IReport
    {
        IEnumerable<WikResponseEntity> GetReportByLanguageDomain(IEnumerable<FileContentEntity> filesContent);
        IEnumerable<WikiPageResponse> GetReportByPage(IEnumerable<FileContentEntity> filesContent);
    }
}
