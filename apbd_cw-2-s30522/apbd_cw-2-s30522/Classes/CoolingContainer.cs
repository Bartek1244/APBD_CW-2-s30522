namespace apbd_cw_2_s30522.Classes;

public class CoolingContainer(double height, double depth, double containerWeight,  double maxWeight, 
    Product product) : Container('C', height, depth, containerWeight, maxWeight)
{
    private Product _product = product;
    private double _temperature = product.MinTemperature;
    
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

    public override string ToString()
    {
        return base.ToString() + $"; product: {_product}; temperature: {_temperature}";
    }
}