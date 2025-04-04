﻿using apbd_cw_2_s30522.Interfaces;

namespace apbd_cw_2_s30522.Classes;

public class GasContainer(double height, double depth,  double containerWeight, double maxWeight) 
    : Container('G', height, depth, containerWeight, maxWeight), IHazardNotifier
{
    public override void Unload()
    {
        LoadWeight = 0.05 * LoadWeight;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[{SerialNumber}] {message}");
    }
    
}