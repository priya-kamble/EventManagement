# EventManagement

### Kal Academy Deep Stack Program - November 2021 - January 2022

### Web Application built using 
- Microsoft Entity Framework Core 3.1 
- Docker
- Microsoft SQL Server
- Redis Database
- ASP.Net Core MVC

### Details of EventManagement project:

### Assignment 3a: 
As part of this assignment:
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
As part of this assignment:
- We have built TokenServiceAPI microservice that will provide Authentication and Authorization services to our project. This microservice is responsible for
  - Having dedicated database to store user authorization related information
  - Registration for new users
  - Provide login/logout support for registered users 
  - Issue a token for logged in user
  - Validate the token that will be used by other microservices.

- We have added 2 additional Docker containers for TokenService API microservice and its MSSQL Database respectively.
- We have also configured the docker container for WebMVC client to integrate the same with TokenService API.

[See a demo of Assignment 3c](https://youtu.be/YwbV9ZY5AGs) 
---
### Assignment 3c: 
As part of this assignment:
- We have built CartAPI & OrderAPI microservices that will provide an E2E shopping experience for users. These microservices will enable users to
  - Add/Update/Delete event tickets in the cart.
  - Purchase the tickets for an event.

- We have also implemented the following:
  - User has to be authorized before accessing his cart.
  - Messaging between OrderAPI & CartAPI.
  - Messaging between OrderAPI & EventAPI.
  - Integration of Stripe Payment system with the application.
  - Logging
  - 3 additional Docker containers for CartAPI microservice, Redis Database and OrderAPI microservice respectively.
  - Configured the docker containers for WebMVC client to integrate the same with CartAPI and OrderAPI.

[See a demo of Assignment 3b](https://www.youtube.com/watch?v=nzRd_yhs6-s)

Swagger document for Event API Microservice is available at: http://localhost:7000/swagger/index.html

Link for the website: http://localhost:7500/


     

 
