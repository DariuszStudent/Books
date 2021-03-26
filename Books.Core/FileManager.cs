using System;
using System.Collections.Generic;
using System.IO;

namespace Books.Core
{
    public class FileManager : IManager
    {
        private string FileName { get; set; } = "books.txt";

        public void AddBookToCTor(Action<int, string, decimal, int, bool> AddNewBook)
        {
            if (!File.Exists(FileName)) return;

            var fileLines = File.ReadAllLines(FileName);
            foreach (var line in fileLines)
            {
                var lineItems = line.Split(';');
                if (int.TryParse(lineItems[0], out var id) && decimal.TryParse(lineItems[2], out var price) && int.TryParse(lineItems[3], out var quantity))
                {
                    AddNewBook(id, lineItems[1], price, quantity, false);
                }
            }
        }

        public void AddBook(Book book)
        {
            File.AppendAllLines(FileName, new List<string> { book.ToString() });
        }

        public void RemoveBook(List<string> list)
        {
            File.Delete(FileName);
            File.WriteAllLines(FileName, list);
        }
    }
}
