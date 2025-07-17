using Microsoft.Playwright;
using TUnit.Playwright;

namespace AspireTest.TestProject.Tests;

[NotInParallel]
public class Playwright : PageTest
{
    public override BrowserNewContextOptions ContextOptions(TestContext testContext)
    {
        var options = base.ContextOptions(testContext);
        options.IgnoreHTTPSErrors = true; // GitHub Actions CI
        return options;
    }

    [Test]
    [NotInParallel]
    public async Task Test()
    {
        // Reference to web app
        var urlSought = GlobalSetup.App!.GetEndpoint("webfrontend");

        // Go to page
        await Page.GotoAsync(urlSought.ToString());

        // Click the 'home' link
        await Page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "TUnit.Aspire" }).ClickAsync();

        // Expect there to be a heading with text 'Hello, world!'
        await Expect(Page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { Name = "Hello, world!" }))
            .ToBeVisibleAsync();
    }

    [Test]
    [NotInParallel]
    public async Task AnotherTest()
    {
        // Reference to web app
        var urlSought = GlobalSetup.App!.GetEndpoint("webfrontend");

        // Go to page
        await Page.GotoAsync(urlSought.ToString());

        // Click the 'weather' link
        await Page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Weather" }).ClickAsync();

        // Wait for loading to complete
        await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

        // Get a reference to the table
        var table = Page.GetByRole(AriaRole.Table);
        await Expect(table).ToHaveCountAsync(1);

        // Should contain 5 rows, including the header row
        await Expect(table.GetByRole(AriaRole.Row)).ToHaveCountAsync(6);
    }
}