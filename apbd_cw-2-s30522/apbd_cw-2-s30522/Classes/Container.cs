using apbd_cw_2_s30522.Exceptions;

namespace apbd_cw_2_s30522.Classes;

public abstract class Container(char type, double height, double containerWeight, double depth, double maxWeight)
{
    private static int _nextId = 1;

    public string SerialNumber { get; } = $"KON-{type}-{_nextId++}";
    public double LoadWeight { get; protected set; }
    public double Height { get; protected set; } = height;
    public double ContainerWeight { get; protected set; } = containerWeight;
    public double Depth { get; protected set; } = depth;
    public double MaxWeight { get; protected set; } = maxWeight;

    public virtual void Load(int addingLoadWeight)
    {
        if (ContainerWeight < LoadWeight + addingLoadWeight)
        {
            throw new OverfillException($"load weight ({LoadWeight + addingLoadWeight}) > container weight ({ContainerWeight})");
        }
        
        LoadWeight += addingLoadWeight;
    }
    
    public virtual void Unload()
    {
        LoadWeight = 0;
    }

    public override string ToString()
    {
        return $"<[{SerialNumber}]: height: {Height}; depth: {Depth}; containerWeight: {ContainerWeight}; maxWeight: {MaxWeight}>";
        
    }
}