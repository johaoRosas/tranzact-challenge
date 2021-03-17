using System;
using System.Collections.Generic;
using System.Linq;
using Tranzact.Wikimedia.Core;
using Tranzact.Wikimedia.Core.Entities;
using Tranzact.Wikimedia.Core.Interfaces;
using Tranzact.Wikimedia.Infrastructure;
using Tranzact.Wikimedia.Infrastructure.Interfaces;
using Tranzact.Wikimedia.Services.Implementation;
using Tranzact.Wikimedia.Services.IService;
using Xunit;

namespace Tranzact.Wikimedia.Test
{
    public class DownloadMultipleFilesTest
    {
        private ISearch _WikiMediaSearch;
        private IMapper _mapper;

        public DownloadMultipleFilesTest()
        {
            _WikiMediaSearch = new WikiMediaSearch();
        }


        [Fact]
        public async void GetDownloadMultipleFiles_Nullo_Empty_Words_ArgumentException()
        { 
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>await _WikiMediaSearch.DownloadMultipleFilesAsync(null));
        }


        [Fact]
        public async void GetDownloadUnique_Null_o_Empty_Words_ArgumentException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await _WikiMediaSearch.DownloadFileAsync(null));
        }
      


        [Fact]
        public async void GetDownloadMultipleFiles_Success()
        {
            _mapper = new Mapper();
            var filesDto = (from r in GetTestData().ToList() select _mapper.MapFromEntityToDto(r)).ToList();

            var response =  await _WikiMediaSearch.DownloadMultipleFilesAsync(filesDto);
            Assert.NotNull(response);

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
