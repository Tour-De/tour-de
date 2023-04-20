using Microsoft.AspNetCore.Mvc;
using Moq;
using TourDe.Api.Controllers;
using TourDe.Api.Data;
using TourDe.Core;
using TourDe.Models;

namespace TourDe.Api.Test.Controllers;

[TestFixture]
public class PersonControllerTests
{
    private Mock<IPersonRepository> _personRepository;
    private PersonController _personController;
    
    [SetUp]
    public void Init()
    {
        _personRepository = new Mock<IPersonRepository>();
        _personController = new PersonController(_personRepository.Object);
    }

    [TearDown]
    public void Cleanup()
    {
        Mock.VerifyAll(_personRepository);
    }

    [Test, AutoData]
    public async Task TestAddPersonSingle(Person person, int insertedId)
    {
        _personRepository
            .Setup(x => x.AddPerson(person))
            .ReturnsAsync(insertedId);

        var result = await _personController.AddPerson(person);

        result.Should().NotBeNull();
        result.Should().BeOfType<CreatedAtActionResult>();
        var createdAtActionResult = (CreatedAtActionResult)result;
        createdAtActionResult.ControllerName.Should().Be(nameof(PersonController));
        createdAtActionResult.ActionName.Should().Be(nameof(PersonController.GetPerson));
        createdAtActionResult.RouteValues!.Single(x => x.Key == "id").Value.Should().Be(insertedId);
    }

    [Test, AutoData]
    public async Task TestDeletePerson(Person person)
    {
        _personRepository
            .Setup(x => x.DeletePerson(person.Id))
            .Returns(Task.CompletedTask);

        var result = (NoContentResult)await _personController.DeletePerson(person.Id);

        result.Should().NotBeNull();
    }

    [Test, AutoData]
    public async Task TestUpdatePerson(Person person)
    {
        _personRepository
            .Setup(x => x.UpdatePerson(person))
            .ReturnsAsync(person);

        var result = (OkObjectResult)await _personController.UpdatePerson(person);

        result.Should().NotBeNull();
        result.Value.Should().BeSameAs(person);
    }

    [Test, AutoData]
    public async Task TestUpdatePersonNotFound(Person person)
    {
        _personRepository
            .Setup(x => x.UpdatePerson(person))
            .ThrowsAsync(new NotFoundException(ExceptionMessages.PersonNotFound));

        Func<Task> act = async () => await _personController.UpdatePerson(person);
        await act.Should().ThrowExactlyAsync<NotFoundException>().WithMessage(ExceptionMessages.PersonNotFound);
    }

    [Test, AutoData]
    public async Task TestGetPerson(Person person)
    {
        _personRepository
            .Setup(x => x.GetPerson(person.Id))
            .ReturnsAsync(person);

        var result = (OkObjectResult)await _personController.GetPerson(person.Id);

        result.Should().NotBeNull();
        result.Value.Should().BeSameAs(person);
    }

    [Test, AutoData]
    public async Task TestGetPersonNotFound(int id)
    {
        _personRepository
            .Setup(x => x.GetPerson(id))
            .ReturnsAsync(default(Person?));

        var result = (NotFoundResult)await _personController.GetPerson(id);

        result.Should().NotBeNull();
    }

    [Test, AutoData]
    public async Task TestGetAllPersonsEmpty()
    {
        _personRepository
            .Setup(x => x.GetAllPersons())
            .ReturnsAsync(new List<Person>());

        var result = await _personController.GetAllPersons();

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

        var result = await _personController.GetAllPersons();

        result.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<List<Person>>().Which.Count.Should().Be(persons.Count);
    }
}