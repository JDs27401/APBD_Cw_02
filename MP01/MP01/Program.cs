// See https://aka.ms/new-console-template for more information

// Console.WriteLine("Hello, World!");

using MP01;

// Container con1 = new Container(ContainerType.C);
// Console.WriteLine(con1);
// con1.loadContainer(22_000);
// Console.WriteLine("bajo jajo");
// Console.WriteLine(con1);
LiquidContainer lCon1 = new LiquidContainer(true);
lCon1.LoadContainer(10000);
Console.WriteLine(lCon1);
lCon1.UnloadContainer();
Console.WriteLine(lCon1);

GasContainer gCon1 = new GasContainer(3);
gCon1.LoadContainer(10000);
Console.WriteLine(gCon1);
gCon1.UnloadContainer();
Console.WriteLine(gCon1);
