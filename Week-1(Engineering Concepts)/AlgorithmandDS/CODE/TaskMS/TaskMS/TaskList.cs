using System;

class Task
{
    public int Id;
    public string Name;
    public string Status;
    public Task Next;
}

class TaskList
{
    Task head;
    public void Add(Task t)
    {
        t.Next = head;
        head = t;
    }
    public Task Search(int id)
    {
        var cur = head;
        while (cur != null)
        {
            if (cur.Id == id) return cur;
            cur = cur.Next;
        }
        return null;
    }
    public void Delete(int id)
    {
        Task prev = null, cur = head;
        while (cur != null && cur.Id != id)
        {
            prev = cur;
            cur = cur.Next;
        }
        if (cur != null)
        {
            if (prev == null) head = cur.Next;
            else prev.Next = cur.Next;
        }
    }
    public void Show()
    {
        var cur = head;
        while (cur != null)
        {
            Console.WriteLine($"{cur.Id} {cur.Name} {cur.Status}");
            cur = cur.Next;
        }
    }
}

class Program
{
    static void Main()
    {
        TaskList tl = new TaskList();
        tl.Add(new Task { Id = 1, Name = "Code", Status = "Pending" });
        tl.Add(new Task { Id = 2, Name = "Test", Status = "InProgress" });
        Console.WriteLine("Before Delete:");
        tl.Show();
        tl.Delete(1);
        Console.WriteLine("After Delete:");
        tl.Show();
    }
}
