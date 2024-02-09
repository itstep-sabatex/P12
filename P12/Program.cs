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
    r.Close();


    var transaction = connection.BeginTransaction();

    cmd = connection.CreateCommand();
    cmd.CommandText = "SELECT NEXT VALUE FOR [dbo].[OrdersSequences]";
    cmd.Transaction = transaction;
    var orderId = cmd.ExecuteScalar();



    cmd = connection.CreateCommand();
    cmd.CommandText = $"insert into [dbo].[Invoices] ([OrderNumber],[Id]) values (@OrderNumber,{orderId})";
    cmd.Transaction = transaction;

    var orderNumberP = cmd.CreateParameter();
    orderNumberP.ParameterName = "OrderNumber";
    orderNumberP.Value = "tr"; // "2024.03.12" "12.03.2024"
    cmd.Parameters.Add(orderNumberP);
    cmd.ExecuteNonQuery();

    cmd = connection.CreateCommand();
    cmd.CommandText = $"insert into [dbo].[InvoiceDetail] ([InvoiceId],[NomenclatureId],[UnitOfMeasurementsId],[Count],[Price],[Sum],[Vat],[Tax]) values ({orderId},10,1,10,5,50,20,12)";
    cmd.Transaction = transaction;
    cmd.ExecuteNonQuery();

    cmd = connection.CreateCommand();
    cmd.CommandText = $"insert into [dbo].[InvoiceDetail] ([InvoiceId],[NomenclatureId],[UnitOfMeasurementsId],[Count],[Price],[Sum],[Vat],[Tax]) values ({orderId},11,1,10,5,50,20,12)";
    cmd.Transaction = transaction;
    cmd.ExecuteNonQuery();
    transaction.Commit();






    //cmd.ExecuteNonQuery();

    //cmd = connection.CreateCommand();
    //cmd.CommandText = "update [dbo].[Invoices] set [OrderNumber] = '1234' where [OrderNumber] ='123' ";
    //cmd.ExecuteNonQuery();

    //cmd = connection.CreateCommand();
    //cmd.CommandText = "delete from [dbo].[Invoices] where [OrderNumber] = '1234'";
    //cmd.ExecuteNonQuery();


    //cmd = connection.CreateCommand();
    //cmd.CommandText = "select count(id) from [dbo].[Invoices]";
    //var i = cmd.ExecuteScalar();
    //Console.WriteLine($"Lines in table {i}");
    //var transaction = connection.BeginTransaction();
    //transaction.Commit();
    //transaction.Rollback();


    connection.Close();

}
//new Microsoft.Data.Sqlite.SqliteConnection("FileName='Demo.db'"))