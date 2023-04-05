using Microsoft.AspNetCore.Mvc;
using TourDe.Api.Routes;
using TourDe.Models;

namespace TourDe.Api.Test;

[TestFixture]
public class PersonRoutesTests: BaseDbContextFixture
{
    [Test, AutoData]
    public async Task TestCreatePerson(Person person)
    {
        var result = (CreatedResult)await PersonApi.AddPerson(_databaseContext, person);

        result.Should().NotBeNull();
        _databaseContext.Persons.Should().HaveCount(1);
        _databaseContext.Persons.First().Should().BeSameAs(person);
    }

    [Test, AutoData]
    public async Task TestDeletePerson(int id)
    {
        var result = (NotFoundResult)await PersonApi.DeletePerson(_databaseContext, id);
        
        result.Should().NotBeNull();
    }
}