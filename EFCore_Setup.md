# EF Core Scaffold SQLServer

## Scaffold Requirements (NuGet)
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools

## Bash Command
```bash
dotnet ef dbcontext scaffold 'Data Source=jdb-sql-southeast.database.windows.net;Initial Catalog=jdb_f1db;User ID=<your-user>;Password=<your-password>;Pooling=False;Connect Timeout=30;Encrypt=True;Authentication=SqlPassword;Application Name=vscode-mssql;Application Intent=ReadWrite;Command Timeout=30' Microsoft.EntityFrameworkCore.SqlServer -t projects -o Data/ScaffoldExisting -c JDBContext --project Portfolio_API.DataAccess --startup-project Portfolio_API.DataAccess --no-onconfiguring --force
```
