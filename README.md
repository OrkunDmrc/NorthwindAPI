# NorthwindAPI
## .Net Core
    - For Dapper appsettings.json > "ORM": "dapper"
    - For EntityFramework appsettings.json > "ORM": "ef"
### Features
    1. CRUD operations.
    2. MVC NortwindAPI.
    3. Simple to understand architecture and operations.
    4. Used MS-SQL as DBFirst.
    5. Both ORMs can be used with a simple modification.

### Technologies
- .Net Core
- Dapper
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.SqlSerer
- Microsoft.EntityFrameworkCore.Tools
- AutoMaper

### End-points
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