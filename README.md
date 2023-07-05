# Blood Connect - Blood Donation Management Web Application

Blood Connect is a web application developed as the final project of the 5ª Academia .NET Atos using ASP.NET Core MVC and Entity Framework, designed to facilitate the connection between blood banks and blood donors.

## Overview
Blood Connect aims to streamline the process of finding suitable blood donors for blood banks. By registering as a donor on the web application, blood banks can then easily 
search for donors based on their specific requirements and contact them for potential blood donations.

## Key Features
- User Registration: Donors can create an account and provide their personal information, including blood type and contact details.
- Donor Search: Blood banks have access to a search feature that allows them to find registered donors based on specific criteria, such as blood type and location.
- CRUD Operations by admin user.
- Authentication and Authorization: The application utilizes the Identity Framework for user authentication and authorization, ensuring secure access to donor and blood bank functionalities.

## Technologies Used
- ASP.NET Core MVC: The web application framework for building the user interface and handling HTTP requests.
- Entity Framework: The object-relational mapping (ORM) framework used for data access and database management.
- SQL Server: The relational database management system (RDBMS) used to store and manage donor and blood bank information.
- Identity Framework: The authentication and authorization framework used to manage user accounts and access control.

## Prerequisites
- .NET Core SDK
- SQL Server
- Visual Studio

## NuGet package
- Microsoft.EntityFrameworkCore
- Microsoft.AspNetCore.IdentityFrameworkCore
- Microsoft.EntityFrameworkCore.Proxies
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.AspNetCore.Identity.EntityFrameworkCore

## Getting Started
1. Clone the repository.
2. Configure the database connection string in the `appsettings.json` file.
3. Open the solution in Visual Studio or Visual Studio Code.
4. Run the database migrations to create the necessary tables and seed initial data.
5. Build and run the application.

