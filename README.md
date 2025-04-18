# Backend – ASP.NET Web API

This is the backend for a project management application built with ASP.NET Core Web API. It exposes a RESTful API that supports project-related CRUD operations and filtering, secured with a simple API key authentication mechanism.

## Features

- **RESTful API Endpoints** for managing projects, clients, users, and statuses
- **API Key Authorization** to protect specific routes without requiring full user authentication
- **Entity Framework Core** for database interaction with SQL Server
- **Async Methods** for improved performance and scalability
- **Includes Navigation Properties** so related data (e.g., client, status, owner) can be returned with project info

## Authentication

- The backend uses a custom `ApiKeyAuthorize` attribute that checks incoming requests for a valid `x-api-key` header.
- API key is configured via `appsettings.json`, environment variables, or Azure portal settings.

## Technologies Used

- ASP.NET Core (Web API)
- Entity Framework Core
- SQL Server (Azure-hosted)

## Setup (Local Development)

1. Clone the repo.
2. Create an `appsettings.Local.json` file:
   ```json
   {
     "ConnectionStrings": {
       "SqlConnection": "your-local-or-cloud-db-connection"
     },
     "ApiKey": "your-api-key-here"
   }
   ```
3. Add `appsettings.Local.json` to `.gitignore`
4. Run using Visual Studio or `dotnet run`

## Deployment

- The API is deployed as an Azure App Service with an Azure SQL Database.
- Production environment values (like the API key and connection string) are configured in the Azure portal under **Configuration > Application settings**.

## Endpoints

Typical endpoints include:

- `GET /api/Projects` – Get all projects (includes related data)
- `POST /api/Projects` – Create a new project
- `PUT /api/Projects` – Update a project
- `DELETE /api/Projects/{id}` – Delete a project
- Similar routes exist for `/Clients`, `/Users`, and `/Statuses`

## Notes

- CORS is enabled to allow the deployed frontend to access the API.
- Swagger UI is integrated and supports manual testing by adding the API key via the "Authorize" button.

---

This backend is optimized for use with a front-end application that sends API requests with a pre-shared API key and handles project management features in a lightweight, secure, and user-friendly way.

