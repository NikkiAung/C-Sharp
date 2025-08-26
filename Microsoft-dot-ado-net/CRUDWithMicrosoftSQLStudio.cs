using System.Data;
using Microsoft.Data.SqlClient;
using DotNetEnv;

namespace Microsoft_dot_ado_net;

public class CRUDWithMicrosoftSQLStudio
{
    private readonly SqlConnectionStringBuilder _builder; 
    public CRUDWithMicrosoftSQLStudio()
    {
        // Load .env file
        Env.Load();

        _builder = new SqlConnectionStringBuilder()
        {
            DataSource = Env.GetString("DataSource"),
            InitialCatalog = Env.GetString("InitialCatalog"),
            UserID = Env.GetString("UserID"),
            Password = Env.GetString("Password"),
            TrustServerCertificate = true
        };
    }

    public void Create()
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine()!;
        Console.Write("Enter GitHub User Name: ");
        string githubUserName = Console.ReadLine()!;
        Console.Write("Enter GitHub Repo Link: ");
        string githubRepoLink = Console.ReadLine()!;

        SqlConnection connection = new SqlConnection(_builder.ConnectionString);
        connection.Open();

        string query = $@"
        INSERT INTO [dbo].[Tbl_Github]
        ([Name]
        ,[GitHubUserName]
        ,[GitHubRepoLink])
        VALUES
        (@Name
        ,@GitHubUserName
        ,@GitHubRepoLink)";

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@Name", name);
        cmd.Parameters.AddWithValue("@GitHubUserName", githubUserName);
        cmd.Parameters.AddWithValue("@GitHubRepoLink", githubRepoLink);
        int result = cmd.ExecuteNonQuery();

        connection.Close();
    }

    public void Read()
    {

        SqlConnection connection = new SqlConnection(_builder.ConnectionString);
        connection.Open();

        string query = "SELECT TOP 10 * FROM Tbl_Github";

        SqlCommand command = new SqlCommand(query, connection);
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        DataTable dt = new DataTable();
        adapter.Fill(dt);

        connection.Close();

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            Console.WriteLine($"{dt.Rows[i]["No"]} {dt.Rows[i]["Name"]} {dt.Rows[i]["GithubUserName"]} {dt.Rows[i]["GithubRepoLink"]}");
            Console.WriteLine("--------------------------------------------------");
        }
    }

    public void Detail(int no)
    {
        SqlConnection connection = new SqlConnection(_builder.ConnectionString);
        connection.Open();

        string query = $"SELECT TOP 10 * FROM Tbl_Github where No = {no}";

        SqlCommand command = new SqlCommand(query, connection);
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            Console.WriteLine($"{dt.Rows[i]["No"]} {dt.Rows[i]["Name"]} {dt.Rows[i]["GithubUserName"]} {dt.Rows[i]["GithubRepoLink"]}");
            Console.WriteLine("--------------------------------------------------");
        }
        connection.Close();
    }

    public void Update()
    {
        Console.Write("Enter No to Update: ");
        int no = int.Parse(Console.ReadLine()!);
        Console.Write("Enter new Name: ");
        string name = Console.ReadLine()!;
        Console.Write("Enter new GitHub User Name: ");
        string githubUserName = Console.ReadLine()!;
        Console.Write("Enter new GitHub Repo Link: ");
        string githubRepoLink = Console.ReadLine()!;

        using SqlConnection connection = new SqlConnection(_builder.ConnectionString);
        connection.Open();

        string query = @"
        UPDATE [dbo].[Tbl_Github]
        SET [Name] = @Name,
            [GitHubUserName] = @GitHubUserName,
            [GitHubRepoLink] = @GitHubRepoLink
        WHERE [No] = @No";

        using SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@Name", name);
        cmd.Parameters.AddWithValue("@GitHubUserName", githubUserName);
        cmd.Parameters.AddWithValue("@GitHubRepoLink", githubRepoLink);
        cmd.Parameters.AddWithValue("@No", no);

        int result = cmd.ExecuteNonQuery();

        Console.WriteLine(result > 0 ? "Update successful." : "Update failed.");

        connection.Close();
    }

    public void Delete()
    {   
        BeforeDelete:
        Console.Write("Enter No to Delete: ");
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int no) || no <= 0)
        {
            Console.WriteLine("Please enter a valid No greater than 0.");
            goto BeforeDelete;
        }

        using SqlConnection connection = new SqlConnection(_builder.ConnectionString);
        connection.Open();

        string query = "DELETE FROM [dbo].[Tbl_Github] WHERE [No] = @No";

        using SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@No", no);

        int result = cmd.ExecuteNonQuery();

        Console.WriteLine(result > 0 ? "Delete successful." : "Delete failed.");
        
        connection.Close();
    }
}
