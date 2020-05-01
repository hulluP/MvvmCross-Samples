using Moq;
using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.Tests;
using Xunit;
using StarWarsSample.Core.Services.Interfaces;
using StarWarsSample.Core.ViewModels;
using System;
using StarWarsSample.Core.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace StarWarsSample.Test
{
    public class TestPeopleViewModel : MvxIoCSupportingTest
    {
        [Fact]
        public async Task TestPeopleViewModel1Async()
        {
            // arrange
            Setup();

            var mockNavService = new Mock<IMvxNavigationService>();
            var mockPeopleService = new Mock<IPeopleService>();
            mockPeopleService.Setup(foo => foo.GetPeopleAsync(It.IsAny<string>())).Returns((string url) => GetPeopleMoq(url));
            var test = new PeopleViewModel(mockPeopleService.Object, mockNavService.Object);
            // act

            await test.Initialize();
            // assert

            Assert.Equal(3, test.People.Count);

        }

        private async Task<PagedResult<Person>> GetPeopleMoq(string url)
        {
            PagedResult<Person> result = new PagedResult<Person>()
            {
                Count = 3,
                Next = string.Empty,
                Previous = string.Empty,
                Results = new List<Person>
                {
                    new Person
                    {
                        Name = "Master Yoda",
                        SkinColor = "Green",
                        Height = "65"
                    },
                    new Person
                    {
                        Name = "Obi-Wan Kenobi",
                        Mass = "80"
                    },
                    new Person
                    {
                        Name = "Master Windu",
                        Height = "165",
                        Mass = "85"
                    }
                }
            };
            return result;
        }
    }
}
