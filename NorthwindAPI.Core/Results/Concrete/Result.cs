using NorthwindAPI.Core.Results.Abstract;

namespace NorthwindAPI.Core.Results.Concrete
{
    public class Result<T> : IResult<T> where T : class
    {
        public T? Object { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Message { get; set; }
        public bool Success { get; set; }
    }
}
