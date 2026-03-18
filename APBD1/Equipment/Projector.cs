namespace APBD1.Equipment;

public class Projector : Equipment
{
    public int Resolution;
    public int BrightnessInLumens;
    public int ContrastToOne;

    public Projector(string name, int resolution, int brightness, int contrast) : base(name)
    {
        Resolution = resolution;
        BrightnessInLumens = brightness;
        ContrastToOne = contrast;
    }
}