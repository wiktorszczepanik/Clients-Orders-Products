## Overview

ASP.NET Core Web API for managing clients, orders, and products. The project uses Entity Framework Core with the Code First approach.

## Technologies

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server

## Structure

* `Entities` – domain models
* `Data` – database context
* `Migrations` – EF Core migrations
* `Services` – Business logic
* `Controllers` – API endpoints
* `DTOs` – request and response models

## Endpoints

| Method | Endpoint           | Description                                                                                                                                 |
| ------ | ------------------ | ------------------------------------------------------------------------------------------------------------------------------------------- |
| GET    | `/api/orders/{id}` | Returns details of a specific order. Returns an appropriate HTTP status code if the order does not exist.                                   |
| PUT    | `/api/orders/{id}` | Updates an order status, sets the fulfillment date, and removes associated products. The operation is executed within a single transaction. |

## Running

```bash
dotnet restore
dotnet ef database update
dotnet run
```
