# NorthwindAPI

NorthwindAPI is a .NET Core-based API that provides CRUD operations for managing entities in the Northwind database. It supports both Dapper and Entity Framework as ORMs, offering flexibility and ease of use.

### Features

1. Full CRUD operations for all entities.
2. Follows the MVC architecture for simplicity and maintainability.
3. Easy-to-understand architecture and operations.
4. Uses MS-SQL with a DB-First approach.
5. Supports both Dapper and Entity Framework with minimal configuration changes.

## Technologies Used

- **.NET Core**
- **Dapper**
- **Entity Framework Core**
  - Microsoft.EntityFrameworkCore
  - Microsoft.EntityFrameworkCore.Design
  - Microsoft.EntityFrameworkCore.SqlServer
  - Microsoft.EntityFrameworkCore.Tools
- **AutoMapper**

## Configuration

To switch between Dapper and Entity Framework, update the `ORM` setting in `appsettings.json`:

```json 
{ 
    "ORM": "dapper" // Use "ef" for Entity Framework 
}
```

### Endpoints
    - Category
        [GET]       .../Categories
        [GET]       .../Categories/id
        [DELETE]    .../Categories/id
        [POST]      .../Category
        [PUT]       .../Category
        [GET]       .../Categories/id/Products

    - Customer
        [GET]       .../Customers
        [GET]       .../Customers/id
        [DELETE]    .../Customers/id
        [POST]      .../Customer
        [PUT]       .../Customer
        [GET]       .../Customers/id/Orders

    - Employee
        [GET]       .../Employees
        [GET]       .../Employees/id
        [DELETE]    .../Employees/id
        [POST]      .../Employee
        [PUT]       .../Employee
        [GET]       .../Employees/id/Orders
        [GET]       .../Employees/id/Territories

    - Order
        [GET]       .../Orders
        [GET]       .../Orders/id
        [DELETE]    .../Orders/id
        [POST]      .../Order
        [PUT]       .../Order
        [GET]       .../Orders/id/Customer
        [GET]       .../Orders/id/OrderDetails
        [GET]       .../Orders/id/Shipper
        [GET]       .../Orders/id/Employee

    - Product
        [GET]       .../Products
        [GET]       .../Products/id
        [DELETE]    .../Products/id
        [POST]      .../Product
        [PUT]       .../Product
        [GET]       .../Products/id/Category
        [GET]       .../Products/id/Supplier
        [GET]       .../Products/id/OrderDetails

    - Region
        [GET]       .../Regions
        [GET]       .../Regions/id
        [DELETE]    .../Regions/id
        [POST]      .../Region
        [PUT]       .../Region
        [GET]       .../Regions/id/Territories

    - Shipper
        [GET]       .../Shippers
        [GET]       .../Shippers/id
        [DELETE]    .../Shippers/id
        [POST]      .../Shipper
        [PUT]       .../Shipper
        [GET]       .../Shippers/id/Orders

    - Supplier
        [GET]       .../Suppliers
        [GET]       .../Suppliers/id
        [DELETE]    .../Suppliers/id
        [POST]      .../Supplier
        [PUT]       .../Supplier
        [GET]       .../Suppliers/id/Products
        
    - Territory
        [GET]       .../Territoriess
        [GET]       .../Territoriess/id
        [DELETE]    .../Territoriess/id
        [POST]      .../Territory
        [PUT]       .../Territory
        [GET]       .../Territoriess/id/Region
        [GET]       .../Territoriess/id/Employees

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/OrkunDmrc/NorthwindAPI.git

2. Navigate to the project directory:
   ```bash
   cd NorthwindAPI

3. Restore dependencies:
   ```bash
   dotnet restore

4. Update the `appsettings.json` file with your database connection string.

5. Build the project:
   ```bash
   dotnet build

6. Run the application:
   ```bash
   dotnet run

7. Access the API at `https://localhost:5001` or `http://localhost:5000`.
