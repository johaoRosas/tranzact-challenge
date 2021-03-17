using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Wikimedia.Core;
using Tranzact.Wikimedia.Core.Entities;
using Tranzact.Wikimedia.Core.Interfaces;
using Xunit;

namespace Tranzact.Wikimedia.Test
{
    public class GroupListTest
    {
        private IGroupList _GroupList;
        public GroupListTest()
        {
            _GroupList = new GroupList();
        }

        [Fact]
        public void GetGroupedList_Nullo_Empty_Words_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _GroupList.GetGroupedList(null));
        }

        [Fact]
       public void GetGroupedList_Success()
       {
            Assert.NotNull(_GroupList.GetGroupedList(GetTestData()));
        }


            [Fact]
        public void GetGroupedListByPage_Success()
        { 
            Assert.NotNull(_GroupList.GetGroupedListByPage(GetTestData()));
        }


            public IList<FileContentEntity> GetTestData()
            {

                List<FileContentEntity> testData = new List<FileContentEntity>
            {
                new FileContentEntity {
                domainCode = "es",
                domain = "Wikipedia",
                language  = "es",
                pageTitle ="Apple",
                period = "01",
                size = 100,
                viewCount = 2000
                },
                new FileContentEntity {
                domainCode = "en",
                domain = "Wikimedia",
                language  = "es",
                pageTitle ="Windows",
                period = "02",
                size = 100,
                viewCount = 2000
                },

            };
                return testData;

            }
        }
}
