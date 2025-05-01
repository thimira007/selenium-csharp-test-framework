## Project setup
Restore dependencies -> run: `dotnet restore`

Build the project -> run: `dotnet build`

## Run Tests
To run all tests -> run: `dotnet test`

To run specific set of tests using a annotation. -> run: `dotnet test --filter Category=@smoke`

To generate default trx report
`dotnet test --logger "trx;LogFileName=test-results.trx"`
