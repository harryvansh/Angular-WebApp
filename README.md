Install the following to resolve dependency issues:

dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design

Run the following commands to build table:
dotnet ef migrations add InitialCreate
dotnet ef database update

Helpful Links:
https://msdn.microsoft.com/en-us/library/jj592676(v=vs.113).aspx
https://stackoverflow.com/questions/40275195/how-to-setup-automapper-in-asp-net-core
https://docs.microsoft.com/en-us/ef/core/get-started/netcore/new-db-sqlite
https://www.thereformedprogrammer.net/updating-many-to-many-relationships-in-entity-framework-core/
