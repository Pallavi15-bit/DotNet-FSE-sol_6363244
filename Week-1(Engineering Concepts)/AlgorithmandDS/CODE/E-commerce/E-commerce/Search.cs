using System;

class Product
{
    public int Id;
    public string Name;
    public string Cat;
}

class Search
{
    public static int Linear(Product[] p, string name)
    {
        for (int i = 0; i < p.Length; i++)
            if (p[i].Name == name) return i;
        return -1;
    }

    public static int Binary(Product[] p, string name)
    {
        int l = 0, r = p.Length - 1;
        while (l <= r)
        {
            int m = (l + r) / 2;
            int cmp = string.Compare(p[m].Name, name);
            if (cmp == 0) return m;
            if (cmp < 0) l = m + 1;
            else r = m - 1;
        }
        return -1;
    }
}

class Program
{
    static void Main()
    {
        Product[] p = {
            new Product { Id = 1, Name = "Apple", Cat = "Fruit" },
            new Product { Id = 2, Name = "Banana", Cat = "Fruit" },
            new Product { Id = 3, Name = "Carrot", Cat = "Veg" }
        };

        Console.WriteLine(Search.Linear(p, "Banana")); // Linear
        Array.Sort(p, (a, b) => a.Name.CompareTo(b.Name));
        Console.WriteLine(Search.Binary(p, "Banana")); // Binary
        Console.ReadLine();
    }
}
