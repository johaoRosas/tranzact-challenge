using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Wikimedia.Core.Entities;

namespace Tranzact.Wikimedia.Core.Interfaces
{
    public interface IGroupList
    {
        IEnumerable<FileContentEntity> GetGroupedList(IEnumerable<FileContentEntity> searchData);
        IEnumerable<FileContentEntity> GetGroupedListByPage(IEnumerable<FileContentEntity> searchData);
    }
}
