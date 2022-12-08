namespace CqrsDapperExample.Models
{
    public class CustomResponseModel
    {
        public int StatusCode { get; set; }
        public Object Data { get; set; }
        public List<string> Errors { get; set; }

        public CustomResponseModel() { 
        
        }

        public void Success(int statusCode, Object data)
        {
            this.StatusCode = statusCode;
            this.Data = data;
            this.Errors = null;
        }

        public void Fail(int statusCode, List<string> errors)
        {
            this.StatusCode = statusCode;
            this.Errors = errors;
            this.Data = null;
        }

        public void Fail(int statusCode, string error)
        {
            this.StatusCode = statusCode;
            this.Errors = new List<string>();
            this.Errors.Add(error);
            this.Data = null;
        }


    }


}
