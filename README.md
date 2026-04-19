# Portfolio_API

![.NET 8](https://img.shields.io/badge/.NET-8.0-blue?style=for-the-badge) 
![C#](https://img.shields.io/badge/C%23-10.0-blue?style=for-the-badge) 
![EF Core](https://img.shields.io/badge/EF_Core-8.0-512BD4?style=for-the-badge) 
![Azure App Service](https://img.shields.io/badge/Azure-App%20Service-blue?style=for-the-badge) 
![Azure SQL Database](https://img.shields.io/badge/Azure-Sql%20Database-blue?style=for-the-badge) 

Multi-purpose backend for personal projects and demos. This repository hosts a .NET 8 Web API and made with assistance of Github Copilot, and Ollama (Qwen2.5-Coder:7b)

## Tech stack
- .NET 8 Web API (C#)
- Entity Framework Core (EF Core)
- Azure SQL Database
- Azure App Service for deployment
- VS Code + REST Client for local testing

## Files & paths of interest
- `Portfolio_API/Controllers/` — API endpoints
- `Portfolio_API.Services/` — Business logic
- `Portfolio_API.Mapper/` — DTO Mapping
- `Portfolio_API.DataAccess/Contexts/` — `ResumeDbContext`
- `Portfolio_API.DataAccess/Repositories/` — domain repositories
- `Portfolio_API/Portfolio_API.http` — REST Client and requests

## Current Features
- `Notion Integration` - Integrated Notion API to view specific Notion pages.
- `Resume Details` - Connected to Azure SQL Database. Contains resume contents.