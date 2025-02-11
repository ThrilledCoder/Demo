using Microsoft.AspNetCore.Mvc.RazorPages;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddProblemDetails();

builder.Services.AddOpenApi();

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/api/users", () =>
{
    Bogus.Faker<User> faker = new();

    faker.RuleFor(u => u.FirstName, f => f.Person.FirstName);
    faker.RuleFor(u => u.LastName, f => f.Person.LastName);
    faker.RuleFor(u => u.Email, f => f.Person.Email);
    faker.RuleFor(u => u.Age, f => f.Random.Int(18, 65));

    return faker.Generate(20);
})
.WithName("IsAlive");

app.MapDefaultEndpoints();
app.Run();


class User()
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; }//, string LastName, string Email, int Age
    public string LastName { get; set; }//, string LastName, string Email, int Age
    public string Email { get; set; }//, string LastName, string Email, int Age
    public int Age { get; set; }//, string LastName, string Email, int Age
}