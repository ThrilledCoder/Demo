using Demo.Application.Users;
using FastEndpoints;

namespace Demo.ApiService.Endpoints;

public class CreateUserEndpoint : Endpoint<CreateUserRequest, string>
{
    public override void Configure()
    {
        Post("/api/users");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateUserRequest request, CancellationToken ct)
    {
        await SendAsync(request.FirstName, StatusCodes.Status200OK, ct);
    }
}
