namespace HelloWorld.Models;

public class Computer
{
    public string Motherboard { get; set; } = null!;
    public int CpuCores { get; set; }
    public bool HasWifi { get; set; }
    public bool HasLte { get; set; }
    public DateTime ReleaseDate { get; set; }
    public decimal Price { get; set; }
    public string VideoCard { get; set; } = null!;
}