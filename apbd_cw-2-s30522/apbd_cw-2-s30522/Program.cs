using apbd_cw_2_s30522.Classes;

Ship ship1 = new Ship(10, 4, 250);
Ship ship2 = new Ship(10, 2, 140);

Container l1 = new LiquidContainer(10, 15, 50,  10,false);
Container g1 = new GasContainer(10, 15, 5, 100);
Container c1 = new CoolingContainer(10, 15, 15, 125, new Product("Banana", 13));

l1.Load(100);
g1.Load(100);
c1.Load(125);

Console.WriteLine(l1);
Console.WriteLine(c1);

ship1.LoadContainer(l1);
ship1.LoadContainer(c1);
ship1.LoadContainer(g1);

Console.WriteLine(ship1);
Console.WriteLine(ship2);

ship1.SwapContainer("KON-L-1", g1);

Console.WriteLine(ship1);

ship1.MoveContainer("KON-C-3", ship2);

Console.WriteLine(ship1);
Console.WriteLine(ship2);