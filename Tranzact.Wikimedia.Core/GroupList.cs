using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Wikimedia.Core.Entities;
using Tranzact.Wikimedia.Core.Interfaces;

namespace Tranzact.Wikimedia.Core
{
    public class GroupList  : IGroupList
    {
        public IEnumerable<FileContentEntity> GetGroupedList(IEnumerable<FileContentEntity> searchData)
        {
            if (searchData == null || searchData.Count() == 0)
                throw new ArgumentException("The parameter is invalid", nameof(searchData));


            var result = searchData.GroupBy(x => new
            {  
              Language = x.language, Domain = x.domain })
            .Select(v => new FileContentEntity() 
            {  
               language = v.Key.Language,
                domain = v.Key.Domain,
                viewCount = v.Sum(y => y.viewCount)
            })
            .ToList();



            return result;
        }

        public IEnumerable<FileContentEntity> GetGroupedListByPage(IEnumerable<FileContentEntity> searchData)
        {
            if (searchData == null || searchData.Count() == 0)
                throw new ArgumentException("The parameter is invalid", nameof(searchData));


            var result = searchData.GroupBy(x => new
            {
                Page = x.pageTitle
            })
            .Select(v => new FileContentEntity()
            {
                pageTitle = v.Key.Page,
                viewCount = v.Sum(y => y.viewCount)
            })
            .ToList();



            return result;
        }
    }
}
