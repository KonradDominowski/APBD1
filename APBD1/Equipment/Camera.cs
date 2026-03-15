namespace APBD1.Equipment;

public class Camera : Equipment
{
    public int Resolution;
    public bool HasTripod;

    public Camera(string name, int resolution, bool hasTripod) : base(name)
    {
        Resolution = resolution;
        HasTripod = hasTripod;
    }
}