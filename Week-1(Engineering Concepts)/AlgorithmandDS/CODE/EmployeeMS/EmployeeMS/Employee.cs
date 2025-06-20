using System;

class Emp
{
    public int Id;
    public string Name;
    public string Pos;
    public double Sal;
}

class Company
{
    Emp[] list = new Emp[100];
    int count = 0;
    public void Add(Emp e) => list[count++] = e;
    public Emp Search(int id)
    {
        for (int i = 0; i < count; i++)
            if (list[i].Id == id) return list[i];
        return null;
    }
    public void Traverse()
    {
        for (int i = 0; i < count; i++)
            Console.WriteLine($"{list[i].Id} {list[i].Name}");
    }
    public void Delete(int id)
    {
        for (int i = 0; i < count; i++)
            if (list[i].Id == id)
            {
                for (int j = i; j < count - 1; j++)
                    list[j] = list[j + 1];
                count--;
                break;
            }
    }
}

class Program
{
    static void Main()
    {
        Company c = new Company();
        c.Add(new Emp { Id = 1, Name = "Alia", Pos = "HR", Sal = 50000 });
        c.Add(new Emp { Id = 2, Name = "Bob", Pos = "IT", Sal = 60000 });
        Console.WriteLine("Before Delete:");
        c.Traverse();
        c.Delete(1);
        Console.WriteLine("After Delete:");
        c.Traverse();
    }
}

