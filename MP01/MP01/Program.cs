// See https://aka.ms/new-console-template for more information

// Console.WriteLine("Hello, World!");

using MP01;

LiquidContainer lCon1 = new LiquidContainer(true);
LiquidContainer lCon2 = new LiquidContainer(false);
lCon1.LoadContainer(10000);
lCon2.LoadContainer(10000);
Console.WriteLine(lCon1 + " z ładunkiem o podwyrzszonym ryzyku");
Console.WriteLine(lCon2 + " bez ładunku o podwyrzszonym ryzyku");
lCon1.UnloadContainer();
Console.WriteLine(lCon1 + " po rozładowaniu ładunku");

GasContainer gCon1 = new GasContainer(10);
gCon1.LoadContainer(10000);
Console.WriteLine(gCon1 + " po załadunku gazem");
gCon1.UnloadContainer();
Console.WriteLine(gCon1 + " po rozładunku gazu");

ContainerShip cShip1 = new ContainerShip("Statek 1", 12, 5000, 50);
Console.WriteLine(cShip1);

cShip1.LoadContainer(lCon1);
Console.WriteLine(cShip1);
cShip1.Show();

cShip1.UnloadContainer(lCon1.GetSerialNumber());
Console.WriteLine(cShip1);

ContainerShip cShip2 = new ContainerShip("Statek 2", 9, 3000, 30);
Console.WriteLine(cShip2);

RefrigiratedContainer rCon1 = new RefrigiratedContainer(14, "Bananas");
RefrigiratedContainer rCon2 = new RefrigiratedContainer(20, "Chocolate");
RefrigiratedContainer rCon3 = new RefrigiratedContainer(3, "Fish");

rCon1.LoadContainer(3000, "Bananas");
rCon2.LoadContainer(5000, "Chocolate");
rCon3.LoadContainer(8000, "Fish");

LiquidContainer lCon3 = new LiquidContainer(true);
LiquidContainer lCon4 = new LiquidContainer(false);
lCon3.LoadContainer(10000);
lCon4.LoadContainer(10000);

cShip2.LoadContainers(new List<Container> { rCon1, rCon2, rCon3, lCon4 });
cShip2.Show();

cShip1.Show();
cShip2.ChangeShip(cShip1, rCon1.GetSerialNumber());
cShip1.Show();
cShip2.Show();

GasContainer gCon3 = new GasContainer(11);
cShip1.Show();
cShip1.SwitchContainer(rCon1.GetSerialNumber(), gCon3);
cShip1.Show();