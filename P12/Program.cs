// See https://aka.ms/new-console-template for more information
using System.Data.Common;
using System.Data;
using Microsoft.Extensions.Configuration;

Console.WriteLine("Hello, World!");

var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").AddUserSecrets<Program>().Build();


using (DbConnection connection = new Microsoft.Data.SqlClient.SqlConnection(config.GetConnectionString("DefaultConnection")))
{
    connection.Open();

    var cmd = connection.CreateCommand();
    cmd.CommandText = "select * from [dbo].[Invoices]";
    var r = cmd.ExecuteReader();

    while (r.Read())
    {
        var id = r.GetInt32("id");
        var orderNumber = r.GetString("OrderNumber");
    }


    //var transaction = connection.BeginTransaction();
    //transaction.Commit();
    //transaction.Rollback();


    connection.Close();

}
//new Microsoft.Data.Sqlite.SqliteConnection("FileName='Demo.db'"))