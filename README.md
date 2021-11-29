# EventManagement

### Kal Academy Deep Stack Program - November 2021

### Web Application built using 
- Microsoft Entity Framework Core 3.1 
- Docker
- Microsoft SQL Server
- ASP.Net Core MVC

### Details of EventManagement project:

### Assignment 3a: 
- We have built web application for users to browse events using multiple filters.
- We have built EventAPI microservice. Within which we have written multiple APIs as below
  - Category API
  - Format API
  - Location API
  - Picture API
  - Event API
- For UI, we have used ASP.Net Web app MVC project as our client. 
- We have used Docker containers for EventAPI microservice, MSSQL Database and WebMVC client.

[See a demo of Assignment 3a](https://youtu.be/6cUGzwwzMZ0) 
---
### Assignment 3b: 
- We have built TokenServiceAPI microservice that will provide Authentication and Authorization services to our project. This microservice will be responsible for
  - Having dedicated database to store user authorization related information
  - Registration for new users
  - Provide login support for registered users 
  - Issue a token for logged in user
  - Validate the token that will be used by other microservices.

- We have added 2 additional Docker containers for TokenService API microservice and its MSSQL Database respectively.
- We have also configured the docker container for WebMVC client to integrate the same with TokenService API.

[See a demo of Assignment 3b](https://youtu.be/YwbV9ZY5AGs) 
---


Swagger document for Event API Microservice will be available at: http://localhost:7000/swagger/index.html

Link for the website: http://localhost:7500/


     

 
