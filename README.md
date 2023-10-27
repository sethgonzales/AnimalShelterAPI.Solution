# _Animal Shelter API_

#### By _Seth Gonzales_

#### _A C# / ASP.NET Core MVC application using Entity Framework Core and MySQL._

## Technologies Used
* C#
* .NET 6
* ASP.NET Core MVC
* Entity Framework Core
* Postman v10.19
* Swashbuckle v6.2.3
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
### Running the project
* Navigate to this project's production directory `AnimalShelter`.
* Recreate the database by running the command `$ dotnet ef database update` in your terminal.
* Navigate to your MySQLWorkbench to double check that your database has been built without error.
* In the command line, run the command `$ dotnet run` or `$ dotnet watch run` to compile and execute the application.
   * To compile the application without running it, use the following command: `$ dotnet build`.

## API Documentation 
Explore API endpoints in your browser or in Postman. If using Swagger, navigate to https://localhost:5001/swagger/index.html, or http://localhost:5000/swagger/index.html to test API endpoints


### Note on Pagination
The Animal Shelter API defaults to 10 items per page, beginning on page number 1. To change the number of items (`pageSize`), or the starting page number (`pageIndex`), you can edit the search parameters following the example below.