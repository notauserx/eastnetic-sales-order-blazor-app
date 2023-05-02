# eastnetic-sales-order-blazor-app

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
