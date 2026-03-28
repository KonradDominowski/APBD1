namespace APBD1.Equipment;

public class Camera : Equipment
{
    public string Resolution;
    public bool HasTripod;

    public Camera(string name, string resolution, bool hasTripod) : base(name)
    {
        Resolution = resolution;
        HasTripod = hasTripod;
    }
    
}