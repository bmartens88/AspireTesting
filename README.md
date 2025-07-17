# Aspire E2E Testing Demonstration
This repository contains a sample application which consists out of the following tools/frameworks:
| Tool/Framework   | Version                      |
| ---------------- | ---------------------------- |
| .NET             | [9.0.7][netSDK]              |
| .NET Aspire      | [9.3][aspireSetup]           |
| TUnit            | [0.25.21][tUnit]             |
| TUnit.Playwright | [0.25.21][tUnitPlaywright]   |
| Playwright       | [1.52.0][playwright]         |

> [!WARNING]
> Some of the packages used are still in early development and have yet to see a stable realese.

## Purpose of this repository
This repository serves a couple of purposes when it comes to testing. It demonstrates how to:
* Setup a .NET Aspire solution
    * with caching, using [Redis][redis]
    * with database interaction, using [PostgreSQL][postgres] and Entity Framework Core
    * with Blazor front-end application which interacts with an API
* Integration testing a .NET Aspire solution using TUnit
* End-to-end (E2E) testing a .NET Aspire solution using Playwright

[netSDK]: https://dotnet.microsoft.com/en-us/download/dotnet/9.0
[aspireSetup]: https://learn.microsoft.com/en-us/dotnet/aspire/fundamentals/setup-tooling?tabs=windows&pivots=vscode
[tUnit]: https://tunit.dev/
[tUnitPlaywright]: https://tunit.dev/docs/examples/playwright/
[playwright]: https://playwright.dev/dotnet/docs/intro
[redis]: https://redis.io
[postgres]: https://www.postgresql.org/
