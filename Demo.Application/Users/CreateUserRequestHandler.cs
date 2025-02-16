using Demo.Core;
using Demo.Core.Models;
using FluentResults;
using MediatR;

namespace Demo.Application.Users
{
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, User>
    {
        async Task<User> IRequestHandler<CreateUserRequest, User>.Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(request.FirstName);
            ArgumentException.ThrowIfNullOrWhiteSpace(request.LastName);

            EmailBuilder emailBuilder = new();
            emailBuilder.SetLastname(request.LastName);
            emailBuilder.SetFirstname(request.FirstName);
            emailBuilder.SetDomain("domain.com");

            var newUser = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = emailBuilder.Build()
            };
            await Task.CompletedTask;

            return newUser;
        }
    }
}
