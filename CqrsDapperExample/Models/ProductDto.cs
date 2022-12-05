using CqrsDapperExample.Entities;

namespace CqrsDapperExample.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<CommentDto> Comments { get; set; }
    }
}
