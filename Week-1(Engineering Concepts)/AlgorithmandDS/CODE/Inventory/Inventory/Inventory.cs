using System;
using System.Collections.Generic;

class Product
{
    public int Id;
    public string Name;
    public int Qty;
    public double Price;
}

class Inventory
{
    List<Product> items = new List<Product>();

    public void Add(Product p) => items.Add(p);

    public void Update(int id, int qty)
    {
        var p = items.Find(x => x.Id == id);
        if (p != null) p.Qty = qty;
    }

    public void Delete(int id) => items.RemoveAll(p => p.Id == id);

    public void Show()
    {
        foreach (var p in items)
            Console.WriteLine($"{p.Id} {p.Name} {p.Qty} {p.Price}");
    }
}

class Program
{
    static void Main()
    {
        Inventory inv = new Inventory();
        inv.Add(new Product { Id = 1, Name = "Pen", Qty = 10, Price = 5.5 });
        inv.Update(1, 20);
      
        inv.Show();
    }
}
