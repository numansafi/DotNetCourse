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
        
        var myComputer = new Computer()
        {
            Motherboard = "26709",
            HasWifi = true,
            HasLte = false,
            ReleaseDate = DateTime.Now.AddDays(-200),
            Price = 999.99m,
            VideoCard = "RTX 2060"
        };

        /*string insertQuery = @"INSERT INTO TutorialAppSchema.Computer 
                     (Motherboard, HasWifi, HasLte, ReleaseDate, Price, VideoCard) 
                     VALUES (@Motherboard, @HasWifi, @HasLte, @ReleaseDate, @Price, @VideoCard)";
        
        int result = dbConnection.Execute(insertQuery, myComputer);

        Console.WriteLine(result);*/
        
        string selectQuery = @"SELECT Computer.Motherboard, Computer.HasWifi, Computer.HasLte, Computer.ReleaseDate, Computer.Price, Computer.VideoCard FROM TutorialAppSchema.Computer";
        IEnumerable<Computer> computers = dbConnection.Query<Computer>(selectQuery);

        foreach (var computer in computers)
        {
            Console.WriteLine($"{nameof(computer.Motherboard)}: {computer.Motherboard}");
            Console.WriteLine($"{nameof(computer.HasWifi)}: {computer.HasWifi}");
            Console.WriteLine($"{nameof(computer.HasLte)}: {computer.HasLte}");
            Console.WriteLine($"{nameof(computer.ReleaseDate)}: {computer.ReleaseDate}");
            Console.WriteLine($"{nameof(computer.Price)}: {computer.Price}");
            Console.WriteLine($"{nameof(computer.VideoCard)}: {computer.VideoCard}");
        }


    }
}