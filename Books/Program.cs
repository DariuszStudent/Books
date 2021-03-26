using System;

class Program
{
    static void Main(string[] args)
    {
        BooksApp booksApp = new BooksApp();
        var exit = false;

        while (!exit)
        {
            Console.Clear();
            booksApp.ShowMenu();
            Console.Write("Wybierz co chcesz zrobić: ");
            var userInput = Console.ReadKey();
            Console.WriteLine();

            switch (userInput.KeyChar)
            {
                case '1':
                    booksApp.AddBook();
                    break;
                case '2':
                    booksApp.ShowAllBooks();
                    booksApp.RemoveBook();
                    break;
                case '3':
                    booksApp.ShowAllBooks();
                    Console.ReadKey();
                    break;
                case '9':
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Wprowadzono złe dane, spróbuj jeszcze raz.");
                    break;
            }
        }
    }
}
