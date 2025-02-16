using Autofac;
using Demo.Application.Users;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;

namespace Demo.Application.Test.Users;

public class CreateUserRequestHandlerTests
{
    // MediatR Validation and the Chain of Responsibility Pattern
    public CreateUserRequestHandlerTests()
    {
    }

    [Fact]
    public async Task Handle_ShouldPass_JohnDoe()
    {
        // arrange
        CreateUserRequest request = new("John", "Doe");
        ContainerBuilder builder = new ();

        var configuration = MediatRConfigurationBuilder
            .Create(typeof(CreateUserRequest).Assembly)
            .WithAllOpenGenericHandlerTypesRegistered()
            .Build();

        builder.RegisterMediatR(configuration);
        var di = builder.Build();
        var scope = di.BeginLifetimeScope();
        var mediator = scope.Resolve<IMediator>();

        // act
        var result = await mediator.Send(request);

        // assert
        Assert.Equal("John", result.FirstName);
        Assert.Equal("Doe", result.LastName);
        Assert.Equal("john.doe@domain.com", result.Email);
    }

    [Fact]
    public async Task Handle_ShouldThrowArgumentException_EmptyFirstname()
    {
        // arrange
        CancellationToken token = new();
        CreateUserRequest request = new("", "Doe");
        ContainerBuilder builder = new ContainerBuilder();

        var configuration = MediatRConfigurationBuilder
            .Create(typeof(CreateUserRequest).Assembly)
            .WithAllOpenGenericHandlerTypesRegistered()
            .Build();

        builder.RegisterMediatR(configuration);
        var di = builder.Build();
        var scope = di.BeginLifetimeScope();
        var mediator = scope.Resolve<IMediator>();

        // act

        // assert
        await Assert.ThrowsAsync<ArgumentException>(async () => await mediator.Send(request,token));
    }

    [Fact]
    public async Task Handle_ShouldThrowArgumentException_EmptyLastname()
    {
        // arrange
        CancellationToken token = new();
        CreateUserRequest request = new("John", "");
        ContainerBuilder builder = new ContainerBuilder();

        var configuration = MediatRConfigurationBuilder
            .Create(typeof(CreateUserRequest).Assembly)
            .WithAllOpenGenericHandlerTypesRegistered()
            .Build();

        builder.RegisterMediatR(configuration);
        var di = builder.Build();
        var scope = di.BeginLifetimeScope();
        var mediator = scope.Resolve<IMediator>();

        // act

        // assert
        await Assert.ThrowsAsync<ArgumentException>(async () => await mediator.Send(request, token));
    }
}


