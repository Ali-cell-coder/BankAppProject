BankApp

A banking backend application developed with ASP.NET Core Web API using Clean Architecture and CQRS principles.

 Features
 
Customer Management
Individual Customers
Corporate Customers
Credit Application Management
Credit Type Management
RESTful API
Swagger API Documentation
Entity Framework Core
FluentValidation
AutoMapper
MediatR (CQRS)
 Technologies
 
ASP.NET Core 8
C#
Entity Framework Core
SQL Server
MediatR
AutoMapper
FluentValidation
Swagger (OpenAPI)

   Project Structure
   
BankApp.WebApi        -> API Layer
BankApp.Application   -> Business Logic (CQRS)
BankApp.Domain        -> Entities
BankApp.Persistence   -> Database Operations
BankApp.Core          -> Common Components

 API Endpoints
 
Corporate Customers
GET /api/CorporateCustomers
GET /api/CorporateCustomers/{id}
POST /api/CorporateCustomers
PUT /api/CorporateCustomers
DELETE /api/CorporateCustomers/{id}
Individual Customers
CRUD Operations
Credit Applications
GET /api/CreditApplications
POST /api/CreditApplications
Credit Types
GET /api/CreditTypes
POST /api/CreditTypes
  Getting Started
git clone https://github.com/Ali-cell-coder/BankAppProject.git

cd BankAppProject/BANKAPP

dotnet restore

dotnet run --project BankApp.WebApi

Swagger:

https://localhost:7185/swagger
