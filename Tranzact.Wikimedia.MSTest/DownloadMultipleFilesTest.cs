using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranzact.Wikimedia.MSTest
{
    [TestClass]
    public class DownloadMultipleFilesTest
    {
        private IDownloadMultipleFiles _DownloadMultipleFiles;

        public DownloadMultipleFilesTest()
        {
            _DownloadMultipleFiles = new DownloadMultipleFiles();
        }


        [TestMethod]
        public void GetDownloadMultipleFiles_Null_Words_ArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => _DownloadMultipleFiles.DownloadMultipleFilesAsync(null));
        }


        [TestMethod]
        public void GetDownloadMultipleFiles_Empty_Words_ArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => _DownloadMultipleFiles.DownloadMultipleFilesAsync(new List<WikimediaEntity>()));
        }


        [TestMethod]
        public async void GetSearchResultsReport_Success()
        {
            IList<string> response = (IList<string>)await _DownloadMultipleFiles.DownloadMultipleFilesAsync(GetTestData());
            Assert.IsNotNull(response);
            Assert.IsFalse(response.ToList().Count == 0);

        }



        public IList<WikimediaEntity> GetTestData()
        {

            List<WikimediaEntity> testData = new List<WikimediaEntity>
            {
                new WikimediaEntity {
                day = "01",
                extension = ".gz",
                hour = "01",
                localPath = @"C:\Users\johao\Source\Repos\TranzactChallenge\TranzactChallenge\Files",
                month = "01",
                name = "pageviews",
                year = "2021"
                },
                new WikimediaEntity {
                day = "02",
                extension = ".gz",
                hour = "02",
                localPath = @"C:\Users\johao\Source\Repos\TranzactChallenge\TranzactChallenge\Files",
                month = "02",
                 name = "pageviews",
                year = "2021"
                },

            };
            return testData;

        }



    }
}
