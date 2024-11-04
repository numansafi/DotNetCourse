using System.Data;
using Dapper;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;

namespace HelloWorld;

class Program
{
    static void Main(string[] args)
    {
        string connectionstring = "Server=localhost,1433;Database=DotNetCourseDatabase;TrustServerCertificate=true;Encrypt=False;Trusted_Connection=false;User id=SA;Password=SQLConnect1!";

        IDbConnection dbConnection = new SqlConnection(connectionstring);
        
        string sqlCommand = "SELECT GETDATE()";

        DateTime dateTimeNow =  dbConnection.QuerySingle<DateTime>(sqlCommand);

        Console.WriteLine($"Date: {dateTimeNow}");
        
        var myComputer = new Computer()
        {
            HasWifi = true,
            HasLte = false,
            ReleaseDate = DateTime.Now.AddDays(-200),
            Price = 999.99m
        };
        
        myComputer.HasWifi = false;

        Console.WriteLine(myComputer.Motherboard);
        Console.WriteLine(myComputer.HasWifi);
        Console.WriteLine(myComputer.HasLte);
        Console.WriteLine(myComputer.ReleaseDate);
        Console.WriteLine(myComputer.Price);
    }
}