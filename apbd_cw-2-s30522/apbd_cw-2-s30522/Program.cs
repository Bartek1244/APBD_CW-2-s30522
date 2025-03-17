using apbd_cw_2_s30522.Classes;

var l = new LiquidContainer(1, 1, 10, 25, true);
var g = new GasContainer(1, 1, 5, 75);
var product = new Product("Banana", 13.4);
var c = new CoolingContainer(1, 1, 10, 100, product);

Console.WriteLine(l);
Console.WriteLine(g);
Console.WriteLine(c);

l.Load(25);
Console.WriteLine(l);
l.Load(10);
Console.WriteLine(l);

g.Load(75);
Console.WriteLine(g);
g.Unload();
Console.WriteLine(g);
// g.Load(75);
g.Load(50);
Console.WriteLine(g);

c.Load(80);
Console.WriteLine(c);
c.Temperature = 10;
c.Temperature = 15;
Console.WriteLine(c);

var ship1 = new Ship(1, 2, 100);

Console.WriteLine(ship1);
ship1.LoadContainers([c, g]);
Console.WriteLine(ship1);
ship1.LoadContainer(c);
Console.WriteLine(ship1);

ship1.RemoveContainer("KON-C-3");
Console.WriteLine(ship1);

ship1.LoadContainers([l, g]);
Console.WriteLine(ship1);

c.Unload();
c.Load(25);
Console.WriteLine(c);
ship1.SwapContainer("KON-G-2", c);
Console.WriteLine(ship1);

var ship2 = new Ship(1, 1, 500);
ship1.MoveContainer("KON-C-3", ship2);
Console.WriteLine(ship1);
Console.WriteLine(ship2);