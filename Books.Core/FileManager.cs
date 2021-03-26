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
            // jeśli nie ma pliku wyjdź z funckji, dalej nie idź, bo wywali błąd i zatrzyma program.
            if (!File.Exists(FileName)) return;

            // tutaj tworzymy tablice string, każda linia to osobna szuflada w której znajdują się informacje.
            var fileLines = File.ReadAllLines(FileName);
            // tutaj idzemy pokolei po pozycjach tablicy.
            foreach (var line in fileLines)
            {
                // tutaj tworzymy kolejną tablicę, każda szuflada to tekst w jednej lini oddzielony znakiem ';',
                // znak ten nie jest brany pod uwage przy dodawaniu
                var lineItems = line.Split(';');
                /* tu sprawdzamy czy uda nam się przekonwertować dane, jeśli tak używamy funckji którą mamy już napisaną
                 * w BookManager, odnosimy się do niej dzięki: >> Action<int, string, decimal, int, bool> AddNewBook
                 * tu miałem największy problem, nie chciałem powielać kodu a to rozwiązanie nie wydaje mi się zbyt elastyczne
                 * ale działa. bool = false oznacza tutaj że nie chcemy zapisać jej do pliku, wkońcu odczytujemy, więc po co :)
                 */
                if (int.TryParse(lineItems[0], out var id) && decimal.TryParse(lineItems[2], out var price) && int.TryParse(lineItems[3], out var quantity))
                {
                    AddNewBook(id, lineItems[1], price, quantity, false);
                }
            }
        }

        /*Tutaj dodajemy kolejną linie do pliku poprzez >> public override string ToString()
         * który utowrzyliśmy w klasie Book, poszczególne informacje w lini oddzielone są oddzielone 
         * znakiem ';' który sami zadeklarowaliśmy.
         */
        public void AddBook(Book book)
        {
            File.AppendAllLines(FileName, new List<string> { book.ToString() });
        }


        /* Tutaj usuwamy plik.txt i tworzymy nowy, ponieważ usuwanie linijki z tekstu gdzieś w środku 
         * byłoby bardzo kłopotliwe. Wymagałoby sporo kodu. Zdaje sobie sprawę że nie jest to optymalne
         * rozwiązanie, ale czy to nie dlatego są Bazy Danych? Ich silnik zrobi to za nas. :)
             */
        public void RemoveBook(List<string> list)
        {
            File.Delete(FileName);
            File.WriteAllLines(FileName, list);
        }
    }
}
