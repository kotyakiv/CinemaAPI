# CinemaAPI
Assignment project for Fatman Oy 

#### The project is done with web API with ASP.NET Core

#### Goal:
to implement API that should allow users to create, read, update, and delete records in a database using HTTP verbs (POST, GET, PUT, DELETE)

#### Required packages for the project:
1. Microsoft.EntityFrameworkCore.InMemory
2. (Optional) NuGet\Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design -Version 6.0.11 

#### The API isn't pubished or hosted. Use Swagger to test and run the project

## Endpoints
-	GET /cinemas - to retrieve a list of all cinemas
-	GET /cinemas/{id} - to retrieve a specific resource by ID
-	GET /cinemas/{id}/showtimes – to get times when shows start
-	POST /cinemas - to create a new cinema
-	PUT /cinemas/{id} - to update a specific cinema by ID
-	DELETE /cinemas/{id} - to delete a specific cinema by ID

## GET /cinemas
retrieve a list of all cinemas  

API response:  
```
[
   {
      "id":0,
      "name:"string",
      "openingHour":0,
      "closingHour":0,
      "showDuration":0
   },
   {
      "id":0,
      "name:"string",
      "openingHour":0,
      "closingHour":0,
      "showDuration":0
   }
]
```
if list is empty, response is 
```
[]
```

## GET /cinemas/{id}
retrieve a specific resource by ID  
API response if id exists:
```
   "id":0,
   "name:"string",
   "openingHour":0,
   "closingHour":0,
   "showDuration":0

```
if there is no id
```
Error: response status is 404
```

## GET /cinemas/{id}/showtimes  
get times when shows start  
API respones
```
[
  [
    10,
    0
  ],
  [
    11,
    55
  ],
]
```

## POST /cinemas
creates a new cinema  
all values are required  
Request body
```
{
    "name:"string",
    "openingHour":0,
    "closingHour":0,
    "showDuration":0
}
```
API respones
```
    "id:1,
    "name:"string",
    "openingHour":0,
    "closingHour":0,
    "showDuration":0
```
API response if:  
- openingHour,closingHour,showDuration are negative  
- hours bigger than 24  
- openingHour and closingHour are equal  
   response is
```
Error: response status is 400
```


## PUT /cinemas/{id}
updates a specific cinema by ID  
all values are required  
API request
```
    "name:"string",
    "openingHour":0,
    "closingHour":0,
    "showDuration":0

```
API response if:  
- openingHour,closingHour,showDuration are negative  
- hours bigger than 24  
- openingHour and closingHour are equal  
```
Error: response status is 400
```
API response
```
    "id:1,
    "name:"string",
    "openingHour":0,
    "closingHour":0,
    "showDuration":0

```

## DELETE /cinemas/{id}
delete a specific cinema by ID  
API response if id exists
```
{
  "success": true
}
```
if id doesn't exists
```
Error: response status is 404
```
