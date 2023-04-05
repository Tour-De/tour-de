using Microsoft.AspNetCore.Mvc;
using TourDe.Api.Routes;
using TourDe.Api.Test.Helpers;
using TourDe.Models;

namespace TourDe.Api.Test;

public class PersonRoutesTests
{
    [Test, AutoData]
    public async Task TestCreatePerson(Person person)
    {
        await using var context = new MockTourDeDb().CreateDbContext();

        var result = (CreatedResult)await PersonApi.AddPerson(context, person);

        result.Should().NotBeNull();
        context.Persons.Should().HaveCount(1);
        context.Persons.First().Should().BeSameAs(person);
    }
}