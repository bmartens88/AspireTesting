﻿// Here you could define global logic that would affect all tests

// You can use attributes at the assembly level to apply to all tests in the assembly

using Aspire.Hosting;

[assembly: Retry(3)]
[assembly: System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]

namespace AspireTest.TestProject;

public class GlobalSetup
{
    public static DistributedApplication? App{ get; private set; }
    public static ResourceNotificationService? NotificationService { get; private set; }

    [Before(TestSession)]
    public static async Task SetUp()
    {
        // Arrange
        var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.AspireTest_AppHost>();
        appHost.Services.ConfigureHttpClientDefaults(clientBuilder =>
        {
            clientBuilder.AddStandardResilienceHandler();
        });
        appHost.Configuration["ASPIRE_ALLOW_UNSECURED_TRANSPORT"] = "true";

        App = await appHost.BuildAsync();
        NotificationService = App.Services.GetRequiredService<ResourceNotificationService>();
        await App.StartAsync();
    }

    [After(TestSession)]
    public static async Task CleanUp()
    {
        Console.WriteLine("...and after!");
        await (App?.DisposeAsync() ?? ValueTask.CompletedTask);
        NotificationService?.Dispose();
    }
}