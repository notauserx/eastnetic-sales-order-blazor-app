# eastnetic-sales-order-blazor-app

A sales order management app, built with .NET 6 and c# 10.

## Run

from the src folder

```
dotnet run --project SalesOrders.Client
dotnet run --project SalesOrders.Api
```

the browse to the app from [this link](https://localhost:7196/)
the browse the swagger from [this link](https://localhost:7080/swagger/index.html)


## Projects

- SalesOrder.Api
    - Houses the api controllers
- SalesOrder.Client
    - The blazor wasm application
- SalesOrder.Data
    - Houses the DAL. SQLite is configured as the db.
- SalesOrder.Contracts
    - Houses the DTOs
- SalesOrder.Core
    - Contains the classes shared between Contracts and Data

## Migrations

Migrations are set up in the SalesOrders.Data project.

Install ef core tools globally 

```bash
dotnet tool install --global dotnet-ef
```

to add a migration after adding/updating the entities, use

```bash
 dotnet ef migrations add <migration-name> --project ../SalesOrders.Data
```

follow it with

```bash
dotnet ef database update
```

to update the db with the changes from the code first models.
