# ASP.NETCoreWebAPI

## Logging with NLog.Web.AspNetCore and NLog

See [Getting started with ASP.NET Core 2](https://github.com/NLog/NLog.Web/wiki/Getting-started-with-ASP.NET-Core-2) with [NLog.Web.AspNetCore](https://www.nuget.org/packages/NLog.Web.AspNetCore/) and [NLog](https://www.nuget.org/packages/NLog/).

## Code First with MySql on Entity Framework Core

See [Getting Started](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql) from `Pomelo.EntityFrameworkCore.MySql`.

### Maintain the Database

```powershell
dotnet ef migrations add <NAME>

dotnet ef migrations remove

dotnet ef database update

dotnet ef migrations script -o doc/ASP.NETCoreWebAPI.mysql
```