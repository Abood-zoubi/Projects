using System;
using System.Collections.Generic;

abstract class LibraryItem
{
    public string Title{get; set;}
    protected bool Borrowed{get; set;}

    protected LibraryItem(string t){Title = t; Borrowed = false;}

    public void Borrow()
    {
        if(Borrowed == true)
        {
            Console.WriteLine($"{Title} is already borrowed.");
        }
        else
        {
            Borrowed = true;
            Console.WriteLine($"You have now borrowed {Title}.");
        }
    }
    abstract public void DisplayDetails();
    abstract public LibraryItem AddItem();
}

class Book: LibraryItem
{
    private string Author{ get; set; }
    private string Genre{ get; set;}
    private int Pages{get; set;}
    public Book(string title, string a, string g, int p): base(title){Author = a; Genre = g; Pages = p;}
    public override LibraryItem AddItem()
    {
        Console.WriteLine("Enter book title: ");
        string title = Console.ReadLine();
        Console.WriteLine("Enter author: ");
        string author = Console.ReadLine();
        Console.WriteLine("Enter book genre: ");
        string genre = Console.ReadLine();
        Console.WriteLine("Enter book pages: ");
        int pages = int.Parse(Console.ReadLine());

        return new Book(title, author, genre, pages);
    }
    public override void DisplayDetails()
    {
        Console.WriteLine($"Book: {Title}, Author: {Author}, Genre: {Genre}, Pages: {Pages}, Borrowed: {Borrowed}");
    }
}

class Magazine: LibraryItem
{
    private string Publisher{get; set;}
    private int IssueNumber{get; set;}

    public Magazine(string title, string p, int i): base(title){Publisher = p; IssueNumber = i;}
    public override LibraryItem AddItem()
    {
        Console.WriteLine("Enter Magazine title: ");
        string title = Console.ReadLine();
        Console.WriteLine("Enter Magazine Publisher: ");
        string publisher = Console.ReadLine();
        Console.WriteLine("Enter Magazine issue number: ");
        int issueNumber = int.Parse(Console.ReadLine());

        return new Magazine(title, publisher, issueNumber);
    }
    public override void DisplayDetails()
    {
        Console.WriteLine($"Magazine: {Title}, Publisher: {Publisher}, Issue Number: {IssueNumber}, Borrowed: {Borrowed}");
    }
}

class DVD: LibraryItem
{
    private string Director{get; set;}
    private float Duration{get; set;}

    public DVD(string title, string director, float duration): base(title){Director = director; Duration = duration;}

    public override LibraryItem AddItem()
    {
        Console.WriteLine("Enter DVD title: ");
        string title = Console.ReadLine();
        Console.WriteLine("Enter DVD director: ");
        string director = Console.ReadLine();
        Console.WriteLine("Enter DVD duration: ");
        float duration = float.Parse(Console.ReadLine());

        return new DVD(title, director, duration);
    }
    public override void DisplayDetails()
    {
        Console.WriteLine($"DVD: {Title}, Director: {Director}, Duration: {Duration} minutes, Borrowed: {Borrowed}");
    }
}

class Program
{
    static List<LibraryItem> libraryItems = new List<LibraryItem>();
    static void Main(string[] args)
    {
        bool end = false;

        while(!end)
        {
            Console.WriteLine("Library Management System");
            Console.WriteLine("1. Add a new library item");
            Console.WriteLine("2. View all items");
            Console.WriteLine("3. Borrow an item");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddLibraryItem();
                    break;
                case "2":
                    ViewAllItems();
                    break;
                case "3":
                    BorrowItem();
                    break;
                case "4":
                    end = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }


static void AddLibraryItem()
{
    Console.WriteLine("Add a new library item:");
    Console.WriteLine("1. Book");
    Console.WriteLine("2. Magazine");
    Console.WriteLine("3. DVD");
    Console.Write("Choose an option: ");

    string choice = Console.ReadLine();
    LibraryItem newItem = null;
    switch (choice)
    {
        case "1":
            newItem = new Book("", "", "", 0).AddItem(); 
            break;
        case "2":
            newItem = new Magazine("", "", 0).AddItem();
            break;
        case "3":
            newItem = new DVD("", "", 0).AddItem();
            break;
        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
    
    libraryItems.Add(newItem);
    Console.WriteLine("Item added successfully.");
}

static void ViewAllItems()
{
    Console.WriteLine("\nLibrary Items:");
    foreach(var item in libraryItems)
    {
            item.DisplayDetails();
    }
}

static void BorrowItem()
{
    Console.WriteLine("\nEnter the title of the item to borrow:");
    string title = Console.ReadLine();

    foreach (var item in libraryItems)
    {
        if (item.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
        {
            item.Borrow();
            return;
        }
    }

    Console.WriteLine("Item not found. Please check the title and try again.");
}
}