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

### Animal Shelter API Endpoints
Base URL: ```http://localhost:5000```

| Request Type | Path |
| :---: | :---: | 
| GET | /api/pets/ |
| GET | /api/pets/{id} |
| POST | /api/pets/ |
| PUT  | /api/pets/{id} |
| DELETE | /api/pets/{id} |

### Path Parameters
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| pageIndex | Number | 1 | not required | Returns the requested index page. |
| pageSize | Number | 10 | not required | Returns up to the requested number of pets per page. |
| name | String | none | not required | Return pets matching requested name. |
| species | String | none | not required | Return pets matching requested species |
| breed | String | none | not required | Return pets matching requested breed |
| color | String | none | not required | Return pets matching requested color |
| minumumAge | Number | none | not required | Returns pets with an age value that is greater than or equal to the specified minimumAge number. |


### Example Queries
This query will return the first page containing up to 10 pets.
```
http://localhost:5000/api/Pets
```
This query will also return the first page containing up to 5 pets.
```
http://localhost:5000/api/Pets?pageIndex=1&pageSize=5
```
This query will return the pet with the id of 3.
```
http://localhost:5000/api/Pets/3
```
This query will return the first page containing up to 5 pets of the species Cat.
```
http://localhost:5000/api/Pets?species=Cat&pageIndex=1&pageSize=5
```
This query will return the first page containing up to 5 pets of the species Cat, name Felix, breed Tuxedo, and minimum age of 3.
```
http://localhost:5000/api/Pets?species=Cat&name=Felix&breed=Tuxedo&minimumAge=3&pageIndex=1&pageSize=5
```

### Example JSON Response
```
[
  {
    "animalId": 3,
    "name": "Felix",
    "species": "Cat",
    "breed": "Tuxedo",
    "color": "Black and White"
    "age": 3
  }
]
```
