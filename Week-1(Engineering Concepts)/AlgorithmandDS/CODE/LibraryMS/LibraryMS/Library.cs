using System;

class Book
{
    public int Id;
    public string Title;
    public string Author;
}

class Library
{
    public static int Linear(Book[] b, string t)
    {
        for (int i = 0; i < b.Length; i++)
            if (b[i].Title == t) return i;
        return -1;
    }
    public static int Binary(Book[] b, string t)
    {
        int l = 0, r = b.Length - 1;
        while (l <= r)
        {
            int m = (l + r) / 2;
            int cmp = string.Compare(b[m].Title, t);
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
        Book[] books = {
            new Book { Id=1, Title="A", Author="X" },
            new Book { Id=2, Title="B", Author="Y" }
        };
        Console.WriteLine(Library.Linear(books, "B"));
        Array.Sort(books, (a, b) => a.Title.CompareTo(b.Title));
        Console.WriteLine(Library.Binary(books, "B"));
    }
}
