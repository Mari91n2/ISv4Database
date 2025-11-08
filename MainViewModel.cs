using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;

public class MainViewModel
{
    public ObservableCollection<Order> QueuedOrders { get; set; }
    public ObservableCollection<Order> ProcessedOrders { get; set; }
    public string StatusMessage { get; set; } = "";
    public string IpAddress { get; set; } = "172.20.254.201";

    public ICommand ProcessNextOrderCommand { get; }
    public ICommand ConnectCommand { get; }

    public MainViewModel()
    {
        using var db = new InventorySystemDbContext();
        db.Database.EnsureCreated();

        var orders = db.Orders.ToList();
        QueuedOrders = new ObservableCollection<Order>(orders.Where(o => o.Status == "queued"));
        ProcessedOrders = new ObservableCollection<Order>(orders.Where(o => o.Status == "processed"));

        ProcessNextOrderCommand = new RelayCommand(ProcessNextOrder);
        ConnectCommand = new RelayCommand(Connect);
    }

    private void ProcessNextOrder()
    {
        if (QueuedOrders.Count == 0)
        {
            StatusMessage = "No queued orders left.";
            return;
        }

        var order = QueuedOrders.First();
        QueuedOrders.Remove(order);
        order.Status = "processed";
        ProcessedOrders.Add(order);

        using var db = new InventorySystemDbContext();
        db.Orders.Update(order);
        db.SaveChanges();

        StatusMessage = $"Processed order {order.Id} for {order.Customer}.";
    }

    private void Connect()
    {
        StatusMessage = $"Connected to {IpAddress}";
    }
}