# Portfolio_API

![.NET 8](https://img.shields.io/badge/.NET-8.0-blue) 
![C#](https://img.shields.io/badge/C%23-10.0-blue) 
![EF Core](https://img.shields.io/badge/EF_Core-8.0-512BD4) 
![Azure App Service](https://img.shields.io/badge/Azure-App%20Service-blue) 
![Azure SQL Database](https://img.shields.io/badge/Azure-Sql%20Database-blue) 

Multi-purpose backend for personal projects and demos. This repository hosts a .NET 8 Web API that exposes endpoints for Employee Management and Resume/Portfolio features. This is made with assistance of Github Copilot

## Tech stack
- .NET 8 Web API (C#)
- Entity Framework Core (EF Core)
- SQLite databases
- Azure App Service for deployment
- VS Code + REST Client for local testing

## Files & paths of interest
- `Portfolio_API/Controllers/` — API endpoints
- `Portfolio_API.Services/` — Business logic
- `Portfolio_API.Mapper/` — DTO Mapping
- `Portfolio_API.DataAccess/Contexts/` — `ResumeDbContext`
- `Portfolio_API.DataAccess/Repositories/` — domain repositories
- `Portfolio_API/Portfolio_API.http` — REST Client and requests