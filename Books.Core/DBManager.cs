using System;
using System.Collections.Generic;

namespace Books.Core
{
    public class DBManager : IManager
    {
        public void AddBookToCTor(Action<int, string, string, decimal, bool> AddNewBook)
        {
            // w przyszłości kod który doda książki z bazy danych do programów
        }

        public void AddBook(Book book)
        {
            // w przyszłości kod który doda książke do Bazy Danych
        }

        public void RemoveBook(List<string> list)
        {
            // w przyszłości kod który usunie książke do Bazy Danych
        }
    }
}
