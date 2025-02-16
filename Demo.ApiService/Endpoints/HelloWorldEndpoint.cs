using FastEndpoints;

namespace Demo.ApiService.Endpoints;

public class HelloWorldEndpoint : Endpoint<string>
{
    public override void Configure()
    {
        Get("/hello/world");
        AllowAnonymous();
    }

    public override async Task HandleAsync(string r, CancellationToken ct)
    {
        await SendAsync("Hello World!", StatusCodes.Status200OK, ct);
    }
}
