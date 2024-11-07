# Getting Started

1. `dotnet ef migrations add IntialMigration --project .\TourDe.Data\TourDe.Data.csproj --startup-project .\TourDe.Api\TourDe.Api.csproj`
1. Create a database named `tourde`.
1. Configure a database user with the `db_owner` role.
1. Update the `DefaultConnectionString` in `appsettings.json` with the details for your particular database flavor.
1. Ensure the database schema is up to date by running the following command from the .NET Core CLI: `dotnet ef database update`
1. Start the API.

## Adding Migrations
In the API project folder, run the command `dotnet ef migrations add {migrationName}` to generate the database changes required from the most recent snapshot.

Note: the `dotnet ef database update` command must be run for the changes to be applied.