using System;
using System.Collections.Generic;
using Tranzact.Wikimedia.Core.Entities;
using Tranzact.Wikimedia.Core.Interfaces;

namespace Tranzact.Wikimedia.Core
{
    public class SearchFiles : ISearchFiles
    {
        public IList<WikimediaEntity> GetLastFiles(int countFiles)
        { 
            DateTime foo = DateTime.Now;
            DateTime univDateTime;
            univDateTime = foo.ToUniversalTime(); 

            List<WikimediaEntity> list = new List<WikimediaEntity>();

            for (int i = 0; i < countFiles; i++)
            {
                list.Add(new WikimediaEntity
                {
                    hour = univDateTime.AddHours(-1 - (i)).Hour < 10 ? "0" + univDateTime.AddHours(-1 - (i)).Hour : univDateTime.AddHours(-1 - (i)).Hour.ToString(),
                    day = univDateTime.AddHours(-1 - (i)).Day < 10 ? "0" + univDateTime.AddHours(-1 - (i)).Day : univDateTime.AddHours(-1 - (i)).Day.ToString(),
                    month = univDateTime.AddHours(-1 - (i)).Month < 10 ? "0" + univDateTime.AddHours(-1 - (i)).Month : univDateTime.AddHours(-1 - (i)).Month.ToString(),
                    year = univDateTime.AddHours(-1 - (i)).Year < 10 ? "0" + univDateTime.AddHours(-1 - (i)).Year : univDateTime.AddHours(-1 - (i)).Year.ToString(),
                    name = "pageviews",
                    extension = ".gz"
                });
            }

            return list;
        }
    }
}
