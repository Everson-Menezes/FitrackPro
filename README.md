# FitrackPro

## Overview

FitrackPro is a health and fitness application designed to help users track their daily nutrition intake, monitor their weight goals, and calculate body mass index (BMI). The application is built using .NET Core, C#, and SQL Server, following principles of Domain-Driven Design (DDD), Clean Architecture, and SOLID principles.

## Features

- **User Management:** Allows users to register, login, and manage their profiles.

- **Nutrition Tracking:** Enables users to log daily food entries, track calorie consumption, and view nutritional summaries.

- **Weight Management:** Helps users set weight goals and track progress.

- **BMI Calculation:** Provides BMI calculations based on user-provided height and weight.

- **Data Persistence:** Stores user data securely using SQL Server.

- **Testing:** Includes comprehensive unit tests using xUnit for core functionality.

## Technologies Used

- **Language:** C#
- **Framework:** .NET Core 8
- **Database:** SQL Server
- **Tools:** Visual Studio 2022, Docker

## Getting Started

### Prerequisites

- .NET Core SDK 8.0 or higher
- Docker Desktop (optional for local development with containers)
- SQL Server Management Studio (SSMS) or Azure Data Studio for database management

## Getting Started

1. Clone the repository:

**bash:**
  
  cd FitrackPro

- Restore NuGet packages and build the solution:

   dotnet restore
   dotnet build

- Run the application:

   dotnet run --project FitrackPro

- Running Tests

  dotnet test FitrackPro.Tests/FitrackPro.Tests.csproj

- Access the application in your web browser at http://localhost:5000  

### Contributing

Contributions are welcome! Please fork the repository and submit pull requests.

### License

This project is licensed under the MIT License - see the LICENSE file for details.

### License

This project is licensed under the MIT License - see the LICENSE file for details.
