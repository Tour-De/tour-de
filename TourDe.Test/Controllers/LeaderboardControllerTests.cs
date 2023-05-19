using Microsoft.AspNetCore.Mvc;
using Moq;
using TourDe.Api.Controllers;
using TourDe.Api.Data;
using TourDe.Models;

namespace TourDe.Api.Test.Controllers
{
    [TestFixture]
    public class LeaderboardControllerTests
    {
        private Mock<IPersonRepository> _personRepository;
        private LeaderboardController _leaderboardController;
    
        [SetUp]
        public void Init()
        {
            _personRepository = new Mock<IPersonRepository>();
            _leaderboardController = new LeaderboardController(_personRepository.Object);
        }

        [TearDown]
        public void Cleanup()
        {
            Mock.VerifyAll(_personRepository);
        }

        [Test]
        public async Task TestGetLeaderboardEmpty()
        {
            _personRepository
                .Setup(x => x.GetAllPersons())
                .ReturnsAsync(new List<Person>());

            var result = await _leaderboardController.GetLeaderBoard();

            result.Should().NotBeNull();
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<Person>>().Which.Should().BeEmpty();
        }

        [Test, AutoData]
        public async Task TestGetAllPersons(List<Person> persons)
        {
            _personRepository
                .Setup(x => x.GetAllPersons())
                .ReturnsAsync(persons);

            var result = await _leaderboardController.GetLeaderBoard();

            result.Should().NotBeNull();
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<Person>>().Which.Count.Should().Be(persons.Count);
        }
    }
}
