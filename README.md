# C# DotNet

## Demo 🎥
Console App + Db with ADO.NET integrated with Microsoft Azure Data Studio (CRUD)

https://github.com/user-attachments/assets/523aab2f-1fe6-4adb-a996-a4143cd9c15e

Simple Console App (CRUD)

https://github.com/user-attachments/assets/c0529fa9-3a34-4842-9e6f-8840ddac27d4

## Completed Topic ✅

- [x] C#  
- [x] SQL

- [x] Console App  
- [x] Console App + Db (Memory Database)  
- [x] Console App + Db (SQL Server) 

    * [x] ADO.NET (CRUD) – Old School 
    * [x] Dapper (CRUD) ORM – Micro ORM (query) 
    * [x] EFCore (CRUD) ORM – Full ORM (no query)
        - EF Core Installation For Command
            - dotnet tool install --global dotnet-ef
            - dotnet tool install --global dotnet-ef --version 7
        - Generate model from database
            - dotnet ef dbcontext scaffold "Server=.;Database=DbName;User Id=userId;Password=password;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext -t Tbl_Name -f (Note can stop building if smt err happens in code, so should put in somewhere but not main)
            Exclude "-t Tbl_Name" if you wanna extract all tables

- [x] Postman
    - To run localhost, dotnet run --launch-profile https
- [x] ASP.NET Core Web API

### Project 1 setup
- [x] For database setup, install the following
    - Microsoft.EntityFrameworkCore
    - Microsoft.EntityFrameworkCore.Design
    - Microsoft.EntityFrameworkCore.SqlServer
    - Microsoft.EntityFrameworkCore.Tools
- [x] summary
    - Database > Table
    - Class Library > EFCore Install > Cmd
    - API Project > Add Class Library > EFCore (Dependecy injection)
    - API Project > Create Controller > CRUD using AppContext
    - Class Library > Domain > BlogService > API Project > Add > Register (builder.Services.AddScoped<BlogService>();)

    ## Demo
    https://github.com/user-attachments/assets/1ee5c5e4-fd42-4c46-89b7-d3690513f7fc

### Project 3 setup
- Use Microsoft Azure Studio for Database
- Use Dapper C# + SQL To CRUD data from Database
- Use HTML, CSS, Bootstrap for frontend

    ## Demo
    https://github.com/user-attachments/assets/cf33224a-f162-433e-8d06-634f1f56b993

- [x] Logic
- [x] HttpClient
- [x] RestSharp
- [x] Refit

## Packages
To install packages, check out nuget : https://www.nuget.org/