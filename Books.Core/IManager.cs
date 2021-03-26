using System;
using System.Collections.Generic;

namespace Books.Core
{
    public interface IManager
    {
        void AddBookToCTor(Action<int, string, decimal, int, bool> AddNewBook);

        void AddBook(Book book);

        void RemoveBook(List<string> list);
    }
}
