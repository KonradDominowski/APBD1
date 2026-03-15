namespace APBD1.Equipment;

public class Projector : Equipment
{
    public int Resolution;
    public int Brightness;
    public int Contrast;

    public Projector(string name, int resolution, int brightness, int contrast) : base(name)
    {
        Resolution = resolution;
        Brightness = brightness;
        Contrast = contrast;
    }
}