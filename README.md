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

This is a Web API application that shares and stores data regarding pets logged at the Animal Shelter. Following full CRUD functionality, users can access the data, update pets, delete pets, and create new pets. This API utilizes pagination to limit the number of results given at a time when a user makes a request to see a list of all pets. A set list of pets are seeded into the database upon download and can be removed if needed.

## Setup and Installation Requirements

### Required Technology
* Before starting, check that all required technologies are used. For more information on configuring [MySQL](https://dev.mysql.com/doc/mysql-installation-excerpt/5.7/en/) and [MySQLWorkbench](https://dev.mysql.com/doc/workbench/en/), follow the links provided.

### Launching and Setting Up the Project
* Navigate to the Animal Shelter Api repository [GitHub](https://github.com/sethgonzales/AnimalShelterAPI.Solution).
* Clone the repository down using `$ git clone https://github.com/sethgonzales/AnimalShelterAPI.Solution.git` in your terminal.
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
* In the command line, run the command `$ dotnet run` or `$ dotnet watch run` to compile and execute the api in your browser.
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
| name | String | none | required for POST & PUT | Return pets matching requested name. |
| species | String | none | required for POST & PUT | Return pets matching requested species. |
| breed | String | none | required for POST & PUT | Return pets matching requested breed. |
| color | String | none | required for POST & PUT | Return pets matching requested color. |
| minimumAge | Number | none | not required | Returns pets with an age value that is greater than or equal to the specified minimumAge number. |
| id | Number | none | required for PUT and DELETE | The ID of the pet requested to see, update, or delete. It must be included in the JSON body of the PUT request. |

### Example GET Requests (Retrieve Lists of Pets)
To retrieve lists of pets by criteria, send GET requests to the following endpoints. 

**Requests:**

This query will return the first page containing up to 10 pets.
```
GET http://localhost:5000/api/Pets
```
This query will return the first page containing up to 5 pets.
```
GET http://localhost:5000/api/Pets?pageIndex=1&pageSize=5
```
This query will return the first page containing up to 5 pets of the species Cat.
```
GET http://localhost:5000/api/Pets?species=Cat&pageIndex=1&pageSize=5
```
This query will return the first page containing up to 5 pets of the species Cat, name Felix, breed Tuxedo, and minimum age of 3.
```
GET http://localhost:5000/api/Pets?species=Cat&name=Felix&breed=Tuxedo&minimumAge=3&pageIndex=1&pageSize=5
```

### Example GET Request (Retrieve a Pet by ID)
To retrieve a specific pet by its ID, send a GET request to the respective pet's endpoint (e.g., /api/pets/{id}). Replace {id} with the actual ID of the pet you want to retrieve.

**Request:**

This query will return the pet with the id of 3.
```
GET http://localhost:5000/api/Pets/3
```

**Example JSON Response**
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

### Example POST Request (Create a New Pet)
To create a new pet, send a POST request to the following endpoint. Include the pet details in the JSON body.

**Request:**
```
POST http://localhost:5000/api/pets/
```
**Example JSON Body**
```
[
  {
  "name": "New Pet",
  "species": "New Species",
  "breed": "New Breed",
  "color": "New Color",
  "age": 2
  }
]
```


### Example PUT Request (Update a Pet)
To update a pet, you must send a PUT request to the respective pet's endpoint (e.g., `/api/pets/{id}`). Ensure that you include the `id` parameter in the JSON body to specify which pet to update. Here's an example of a PUT request:

**Request:**
```
PUT http://localhost:5000/api/pets/3
```
**Example JSON Body:**
```
[
  {
    "id": 3,
    "name": "New Name",
    "species": "New Species",
    "breed": "New Breed",
    "color": "New Color",
    "age": 4
  }
]
```
### Example DELETE Request (Delete a Pet)
To delete a pet, send a DELETE request to the respective pet's endpoint (e.g., /api/pets/{id}). Replace {id} with the actual ID of the pet you want to delete.

**Request:**

```
DELETE http://localhost:5000/api/pets/3
```

## Known Bugs

* There are no known bugs for this API. If you find any, please report them to sethgonzales157@gmail.com

## MIT License
```
Copyright (c) 2023 Seth Gonzales

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```

## Contact Information

If you run into any issues, or would like to contribute to our code, please email: sethgonzales157@gmail.com.

<p align="center"><a href="#">Return to Top</a></p>