namespace BookApp.Models
{
    public class Book:BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }

        //Navigation Property
        public Author? Author { get; set; }
        public Category? Category { get; set; }

    }
}
