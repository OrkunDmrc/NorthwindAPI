using NorthwindAPI.Core.Results.Abstract;

namespace NorthwindAPI.Core.Results.Concrete
{
    public class Result<T> : IResult<T> where T : class
    {
        public T? Object { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Message { get; set; }
        public bool Success { get; set; }
        public IResult<T> FillSuccessResult(T resultObject)
        {
            Success = true;
            Object = resultObject;
            ErrorMessage = null;
            return this;
        }

        public IResult<T> FillUnsuccessResult(string errorMessage)
        {
            Success = false;
            Object = null;
            ErrorMessage = errorMessage;
            return this;
        }
    }
}
