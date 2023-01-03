namespace API.Errors
{
    public class ApiException
    {
        public ApiException(int statusCide, string? message = null, string? details = null)
        {
            StatusCode = statusCide;
            Message = message;
            Details = details;
        }

        public int StatusCode { get; set; }
        public string? Message { get; set; } = string.Empty;
        public string? Details { get; set; } = string.Empty;
    }
}
