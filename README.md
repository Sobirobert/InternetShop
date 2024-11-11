# Online Shop
## Description
The application is designed to manage a small online store for a small business. It allows users to add products along with attachments and photos. In the online store, custom categories can be created with descriptions. Customers can register and then place their orders by providing their home address and other contact details.

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

## Requirements:

- .NET 8 SDK
- SQL Server
- An IDE such as Visual Studio 2022 or Visual Studio Code

## Installation
To run the application, follow these steps:

 Clone the repository to your local machine.
 Open the solution in your IDE.
 Restore the NuGet packages.
 Update the connection string in appsettings.json to point to your SQL Server instance.
 Run the Entity Framework Core migrations to set up your database: dotnet ef database update
 Start the application. If using Visual Studio, press F5. If using the .NET CLI, navigate to the WebAPI project directory and run: dotnet run

Features

(Current features...)    
- User Authentication: Registering and authenticating users with different roles (Customer, Administrator).
- Product Management: Adding, updating, and removing products in the online store.
- Image Upload: Attaching images to products for better visualization.
- Attachment Upload: Including instructions in PDF format or other file types.
- Category Management: Adding, updating, and removing categories.
- Order Management: Creating new orders, updating existing ones, and adding products to the cart.
- Log Saving: Saving logs to a file.
- Application Security Status Control.
- Data Caching: Ensuring greater application fluidity.
- SDK: The online store SDK provides a comprehensive interface for integration with the store platform, allowing developers to easily implement user authentication, product management, and image uploading in their applications.

## Planned Features
To further improve and make the online store useful, I plan to introduce the following features:
- integrate payments to orders,
- build an order invoicing system,
- introduce a newsletter to advertise products,

## Development
This solution is based on the principles of clean architecture, dividing the concerns into different projects: Application: contains the basic application logic and interfaces.
Domain: includes domain entities and enums.
Infrastructure: handles data access and external services.
WebAPI: application entry point, hosting the Web API.

## Dependencies

This project uses several NuGet packages to provide its functionality. Below is a list of key packages and their versions:
- AutoMapper (AutoMapper, AutoMapper.Extensions.Microsoft.DependencyInjection): A convention-based object-object mapper. Version: 13.0.1
- FluentEmail (FluentEmail.Core, FluentEmail.Razor, FluentEmail.Smtp): An email sending library for .NET, making it easier to send emails with Razor templates. Version: 3.0.2
- FluentValidation.AspNetCore: Provides a way to use FluentValidation to validate objects in ASP.NET Core. Version: 11.3.0
- Microsoft.AspNetCore.Authentication.JwtBearer: Support for JWT (JSON Web Tokens) in ASP.NET Core. Version: 8.0.6
- Microsoft.AspNetCore.Http.Abstractions: ASP.NET Core HTTP object model for HTTP requests and responses and also common extension methods for registering middleware in an IApplicationBuilder. Version: 2.2.0
- Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation: Adds support for runtime compilation of Razor views in ASP.NET Core. Version: 8.0.6
- Microsoft.AspNetCore.Mvc.Versioning: A service API versioning library for Microsoft ASP.NET Core. Version: 5.1.0
- Microsoft.Data.SqlClient: he current data provider for SQL Server and Azure SQL databases. This has replaced System.Data.SqlClient. These classes provide access to SQL and encapsulate database-specific protocols, including tabular data stream. Version="5.2.1
- Microsoft.Extensions.Caching.StackExchangeRedis: Distributed cache implementation of Microsoft.Extensions.Caching.Distributed.IDistributedCache using Redis. Version: 8.0.6
- Microsoft.Extensions.Logging: Logging infrastructure default implementation for Microsoft.Extensions.Logging. Version="8.0.0
- Microsoft.EntityFrameworkCore (Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.SqlServer, Microsoft.EntityFrameworkCore.Design, Microsoft.EntityFrameworkCore.Tools): A framework for working with databases using objects and LINQ. Version: 8.0.6
- Microsoft.AspNetCore.Mvc.Core: ASP.NET Core MVC core components. Contains common action result types, attribute routing, application model conventions, API explorer, application parts, filters, formatters, model binding, and more. Version: 2.2.5
- Microsoft.AspNetCore.Identity (Microsoft.AspNetCore.Identity, Microsoft.AspNetCore.Identity.EntityFrameworkCore): ASP.NET Core Identity framework for managing users, roles, and authentication. Version: 2.1.39 (Identity), 8.0.6 (Identity.EntityFrameworkCore)
- Swashbuckle.AspNetCore (Swashbuckle.AspNetCore, Swashbuckle.AspNetCore.Annotations, Swashbuckle.AspNetCore.Filters): Swagger tooling for API's built with ASP.NET Core. Version: 6.4.0, 6.6.1 (Annotations), 8.0.2 (Filters)
- Cosmonaut (Cosmonaut, Cosmonaut.Extensions.Microsoft.DependencyInjection): A library that simplifies the use of Azure Cosmos DB. Version: 2.11.3 (Cosmonaut), 2.3.0 (Extensions)
- Humanizer.Core A library that helps in manipulating and displaying strings, enums, dates, times, timespans, numbers, and quantities. Version: 2.14.1
- Refit (Refit) Simplifies the creation of REST API clients by turning interfaces into live HTTP services. Version: 6.0.94
- HealthChecks ((AspNetCore.HealthChecks.UI, AspNetCore.HealthChecks.UI.Client, AspNetCore.HealthChecks.UI.InMemory.Storage, Microsoft.Extensions.Diagnostics.HealthChecks, Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore) Provides health check endpoints and a UI for monitoring the health of your application and its dependencies. Version: 8.0.1
- NLog (NLog.Web.AspNetCore) A logging platform for .NET with rich log routing and management capabilities. Version: 5.3.11
                 
## Adding a New Feature
To add a new feature, start by defining any necessary domain entities and interfaces in the Application and Domain projects. Implement the interfaces in the Infrastructure project. Finally, expose the functionality through controllers in the WebAPI project.

Visit the local server (default address http://localhost:5000 or specified in the console output) in your browser to use the application.
