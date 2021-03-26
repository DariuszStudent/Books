using System.Collections.Generic;
using System.Linq;

namespace Books.Core
{
    public class BookManager
    {
        // --------------------------------------------------------------------------------
        /* Tutaj tworzymy funckję statyczną GetManager()
         * w return towrzymy nowy obiekt FileManager - tu możemy zmienić na DBManager
         * i to wszystko, dzięki temu moglibyśmy zapisywać w Bazie danych. Jedna zmiana, 
         * bez ruszania ruszania reszty kodu
         */
        public static IManager GetManager()
        {
            return new FileManager();
        }
        // --------------------------------------------------------------------------------

        private List<Book> Books { get; set; }
        // tu tworzymy propertis manager z IManager, gdzie przypisujemy od razu funkcję GetManager()
        // dzięki temu możemy używać FileManager, lub DBManager. Wystarczy zmienić jedną linijkę wyzej.
        private IManager manager { get; set; } = GetManager();

        public BookManager()
        {
            Books = new List<Book>();
            // tu w konstruktorze dodajemy książki z pliku txt to listy Books.
            // Patrz opis FileManager! wartość bool AddBook jest false, patrz FM.
            // w końcu nie chcemy odczytywać i od razu zapisywać.
            manager.AddBookToCTor(AddBook);
        }

        public void AddBook(int id, string name, string author, decimal price, bool shouldToSave = true)
        {
            var book = new Book(id, name, author, price);
            Books.Add(book);
            // dzięki wartości bool shouldToSave panujemy nad tym czy dodajemy do pliku czy nie.
            // w konstruktorze nie chcemy tego robić, bo po co, za to jak dodajemy książkę to tak
            // a że korzystamy z funckji dwa razy, patrz wyżej "2 References"
            // robimy to, ponieważ chcemy uniknąć pisania tego samego kodu 2 razy.
            if (shouldToSave) manager.AddBook(book);
        }

        public void RemoveBook(int id)
        {
            for (int i = 0; i < Books.Count; i++)
            {
                if (id == Books[i].Id)
                {
                    Books.Remove(Books[i]);
                }
            }
            // --------------------------------------------------------------------------------------------------------
            // tworzymy nową listę książek
            var listBooks = new List<string>();  
            // przechodzimy po każdej książce w liście Books
            foreach (var book in Books)
            {
                // Dodajemy każdą pozycję do utworzonej książki w formacie
                // który utowrzyliśmy w Book >> public override string ToString()
                listBooks.Add(book.ToString());
            }
            
            // rzucamy tą listę do RemoveBook przez Interface do FileManager, patrz wyżej
            manager.RemoveBook(listBooks);
            // --------------------------------------------------------------------------------------------------------
        }

        public int GetId()
        {
            var id = 1;
            // Tworzmy nową listę i sortujemy ją poprzez ID, używamy Linq
            var sortedList = Books.OrderBy(o => o.Id).ToList();
            // następnie pokolei lecimy i sprawdzamy id czy jest, jeśli nie ma na liście wyrzucamy je, return
            foreach (var book in sortedList)
            {
                if (book.Id == id) id++;
                else return id;
            }
            return id;
        }

        public List<string> ShowAllBooks()
        {
            List<string> stringBooks = new List<string>();

            foreach (var book in Books)
            {
                var stringEdit = "Id. " + book.Id + " | " + book.Name + " | Autor: " + book.Author + " | " + book.Price + "zł.";
                stringBooks.Add(stringEdit);
            }
            return stringBooks;
        }
    }
}
