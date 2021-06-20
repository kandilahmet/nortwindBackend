using Newtonsoft.Json;

namespace Core.Utilities.Middleware
{
    public class ErrorDetailsBase
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}