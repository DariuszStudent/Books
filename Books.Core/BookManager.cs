using System.Collections.Generic;

namespace Books.Core
{
    public class BookManager
    {
        public static IManager GetManager()
        {
            return new FileManager();
        }

        private List<Book> Books { get; set; }
        private IManager manager { get; set; } = GetManager();

        public BookManager()
        {
            Books = new List<Book>();

            manager.AddBookToCTor(AddBook);
        }

        public void AddBook(int id, string name, decimal price, int quantity, bool shouldToSave = true)
        {
            var book = new Book(id, name, price, quantity);
            Books.Add(book);
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
            var listBooks = new List<string>();  // tworzymy nową listę książek, ponieważ:
            foreach (var book in Books)
            {
                listBooks.Add(book.ToString());
            }
            /* Tutaj tworzymy nową listę książek, ułatwia nam to zadanie odejmowania jednej książki z listy. Ponieważ
             * byłoby to bardzo kłopotliwe przy pliku txt. Duża ilość kodu musiałaby się znaleźć, zdaje sobie sprawę,
             * że nie jest to optymalne rozwiązanie. Ale czy to nie po to powstały Bazy Danych? Żeby to silnik robił za nas?
             * Tak więc tworzymi kolejną listę książek tutaj, a w FileManager usuwamy cały plik i zapisujemy nowy z 
             * listą aktualną z programu (tą którą tutaj stworzyliśmy)
             */

            manager.RemoveBook(listBooks);
            // --------------------------------------------------------------------------------------------------------
        }
        public int GetId()
        {
            var id = 1;
            foreach (var item in Books)
            {
                if (id == item.Id) id++;
                else break;
            }
            return id;
        }
        public List<string> ShowAllBooks()
        {
            List<string> stringBooks = new List<string>();

            foreach (var book in Books)
            {
                var stringEdit = "Id. " + book.Id + ". " + book.Name + ". " + book.Price + "zł. / ilość: " + book.Quantity;
                stringBooks.Add(stringEdit);
            }
            return stringBooks;
        }
    }
}
