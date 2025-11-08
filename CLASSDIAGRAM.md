## 📦 Inventory System – Class Diagram

```mermaid
classDiagram
    class Item {
        +int Id
        +string Name
        +decimal PricePerUnit
        +decimal Quantity
    }

    class OrderLine {
        +int Id
        +Item Item
        +decimal Quantity
        +string ToString()
    }

    class Order {
        +int Id
        +string Customer
        +List~OrderLine~ OrderLines
        +DateTime Time
        +string Status
        +decimal TotalPrice()
        +string ToString()
    }

    class Customer {
        +string Name
        +List~Order~ Orders
        +void CreateOrder(OrderBook orderBook, Order order)
    }

    class OrderBook {
        +List~Order~ QueuedOrders
        +List~Order~ ProcessedOrders
        +void QueueOrder(Order order)
        +void ProcessNextOrder()
        +decimal TotalRevenue()
    }

    class Inventory {
        +List~Item~ Items
        +List~Item~ LowStockItems()
    }

    class PrintableObservableCollection~T~ {
        +string ToString()
    }

    %% RELATIONSHIPS
    Customer "1" --> "*" Order
    Order "1" --> "*" OrderLine
    OrderLine "*" --> "1" Item
    OrderBook "1" --> "*" Order
    Inventory "1" --> "*" Item
