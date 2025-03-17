using System.Xml;

namespace apbd_cw_2_s30522.Classes;

public class Ship(double maxVelocity, int maxContainersQty, double maxWeight)
{
    public List<Container> Containers { get; set; } = [];
    public double MaxVelocity { get; set; } = maxVelocity;
    public int MaxContainersQty { get; set; } = maxContainersQty;
    public double MaxWeight { get; set; } = maxWeight;

    public void LoadContainer(Container container)
    {
        if (Containers.Count == MaxContainersQty)
        {
            Console.WriteLine("Ship is full, cannot add container. Operation aborted.");
            return;
        }

        if (CurrentWeight() + container.LoadWeight > MaxWeight)
        {
            Console.WriteLine("Ship max weight would be exceeded, cannot add container. Operation aborted.");
            return;
        }
        
        Containers.Add(container);
    }

    public void LoadContainers(List<Container> newContainers)
    {
        if (newContainers.Count + Containers.Count > MaxContainersQty)
        {
            Console.WriteLine("Ship max container capacity would be exceeded, cannot add containers. Operation aborted.");
            return;
        }

        if (TotalWeight(newContainers) + CurrentWeight() > MaxWeight)
        {
            Console.WriteLine("Ship max weight would be exceeded, cannot add containers. Operation aborted.");
            return;
        }
        
        Containers.AddRange(newContainers);
    }

    public void RemoveContainer(string serialNumber)
    {
        Container? container = Find(serialNumber);

        if (container == null)
        {
            Console.WriteLine($"Container [{serialNumber}] not found");
            return;
        }

        Containers.Remove(container);
        Console.WriteLine($"Container [{serialNumber}] removed");
    }

    public void SwapContainer(string serialNumber, Container newContainer)
    {
        Container? container = Find(serialNumber);

        if (container == null)
        {
            Console.WriteLine($"Container [{serialNumber}] not found. Swap operation aborted.");
            return;
        }

        if (CurrentWeight() - container.LoadWeight + newContainer.LoadWeight > MaxWeight)
        {
            Console.WriteLine("Ship max weight would be exceeded, cannot swap container. Operation aborted.");
        }

        Containers.Remove(container);
        Containers.Add(newContainer);
    }

    public void MoveContainer(string serialNumber, Ship newShip)
    {
        Container? container = Find(serialNumber);

        if (container == null)
        {
            Console.WriteLine($"Container [{serialNumber}] not found. Move operation aborted.");
            return;
        }

        if (newShip.Containers.Count == newShip.MaxContainersQty)
        {
            Console.WriteLine("Other Ship container capacity would be exceeded, cannot move container. Operation aborted.");
            return;
        }

        if (newShip.CurrentWeight() + container.LoadWeight > newShip.MaxWeight)
        {
            Console.WriteLine("Other ship max weight would be exceeded, cannot move container. Operation aborted.");
            return;
        }

        Containers.Remove(container);
        newShip.Containers.Add(container);
    }
    
    private Container? Find(string serialNumber)
    {
        Container? pivotContainer = null;

        foreach (Container container in Containers) 
        {
            if (container.SerialNumber == serialNumber)
            {
                pivotContainer = container;
                break;
            }
        }

        return pivotContainer;
    }
    
    private double CurrentWeight()
    {
        return TotalWeight(Containers);
    }

    private static double TotalWeight(List<Container> containers)
    {
        double weight = 0;
        
        foreach (Container container in containers)
        {
            weight += container.LoadWeight;
        }
        
        return weight;
    }

    public override string ToString()
    {
        string result = $"<maxVelocity: {MaxVelocity}; maxContainerQty: {MaxContainersQty}; maxWeight: {MaxWeight}; Containers: ";
        
        foreach (Container container in Containers)
        {
            result += container + " ";
        }

        result += ">";
        
        return result;
    }
}