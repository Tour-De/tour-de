using AutoFixture;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using TourDe.Api.Controllers;
using TourDe.Models;
using TourDe.Services.Interfaces;

namespace TourDe.Api.Test.Controllers;

public sealed class IdentityControllerTests : IDisposable
{
    private readonly Mock<IIdentityService> _identityServiceMock;
    private readonly Fixture _fixture = new();

    private readonly IdentityController _controller;

    public IdentityControllerTests()
    {
        _identityServiceMock = new Mock<IIdentityService>(MockBehavior.Strict);
        var nullLogger = new NullLoggerFactory();

        _controller = new IdentityController(nullLogger, _identityServiceMock.Object);
    }

    /// <inheritdoc />
    public void Dispose()
    {
        Mock.Verify(_identityServiceMock);
    }

    [Fact]
    public async Task LoginEmptyEmail()
    {
        // Arrange
        var appUser = _fixture.Create<ApplicationUser>();
        appUser.Email = string.Empty;

        // Act
        var response = await _controller.Login(appUser);

        // Assert
        response
            .Should().BeOfType<ObjectResult>()
            .Which.Value.Should().BeOfType<ProblemDetails>()
            .Which.Detail.Should().Be("Email is required");
    }

    [Fact]
    public async Task LoginIdentityServiceFail()
    {
        // Arrange
        var appUser = _fixture.Create<ApplicationUser>();
        var errorMessage = _fixture.Create<string>();
        var identityServiceResult = Result.Fail<IList<string>>(errorMessage);

        _identityServiceMock
            .Setup(x => x.Login(appUser))
            .ReturnsAsync(identityServiceResult);

        // Act
        var response = await _controller.Login(appUser);

        // Assert
        response
            .Should().BeOfType<ObjectResult>()
            .Which.Value.Should().BeOfType<ProblemDetails>()
            .Which.Detail.Should().Be(errorMessage);
    }

    [Fact]
    public async Task LoginSuccess()
    {
        // Arrange
        var appUser = _fixture.Create<ApplicationUser>();
        var roles = _fixture.Create<IList<string>>();
        var identityServiceResult = Result.Ok(roles);

        _identityServiceMock
            .Setup(x => x.Login(appUser))
            .ReturnsAsync(identityServiceResult);

        // Act
        var response = await _controller.Login(appUser);

        // Assert
        response
            .Should().BeOfType<OkObjectResult>()
            .Which.Value.Should().BeOfType<List<string>>()
            .Which.Should().BeEquivalentTo(roles);
    }
}