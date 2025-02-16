using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Demo_ApiService>("apiservice");
var cache = builder.AddRedis("servicecache");
var messageBus = builder.AddRabbitMQ("messagebus").WithLifetime(ContainerLifetime.Persistent);
var logging = builder.AddSeq("logging");
var userDb = builder.AddPostgres("db").WithPgAdmin();

builder.AddProject<Projects.Demo_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WithReference(cache)
    .WithReference(userDb)
    .WithReference(messageBus)
    .WithReference(logging)
    .WaitFor(apiService);

builder.Build().Run();
