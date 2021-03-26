namespace Books.Core
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }

        public Book(int id, string name, string author, decimal price)
        {
            Id = id;
            Name = name;
            Author = author;
            Price = price;
        }

        public override string ToString()
        {
            return Id.ToString() + ";" + Name + ";" + Author + ";" + Price.ToString();
        }
    }
}
