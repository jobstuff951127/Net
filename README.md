# Project Overview ##
Description This project is a .NET 8 application that follows the Repository Design Pattern, Unit of Work Design Pattern, and Dependency Injection Design Pattern. It utilizes the latest .NET framework version (as of the last update) and incorporates Entity Framework Core for data access, SQL Server as the database, and ASP.NET Web API for creating a RESTful API. The project also achieves a code coverage of 60% using AutoFixture and AutoFixture.AutoMoq for unit testing. 

## Key Components 

- **Repository Design Pattern**: The project employs the Repository pattern to separate the data access layer from the business logic. This promotes code reusability and maintainability. 
- **Unit of Work Design Pattern**: The Unit of Work pattern helps manage database transactions and ensures that multiple database operations are treated as a single unit of work. 
- **Dependency Injection Design Pattern**: Dependency injection is used to inject dependencies into classes, making the application more modular and testable. 
- **Entity Framework Core**: Entity Framework Core is used for database access and entity management, providing a robust ORM (Object-Relational Mapping) solution. 
- **SQL Server**: The project uses SQL Server as the database system to store and manage data. 
- **ASP.NET Web API**: The application is built using ASP.NET Web API, which provides a framework for creating RESTful APIs. 
- **Code Coverage (AutoFixture and AutoFixture.AutoMoq)**: Code coverage is maintained at 60% or higher, ensuring that a significant portion of the codebase is tested. AutoFixture and AutoFixture.AutoMoq are used for generating test data and automating unit tests.
- ## Getting Started
- ### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) 
- Visual Studio or your preferred code editor
- ### Installation
- Clone the repository to your local machine. 2. Open the project in your chosen IDE. ### Configuration 1. Configure your SQL Server connection string in the application configuration file (`appsettings.json` or `.config`). 
### Usage 
- The project is structured according to the Repository and Unit of Work patterns, making it easy to add, update, and retrieve data from the database. ## Testing - Unit tests are implemented using AutoFixture and AutoFixture.AutoMoq to generate test data and ensure comprehensive code coverage.
## Contributions 
- Contributions and suggestions are welcome. If you'd like to contribute, please fork the repository and submit a pull request. 

## License 
- This project is licensed under the [MIT License](LICENSE). # Net
