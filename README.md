# ORM Tokenization Example with Entity Framework
Example application to tokenize sensitive data with Entity Framework utilizing [Basis Theory's REST API](https://docs.basistheory.com/#getting-started).

## Requirements
1. [Basis Theory Account](https://basistheory.com)
1. [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0)

### TL;DR


The following is how to run the example application.

```bash
export BT_API_KEY=<INSERT YOUR API KEY>
dotnet run --project ORMTokenizationExample
```

## Lab How-To
1. Set up a [Basis Theory Account](https://portal.basistheory.com/register)
2. Set up a [server to server application](https://docs.basistheory.com/#applications-application-types) with token [create and read permissions](https://docs.basistheory.com/#permissions-permission-types).
    - You can follow the .NET Quickstart [here](https://developers.basistheory.com/getting-started/quickstart-with-dotnet/) to set up your first application and .NET environment
3. Export the resulting API Key to your local shell `export BT_API_KEY=${API_KEY}`
4. Clone `git@github.com:Basis-Theory-Labs/orm-tokenization-example.git` and switch to it as your working directory.
5. Run the example application with `dotnet run --project ORMTokenizationExample`
