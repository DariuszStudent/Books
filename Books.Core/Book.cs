namespace Books.Core
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Book(int id, string name, decimal price, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return Id.ToString() + ";" + Name + ";" + Price.ToString() + ";" + Quantity.ToString();
        }
    }
}
