// See https://aka.ms/new-console-template for more information

using Microsoft_dot_ado_net;
Console.WriteLine("Hello, World!");


CRUDWithMicrosoftSQLStudio service = new CRUDWithMicrosoftSQLStudio();
service.Read();
service.Detail();
service.Create();
service.Update();
service.Delete();