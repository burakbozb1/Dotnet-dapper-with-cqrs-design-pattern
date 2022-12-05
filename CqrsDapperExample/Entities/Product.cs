namespace CqrsDapperExample.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public List<Comment>? Comments { get; set; }

    }
}
