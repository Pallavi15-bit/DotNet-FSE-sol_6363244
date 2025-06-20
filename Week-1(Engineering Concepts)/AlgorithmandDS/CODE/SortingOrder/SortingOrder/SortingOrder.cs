using System;

class Order
{
    public int Id;
    public string Name;
    public double Total;
}

class Sorter
{
    public static void Bubble(Order[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
            for (int j = 0; j < n - i - 1; j++)
                if (arr[j].Total > arr[j + 1].Total)
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
    }
    public static void Quick(Order[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);
            Quick(arr, low, pi - 1);
            Quick(arr, pi + 1, high);
        }
    }
    static int Partition(Order[] arr, int low, int high)
    {
        double pivot = arr[high].Total;
        int i = low - 1;
        for (int j = low; j < high; j++)
        {
            if (arr[j].Total <= pivot)
                (arr[++i], arr[j]) = (arr[j], arr[i]);
        }
        (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
        return i + 1;
    }
}

class Program
{
    static void Main()
    {
        Order[] orders = {
            new Order{Id=1, Name="A", Total=300},
            new Order{Id=2, Name="B", Total=100},
            new Order{Id=3, Name="C", Total=200}
        };
        Order[] bubbleOrders = (Order[])orders.Clone();
        Sorter.Bubble(bubbleOrders);
        Console.WriteLine("Bubble Sort:");
        foreach (var o in bubbleOrders)
            Console.WriteLine($"{o.Name} - {o.Total}");
        Sorter.Quick(orders, 0, orders.Length - 1);
        Console.WriteLine("Quick Sort:");
        foreach (var o in orders)
            Console.WriteLine($"{o.Name} - {o.Total}");
    }
}
