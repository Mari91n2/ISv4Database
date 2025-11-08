using System;

namespace InventorySystem;

public class Order
{
    public int Id { get; set; }
    public string Customer { get; set; } = null!;
    public string OrderLines { get; set; } = null!;
    public string Time { get; set; } = null!;
    public string Status { get; set; } = null!;
}