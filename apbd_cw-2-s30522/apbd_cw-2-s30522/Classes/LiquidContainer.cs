using apbd_cw_2_s30522.Interfaces;

namespace apbd_cw_2_s30522.Classes;

public class LiquidContainer(double height, double containerWeight, double depth, double maxWeight, bool hazardous) 
    : Container('L', height, containerWeight, depth, maxWeight), IHazardNotifier
{
    public bool Hazardous { get; set; } = hazardous;

    public override void Load(int addingLoadWeight)
    {
        if (Hazardous && LoadWeight + addingLoadWeight > 0.5 * MaxWeight)
        {
            NotifyHazard("Warning! Filling container with hazardous liquid for over 50% of its capacity! " +
                         "Operation aborted.");
            return;
        }

        if (!Hazardous && LoadWeight + addingLoadWeight > 0.9 * MaxWeight)
        {
            NotifyHazard("Warning! Filling container with liquid for over 90% of its capacity"+
                         "Operation aborted.");
            return;
        }

        base.Load(addingLoadWeight);
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine(message);
    }

    public override string ToString()
    {
        return base.ToString() + $"; hazardous: {Hazardous}";
    }
}