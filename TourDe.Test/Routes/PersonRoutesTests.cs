using Microsoft.AspNetCore.Mvc;
using Moq;
using TourDe.Api.Data;
using TourDe.Api.Routes;
using TourDe.Models;

namespace TourDe.Api.Test.Routes;

[TestFixture]
public class PersonRoutesTests
{
    private readonly Mock<IPersonRepository> _personRepository;

    public PersonRoutesTests()
    {
        _personRepository = new Mock<IPersonRepository>();
    }

    [Test, AutoData]
    public async Task TestAddPersonSingle(Person person, int insertedId)
    {
        _personRepository
            .Setup(x => x.AddPerson(person))
            .ReturnsAsync(insertedId);

        var result = (CreatedResult)await PersonApi.AddPerson(_personRepository.Object, person);

        result.Should().NotBeNull();
        result.Location.Should().Be($"/api/person/{insertedId}");
    }

    [Test, AutoData]
    public async Task TestDeletePerson(Person person)
    {
        _personRepository
            .Setup(x => x.DeletePerson(person.Id))
            .Returns(Task.CompletedTask);

        var result = (NoContentResult)await PersonApi.DeletePerson(_personRepository.Object, person.Id);

        result.Should().NotBeNull();
    }

    [Test, AutoData]
    public async Task TestUpdatePerson(Person person)
    {
        _personRepository
            .Setup(x => x.UpdatePerson(person))
            .ReturnsAsync(person);

        var result = (OkObjectResult)await PersonApi.UpdatePerson(_personRepository.Object, person, person.Id);

        result.Should().NotBeNull();
        result.Value.Should().BeSameAs(person);
    }

    [Test, AutoData]
    public async Task TestUpdatePersonNotFound(Person person)
    {
        var result = (NotFoundResult)await PersonApi.UpdatePerson(_personRepository.Object, person, person.Id);

        result.Should().NotBeNull();
    }

    [Test, AutoData]
    public async Task TestGetPerson(Person person)
    {
        _personRepository
            .Setup(x => x.GetPerson(person.Id))
            .ReturnsAsync(person);

        var result = (OkObjectResult)await PersonApi.GetPerson(_personRepository.Object, person.Id);

        result.Should().NotBeNull();
        result.Value.Should().BeSameAs(person);
    }

    [Test, AutoData]
    public async Task TestGetPersonNotFound(int id)
    {
        _personRepository
            .Setup(x => x.GetPerson(id))
            .ReturnsAsync(default(Person?));

        var result = (NotFoundResult)await PersonApi.GetPerson(_personRepository.Object, id);

        result.Should().NotBeNull();
    }

    [Test, AutoData]
    public async Task TestGetAllPersonsEmpty()
    {
        _personRepository
            .Setup(x => x.GetAllPersons())
            .ReturnsAsync(new List<Person>());

        var result = await PersonApi.GetAllPersons(_personRepository.Object);

        result.Should().NotBeNull();
        result.Value.Should().BeEmpty();
    }

    [Test, AutoData]
    public async Task TestGetAllPersons(List<Person> persons)
    {
        _personRepository
            .Setup(x => x.GetAllPersons())
            .ReturnsAsync(persons);

        var result = await PersonApi.GetAllPersons(_personRepository.Object);

        result.Should().NotBeNull();
        result.Value.Should().BeEquivalentTo(persons);
    }
}