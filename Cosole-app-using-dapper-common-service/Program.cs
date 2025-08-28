// See https://aka.ms/new-console-template for more information
using DotNetEnv;
using SLHDotNetTrainingBatch1.Shared;

Console.WriteLine("Hello, World!");

// Load environment variables before using them
Env.Load();

AdoDotNetService service = new AdoDotNetService(new Microsoft.Data.SqlClient.SqlConnectionStringBuilder()
{
    DataSource = Env.GetString("DataSource"),
    InitialCatalog = Env.GetString("InitialCatalog"),
    UserID = Env.GetString("UserID"),
    Password = Env.GetString("Password"),
    TrustServerCertificate = true
});