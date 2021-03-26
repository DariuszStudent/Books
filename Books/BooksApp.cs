using System;
using Books.Core;


public class BooksApp
{
    BookManager bookManager = new BookManager();
    public void ShowMenu()
    {
        Console.WriteLine("1. Dodaj książkę.");
        Console.WriteLine("2. Usuń książkę.");
        Console.WriteLine("3. Pokaż książki.");
        Console.WriteLine("9. Wyjście.");
    }

    public void AddBook()
    {
        var id = bookManager.GetId();
        Console.WriteLine("Id nowej książki wynosi : " + id);
        Console.WriteLine("Podaj nazwę książki: ");
        var name = Console.ReadLine();
        Console.WriteLine("Podaj autora: ");
        var author = Console.ReadLine();
        Console.WriteLine("Podaj cenę książki: ");
        var price = Helpers.JustDecimals();
        bookManager.AddBook(id, name, author, price);
    }

    public void RemoveBook()
    {
        Console.WriteLine(" Podaj ID ksiazki do usuniecia : ");
        var id = Helpers.JustInts();
        bookManager.RemoveBook(id);
    }

    public void ShowAllBooks()
    {
        foreach (var books in bookManager.ShowAllBooks())
        {
            Console.WriteLine(books);
        }
    }
}

