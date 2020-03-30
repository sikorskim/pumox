namespace Pumox.Models
{
    public class Response
    {
        public object Results { get; set; }
        public Response (object results)
        {
            Results = results;
        }
    }
}
