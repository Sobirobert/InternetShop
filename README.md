Online Shop
Description
The application is designed to manage a small online store for a small business. It allows users to add products along with attachments and photos. In the online store, custom categories can be created with descriptions. Customers can register and then place their orders by providing their home address and other contact details.

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

Requirements:

- .NET 8 SDK
- SQL Server
- An IDE such as Visual Studio 2022 or Visual Studio Code

Installation
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

Build the project:

    
    dotnet build
    


Run the application:

    
    dotnet run
    


Visit the local server (default address http://localhost:5000 or specified in the console output) in your browser to use the application.

The application runs in development mode and uses Swagger for API testing during development.
