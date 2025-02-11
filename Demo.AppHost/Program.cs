var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Demo_ApiService>("apiservice");

builder.AddProject<Projects.Demo_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
