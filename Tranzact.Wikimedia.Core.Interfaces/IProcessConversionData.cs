using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Wikimedia.Core.Entities;

namespace Tranzact.Wikimedia.Core.Interfaces
{
    public interface IProcessConversionData
    {
        IEnumerable<FileContentEntity> ConvertDataToProcess(IList<FileContentEntity> filesContent, IList<Codedentity> codes);
        string GetLanguage(FileContentEntity filesContent, List<Codedentity> codes);
        string GetDomain(FileContentEntity filesContent, List<Codedentity> codes);
    }
}
