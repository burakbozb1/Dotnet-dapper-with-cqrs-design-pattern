namespace CqrsDapperExample.Models
{
    public class NoContentDto
    {
        public int StatusCode { get; set; }

        public NoContentDto(int statusCode)
        {
            this.StatusCode = statusCode;
        }

        public NoContentDto() { 
        
        }

        public void SetStatus(int statusCode)
        {
            this.StatusCode = statusCode;
        }
    }


}
