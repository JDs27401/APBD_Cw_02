// See https://aka.ms/new-console-template for more information

// Console.WriteLine("Hello, World!");

using MP01;

LiquidContainer lCon1 = new LiquidContainer(true);
lCon1.LoadContainer(10000);
Console.WriteLine(lCon1);
// lCon1.UnloadContainer();
// Console.WriteLine(lCon1);

GasContainer gCon1 = new GasContainer(3);
gCon1.LoadContainer(10000);
Console.WriteLine(gCon1);
// gCon1.UnloadContainer();
// Console.WriteLine(gCon1);

ContainerShip cShip1 = new ContainerShip("Statek 1", 12, 5000, 50);
Console.WriteLine(cShip1);

cShip1.LoadContainer(lCon1);
Console.WriteLine(cShip1);
cShip1.Show();

cShip1.UnloadContainer(lCon1.GetSerialNumber());
Console.WriteLine(cShip1);