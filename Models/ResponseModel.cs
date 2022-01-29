namespace FreeGamesConsume.Models
{
    public class ResponseModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = "";
        public object Data { get; set; } = null;


        public ResponseModel(int statusCode, string message, int data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        public ResponseModel(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public ResponseModel(int statusCode, object data)
        {
            StatusCode = statusCode;
            Data = data;
        }
    }
}
