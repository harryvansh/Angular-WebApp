Install the following to resolve dependency issues:

dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design

Run the following commands to build table:
dotnet ef migrations add InitialCreate
dotnet ef database update