using AspireTest.Data.Data;
using AspireTest.MigrationService;
using AspireTest.ServiceDefaults;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddHostedService<Worker>();

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(Worker.ActivitySourceName));
builder.AddNpgsqlDbContext<TodoDbContext>(connectionName: "tododb");

var host = builder.Build();
host.Run();