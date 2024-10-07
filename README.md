LarixApp
Description
The application is designed to support a small company in the window production process. It includes a product inventory, a customer registry, and allows the calculation of window prices as well as determining the order value for specific customers.

Features
Customer registry management
Window inventory management
Automatic price calculation based on selected parameters
Order value calculation

Requirements
.NET 8 SDK or higher

Installation
To run the application, follow these steps:

    Clone the repository to your local machine.
    Open the solution in your IDE.
    Restore the NuGet packages.
    Update the connection string in appsettings.json to point to your SQL Server instance.
    Run the Entity Framework Core migrations to set up your database: dotnet ef database update
    Start the application. If using Visual Studio, press F5. If using the .NET CLI, navigate to the WebAPI project directory and run: dotnet run

Navigate to the project directory:

    
    cd LarixApp
    


Build the project:

    
    dotnet build
    


Run the application:

    
    dotnet run
    


Visit the local server (default address http://localhost:5000 or specified in the console output) in your browser to use the application.

The application runs in development mode and uses Swagger for API testing during development.
