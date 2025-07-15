using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var postgres = builder.AddPostgres("postgres")
    .AddDatabase("tododb");

var migrations = builder.AddProject<AspireTest_MigrationService>("migrations")
    .WithReference(postgres)
    .WaitFor(postgres);

var apiService = builder.AddProject<AspireTest_ApiService>("apiservice")
    .WithReference(postgres)
    .WithReference(migrations)
    .WithHttpHealthCheck("/health")
    .WaitFor(postgres)
    .WaitForCompletion(migrations);

builder.AddProject<AspireTest_WebApp>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();