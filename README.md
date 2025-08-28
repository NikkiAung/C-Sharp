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

- Postman
- ASP.NET Core Web API
- Logic
- HttpClient
- RestSharp
- Refit
- Console App + API

## Packages
To install packages, check out nuget : https://www.nuget.org/