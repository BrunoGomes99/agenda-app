namespace AgendaApp.WebApi
{
    public class ResponseBase
    {
        public ResponseBase()
        {
            Success = true;
            ErrorMessage = "";
            Data = null;
        }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public object? Data { get; set; }
    }
}