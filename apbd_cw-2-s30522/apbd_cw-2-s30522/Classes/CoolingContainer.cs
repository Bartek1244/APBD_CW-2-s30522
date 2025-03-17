namespace apbd_cw_2_s30522.Classes;

public class CoolingContainer(double height, double containerWeight, double depth, double maxWeight, 
    Product product, double temperature) : Container('C', height, containerWeight, depth, maxWeight)
{
    private Product _product = product;
    private double _temperature = temperature;
    
    public Product Product
    {
        get => _product;
        set
        {
            _product = value;
            _temperature = value.MinTemperature;
        }
    }

    public double Temperature
    {
        get => _temperature;
        set
        {
            if (value < _product.MinTemperature)
            {
                Console.WriteLine("Cannot set temperature below min product level.");
                return;
            }
            
            _temperature = value;
        }
    }



}