using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourDe.Api.Routes;
using TourDe.Api.Test.Helpers;
using TourDe.Models;

namespace TourDe.Api.Test;

public class PersonRoutesTests
{
    [Test]
    public async Task TestCreatePerson()
    {
        await using var context = new MockTourDeDb().CreateDbContext();

        var person = new Person
        {
            FirstName = "Tester",
            LastName = "McTest",
            DateOfBirth = new DateTime(2000, 1, 1)
        };

        var result = (CreatedResult)await PersonApi.AddPerson(context, person);

        result.StatusCode.Should().Be(StatusCodes.Status201Created);
    }
}