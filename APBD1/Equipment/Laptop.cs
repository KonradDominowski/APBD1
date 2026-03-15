namespace APBD1.Equipment;

public class Laptop : Equipment
{
    public int ScreenSize { get; set; }
    public int BatterSize { get; set; }
    public OperatingSystem OperatingSystem { get; set; }

    public Laptop(string name, int screenSize, int batterSize, OperatingSystem operatingSystem) : base(name)
    {
        ScreenSize = screenSize;
        BatterSize = batterSize;
        OperatingSystem = operatingSystem;
    }
}