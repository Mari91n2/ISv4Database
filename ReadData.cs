using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem;

public static class ReadOrders
{
    // Hjælpe-metode til konsoltest (køres ikke af GUI)
    public static void Run()
    {
        using var db = new InventorySystemDbContext();
        var orders = db.Orders.AsNoTracking().ToList();

        Console.WriteLine("Queued Orders:");
        foreach (var o in orders.Where(x => x.Status == "queued"))
            Console.WriteLine($"Id: {o.Id}, Customer: {o.Customer}, Lines: {o.OrderLines}, Time: {o.Time}");

        Console.WriteLine("\nProcessed Orders:");
        foreach (var o in orders.Where(x => x.Status == "processed"))
            Console.WriteLine($"Id: {o.Id}, Customer: {o.Customer}, Lines: {o.OrderLines}, Time: {o.Time}");
    }
}