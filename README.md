--------Entity framework help--------
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design

Run the following commands to build table:
dotnet ef migrations add InitialCreate
dotnet ef database update
---------------------------------------

-----add @angular/material to project--------
npm install --save @angular/material@5.2.0  @angular/cdk@5.2.0
npm install --save @angular/animations@5.2.0
 in ClientApp directory or Angular-WebApp (not sure yet)

 dotnet build
 dotnet run
 --------------------------------------------

Helpful Links:
https://msdn.microsoft.com/en-us/library/jj592676(v=vs.113).aspx
https://stackoverflow.com/questions/40275195/how-to-setup-automapper-in-asp-net-core
https://docs.microsoft.com/en-us/ef/core/get-started/netcore/new-db-sqlite
https://www.thereformedprogrammer.net/updating-many-to-many-relationships-in-entity-framework-core/
https://docs.microsoft.com/en-us/ef/core/modeling/relationships
http://hive.rinoy.in/how-to-add-material-ui-components-in-asp-net-core-2-and-angular-web-application/
https://v5.material.angular.io/components/stepper/overview