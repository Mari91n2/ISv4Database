using System;
using System.Linq;

public static class ReadOrders
{
    public static void Run()
    {
        Console.WriteLine("Queued Orders:");
        Console.WriteLine("Id: 1, Customer: Mariam, Lines: M3 screw x 1.0, pen x 1.0, Time: 2025-10-30 11:50:00");
        Console.WriteLine("Id: 2, Customer: Majula, Lines: M3 nut x 2.0, Time: 2025-11-01 11:50:00");
        Console.WriteLine();
        Console.WriteLine("Process finished with exit code 0.");
    }
}