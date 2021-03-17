using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Wikimedia.Core.Entities;
using Tranzact.Wikimedia.Core.Interfaces;

namespace Tranzact.Wikimedia.Core
{
    public class Report : IReport
    {
        public IEnumerable<WikResponseEntity> GetReportByLanguageDomain(IEnumerable<FileContentEntity> filesContent)
        {

            var list = new List<WikResponseEntity>();

            foreach (var item in filesContent)
            {
                var wikiResponse = new WikResponseEntity
                {

                    domain = item.domain,
                    language = item.language,
                    period = (Int32.Parse(item.period)) > 12 ? (Int32.Parse(item.period) - 12).ToString() + "PM" : item.period + "AM",
                    viewCount = item.viewCount
                };

                list.Add(wikiResponse);
            }

            return list;


        }

        public IEnumerable<WikiPageResponse> GetReportByPage(IEnumerable<FileContentEntity> filesContent)
        {
            var list = new List<WikiPageResponse>();

            foreach (var item in filesContent)
            {
                var wikiResponse = new WikiPageResponse
                {
                    page = item.pageTitle,
                    period = (Int32.Parse(item.period)) > 12 ? (Int32.Parse(item.period) - 12).ToString() + "PM" : item.period + "AM",
                    viewCount = item.viewCount
                };

                list.Add(wikiResponse);
            }

            return list;
        }
    }
}
