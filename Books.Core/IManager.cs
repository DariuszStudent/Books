using System;
using System.Collections.Generic;

namespace Books.Core
{
    public interface IManager
    {
        // funckje w Interface są publiczne, nie wpisujemy tego, bo kompilator wywali błąd, po prostu
        // zawieramy to co ma się znaleźć, MUSI się znaleźć w classach które dziedziczą po interface.
        // Interfejsy definiują jedynie nazwy metod, typ zwracany i przyjmowane parametry
        void AddBookToCTor(Action<int, string, string, decimal, bool> AddNewBook);

        void AddBook(Book book);

        void RemoveBook(List<string> list);
    }
}
