using Demo.Web;
using Demo.Web.Components;
using Demo.Application;
using Microsoft.FluentUI.AspNetCore.Components;
using Demo.Infrastructure;
using Demo.Presentation;

var builder = WebApplication.CreateBuilder(args);
{
    builder.AddServiceDefaults();

    builder.Services.AddRazorComponents()
        .AddInteractiveServerComponents();

    builder.Services.AddFluentUIComponents();

    builder.Services
        .AddApplication(builder.Configuration)
        .AddInfrastructure(builder.Configuration)
        .AddPresentation(builder.Configuration);

    builder.Services.AddOutputCache();

    builder.Services.AddHttpClient<UsersApiClient>(client =>
        {
            client.BaseAddress = new("https+http://apiservice");
        });
}

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.UseOutputCache();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapDefaultEndpoints();

app.Run();
