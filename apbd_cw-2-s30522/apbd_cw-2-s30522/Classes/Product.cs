namespace apbd_cw_2_s30522.Classes;

public class Product(string name, double minTemperature)
{
    public string Name { get; set; } = name;
    public double MinTemperature { get; set; } = minTemperature;
}