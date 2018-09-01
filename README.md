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
------------------------------------------------------------------
To build in developement mode try the following:
	
export ASPNETCORE_ENVIRONMENT=Development

[me@linuxbox me]$ export PATH=$PATH:directory

A better way would be to edit your .bash_profile or .profile file (depending on your distribution) to include the above command. That way, it would be done automatically every time you log in.

reference:
http://www.linuxcommand.org/lc3_wss0010.php
------------------------------------------------------------------
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
https://medium.com/@balramchavan/best-practices-building-angular-services-using-facade-design-pattern-for-complex-systems-d8c516cb95eb
