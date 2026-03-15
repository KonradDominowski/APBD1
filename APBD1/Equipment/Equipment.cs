namespace APBD1.Equipment;

public abstract class Equipment
{
    public static int MaxId = 0;
    public int Id { get; set; }
    public string Name { get; set; }
    public EquipmentState State { get; set; }
    
    public Equipment(string name)
    {
        Id = ++MaxId;
        Name = name;
        State = EquipmentState.Available;
    }
}