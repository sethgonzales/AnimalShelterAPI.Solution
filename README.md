# _Animal Shelter API_

#### By _Seth Gonzales_

#### _A C# / ASP.NET Core MVC application using Entity Framework Core and MySQL._

## Technologies Used
* C#
* .NET 6
* ASP.NET Core MVC
* Entity Framework Core
* Postman v10.19
* MySQL
* MySQL Workbench

## Description

This is a Web API application that shares and stores data regarding pets logged at the Animal Shelter. Following full CRUD functionality, users can access the data, update pets, delete pets, and create new pets. This API utilizes pagination to limit the number of results given at a time when a user makes a request to see a list of all pets. A set list of pets are seeded into the database upon download, and can be removed if needed.

## Setup and Installation Requirements

### Required Technology
* Before starting, check that all required technologies are used. For more information on configuring [MySQL](https://dev.mysql.com/doc/mysql-installation-excerpt/5.7/en/) and [MySQLWorkbench](https://dev.mysql.com/doc/workbench/en/), follow the links provided.

### Launching and Setting Up the Project
* Navigate to the Animal Shelter Api repository [GitHub](https://github.com/sethgonzales/AnimalShelterAPI.Solution).
* Clone the repository down using `$ git clone https://github.com/sethgonzales/AnimalShelterAPI.Solution.git n` in your terminal.
* Within the production directory `AnimalShelter`, create a new file called `appsettings.json`.
* Within `appsettings.json`, put in the following code, replacing the `database`, `uid`, and `pwd` values with your own database name, username, and password for MySQL.
```json
{
  "Logging": {
      "LogLevel": {
      "Default": "Warning"
      }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=YOUR_DATABASE;uid=YOUR_USERNAME;pwd=YOUR_PASSWORD;"
  }
}
```